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
            string insName = ins_fname.Text + ' ' + ins_lname.Text;
            string studentName = student_fname.Text + ' ' + student_lname.Text;
            string studentRating = student_rating.Text;
            string studentTraining = student_training.Text;
            string studentInitials = student_initials.Text;

            //make sure all the data is correct
            Setup sesh = new Setup(insName, studentName, studentInitials, studentRating, studentTraining);
            //create the session in the background
            if (sesh.check())
            {
                session_status.Text = "Session successfully created for: " + insName + " and " + studentName + " for " + studentTraining;
            }
            else
            {
                session_status.Text = "Error creating session!";
            }
            //switch to the training session screen
            (new views.training()).Show();
            this.Hide();
        }
    }
}
