using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REG = Part_Number_Info.Control.PartNumberRegex.RegexPartSupply;

namespace Part_Number_Info.Control.PartNumberParse
{
	class ParseSupply	 :ParseAbstract
	{

		public ParseSupply() { }

		protected override void on_match()
		{
			if (match.Success)
			{
				for (int i = 0; i < REG.Groups.Length; i++)
				{
					partNumberGroups[i] =
						(match.Groups[REG.Groups[i]].Success)
						? match.Groups[REG.Groups[i]].Value.ToString()
						: string.Empty;

				}
			}

			png =
				new Model.PartNumberGrouping(
					type: partNumberGroups[0]
					, part_group: partNumberGroups[1]
					, part_number: partNumberGroups[2]
					, code_modification: partNumberGroups[3]
					, code_color: partNumberGroups[4]
					);	  							
		}

		protected override void on_text()
		{
			match =
				REG.Check.Match(
					input_text);


		}
	}
}
