using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REG = Part_Number_Info.Control.PartNumberRegex.RegexPartStandard;

namespace Part_Number_Info.Control.PartNumberParse
{
	class ParseStandard : ParseAbstract
	{
		protected override void on_match()
		{
			if (match.Success)
			{

				for (int i = 0; i < REG.Groups.Length; i++)
				{
					partNumberGroups[i] = match.Groups[REG.Groups[i]].Value.ToString();

				}							

				partNumberColors =
					Control.Code_Modification_Color.parse_modification_and_color_code(
						arg: partNumberGroups[3]);

				partNumberGroups[4] = partNumberColors[0];
				partNumberGroups[5] = partNumberColors[1];

			}



			png =
				new Model.PartNumberGrouping(
					type: partNumberGroups[0]
					, part_group: partNumberGroups[1]
					, part_number: partNumberGroups[2]
					, code_modification: partNumberColors[0]
					, code_color: partNumberColors[1]
					);
		}

		protected override void on_text()
		{
			match =
				REG.Check.Match(
					input_text);
		}

		public ParseStandard()
		{

		}
	}
}
