using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingAssistant.models
{
    public class Report
    {
        //conditions, ppoints, npoints
        public List<string> reviewed;
        //gnd,twr,app,gen,pos,combos
        public List<Dictionary<string, int>> events;
        public string dComment;
        public string sComment;
        public string reviewItems;
        public string log;
        protected Session sesh;
        public Report(List<string> reviewed, List<Dictionary<string, int>> events, Session sesh)
        {
            this.reviewed = reviewed;
            this.events = events;
            this.dComment = "";
            this.sComment = "";
            this.sesh = sesh;
            this.reviewItems = "";
            generateCbReview();
        }

        public string generateDatabaseComment()
        {
            return generateDatabaseHeader() + "\r\n" + this.log + "\r\n" + "\r\n" + generateEventLog();
        }

        public string generateStudentComment()
        {
            return generateStudentHeader() + "\r\n" + generateEventLog();
        }

        public string generateReport()
        {
            string report = generateSummary();
            report += generateDatabaseComment();
            report += generateStudentComment();
            report += this.log + "\r\n" + this.reviewItems;

            return report;
        }

        public string generateHtmlReport()
        {
            return "";
        }

        protected string generateDatabaseHeader()
        {
            string h = "Spent " + Globals.getTotalTime().ToString() + " minutes with " + Globals.studentName + " training on " + Globals.trainingStr + ". " + Globals.getBriefTime().ToString() + " minutes reviewing, " + Globals.getLiveTime().ToString() + " minutes training.\r\n";
            foreach(string s in this.reviewed)
            {
                h += s + "\r\n";
            }
            return h;

        }

        protected string generateStudentHeader()
        {
            string h = Globals.studentInitials + ", in this session we spent " + Globals.getBriefTime().ToString() + " minutes reviewing and " + Globals.getLiveTime().ToString() + " minutes training on " + Globals.trainingStr + ".\r\n";
            string ri;
            if (this.reviewItems == "")
            {
                ri = "No items were marked for review.\r\n";
            }
            else
            {
                ri = "You should review " + this.reviewItems + "check the syllabi for reference materials.\r\n";
            }
            h += ri;
            if (this.sesh.ots == 2) { h += "\r\nCongratulations, OTS passed!\r\n"; }
            return h;
        }

        protected void generateCbReview()
        {
            switch (this.events[5]["brief"])
            {
                case 10: this.log += "Controller brief - Satisfactory\r\n"; break;
                case 5: this.log += "Controller brief - Need Improvement\r\n"; this.reviewItems += "controller briefing, "; break;
                case 0: this.log += "Controller brief - Unsatisfactory\r\n"; this.reviewItems += "controller briefing, "; break;
            }
            switch (this.events[5]["runway"])
            {
                case 10: this.log += "Runway selection - Satisfactory\r\n"; break;
                case 5: this.log += "Runway selection - Need Improvement\r\n"; this.reviewItems += "runway selection, "; break;
                case 0: this.log += "Runway selection - Unsatisfactory\r\n"; this.reviewItems += "runway selection, "; break;
            }
            switch (this.events[5]["weather"])
            {
                case 10: this.log += "Weather awareness - Satisfactory\r\n"; break;
                case 5: this.log += "Weather awareness - Need Improvement\r\n"; this.reviewItems += "weather and ATIS/METARs, "; break;
                case 0: this.log += "Weather awareness - Unsatisfactory\r\n"; this.reviewItems += "weather and ATIS/METARs, "; break;
            }
            switch (this.events[5]["coordination"])
            {
                case 10: this.log += "Controller coordination - Satisfactory\r\n"; break;
                case 5: this.log += "Controller coordination - Need Improvement\r\n"; this.reviewItems += "controller coordination, "; break;
                case 0: this.log += "Controller coordination - Unsatisfactory\r\n"; this.reviewItems += "controller coordination, "; break;
            }
            switch (this.events[5]["flow"])
            {
                case 10: this.log += "Traffic flow - Satisfactory\r\n"; break;
                case 5: this.log += "Traffic flow - Need Improvement\r\n"; this.reviewItems += "traffic flow management, "; break;
                case 0: this.log += "Traffic flow - Unsatisfactory\r\n"; this.reviewItems += "traffic flow management, "; break;
            }
            switch (this.events[5]["identity"])
            {
                case 10: this.log += "Aircraft identity - Satisfactory\r\n"; break;
                case 5: this.log += "Aircraft identity - Need Improvement\r\n"; this.reviewItems += "maintaining aircraft identity, "; break;
                case 0: this.log += "Aircraft identity - Unsatisfactory\r\n"; this.reviewItems += "maintaining aircraft identity, "; break;
            }
            switch (this.events[5]["separation"])
            {
                case 10: this.log += "Aircraft separation - Satisfactory\r\n"; break;
                case 5: this.log += "Aircraft separation - Need Improvement\r\n"; this.reviewItems += "maintaining minimum separation, "; break;
                case 0: this.log += "Aircraft separation - Unsatisfactory\r\n"; this.reviewItems += "maintaining minimum separation, "; break;
            }
            switch (this.events[5]["pointouts"])
            {
                case 10: this.log += "Traffic pointouts - Satisfactory\r\n"; break;
                case 5: this.log += "Traffic pointouts - Need Improvement\r\n"; this.reviewItems += "providing traffic and safety pointouts, "; break;
                case 0: this.log += "Traffic pointouts - Unsatisfactory\r\n"; this.reviewItems += "providing traffic and safety pointouts, "; break;
            }
            switch (this.events[5]["airspace"])
            {
                case 10: this.log += "Airspace knowledge - Satisfactory\r\n"; break;
                case 5: this.log += "Airspace knowledge - Need Improvement\r\n"; this.reviewItems += "general airspace knowledge, "; break;
                case 0: this.log += "Airspace knowledge - Unsatisfactory\r\n"; this.reviewItems += "general airspace knowledge, "; break;
            }
            switch (this.events[5]["loa"])
            {
                case 10: this.log += "LOA and SOP knowledge - Satisfactory\r\n"; break;
                case 5: this.log += "LOA and SOP knowledge - Need Improvement\r\n"; this.reviewItems += "LOA and SOP directives, "; break;
                case 0: this.log += "LOA and SOP knowledge - Unsatisfactory\r\n"; this.reviewItems += "LOA and SOP directives, "; break;
            }
            switch (this.events[5]["phraseology"])
            {
                case 10: this.log += "Phraseology - Satisfactory\r\n"; break;
                case 5: this.log += "Phraseology - Need Improvement\r\n"; this.reviewItems += "phraseology, "; break;
                case 0: this.log += "Phraseology - Unsatisfactory\r\n"; this.reviewItems += "phraseology, "; break;
            }
            switch (this.events[5]["priority"])
            {
                case 10: this.log += "Duty priority knowledge - Satisfactory\r\n"; break;
                case 5: this.log += "Duty priority knowledge - Need Improvement\r\n"; this.reviewItems += "duty priorities, "; break;
                case 0: this.log += "Duty priority knowledge - Unsatisfactory\r\n"; this.reviewItems += "duty priorities, "; break;
            }
        }
        
        public string generateSummary()
        {
            string student = Globals.studentName + " (" + Globals.studentInitials + ")";
            string ins = Globals.insName + " (" + Globals.insInitials + ")";
            //ins, student, ratings, time, conditions, ppoints, npoints
            string summary = "Training session on " + DateTime.Now.ToString() + "\r\n";
            summary += "Instructor: " + ins + " Student: " + student + "\r\n";
            summary += "Student is certified for " + Globals.ratingStr + " and is training for " + Globals.trainingStr + "\r\n";
            summary += "Total training session time: " + Globals.getTotalTime().ToString() + " minutes\r\n";
            string pass = this.sesh.checkFail() ? "fail" : "pass";
            summary += "The total score was " + Math.Round((this.sesh.score * 100),2) + "%. The program recommend that this student " + pass + " the session.\r\n";
            string complexity = this.sesh.complexity.ToString();
            complexity = Helpers.Capitalize(complexity.Replace('_', ' '));
            summary += "Weather: " + this.sesh.weather.ToString().ToUpper() + "\r\nComplexity: " + complexity + "\r\nTraffic: " + this.sesh.traffic.ToString() + "\r\n";
            if (this.sesh.ots == 0) { summary += "This session was not an OTS\r\n"; }
            else if (this.sesh.ots == 1) { summary += "This OTS session was failed.\r\n"; }
            else summary += "This OTS session was passed.\r\n";
            return summary;
        }

        protected string generateEventLog()
        {
            Dictionary<string, int> gEvents = this.events[0];
            Dictionary<string, int> tEvents = this.events[1];
            Dictionary<string, int> aEvents = this.events[2];
            Dictionary<string, int> nEvents = this.events[3];
            Dictionary<string, int> pEvents = this.events[4];
            gEvents = gEvents.Where(x => x.Value > 0).ToDictionary(x => x.Key, x => x.Value);
            tEvents = tEvents.Where(x => x.Value > 0).ToDictionary(x => x.Key, x => x.Value);
            aEvents = aEvents.Where(x => x.Value > 0).ToDictionary(x => x.Key, x => x.Value);
            nEvents = nEvents.Where(x => x.Value > 0).ToDictionary(x => x.Key, x => x.Value);
            pEvents = pEvents.Where(x => x.Value > 0).ToDictionary(x => x.Key, x => x.Value);
            string log = "";
            if (gEvents.Count == 0 && aEvents.Count == 0 && tEvents.Count == 0 && nEvents.Count == 0)
            {
                log += "No markdowns were returned from the training session.\r\n";
            }
            else
            {
                log += "The following markdowns were returned from the training session:\r\n";

                log += gEvents.ContainsKey("wafdof") ? gEvents["wafdof"] + " wrong altitude for direction of flight errors\r\n" : "";
                log += gEvents.ContainsKey("squawk") ? gEvents["squawk"] + " no/incorrect squawk codes assigned\r\n" : "";
                log += gEvents.ContainsKey("clnc_late") ? gEvents["clnc_late"] + " late or delayed clearances\r\n" : "";
                log += gEvents.ContainsKey("clnc_wrong") ? gEvents["clnc_wrong"] + " incorrect clearances\r\n" : "";
                log += gEvents.ContainsKey("taxi") ? gEvents["taxi"] + " incorrect taxi instructions\r\n" : "";

                log += tEvents.ContainsKey("landing") ? tEvents["landing"] + " incorrect landing clearances\r\n" : "";
                log += tEvents.ContainsKey("takeoff") ? tEvents["takeoff"] + " incorrect takeoff clearances\r\n" : "";
                log += tEvents.ContainsKey("luaw") ? tEvents["luaw"] + " landing clearances given while aircraft was LUAW\r\n" : "";
                log += tEvents.ContainsKey("turbulence") ? tEvents["turbulence"] + " missed/incorrect wake turbulence situations\r\n" : "";

                log += aEvents.ContainsKey("clnc") ? aEvents["clnc"] + " incorrect approach clearances\r\n" : "";
                log += aEvents.ContainsKey("mva") ? aEvents["mva"] + " vectors given below minimum vectoring altitude\r\n" : "";
                log += aEvents.ContainsKey("sop") ? aEvents["sop"] + " SOP or LOA violations\r\n" : "";
                log += aEvents.ContainsKey("fix") ? aEvents["fix"] + " incorrect or invalid fixes given\r\n" : "";
                log += aEvents.ContainsKey("final") ? aEvents["final"] + " late or incorrect final vectors given\r\n" : "";

                log += nEvents.ContainsKey("slow") ? nEvents["slow"] + " instances of generally slow flow of traffic\r\n" : "";
                log += nEvents.ContainsKey("separation") ? nEvents["separation"] + " instances of loss of separation\r\n" : "";
                log += nEvents.ContainsKey("phraseology") ? nEvents["phraseology"] + " instances of incorrect phraseology\r\n" : "";
                log += nEvents.ContainsKey("near") ? nEvents["near"] + " near-instances (planes almost crashed)\r\n" : "";
                log += nEvents.ContainsKey("incident") ? nEvents["incident"] + " incidents (planes did crash)\r\n" : "";
                log += nEvents.ContainsKey("readback") ? nEvents["readback"] + " incorrect readbacks\r\n" : "";
                log += nEvents.ContainsKey("coordination") ? nEvents["coordination"] + " missed or incorrect controller coordination\r\n" : "";
            }

            if (this.sesh.customMarkdowns.Count > 0)
            {
                foreach(string s in this.sesh.customMarkdowns)
                {
                    log += "-" + s + "\r\n";
                }
            }

            if (pEvents.Count == 0) { log += "No markups were returned from the session.\r\n"; }
            else
            {
                log += "The following markups were returned from the session:\r\n";
                log += pEvents.ContainsKey("flow") ? pEvents["flow"] + " instances of good traffic flow management\r\n" : "";
                log += pEvents.ContainsKey("situational") ? pEvents["situational"] + " instances of good situational awareness\r\n" : "";
                log += pEvents.ContainsKey("phraseology") ? pEvents["phraseology"] + " instances of good phraseology\r\n" : "";
                log += pEvents.ContainsKey("separation") ? pEvents["separation"] + " instances of good aircraft separation\r\n" : "";
                log += pEvents.ContainsKey("pointouts") ? pEvents["pointouts"] + " instances of good traffic and safety pointouts\r\n" : "";
                log += pEvents.ContainsKey("sequencing") ? pEvents["sequencing"] + " instances of good sequencing and spacing\r\n" : "";
            }
            if(this.sesh.customMarkups.Count > 0)
            {
                foreach(string s in this.sesh.customMarkups)
                {
                    log += "-" + s + "\r\n";
                }
            }
            return log + "\r\n";
        }


    }
}
