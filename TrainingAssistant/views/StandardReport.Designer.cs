namespace TrainingAssistant.views
{
    partial class StandardReport
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
            this.lbl_report = new System.Windows.Forms.Label();
            this.txt_report = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lbl_report
            // 
            this.lbl_report.AutoSize = true;
            this.lbl_report.Location = new System.Drawing.Point(47, 34);
            this.lbl_report.Name = "lbl_report";
            this.lbl_report.Size = new System.Drawing.Size(0, 13);
            this.lbl_report.TabIndex = 0;
            // 
            // txt_report
            // 
            this.txt_report.Location = new System.Drawing.Point(50, 50);
            this.txt_report.Name = "txt_report";
            this.txt_report.Size = new System.Drawing.Size(284, 525);
            this.txt_report.TabIndex = 1;
            this.txt_report.Text = "";
            // 
            // StandardReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 618);
            this.Controls.Add(this.txt_report);
            this.Controls.Add(this.lbl_report);
            this.Name = "StandardReport";
            this.Text = "StandardReport";
            this.Load += new System.EventHandler(this.StandardReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_report;
        private System.Windows.Forms.RichTextBox txt_report;
    }
}