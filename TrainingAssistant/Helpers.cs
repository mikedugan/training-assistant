using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingAssistant
{
    class Helpers
    {
        public static string ToUppercase(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }           

            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
