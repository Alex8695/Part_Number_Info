using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_Number_Info.Control
{
	class Code_Modification_Color
	{
		/// <summary>
		/// 0: Modification Code
		/// 1: Color Code
		/// </summary>
		/// <param name="arg"></param>
		/// <returns></returns>
		public static string[] parse_modification_and_color_code(string arg)
		{
			string _in;
			string[] _inWorking;
			string[] _out;
			int _numberCount;

			// 1 M
			// 2 MM
			// 3 CCC
			// 4 MCCC
			// 5 MMCCC

			_out = new string[2];
			_in = arg;			  
											  
			_numberCount = 
				_in.Length;

			_inWorking = 
				_in.PadRight(5, ' ')
				.Select(S => S.ToString())
				.ToArray();

			switch (_numberCount)
			{
				case 1:
					_out[0] = _inWorking[0];
					_out[1] = string.Empty;
					return _out;

				case 2:
					_out[0] = string.Format("{0}{1}", _inWorking);
					_out[1] = string.Empty;
					return _out;

				case 3:
					_out[0] = string.Empty;
					_out[1] = string.Format("{0}{1}{2}", _inWorking);
					return _out;

				case 4:
					_out[0] = _inWorking[0];
					_out[1] = string.Format("{1}{2}{3}", _inWorking);
					return _out;

				case 5:
					_out[0] = string.Format("{0}{1}", _inWorking);
					_out[1] = string.Format("{2}{3}{4}",
						_inWorking);
					return _out;

				default:
					_out[0] = string.Empty;
					_out[1] = string.Empty;
					return _out;
			}


		}

	}
}
