using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace TrainingAssistant
{
    class Helpers
    {
		public static string Capitalize(string s)
		{
			TextInfo t = new CultureInfo ("en-US", false).TextInfo;
			return t.ToTitleCase (s);
		}
    }
}
