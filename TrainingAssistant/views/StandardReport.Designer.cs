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
            this.txt_database = new System.Windows.Forms.RichTextBox();
            this.txt_student = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.txt_report.Location = new System.Drawing.Point(12, 173);
            this.txt_report.Name = "txt_report";
            this.txt_report.Size = new System.Drawing.Size(309, 402);
            this.txt_report.TabIndex = 1;
            this.txt_report.Text = "";
            // 
            // txt_database
            // 
            this.txt_database.Location = new System.Drawing.Point(327, 173);
            this.txt_database.Name = "txt_database";
            this.txt_database.Size = new System.Drawing.Size(321, 402);
            this.txt_database.TabIndex = 2;
            this.txt_database.Text = "";
            // 
            // txt_student
            // 
            this.txt_student.Location = new System.Drawing.Point(654, 173);
            this.txt_student.Name = "txt_student";
            this.txt_student.Size = new System.Drawing.Size(313, 402);
            this.txt_student.TabIndex = 3;
            this.txt_student.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F);
            this.label1.Location = new System.Drawing.Point(96, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Session Summary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F);
            this.label2.Location = new System.Drawing.Point(427, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Database Comment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F);
            this.label3.Location = new System.Drawing.Point(757, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Student Comment";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 18F);
            this.label4.Location = new System.Drawing.Point(376, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Training Session Results";
            // 
            // StandardReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 618);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_student);
            this.Controls.Add(this.txt_database);
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
        private System.Windows.Forms.RichTextBox txt_database;
        private System.Windows.Forms.RichTextBox txt_student;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}