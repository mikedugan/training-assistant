using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingAssistant.models
{
    class Session
    {
        DateTime start { get; set; }
        DateTime finish { get; set; }
        int markups { get; set; }
        int markdowns { get; set; }
        List<string> reviewed { get; set; }
        public bool otsPass { get; set; }
        public bool otsFail { get; set; }

        public Session()
        {
            this.start = DateTime.Now;
        }

        public Boolean isPassing()
        {
            //calculate if the student is passing
            return true;
        }

        public int calculateGrade()
        {
            //calculate the grade and return it
            return 5;
        }

        public int getTime()
        {
            return (int)DateTime.Now.Subtract(this.start).TotalMinutes;
        }

        public void addMarkup()
        {
            this.markups += 1;
        }

        public void addMarkdown()
        {
            this.markdowns -= 1;
        }

        public int getMarkups()
        {
            return this.markups;
        }

        public int getMarkdowns()
        {
            return this.markdowns;
        }

        public void addReview(string s)
        {
            this.reviewed.Add(s);
        }

        public bool removeReview(string s)
        {
            return this.reviewed.Remove(s);
        }

        public Report finishTraining()
        {
            Report r = new Report();

            return r;
        }
    }
}
