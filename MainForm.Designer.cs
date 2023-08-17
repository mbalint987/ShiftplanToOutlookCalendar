namespace ShiftplanToOutlookCalendar {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            Button_ConnectToOutlook = new Button();
            groupBox1 = new GroupBox();
            Label_ConnectedToOutlook = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            Label_DataFileLoaded = new Label();
            Button_PreviewData = new Button();
            Button_LoadDataFile = new Button();
            label3 = new Label();
            groupBox3 = new GroupBox();
            Label_OldDataHasRemoved = new Label();
            Button_RemoveOldData = new Button();
            label2 = new Label();
            groupBox4 = new GroupBox();
            Label_DataHasImported = new Label();
            Button_ImportData = new Button();
            label5 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // Button_ConnectToOutlook
            // 
            Button_ConnectToOutlook.Location = new Point(6, 64);
            Button_ConnectToOutlook.Name = "Button_ConnectToOutlook";
            Button_ConnectToOutlook.Size = new Size(444, 29);
            Button_ConnectToOutlook.TabIndex = 0;
            Button_ConnectToOutlook.Text = "Kapcsolódás";
            Button_ConnectToOutlook.UseVisualStyleBackColor = true;
            Button_ConnectToOutlook.Click += Button_ConnectToOutlook_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Label_ConnectedToOutlook);
            groupBox1.Controls.Add(Button_ConnectToOutlook);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(456, 111);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "1. lépés: Kapcsolódás az Outlook-hoz";
            // 
            // Label_ConnectedToOutlook
            // 
            Label_ConnectedToOutlook.AutoSize = true;
            Label_ConnectedToOutlook.Location = new Point(148, 32);
            Label_ConnectedToOutlook.Name = "Label_ConnectedToOutlook";
            Label_ConnectedToOutlook.Size = new Size(132, 20);
            Label_ConnectedToOutlook.TabIndex = 0;
            Label_ConnectedToOutlook.Text = "Nincs kapcsolódva";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 32);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 0;
            label1.Text = "Kapcsolat állapota:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Label_DataFileLoaded);
            groupBox2.Controls.Add(Button_PreviewData);
            groupBox2.Controls.Add(Button_LoadDataFile);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 129);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(456, 141);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "2. lépés: Adatfájl betöltése";
            // 
            // Label_DataFileLoaded
            // 
            Label_DataFileLoaded.AutoSize = true;
            Label_DataFileLoaded.Location = new Point(136, 32);
            Label_DataFileLoaded.Name = "Label_DataFileLoaded";
            Label_DataFileLoaded.Size = new Size(41, 20);
            Label_DataFileLoaded.TabIndex = 0;
            Label_DataFileLoaded.Text = "Nem";
            // 
            // Button_PreviewData
            // 
            Button_PreviewData.Enabled = false;
            Button_PreviewData.Location = new Point(6, 99);
            Button_PreviewData.Name = "Button_PreviewData";
            Button_PreviewData.Size = new Size(444, 29);
            Button_PreviewData.TabIndex = 0;
            Button_PreviewData.Text = "Adatok előnézete";
            Button_PreviewData.UseVisualStyleBackColor = true;
            Button_PreviewData.Click += Button_PreviewData_Click;
            // 
            // Button_LoadDataFile
            // 
            Button_LoadDataFile.Enabled = false;
            Button_LoadDataFile.Location = new Point(6, 64);
            Button_LoadDataFile.Name = "Button_LoadDataFile";
            Button_LoadDataFile.Size = new Size(444, 29);
            Button_LoadDataFile.TabIndex = 0;
            Button_LoadDataFile.Text = "Adatfájl betöltése";
            Button_LoadDataFile.UseVisualStyleBackColor = true;
            Button_LoadDataFile.Click += Button_LoadDataFile_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 32);
            label3.Name = "label3";
            label3.Size = new Size(124, 20);
            label3.TabIndex = 0;
            label3.Text = "Adatfájl betöltve:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(Label_OldDataHasRemoved);
            groupBox3.Controls.Add(Button_RemoveOldData);
            groupBox3.Controls.Add(label2);
            groupBox3.Location = new Point(12, 279);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(456, 111);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "3. lépés: Régi adatok törlése";
            // 
            // Label_OldDataHasRemoved
            // 
            Label_OldDataHasRemoved.AutoSize = true;
            Label_OldDataHasRemoved.Location = new Point(155, 38);
            Label_OldDataHasRemoved.Name = "Label_OldDataHasRemoved";
            Label_OldDataHasRemoved.Size = new Size(41, 20);
            Label_OldDataHasRemoved.TabIndex = 0;
            Label_OldDataHasRemoved.Text = "Nem";
            // 
            // Button_RemoveOldData
            // 
            Button_RemoveOldData.Enabled = false;
            Button_RemoveOldData.Location = new Point(6, 70);
            Button_RemoveOldData.Name = "Button_RemoveOldData";
            Button_RemoveOldData.Size = new Size(444, 29);
            Button_RemoveOldData.TabIndex = 0;
            Button_RemoveOldData.Text = "Régi adatok törlése";
            Button_RemoveOldData.UseVisualStyleBackColor = true;
            Button_RemoveOldData.Click += Button_RemoveOldData_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 38);
            label2.Name = "label2";
            label2.Size = new Size(143, 20);
            label2.TabIndex = 0;
            label2.Text = "Régi adatok törölve:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(Label_DataHasImported);
            groupBox4.Controls.Add(Button_ImportData);
            groupBox4.Controls.Add(label5);
            groupBox4.Location = new Point(12, 396);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(456, 111);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "4. lépés: Adatok importálása";
            // 
            // Label_DataHasImported
            // 
            Label_DataHasImported.AutoSize = true;
            Label_DataHasImported.Location = new Point(165, 38);
            Label_DataHasImported.Name = "Label_DataHasImported";
            Label_DataHasImported.Size = new Size(41, 20);
            Label_DataHasImported.TabIndex = 0;
            Label_DataHasImported.Text = "Nem";
            // 
            // Button_ImportData
            // 
            Button_ImportData.Enabled = false;
            Button_ImportData.Location = new Point(6, 70);
            Button_ImportData.Name = "Button_ImportData";
            Button_ImportData.Size = new Size(444, 29);
            Button_ImportData.TabIndex = 0;
            Button_ImportData.Text = "Adatok importálása";
            Button_ImportData.UseVisualStyleBackColor = true;
            Button_ImportData.Click += Button_ImportData_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 38);
            label5.Name = "label5";
            label5.Size = new Size(153, 20);
            label5.TabIndex = 0;
            label5.Text = "Adatok beimportálva:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 519);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Shiftplan to Outlook Calendar";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button Button_ConnectToOutlook;
        private GroupBox groupBox1;
        private Label Label_ConnectedToOutlook;
        private Label label1;
        private GroupBox groupBox2;
        private Label Label_DataFileLoaded;
        private Button Button_LoadDataFile;
        private Label label3;
        private Button Button_PreviewData;
        private GroupBox groupBox3;
        private Label Label_OldDataHasRemoved;
        private Button Button_RemoveOldData;
        private Label label2;
        private GroupBox groupBox4;
        private Label Label_DataHasImported;
        private Button Button_ImportData;
        private Label label5;
    }
}