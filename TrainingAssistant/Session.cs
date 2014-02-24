using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingAssistant
{
    class Session
    {
        public DateTime startTime;
        public DateTime finishTime;

        public string insName;
        public string studentName;
        public string studentInitials;
        public string studentRating;
        public string studentTraining;
        public Session(string iName, string sName, string sInitials, string sRating, string sTraining)
        {
            this.insName = iName;
            this.studentName = sName;
            this.studentInitials = sInitials;
            this.studentRating = sRating;
            this.studentTraining = sTraining;

            this.startTime = DateTime.Now;
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
