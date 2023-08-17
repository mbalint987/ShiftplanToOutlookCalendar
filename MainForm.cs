using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Office.Interop.Outlook;
using Newtonsoft.Json;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;

namespace ShiftplanToOutlookCalendar {
    public partial class MainForm : Form {
        private Microsoft.Office.Interop.Outlook.Application applicationInstance;
        private List<Record> dataRecords = new List<Record>();
        private Configuration configuration;

        public MainForm() {
            InitializeComponent();
        }

        private void Button_ConnectToOutlook_Click(object sender, EventArgs e) {
            try {
                Button_ConnectToOutlook.Enabled = false;
                applicationInstance = new Microsoft.Office.Interop.Outlook.Application();

                Label_ConnectedToOutlook.Text = "Kapcsolódva (verzió: " + applicationInstance.Version + ")";
                Button_LoadDataFile.Enabled = true;
            }
            catch {
                Button_ConnectToOutlook.Enabled = true;
                Button_LoadDataFile.Enabled = false;

                Label_ConnectedToOutlook.Text = "Nincs kapcsolódva";

                MessageBox.Show("Nem sikerült a kapcsolódás, próbálja újra!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_LoadDataFile_Click(object sender, EventArgs e) {
            try {
                dataRecords.Clear();

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.CheckFileExists = true;
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.ShowDialog();

                var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);
                csvConfiguration.Delimiter = ";";

                var reader = new StreamReader(openFileDialog.FileName);
                var csv = new CsvReader(reader, csvConfiguration);
                reader.ReadLine();
                var records = csv.GetRecords<dynamic>();

                foreach (ExpandoObject record in records) {
                    IDictionary<string, object?> recordValues = new Dictionary<string, object?>(record);

                    if ((string)recordValues["Személy azonosítója*"] == configuration.EmployeeID && ((string)recordValues["Minõsítõ*"] == "Készenlét" || (string)recordValues["Minõsítõ*"] == "Munkaidõ")) {
                        Record r = new Record();

                        r.Start = DateTime.Parse(String.Format("{0} {1}", (string)recordValues["Munkaidõ-beosztás kezdete dátum"], (string)recordValues["Munkaidõ-beosztás kezdete*"]));
                        r.End = DateTime.Parse(String.Format("{0} {1}", (string)recordValues["Munkaidõ-beosztás vége dátum"], (string)recordValues["Munkaidõ-beosztás vége*"]));
                        r.RecordType = (string)recordValues["Minõsítõ*"];

                        if (r.RecordType == "Munkaidõ") {
                            r.MunkaidõType = "Core";

                            if (r.Start.Hour <= configuration.EarlyShiftStartHour)
                                r.MunkaidõType = "Early";
                            else if (r.Start.Hour >= configuration.LateShiftStartHour && r.End.Hour >= configuration.LateShiftEndHour)
                                r.MunkaidõType = "Late";
                        }

                        dataRecords.Add(r);
                    }
                }

                reader.Close();

                Label_DataFileLoaded.Text = dataRecords.Count + " sor betöltve";

                if (dataRecords.Count > 0) {
                    Button_PreviewData.Enabled = true;
                    Button_ImportData.Enabled = true;
                    Button_RemoveOldData.Enabled = true;
                    //Button_LoadDataFile.Enabled = false;
                }
            }
            catch {
                Label_DataFileLoaded.Text = "Nem";

                Button_PreviewData.Enabled = false;
                Button_ImportData.Enabled = false;
                Button_RemoveOldData.Enabled = false;
                //Button_LoadDataFile.Enabled = true;

                dataRecords.Clear();

                MessageBox.Show("Nem sikerült a fájl és/vagy az adatok beolvasása, próbálja újra!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_PreviewData_Click(object sender, EventArgs e) {
            DataPreviewForm form = new DataPreviewForm(dataRecords);
            form.ShowDialog();
        }

        private void Button_RemoveOldData_Click(object sender, EventArgs e) {
            int totalDeletedItems = 0, numberOfDeletedItems = 0;
            
            try {
                double recordToMonth = Math.Ceiling(Convert.ToDouble((dataRecords.Count / 2)));
                int month = dataRecords[Convert.ToInt32(recordToMonth)].Start.Month;
                int year = dataRecords[Convert.ToInt32(recordToMonth)].Start.Year;

                DialogResult dialogResult = MessageBox.Show(String.Format("A meglévõ adatok törlését a következõ hónapra fogom elvégezni: {0}/{1}. Folytassam a mûveletet?", year, month.ToString("00")), "Kérdés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes) {
                    Button_RemoveOldData.Enabled = false;

                    do {
                        numberOfDeletedItems = 0;

                        NameSpace OlNamspace = applicationInstance.GetNamespace("MAPI");
                        MAPIFolder AppointmentFolder =
                        OlNamspace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);

                        Items calendarItems = AppointmentFolder.Items;

                        foreach (AppointmentItem calendarItem in calendarItems) {
                            if (calendarItem != null && calendarItem.Subject != null && calendarItem.Body != null) {
                                if (calendarItem.Start.Year == year && calendarItem.Start.Month == month && calendarItem.End.Year == year && calendarItem.End.Month == month && calendarItem.Body.Contains("Generated by STOC") && calendarItem.Subject.Contains("AIIS")) {
                                    calendarItem.Delete();
                                    numberOfDeletedItems++;
                                }
                            }
                        }
                        totalDeletedItems += numberOfDeletedItems;
                    } while (numberOfDeletedItems != 0);

                    Label_OldDataHasRemoved.Text = totalDeletedItems + " elem törölve";
                }
            }
            catch {
                Label_OldDataHasRemoved.Text =  "Nem";
                Button_RemoveOldData.Enabled = true;

                MessageBox.Show("A régi adatok törlése közben hiba lépett fel. Lehetséges, hogy nem vagy nem az összes elem került törlésre. A regisztrált törlések száma: " + numberOfDeletedItems, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_ImportData_Click(object sender, EventArgs e) {
            Button_ImportData.Enabled = false;

            int numberOfImportedItems = 0;

            foreach (Record dataRecord in dataRecords) {
                try {
                    Microsoft.Office.Interop.Outlook.AppointmentItem AppointmentInstance = null;

                    AppointmentInstance = (Microsoft.Office.Interop.Outlook.AppointmentItem)applicationInstance.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);

                    AppointmentInstance.Subject = String.Format("AIIS: {0} shift", dataRecord.MunkaidõType);
                    AppointmentInstance.Body = "Generated by STOC at " + DateTime.Now.ToString();
                    AppointmentInstance.Start = dataRecord.Start;
                    AppointmentInstance.End = dataRecord.End;
                    AppointmentInstance.ReminderSet = false;
                    AppointmentInstance.BusyStatus = Microsoft.Office.Interop.Outlook.OlBusyStatus.olBusy;
                    AppointmentInstance.Categories = "AIIS";

                    AppointmentInstance.Save();

                    numberOfImportedItems++;
                }
                catch {
                    MessageBox.Show("Egy elem beimportálása nem sikerült. Folytatjuk a többi elemmel...", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Label_DataHasImported.Text = numberOfImportedItems + " elem beimportálva";
        }

        private void MainForm_Load(object sender, EventArgs e) {
            string fileName = "config.json";
            if (File.Exists(fileName)) {
                try {
                    configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(fileName));

                    if (File.ReadAllText(fileName) != JsonConvert.SerializeObject(configuration)) {
                        File.Delete(fileName);
                        File.WriteAllText(fileName, JsonConvert.SerializeObject(configuration));
                    }
                }
                catch {
                    MessageBox.Show("A konfigurációt nem sikerült beolvasni. A hibás konfigurációt törlöm és újat hozok létre!","Figyelmeztetés",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    try {
                        File.Delete(fileName);
                        configuration = new Configuration();
                        File.WriteAllText(fileName, JsonConvert.SerializeObject(configuration));
                    }
                    catch {
                        MessageBox.Show("Nem sikerült az új konfigurációt létrehozni. Az alkalmazást bezárom...", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }
            else {
                try {
                    configuration = new Configuration();
                    File.WriteAllText(fileName, JsonConvert.SerializeObject(configuration));
                }
                catch {
                    MessageBox.Show("Nem sikerült az új konfigurációt létrehozni. Az alkalmazást bezárom...", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Windows.Forms.Application.Exit();
                }
            }
        }
    }
}