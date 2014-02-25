using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingAssistant
{
    class Setup
    {

        public string[] student;
        public string[] instructor;
        public int[] ratings;
        public List<string> errors { get; set; }
        public Setup(string[] student, string[] instructor, int[] ratings)
        {
            //[fname, lname, initials]
            this.student = student;
            //[fname, lname, initials]
            this.instructor = instructor;
            //[rating, training, insrating]
            this.ratings = ratings;
            this.errors = new List<string>();
        }

        public bool check()
        {
            //ratings1 = rating ratings2 = training for
            this.errors = new List<string>();
            if (this.instructor[0] == null || this.instructor[0] == "") { this.errors.Add("Please add instructor's first name.\r\n"); }
            if (this.instructor[1] == null || this.instructor[1] == "") { this.errors.Add("Please add instructor's last name.\r\n"); }
            if (this.instructor[2].Length != 2) { this.errors.Add("Instructor initials not valid.\r\n"); }
            if (this.student[0] == null || this.student[0] == "") { this.errors.Add("Please add student's first name.\r\n"); }
            if (this.student[1] == null || this.student[1] == "") { this.errors.Add("Please add student's last name.\r\n"); }
            if (this.student[2].Length != 2) { this.errors.Add("Invalid student controller initials.\r\n"); }
            /*if (this.ratings[0] == null) { this.errors.Add("Please select the student's rating.\r\n"); }
            if (this.ratings[1] == null) { this.errors.Add("Please select the training type.\r\n"); }*/
            if (this.ratings[0] == 0 && this.ratings[1] > 0) { this.errors.Add("Observer cannot train above C/D ground.\r\n");}
            if (this.ratings[0] == 1 && this.ratings[1] > 5) { this.errors.Add("S1 cannot train above class B tower."); }
            if (this.ratings[0] == 2 && this.ratings[1] > 8) { this.errors.Add("S2 cannot train for center."); }
            return this.errors.Count == 0;
        }
    }
}
