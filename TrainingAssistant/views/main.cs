using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainingAssistant.views
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            var start = new views.setup();
            start.Show();
            this.Hide();
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            var settings = new views.settings();
            settings.Show();
        }

        private void btn_about_Click(object sender, EventArgs e)
        {
              var about = new views.about();
              about.Show();
        }
    }
}
