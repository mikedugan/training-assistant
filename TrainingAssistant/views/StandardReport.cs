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
    public partial class StandardReport : Form
    {
        TrainingAssistant.models.Report report { get; set; }
        public StandardReport(models.Report report)
        {
            InitializeComponent();
            this.report = report;
            this.txt_report.Text = report.generateReport();
        }

        private void StandardReport_Load(object sender, EventArgs e)
        {

        }
    }
}
