using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShiftplanToOutlookCalendar {
    public partial class DataPreviewForm : Form {
        public List<Record> records;
        public DataPreviewForm(List<Record> records) {
            InitializeComponent();
            this.records = records;
        }

        private void DataPreviewForm_Load(object sender, EventArgs e) {
            DataGridView_Preview.DataSource = this.records;
            DataGridView_Preview.AutoGenerateColumns = true;
            DataGridView_Preview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
