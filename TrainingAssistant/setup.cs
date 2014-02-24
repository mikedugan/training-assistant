using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingAssistant
{
    class Setup
    {

        public string insName;
        public string studentName;
        public string studentInitials;
        public string studentRating;
        public string studentTraining;
        public Setup(string iName, string sName, string sInitials, string sRating, string sTraining)
        {
            this.insName = iName;
            this.studentName = sName;
            this.studentInitials = sInitials;
            this.studentRating = sRating;
            this.studentTraining = sTraining;
        }

        public bool check()
        {
            bool isValid = true;
            isValid = this.insName.Split(' ').Count() == 2;
            isValid = this.studentName.Split(' ').Count() == 2;
            isValid = this.studentInitials.Length == 2;
            return isValid;
        }
    }
}
