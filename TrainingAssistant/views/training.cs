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
        private Timer timer;
        public training()
        {
            s = new Session();
            InitializeComponent();
            this.lbl_timer.Text = "Session starting at " + DateTime.Now.ToString();
            this.startTimer();
        }

        private void startTimer()
        {
            this.timer = new Timer();
            timer.Interval = 5000;
            this.timer.Enabled = true;
            this.timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.updateTimer();
            this.lbl_score.Text = Math.Round((this.s.updateScore() * 100), 2) + "%";
            this.lbl_npoints.Text = this.s.negPoints.ToString();
            this.lbl_ppoints.Text = this.s.posPoints.ToString();
        }

        private void btn_d_wafdof_Click(object sender, EventArgs e)
        {
            this.s.gndEvents["wafdof"]++;
        }
        private void btn_d_squawk_Click(object sender, EventArgs e)
        {
            this.s.gndEvents["squawk"]++;
        }

        private void btn_d_cddelay_Click(object sender, EventArgs e)
        {
            this.s.gndEvents["clnc_late"]++;
        }

        private void btn_d_cdclearance_Click(object sender, EventArgs e)
        {
            this.s.gndEvents["clnc_wrong"]++;
        }

        private void btn_d_landing_Click(object sender, EventArgs e)
        {
            this.s.twrEvents["landing"]++;
        }

        private void btn_d_takeoff_Click(object sender, EventArgs e)
        {
            this.s.twrEvents["takeoff"]++;
        }

        private void btn_d_luaw_Click(object sender, EventArgs e)
        {
            this.s.twrEvents["luaw"]++;
        }

        private void btn_d_waketurb_Click(object sender, EventArgs e)
        {
            this.s.twrEvents["turbulence"]++;
        }

        private void btn_d_appclearance_Click(object sender, EventArgs e)
        {
            this.s.appEvents["clearance"]++;
        }

        private void btn_d_mva_Click(object sender, EventArgs e)
        {
            this.s.appEvents["mva"]++;
        }

        private void btn_d_loasop_Click(object sender, EventArgs e)
        {
            this.s.appEvents["sop"]++;
        }

        private void btn_d_fix_Click(object sender, EventArgs e)
        {
            this.s.appEvents["fix"]++;
        }

        private void btn_d_slow_Click(object sender, EventArgs e)
        {
            this.s.genEvents["slow"]++;
        }

        private void btn_d_separation_Click(object sender, EventArgs e)
        {
            this.s.genEvents["separation"]++;
        }

        private void btn_d_phraseology_Click(object sender, EventArgs e)
        {
            this.s.genEvents["phraseology"]++;
        }

        private void btn_d_nearincident_Click(object sender, EventArgs e)
        {
            this.s.genEvents["near"]++;
        }

        private void btn_d_incident_Click(object sender, EventArgs e)
        {
            this.s.genEvents["incident"]++;
        }

        private void btn_u_flow_Click(object sender, EventArgs e)
        {
            this.s.posEvents["flow"]++;
        }

        private void btn_u_situational_Click(object sender, EventArgs e)
        {
            this.s.posEvents["situational"]++;
        }

        private void btn_u_phraseology_Click(object sender, EventArgs e)
        {
            this.s.posEvents["phraseology"]++;
        }

        private void btn_u_separation_Click(object sender, EventArgs e)
        {
            this.s.posEvents["separation"]++;
        }

        private void btn_u_pointouts_Click(object sender, EventArgs e)
        {
            this.s.posEvents["pointouts"]++;
        }

        private void btn_u_sequence_Click(object sender, EventArgs e)
        {
            this.s.posEvents["sequencing"]++;
        }

        private void cb_signonbrief_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_signonbrief.SelectedIndex)
            {
                case 0:
                    this.s.combos["brief"] = 10;
                    break;
                case 1:
                    this.s.combos["brief"] = 5;
                    break;
                case 2:
                    this.s.combos["brief"] = 0;
                    break;
            }
            
        }

        private void cb_rwyselection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_rwyselection.SelectedIndex)
            {
                case 0:
                    this.s.combos["runway"] = 10;
                    break;
                case 1:
                    this.s.combos["runway"] = 5;
                    break;
                case 2:
                    this.s.combos["runway"] = 0;
                    break;
            }
        }

        private void cb_weather_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_weather.SelectedIndex)
            {
                case 0:
                    this.s.combos["weather"] = 10;
                    break;
                case 1:
                    this.s.combos["weather"] = 5;
                    break;
                case 2:
                    this.s.combos["weather"] = 0;
                    break;
            }
        }

        private void cb_coordination_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_coordination.SelectedIndex)
            {
                case 0:
                    this.s.combos["coordination"] = 10;
                    break;
                case 1:
                    this.s.combos["coordination"] = 5;
                    break;
                case 2:
                    this.s.combos["coordination"] = 0;
                    break;
            }
        }

        private void cb_trafficflow_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_trafficflow.SelectedIndex)
            {
                case 0:
                    this.s.combos["flow"] = 10;
                    break;
                case 1:
                    this.s.combos["flow"] = 5;
                    break;
                case 2:
                    this.s.combos["flow"] = 0;
                    break;
            }
        }

        private void cb_aircraftidentity_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_aircraftidentity.SelectedIndex)
            {
                case 0:
                    this.s.combos["identity"] = 10;
                    break;
                case 1:
                    this.s.combos["identity"] = 5;
                    break;
                case 2:
                    this.s.combos["identity"] = 0;
                    break;
            }
        }

        private void cb_separation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_separation.SelectedIndex)
            {
                case 0:
                    this.s.combos["separation"] = 10;
                    break;
                case 1:
                    this.s.combos["separation"] = 5;
                    break;
                case 2:
                    this.s.combos["separation"] = 0;
                    break;
            }
        }

        private void cb_pointouts_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_pointouts.SelectedIndex)
            {
                case 0:
                    this.s.combos["pointouts"] = 10;
                    break;
                case 1:
                    this.s.combos["pointouts"] = 5;
                    break;
                case 2:
                    this.s.combos["pointouts"] = 0;
                    break;
            }
        }

        private void cb_airspace_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_separation.SelectedIndex)
            {
                case 0:
                    this.s.combos["airspace"] = 10;
                    break;
                case 1:
                    this.s.combos["airspace"] = 5;
                    break;
                case 2:
                    this.s.combos["airspace"] = 0;
                    break;
            }
        }

        private void cb_loa_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_loa.SelectedIndex)
            {
                case 0:
                    this.s.combos["loa"] = 10;
                    break;
                case 1:
                    this.s.combos["loa"] = 5;
                    break;
                case 2:
                    this.s.combos["loa"] = 0;
                    break;
            }
        }

        private void cb_phraseology_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_phraseology.SelectedIndex)
            {
                case 0:
                    this.s.combos["phraseology"] = 10;
                    break;
                case 1:
                    this.s.combos["phraseology"] = 5;
                    break;
                case 2:
                    this.s.combos["phraseology"] = 0;
                    break;
            }
        }

        private void cb_dutypriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_dutypriority.SelectedIndex)
            {
                case 0:
                    this.s.combos["priority"] = 10;
                    break;
                case 1:
                    this.s.combos["priority"] = 5;
                    break;
                case 2:
                    this.s.combos["priority"] = 0;
                    break;
            }
        }

        private void chk_reviewsop_CheckedChanged(object sender, EventArgs e)
        {
            string s = "SOPs were reviewed.";
            if(this.chk_reviewsop.Checked)
            {
                this.s.reviewed.Add(s);
            }
            else
            {
                this.s.reviewed.Remove(s);
            }
        }

        private void chk_reviewphraseology_CheckedChanged(object sender, EventArgs e)
        {
            string s = "Phraseology was reviewed.";
            if(this.chk_reviewphraseology.Checked)
            {
                this.s.reviewed.Add(s);
            }
            else
            {
                this.s.reviewed.Remove(s);
            }
        }

        private void chk_reviewpriority_CheckedChanged(object sender, EventArgs e)
        {
            string s = "Duty priorities were reviewed.";
            if(this.chk_reviewpriority.Checked)
            {
                this.s.reviewed.Add(s);
            }
            else
            {
                this.s.reviewed.Remove(s);
            }
        }

        private void chk_reviewother_CheckedChanged(object sender, EventArgs e)
        {
            string s = "We reviewed other topics as well.";
            if(this.chk_reviewother.Checked)
            {
                this.s.reviewed.Add(s);
            }
            else
            {
                this.s.reviewed.Remove(s);
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
            this.s.complete();
        }

        private void updateTimer()
        {
            this.lbl_timer.Text = "Time Elapsed: " + this.s.getTime().ToString() + " minutes";
        }

        private void updateMarkups()
        {
            this.lbl_markups.Text = this.s.markups.ToString();
        }

        private void updateMarkdowns()
        {
            this.lbl_markdowns.Text = this.s.markdowns.ToString();
        }
    }
}
