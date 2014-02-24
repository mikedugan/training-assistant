using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingAssistant.models
{
    class Session
    {
        public enum TrafficLevel { light, moderate, heavy }
        public enum ComplexityLevel { very_easy, easy, moderate, hard, very_hard}
        public enum WeatherConditions { vfr, mvfr, ifr}
        DateTime start { get; set; }
        DateTime finish { get; set; }
        int markups { get; set; }
        int markdowns { get; set; }
        List<string> reviewed { get; set; }
        public bool otsPass { get; set; }
        public bool otsFail { get; set; }

        public int posPoints { get; set; }
        public int negPoints { get; set; }
        public double score { get; set; }
        public TrafficLevel traffic { get; set; }
        public ComplexityLevel complexity { get; set; }
        public WeatherConditions weather { get; set; }
        public Dictionary<string, int> combos { get; set; }

        public Session()
        {
            this.start = DateTime.Now;
            this.complexity = ComplexityLevel.easy;
            this.traffic = TrafficLevel.light;
            this.weather = WeatherConditions.vfr;
            this.posPoints = 120;
            this.combos = new Dictionary<string, int>()
            {
                {"brief", 10},
                {"runway", 10},
                {"weather", 10},
                {"coordination", 10},
                {"flow", 10},
                {"identity", 10},
                {"separation", 10},
                {"pointouts", 10},
                {"airspace", 10},
                {"loa", 10},
                {"phraseology", 10},
                {"priority", 10}
            };
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

        public void complete()
        {
            this.finish = DateTime.Now;
        }

        public double updateScore()
        {
            double modifier = 1;
            switch (this.complexity) 
            {
                case ComplexityLevel.easy:
                    break;
                case ComplexityLevel.very_easy:
                    break;
                case ComplexityLevel.moderate:
                    modifier -= 0.05;
                    break;
                case ComplexityLevel.hard:
                    modifier -= 0.1;
                    break;
                case ComplexityLevel.very_hard:
                    modifier -= 0.15;
                    break;
            }
            switch (this.weather)
            {
                case WeatherConditions.vfr:
                    break;
                case WeatherConditions.mvfr:
                    modifier -= 0.03;
                    break;
                case WeatherConditions.ifr:
                    modifier -= 0.05;
                    break;
            }

            switch (this.traffic)
            {
                case TrafficLevel.light:
                    break;
                case TrafficLevel.moderate:
                    modifier -= 0.05;
                    break;
                case TrafficLevel.heavy:
                    modifier -= 0.1;
                    break;
            }
            this.posPoints = this.combos.Values.Sum();
            double n = this.negPoints * modifier;
            n += this.posPoints;
            this.score = n / 120;
            return this.score;
            
        }

        public Report finishTraining()
        {
            Report r = new Report();

            return r;
        }
    }
}
