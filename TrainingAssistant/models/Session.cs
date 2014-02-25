using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingAssistant.models
{
    class Session
    {
        public List<string> errors { get; set; }
        public enum TrafficLevel { light, moderate, heavy }
        public enum ComplexityLevel { very_easy, easy, moderate, hard, very_hard}
        public enum WeatherConditions { vfr, mvfr, ifr}
        DateTime start { get; set; }
        DateTime finish { get; set; }
        public int markups { get; set; }
        public int markdowns { get; set; }
        public List<string> reviewed { get; set; }
        public bool otsPass { get; set; }
        public bool otsFail { get; set; }

        public int posPoints { get; set; }
        public int negPoints { get; set; }
        public double score { get; set; }
        public TrafficLevel traffic { get; set; }
        public ComplexityLevel complexity { get; set; }
        public WeatherConditions weather { get; set; }
        public Dictionary<string, int> combos { get; set; }
        public Dictionary<string, int> gndEvents { get; set; }
        public Dictionary<string, int> twrEvents { get; set; }
        public Dictionary<string, int> appEvents { get; set; }
        public Dictionary<string, int> genEvents { get; set; }
        public Dictionary<string, int> posEvents { get; set; }
        public double modifier { get; set; }

        public Session()
        {
            this.start = DateTime.Now;
            this.complexity = ComplexityLevel.easy;
            this.traffic = TrafficLevel.light;
            this.weather = WeatherConditions.vfr;
            this.posPoints = 120;
            this.modifier = 1;
            this.reviewed = new List<string>();
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
            this.gndEvents = new Dictionary<string, int>()
            {
                {"wafdof", 0},
                {"squawk", 0},
                {"clnc_late", 0},
                {"clnc_wrong", 0},
                {"taxi", 0}
            };
            this.twrEvents = new Dictionary<string, int>()
            {
                {"landing", 0},
                {"takeoff", 0},
                {"luaw", 0},
                {"turbulence", 0}
            };
            this.appEvents = new Dictionary<string, int>()
            {
                {"clnc", 0},
                {"mva", 0},
                {"sop", 0},
                {"fix", 0},
                {"final", 0}
            };
            this.genEvents = new Dictionary<string, int>()
            {
                {"slow", 0},
                {"separation", 0},
                {"phraseology", 0},
                {"near", 0},
                {"incident", 0},
                {"readback", 0},
                {"coordination", 0}
            };
            this.posEvents = new Dictionary<string, int>()
            {
                {"flow", 0},
                {"situational", 0},
                {"phraseology", 0},
                {"separation", 0},
                {"pointouts", 0},
                {"sequencing", 0}
            };

        }

        public int getTime()
        {
            return (int)DateTime.Now.Subtract(this.start).TotalMinutes;
        }

        public void complete(string[] ins, string[] student, string[] ratings)
        {
            //ins, student, ratings, time, conditions, ppoints, npoints
            //public List<string[]> info;
            //public List<string> reviewed;
            //gnd,twr,app,gen,pos,combos
            //public List<Dictionary<string, int>> events
            this.finish = DateTime.Now;
            double delta = this.finish.Subtract(this.start).TotalMinutes;
            List<Dictionary<string, int>> e = new List<Dictionary<string, int>>();
            e.Add(this.gndEvents); e.Add(this.twrEvents); e.Add(this.appEvents); e.Add(this.genEvents); e.Add(this.posEvents); e.Add(this.combos);
            List<string[]> info = new List<string[]>();
            string[] t = new string[1]; t[0] = delta.ToString();
            info.Add(ins); info.Add(student); info.Add(ratings); info.Add(t);
            Report r = new Report(info, this.reviewed, e);
        }

        public double updateScore()
        {
            switch (this.complexity) 
            {
                case ComplexityLevel.easy:
                    break;
                case ComplexityLevel.very_easy:
                    break;
                case ComplexityLevel.moderate:
                    this.modifier -= 0.05;
                    break;
                case ComplexityLevel.hard:
                    this.modifier -= 0.1;
                    break;
                case ComplexityLevel.very_hard:
                    this.modifier -= 0.15;
                    break;
            }
            switch (this.weather)
            {
                case WeatherConditions.vfr:
                    break;
                case WeatherConditions.mvfr:
                    this.modifier -= 0.03;
                    break;
                case WeatherConditions.ifr:
                    this.modifier -= 0.05;
                    break;
            }

            switch (this.traffic)
            {
                case TrafficLevel.light:
                    break;
                case TrafficLevel.moderate:
                    this.modifier -= 0.05;
                    break;
                case TrafficLevel.heavy:
                    this.modifier -= 0.1;
                    break;
            }
            this.posPoints = calcPosPoints() + this.combos.Values.Sum();
            this.negPoints = calcNegPoints();
            this.score = (this.posPoints - (this.negPoints * this.modifier)) / 120.0;
            return this.score >= 1 ? 1 : this.score;
        }

        public bool checkFail()
        {
            if (this.score < 0.75) { return true; }
            if (this.twrEvents["luaw"] > 3) { return true; }
            if (this.appEvents["mva"] > 3) { return true; }
            if (this.genEvents["separation"] > 3) { return true; }
            if (this.genEvents["near"] > 2) { return true; }
            if (this.genEvents["incident"] > 1) { return true; }
            return false;
        }

        public int calcMarkups()
        {
            return this.posEvents.Values.Sum();
        }

        public int calcMarkdowns()
        {
            return this.gndEvents.Values.Sum() + this.twrEvents.Values.Sum() + this.appEvents.Values.Sum() + this.genEvents.Values.Sum();
        }

        public int calcNegPoints()
        {
            int n = 0;
            n += this.gndEvents["wafdof"] * 2;
            n += this.gndEvents["squawk"] * 2;
            n += this.gndEvents["clnc_late"] * 1;
            n += this.gndEvents["clnc_wrong"] * 2;
            n += this.gndEvents["taxi"] * 2;

            n += this.twrEvents["landing"] * 2;
            n += this.twrEvents["takeoff"] * 2;
            n += this.twrEvents["luaw"] * 4;
            n += this.twrEvents["turbulence"] * 3;

            n += this.appEvents["clnc"] * 3;
            n += this.appEvents["mva"] * 4;
            n += this.appEvents["sop"] * 2;
            n += this.appEvents["fix"] * 2;
            n += this.appEvents["final"] * 2;

            n += this.genEvents["slow"] * 2;
            n += this.genEvents["separation"] * 3;
            n += this.genEvents["phraseology"] * 2;
            n += this.genEvents["near"] * 4;
            n += this.genEvents["incident"] * 6;
            n += this.genEvents["coordination"] * 2;
            n += this.genEvents["readback"] * 1;

            return n;
        }

        public int calcPosPoints()
        {
            int n = 0;
            n += this.posEvents["flow"] * 2;
            n += this.posEvents["situational"] * 4;
            n += this.posEvents["phraseology"] * 2;
            n += this.posEvents["separation"] * 3;
            n += this.posEvents["pointouts"] * 2;
            n += this.posEvents["sequencing"] * 3;

            return n;
        }
    }
}
