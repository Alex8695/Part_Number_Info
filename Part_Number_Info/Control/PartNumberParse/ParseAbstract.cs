using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PNG = Part_Number_Info.Model.PartNumberGrouping;

namespace Part_Number_Info.Control.PartNumberParse
{
	abstract class ParseAbstract
	{					   
		public PNG Part_Number_Grouping { get { return png; } }


		protected string[] partNumberGroups;
		protected string[] partNumberColors;
		protected string input_text;
		protected Match match;
		protected PNG png;

		protected abstract void on_match();
		protected abstract void on_text();
																		 

		public bool Parse(string from_text)
		{
			input_text =
				Utility_Text.Text_Validate.Get_Valid_Text(
					txt: from_text);

			partNumberColors =
				new string[2];

			partNumberGroups =
				new string[6];

			on_text();

			on_match();

			return png.Group01 != string.Empty;
		}
		

		public ParseAbstract() { }
	}
}
