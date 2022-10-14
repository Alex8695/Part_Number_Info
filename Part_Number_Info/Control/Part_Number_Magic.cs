using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNG = Part_Number_Info.Model.PartNumberGrouping;
using PRT_STD = Part_Number_Info.Control.PartNumberParse.ParseStandard;
using PRT_SUPPLY = Part_Number_Info.Control.PartNumberParse.ParseSupply;

namespace Part_Number_Info.Control
{
	class Part_Number_Magic
	{
		public static PNG Text_To_Part_Number_Grouping(string text)
		{
			PNG _out = null;
			PRT_STD _prtStandard;
			PRT_SUPPLY _prtSupply;
			string _in;		   

			_in =
				Input_Format.Format_Input(
					input_text: text);

			if (_in==string.Empty)
			{
				_out =
					new PNG();

			}
			else
			{

				_prtSupply = new PRT_SUPPLY();

				if (char.IsDigit(_in[0]))
				{
					_prtStandard = 
						new PRT_STD();

					if (!_prtStandard.Parse(_in))
					{
						_prtSupply =
							new PRT_SUPPLY();

						if (_prtSupply.Parse(_in))
						{
							_out =
								_prtSupply.Part_Number_Grouping;
						}	
					}
					else
					{
						_out =
							_prtStandard.Part_Number_Grouping;
					}
				}
				else
				{
					_prtSupply =
						new PRT_SUPPLY();

					if (!_prtSupply.Parse(_in))
					{
						_prtStandard =
							new PRT_STD();

						if (_prtStandard.Parse(_in))
						{
							_out =
								_prtStandard.Part_Number_Grouping;
						}
					}
					else
					{
						_out =
							_prtSupply.Part_Number_Grouping;

					}
				}	  
			}	   

			return (_out==null)?new PNG():_out;
		}
	}
}
