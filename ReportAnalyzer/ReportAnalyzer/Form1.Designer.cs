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
            this.button1.Location = new System.Drawing.Point(38, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxEmp
            // 
            this.textBoxEmp.Location = new System.Drawing.Point(38, 22);
            this.textBoxEmp.Name = "textBoxEmp";
            this.textBoxEmp.Size = new System.Drawing.Size(390, 20);
            this.textBoxEmp.TabIndex = 1;
            this.textBoxEmp.Text = "h:\\_SDL\\EMP_tracker\\emp\\";
            // 
            // textBoxTracker
            // 
            this.textBoxTracker.Location = new System.Drawing.Point(38, 63);
            this.textBoxTracker.Name = "textBoxTracker";
            this.textBoxTracker.Size = new System.Drawing.Size(390, 20);
            this.textBoxTracker.TabIndex = 2;
            this.textBoxTracker.Text = "h:\\_SDL\\EMP_tracker\\tra\\";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 148);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(694, 277);
            this.textBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxTracker);
            this.Controls.Add(this.textBoxEmp);
            this.Controls.Add(this.button1);
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

