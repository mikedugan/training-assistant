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
            SetCbIndex();
            this.setup_page();
            this.lbl_timer.Text = "Session starting at " + Globals.sessionStart.ToString();
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
            this.s.score = this.s.updateScore();
            this.lbl_score.Text = Math.Round((this.s.score * 100), 2).ToString() + "%";
            if (this.s.checkFail()) { this.lbl_fail.Text = "Fail"; } else this.lbl_fail.Text = "Pass";
        }
        private void updateTimer()
        {
            this.lbl_timer.Text = "Time Elapsed: " + this.s.getTime().ToString() + " minutes";
        }

        private void setup_page()
        {
            this.lbl_iname.Text = Globals.insName + "(" + Globals.insInitials + ")";
            this.lbl_sname.Text = Globals.studentName + "(" + Globals.studentInitials + ")";
            this.lbl_fail.Text = Globals.studentTraining.ToString();
            this.button1.Enabled = false;
            if (Globals.studentTraining < 3)
            {
                this.btn_d_landing.Enabled = false;
                this.btn_d_takeoff.Enabled = false;
                this.btn_d_luaw.Enabled = false;
                this.btn_d_waketurb.Enabled = false;
                this.btn_d_separation.Enabled = false;
                this.cb_separation.Enabled = false;
            }

            if (Globals.studentTraining < 6)
            {
                this.btn_d_appclearance.Enabled = false;
                this.btn_d_mva.Enabled = false;
                this.btn_d_loasop.Enabled = false;
                this.btn_d_fix.Enabled = false;
                this.btn_d_final.Enabled = false;
            }

        }

        private void SetCbIndex()
        {
            this.cb_aircraftidentity.SelectedIndex = 0;
            this.cb_airspace.SelectedIndex = 0;
            this.cb_coordination.SelectedIndex = 0;
            this.cb_dutypriority.SelectedIndex = 0;
            this.cb_loa.SelectedIndex = 0;
            this.cb_lvl_complexity.SelectedIndex = 0;
            this.cb_lvl_traffic.SelectedIndex = 0;
            this.cb_lvl_weather.SelectedIndex = 0;
            this.cb_phraseology.SelectedIndex = 0;
            this.cb_pointouts.SelectedIndex = 0;
            this.cb_rwyselection.SelectedIndex = 0;
            this.cb_separation.SelectedIndex = 0;
            this.cb_signonbrief.SelectedIndex = 0;
            this.cb_trafficflow.SelectedIndex = 0;
            this.cb_weather.SelectedIndex = 0;
        }

        #region click handlers
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
            this.s.appEvents["clnc"]++;
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
        private void btn_d_taxi_Click(object sender, EventArgs e)
        {
            this.s.gndEvents["taxi"]++;
        }

        private void btn_d_final_Click(object sender, EventArgs e)
        {
            this.s.appEvents["final"]++;
        }

        private void btn_d_coordination_Click(object sender, EventArgs e)
        {
            this.s.genEvents["coordination"]++;
        }

        private void btn_d_readback_Click(object sender, EventArgs e)
        {
            this.s.genEvents["readback"]++;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.s.complete();
        }

        private void btn_golive_Click(object sender, EventArgs e)
        {
            Globals.briefFinish = DateTime.Now;
            this.button1.Enabled = true;
        }
        #endregion

        #region cb handlers
        private void cb_lvl_weather_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_lvl_weather.SelectedIndex)
            {
                case 0:
                    this.s.weather = Session.WeatherConditions.vfr;
                    break;
                case 1:
                    this.s.weather = Session.WeatherConditions.mvfr;
                    break;
                case 3:
                    this.s.weather = Session.WeatherConditions.ifr;
                    break;
            }
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
            switch (this.cb_airspace.SelectedIndex)
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
        private void cb_lvl_complexity_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_lvl_complexity.SelectedIndex)
            {
                case 0:
                    this.s.complexity = Session.ComplexityLevel.very_easy;
                    break;
                case 1:
                    this.s.complexity = Session.ComplexityLevel.easy;
                    break;
                case 2:
                    this.s.complexity = Session.ComplexityLevel.moderate;
                    break;
                case 3:
                    this.s.complexity = Session.ComplexityLevel.hard;
                    break;
                case 4:
                    this.s.complexity = Session.ComplexityLevel.very_hard;
                    break;
            }
        }

        private void cb_lvl_traffic_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cb_lvl_traffic.SelectedIndex)
            {
                case 0:
                    this.s.traffic = Session.TrafficLevel.light;
                    break;
                case 1:
                    this.s.traffic = Session.TrafficLevel.moderate;
                    break;
                case 2:
                    this.s.traffic = Session.TrafficLevel.heavy;
                    break;
            }
        }
        #endregion

        #region chk handlers

        private void rb_pass_CheckedChanged(object sender, EventArgs e)
        {
            this.s.ots = 2;
        }

        private void rb_fail_CheckedChanged(object sender, EventArgs e)
        {
            this.s.ots = 1;
        }

        private void rb_na_CheckedChanged(object sender, EventArgs e)
        {
            this.s.ots = 0;
        }
        private void chk_r_runway_CheckedChanged(object sender, EventArgs e)
        {
            string s = "Runway configuration was reviewed.";
            if(this.chk_r_runway.Checked)
            {
                this.s.reviewed.Add(s);
            }

            else this.s.reviewed.Remove(s);
        }

        private void chk_r_weather_CheckedChanged(object sender, EventArgs e)
        {
            string s = "Weather conditions and applications were reviewed.";
            if(this.chk_r_weather.Checked)
            {
                this.s.reviewed.Add(s);
            }

            else this.s.reviewed.Remove(s);
        }

        private void chk_r_coordination_CheckedChanged(object sender, EventArgs e)
        {
            string s = "Controller coordination was reviewed.";
            if(this.chk_r_coordination.Checked)
            {
                this.s.reviewed.Add(s);
            }

            else this.s.reviewed.Remove(s);
        }

        private void chk_r_flow_CheckedChanged(object sender, EventArgs e)
        {
            string s = "Traffic flow management was reviewed.";
            if(this.chk_r_flow.Checked)
            {
                this.s.reviewed.Add(s);
            }

            else this.s.reviewed.Remove(s);
        }

        private void chk_r_identity_CheckedChanged(object sender, EventArgs e)
        {
            string s = "Maintaining aircraft identity was reviewed.";
            if(this.chk_r_identity.Checked)
            {
                this.s.reviewed.Add(s);
            }

            else this.s.reviewed.Remove(s);
        }

        private void chk_r_separation_CheckedChanged(object sender, EventArgs e)
        {
            string s = "Aircraft separation requirements and methods were reviewed.";
            if(this.chk_r_separation.Checked)
            {
                this.s.reviewed.Add(s);
            }

            else this.s.reviewed.Remove(s);
        }

        private void chk_r_pointouts_CheckedChanged(object sender, EventArgs e)
        {
            string s = "Traffic and safety pointouts were reviewed.";
            if(this.chk_r_pointouts.Checked)
            {
                this.s.reviewed.Add(s);
            }

            else this.s.reviewed.Remove(s);
        }

        private void chk_r_airspace_CheckedChanged(object sender, EventArgs e)
        {
            string s = "General airspace knowledge was reviewed.";
            if(chk_r_airspace.Checked)
            {
                this.s.reviewed.Add(s);
            }

            else this.s.reviewed.Remove(s);
        }

        private void chk_r_loa_CheckedChanged(object sender, EventArgs e)
        {
            string s = "LOA and SOP directives were reviewed.";
            if(chk_r_loa.Checked)
            {
                this.s.reviewed.Add(s);
            }

            else this.s.reviewed.Remove(s);
        }

        private void chk_r_phraseology_CheckedChanged(object sender, EventArgs e)
        {
            string s = "General phraseology was reviewed";
            if(chk_r_phraseology.Checked)
            {
                this.s.reviewed.Add(s);
            }

            else this.s.reviewed.Remove(s);
        }

        private void chk_r_duty_CheckedChanged(object sender, EventArgs e)
        {
            string s = "Duty priorities were reviewed.";
            if(chk_r_duty.Checked)
            {
                this.s.reviewed.Add(s);
            }

            else this.s.reviewed.Remove(s);
        }

        #endregion

        private void chk_r_brief_CheckedChanged(object sender, EventArgs e)
        {
            
        }

    }
}
