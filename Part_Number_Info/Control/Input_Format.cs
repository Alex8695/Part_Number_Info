using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXT = Utility_Text.Text_Validate;

namespace Part_Number_Info.Control
{
	class Input_Format
	{
		public static string Format_Input(string input_text)
		{
			string _out;
			string _in;
			char[] _chars;

			_in = 
				TXT.Get_Valid_Text(
					input_text);

			_chars = 
				_in.ToArray();

			_out =
				string.Empty;

			for (int i = 0; i < _chars.Length; i++)
			{

				if (char.IsWhiteSpace(_chars[i]))
				{
					continue;
				}

				if (char.IsDigit(_chars[i]))
				{
					_out = $"{_out}{_chars[i]}";
					continue;
				}

				if (char.IsLetter(_chars[i]))
				{
					_out = $"{_out}{char.ToUpperInvariant(_chars[i])}";
					continue;
				}
			}

			return _out;
		}

	}
}
