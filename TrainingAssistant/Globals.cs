using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingAssistant
{
    public class Globals
    {
        public static string insName {get;set;}
        public static string studentName {get;set;}
        public static string insInitials {get;set;}
        public static string studentInitials {get;set;}
        public static DateTime sessionStart { get; set; }
        public static DateTime sessionFinish { get; set; }
        public static DateTime briefFinish { get; set; }

        public static int studentRating { get; set; }
        public static int studentTraining { get; set; }
        public static string ratingStr { get; set; }
        public static string trainingStr { get; set; }

        public static double getTotalTime()
        {
            return Math.Round(Globals.sessionFinish.Subtract(Globals.sessionStart).TotalMinutes, 2);
        }
    }
}
