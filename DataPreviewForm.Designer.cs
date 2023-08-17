namespace ShiftplanToOutlookCalendar {
    partial class DataPreviewForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DataGridView_Preview = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)DataGridView_Preview).BeginInit();
            SuspendLayout();
            // 
            // DataGridView_Preview
            // 
            DataGridView_Preview.AllowUserToAddRows = false;
            DataGridView_Preview.AllowUserToDeleteRows = false;
            DataGridView_Preview.AllowUserToOrderColumns = true;
            DataGridView_Preview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView_Preview.Location = new Point(12, 12);
            DataGridView_Preview.Name = "DataGridView_Preview";
            DataGridView_Preview.ReadOnly = true;
            DataGridView_Preview.RowHeadersWidth = 51;
            DataGridView_Preview.RowTemplate.Height = 29;
            DataGridView_Preview.Size = new Size(1330, 796);
            DataGridView_Preview.TabIndex = 0;
            // 
            // DataPreviewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1348, 820);
            Controls.Add(DataGridView_Preview);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DataPreviewForm";
            Text = "Adatok előnézete";
            Load += DataPreviewForm_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridView_Preview).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DataGridView_Preview;
    }
}