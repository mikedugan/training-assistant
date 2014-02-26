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
        public setup()
        {
            InitializeComponent();
        }

        private void session_start_Click(object sender, EventArgs e)
        {
            string[] student = new string[3];
            string[] ins = new string[3];
            int[] ratings = new int[3];
            string[] rateText = new string[3];
            student[0] = this.student_fname.Text;
            student[1] = this.student_lname.Text;
            student[2] = this.student_initials.Text;
            ins[0] = this.ins_fname.Text;
            ins[1] = this.ins_lname.Text;
            ins[2] = this.ins_initials.Text;
            ratings[1] = this.student_training.SelectedIndex;
            ratings[0] = this.student_rating.SelectedIndex;
            rateText[1] = this.student_training.SelectedItem.ToString();
            rateText[0] = this.student_rating.SelectedItem.ToString();


            //make sure all the data is correct
            Setup sesh = new Setup(student, ins, ratings, rateText);
            //create the session in the background
            if ( ! sesh.check())
            {
                this.lbl_error.ResetText();
                this.lbl_error.ForeColor = Color.Red;
                foreach(string s in sesh.errors)
                {
                    this.lbl_error.Text += s;
                }
            }
            else
            {
            //switch to the training session screen
            (new views.training(ins, student, rateText)).Show();
            this.Hide();
            }
        }
    }
}
