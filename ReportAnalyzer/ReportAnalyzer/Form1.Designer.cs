namespace ReportAnalyzer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UIButtonCompareEMPnTRA = new System.Windows.Forms.Button();
            this.textBoxEmp = new System.Windows.Forms.TextBox();
            this.textBoxTracker = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.UIButtonCreatePOReport = new System.Windows.Forms.Button();
            this.UINameList = new System.Windows.Forms.CheckedListBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.UIdateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.UIdateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // UIButtonCompareEMPnTRA
            // 
            this.UIButtonCompareEMPnTRA.Location = new System.Drawing.Point(51, 133);
            this.UIButtonCompareEMPnTRA.Margin = new System.Windows.Forms.Padding(4);
            this.UIButtonCompareEMPnTRA.Name = "UIButtonCompareEMPnTRA";
            this.UIButtonCompareEMPnTRA.Size = new System.Drawing.Size(100, 28);
            this.UIButtonCompareEMPnTRA.TabIndex = 0;
            this.UIButtonCompareEMPnTRA.Text = "Compare REports";
            this.UIButtonCompareEMPnTRA.UseVisualStyleBackColor = true;
            this.UIButtonCompareEMPnTRA.Click += new System.EventHandler(this.UIButtonCompareEMPnTRA_Click);
            // 
            // textBoxEmp
            // 
            this.textBoxEmp.Location = new System.Drawing.Point(51, 27);
            this.textBoxEmp.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEmp.Name = "textBoxEmp";
            this.textBoxEmp.Size = new System.Drawing.Size(381, 22);
            this.textBoxEmp.TabIndex = 1;
            this.textBoxEmp.Text = "c:\\TEMP\\20190919_report\\emp\\";
            // 
            // textBoxTracker
            // 
            this.textBoxTracker.Location = new System.Drawing.Point(51, 57);
            this.textBoxTracker.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTracker.Name = "textBoxTracker";
            this.textBoxTracker.Size = new System.Drawing.Size(381, 22);
            this.textBoxTracker.TabIndex = 2;
            this.textBoxTracker.Text = "c:\\TEMP\\20190919_report\\tra\\";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 182);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(363, 340);
            this.textBox1.TabIndex = 3;
            // 
            // UIButtonCreatePOReport
            // 
            this.UIButtonCreatePOReport.Location = new System.Drawing.Point(158, 133);
            this.UIButtonCreatePOReport.Name = "UIButtonCreatePOReport";
            this.UIButtonCreatePOReport.Size = new System.Drawing.Size(224, 28);
            this.UIButtonCreatePOReport.TabIndex = 4;
            this.UIButtonCreatePOReport.Text = "Prepare PO report";
            this.UIButtonCreatePOReport.UseVisualStyleBackColor = true;
            this.UIButtonCreatePOReport.Click += new System.EventHandler(this.UIButtonCreatePOReport_Click_1);
            // 
            // UINameList
            // 
            this.UINameList.FormattingEnabled = true;
            this.UINameList.Items.AddRange(new object[] {
            "Alicja Marglewska",
            "Blazej Agacinski",
            "Dawid Marchlewicz",
            "Malgorzata Marcysiak",
            "Pawel Sochal",
            "Przemyslaw Nejman",
            "Radoslaw Domian",
            "Slawomir Jasiecki",
            "Szymon Kaszak",
            "Szymon Kobylinski",
            "Tomasz Tojek",
            "Wojciech Mamel",
            "Kamil Janik",
            "Pawel Matraszek",
            "Seweryn Biernacki",
            "Stanislaw Pawlak"});
            this.UINameList.Location = new System.Drawing.Point(465, 27);
            this.UINameList.Name = "UINameList";
            this.UINameList.Size = new System.Drawing.Size(221, 310);
            this.UINameList.TabIndex = 5;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(51, 86);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(381, 22);
            this.textBoxPath.TabIndex = 6;
            this.textBoxPath.Text = "c:\\TEMP\\20190919_report\\";
            // 
            // UIdateTimePickerStart
            // 
            this.UIdateTimePickerStart.Location = new System.Drawing.Point(716, 27);
            this.UIdateTimePickerStart.Name = "UIdateTimePickerStart";
            this.UIdateTimePickerStart.Size = new System.Drawing.Size(200, 22);
            this.UIdateTimePickerStart.TabIndex = 7;
            // 
            // UIdateTimePickerEnd
            // 
            this.UIdateTimePickerEnd.Location = new System.Drawing.Point(716, 57);
            this.UIdateTimePickerEnd.Name = "UIdateTimePickerEnd";
            this.UIdateTimePickerEnd.Size = new System.Drawing.Size(200, 22);
            this.UIdateTimePickerEnd.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.UIdateTimePickerEnd);
            this.Controls.Add(this.UIdateTimePickerStart);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.UINameList);
            this.Controls.Add(this.UIButtonCreatePOReport);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxTracker);
            this.Controls.Add(this.textBoxEmp);
            this.Controls.Add(this.UIButtonCompareEMPnTRA);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UIButtonCompareEMPnTRA;
        private System.Windows.Forms.TextBox textBoxEmp;
        private System.Windows.Forms.TextBox textBoxTracker;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button UIButtonCreatePOReport;
        private System.Windows.Forms.CheckedListBox UINameList;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.DateTimePicker UIdateTimePickerStart;
        private System.Windows.Forms.DateTimePicker UIdateTimePickerEnd;
    }
}

