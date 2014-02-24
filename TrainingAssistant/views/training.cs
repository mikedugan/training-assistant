using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainingAssistant.models;

namespace TrainingAssistant.views
{
    public partial class training : Form
    {
        Session s { get; set; }
        public training()
        {
            s = new Session();
            InitializeComponent();
            this.lbl_timer.Text = DateTime.Now.ToString();
        }

        private void btn_d_wafdof_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }
        private void btn_d_squawk_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_cddelay_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_cdclearance_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_landing_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_takeoff_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_luaw_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_waketurb_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_appclearance_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_mva_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_loasop_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_fix_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_slow_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_separation_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_phraseology_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_nearincident_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_d_incident_Click(object sender, EventArgs e)
        {
            this.s.addMarkdown();
            this.updateMarkdowns();
        }

        private void btn_u_flow_Click(object sender, EventArgs e)
        {
            this.s.addMarkup();
            this.updateMarkups();
        }

        private void btn_u_situational_Click(object sender, EventArgs e)
        {
            this.s.addMarkup();
            this.updateMarkups();
        }

        private void btn_u_phraseology_Click(object sender, EventArgs e)
        {
            this.s.addMarkup();
            this.updateMarkups();
        }

        private void btn_u_separation_Click(object sender, EventArgs e)
        {
            this.s.addMarkup();
            this.updateMarkups();
        }

        private void btn_u_pointouts_Click(object sender, EventArgs e)
        {
            this.s.addMarkup();
            this.updateMarkups();
        }

        private void btn_u_sequence_Click(object sender, EventArgs e)
        {
            this.s.addMarkup();
            this.updateMarkups();
        }

        private void cb_signonbrief_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_rwyselection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_weather_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_coordination_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_trafficflow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_aircraftidentity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_separation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_pointouts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_airspace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_loa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_phraseology_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_dutypriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chk_reviewsop_CheckedChanged(object sender, EventArgs e)
        {
            string s = "SOPs were reviewed.";
            if(this.chk_reviewsop.Checked)
            {
                this.s.addReview(s);
            }

            else
            {
                this.s.removeReview(s);
            }
        }

        private void chk_reviewphraseology_CheckedChanged(object sender, EventArgs e)
        {
            string s = "Phraseology was reviewed.";
            if(this.chk_reviewphraseology.Checked)
            {
                this.s.addReview(s);
            }

            else
            {
                this.s.removeReview(s);
            }
        }

        private void chk_reviewpriority_CheckedChanged(object sender, EventArgs e)
        {
            string s = "Duty priorities were reviewed.";
            if(this.chk_reviewpriority.Checked)
            {
                this.s.addReview(s);
            }
            else
            {
                this.s.removeReview(s);
            }
        }

        private void chk_reviewother_CheckedChanged(object sender, EventArgs e)
        {
            string s = "We reviewed other topics as well.";
            if(this.chk_reviewother.Checked)
            {
                this.s.addReview(s);
            }
            else
            {
                this.s.removeReview(s);
            }
        }

        private void chk_otspass_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_otspass.Checked)
            {
                this.s.otsPass = true;
            }
            else
            {
                this.s.otsPass = false;   
            }
        }

        private void chk_otsfail_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chk_otsfail.Checked)
            {
                this.s.otsPass = false;
                this.s.otsFail = true;
            }
            else
            {
                this.s.otsFail = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void updateMarkups()
        {
            this.lbl_markups.Text = this.s.getMarkups().ToString();
        }

        private void updateMarkdowns()
        {
            this.lbl_markdowns.Text = this.s.getMarkdowns().ToString();
        }
    }
}
