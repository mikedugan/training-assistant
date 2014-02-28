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
    public partial class setup : Form
    {
        protected List<string> errors;
        public setup()
        {
            InitializeComponent();
            this.errors = new List<string>();
        }

        private void session_start_Click(object sender, EventArgs e)
        {
            Globals.studentName = Helpers.Capitalize(this.student_fname.Text + " " + this.student_lname.Text);
            Globals.studentInitials = this.student_initials.Text.ToUpper();
            Globals.insName = Helpers.Capitalize(this.ins_fname.Text + " " + this.ins_lname.Text);
            Globals.insInitials = this.ins_initials.Text.ToUpper();
            Globals.studentRating = this.student_rating.SelectedIndex;
            Globals.studentTraining = this.student_training.SelectedIndex;
            Globals.ratingStr = this.student_rating.SelectedItem.ToString();
            Globals.trainingStr = this.student_training.SelectedItem.ToString();
            //make sure all the data is correct
            //create the session in the background
            if ( ! this.check())
            {
                this.lbl_error.ResetText();
                this.lbl_error.ForeColor = Color.Red;
                foreach(string s in this.errors)
                {
                    this.lbl_error.Text += s;
                }
            }
            else
            {
            //switch to the training session screen
                
            (new views.training()).Show();
            this.Hide();
            }
        }

        public bool check()
        {
            this.errors = new List<string>();
            //ratings1 = rating ratings2 = training for
            if (String.IsNullOrWhiteSpace(Globals.insName)) { this.errors.Add("Please add instructor's name.\r\n"); }
            if (Globals.insInitials.Length != 2) { this.errors.Add("Instructor initials not valid.\r\n"); }
            if (String.IsNullOrWhiteSpace(Globals.studentName)) { this.errors.Add("Please add student's name.\r\n"); }
            if (Globals.studentInitials.Length != 2) { this.errors.Add("Invalid student controller initials.\r\n"); }
            /*if (this.ratings[0] == null) { this.errors.Add("Please select the student's rating.\r\n"); }
            if (this.ratings[1] == null) { this.errors.Add("Please select the training type.\r\n"); }*/
            if (Globals.studentRating == 0 && Globals.studentTraining > 0) { this.errors.Add("Observer cannot train above C/D ground.\r\n"); }
            if (Globals.studentRating == 1 && Globals.studentTraining > 5) { this.errors.Add("S1 cannot train above class B tower."); }
            if (Globals.studentRating == 2 && Globals.studentTraining > 8) { this.errors.Add("S2 cannot train for center."); }
            return this.errors.Count == 0;
        }
    }
}
