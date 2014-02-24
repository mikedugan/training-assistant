namespace TrainingAssistant.views
{
    partial class main
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
            this.pageTitle = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_settings = new System.Windows.Forms.Button();
            this.btn_about = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pageTitle
            // 
            this.pageTitle.AutoSize = true;
            this.pageTitle.Font = new System.Drawing.Font("Calibri", 12F);
            this.pageTitle.Location = new System.Drawing.Point(187, 18);
            this.pageTitle.Name = "pageTitle";
            this.pageTitle.Size = new System.Drawing.Size(125, 19);
            this.pageTitle.TabIndex = 0;
            this.pageTitle.Text = "Training Assistant";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(191, 70);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(121, 23);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Start Session";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_settings
            // 
            this.btn_settings.Location = new System.Drawing.Point(214, 115);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(75, 23);
            this.btn_settings.TabIndex = 2;
            this.btn_settings.Text = "Settings";
            this.btn_settings.UseVisualStyleBackColor = true;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // btn_about
            // 
            this.btn_about.Location = new System.Drawing.Point(214, 161);
            this.btn_about.Name = "btn_about";
            this.btn_about.Size = new System.Drawing.Size(75, 23);
            this.btn_about.TabIndex = 3;
            this.btn_about.Text = "About";
            this.btn_about.UseVisualStyleBackColor = true;
            this.btn_about.Click += new System.EventHandler(this.btn_about_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 625);
            this.Controls.Add(this.btn_about);
            this.Controls.Add(this.btn_settings);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.pageTitle);
            this.Name = "main";
            this.Text = "main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pageTitle;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.Button btn_about;
    }
}