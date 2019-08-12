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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxEmp = new System.Windows.Forms.TextBox();
            this.textBoxTracker = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 133);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxEmp
            // 
            this.textBoxEmp.Location = new System.Drawing.Point(51, 27);
            this.textBoxEmp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxEmp.Name = "textBoxEmp";
            this.textBoxEmp.Size = new System.Drawing.Size(519, 22);
            this.textBoxEmp.TabIndex = 1;
            this.textBoxEmp.Text = "c:\\TEMP\\_TrackerAnalyzer\\emp\\";
            // 
            // textBoxTracker
            // 
            this.textBoxTracker.Location = new System.Drawing.Point(51, 78);
            this.textBoxTracker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTracker.Name = "textBoxTracker";
            this.textBoxTracker.Size = new System.Drawing.Size(519, 22);
            this.textBoxTracker.TabIndex = 2;
            this.textBoxTracker.Text = "c:\\TEMP\\_TrackerAnalyzer\\tra\\";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 182);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(924, 340);
            this.textBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxTracker);
            this.Controls.Add(this.textBoxEmp);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxEmp;
        private System.Windows.Forms.TextBox textBoxTracker;
        private System.Windows.Forms.TextBox textBox1;
    }
}

