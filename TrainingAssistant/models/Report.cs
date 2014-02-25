using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingAssistant.models
{
    class Report
    {
        //ins, student, ratings, time, conditions, ppoints, npoints
        public List<string[]> info;
        public List<string> reviewed;
        //gnd,twr,app,gen,pos,combos
        public List<Dictionary<string, int>> events;
        public string dComment;
        public string sComment;
        public Report(List<string[]> info, List<string> reviewed, List<Dictionary<string, int>> events)
        {
            this.info = info;
            this.reviewed = reviewed;
            this.events = events;
            this.dComment = "";
            this.sComment = "";
        }

        public string generateDatabaseComment()
        {
            return "";
        }

        public string generateStudentComment()
        {
            return "";
        }

        public string generateReport()
        {
            return "";
        }

        protected string generateDatabaseHeader()
        {
            return "";
        }

        protected string generateStudentHeader()
        {
            return "";
        }

        protected string generateCbReview()
        {
            return "";
        }
        
        protected string generateSummary()
        {
            return "";
        }

        protected string generateEventLog()
        {
            return "";
        }


    }
}
