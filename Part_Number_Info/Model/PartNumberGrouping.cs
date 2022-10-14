using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TXT = Utility_Text.Text_Validate;

namespace Part_Number_Info.Model
{
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	class PartNumberGrouping
	{

		/// <summary>
		/// First Charachter Grouping: Type, Model, or Version
		/// </summary>
		public string Group01 { get { return partGrouping[(int)Part_Group_Type.TYPE]; } internal set { partGrouping[(int)Part_Group_Type.TYPE] = value; } }

		/// <summary>
		/// Second Charachter Grouping: Main Group[0] & Sub Group [1,2]
		/// </summary>
		/// 
		public string Group02 { get { return partGrouping[(int)Part_Group_Type.PART_GROUP]; } }

		/// <summary>
		/// Thrid Charachter Grouping: Part Number
		/// </summary>
		/// 
		public string Group03 { get { return partGrouping[(int)Part_Group_Type.PART_NUMBER]; } }


		/// <summary>
		/// Fourth Charachter Grouping - Modification Code
		/// </summary>
		/// 
		public string Group04 { get { return partGrouping[(int)Part_Group_Type.MODIFICATION_CODE]; } }


		/// <summary>
		/// Fifth Charachter Grouping - Color Code
		/// </summary>
		/// 
		public string Group05 { get { return partGrouping[(int)Part_Group_Type.COLOR_CODE]; } }


		public string[] Groups { get { return partGrouping; } }

	

		private string[] partGrouping = new string[5];



		internal PartNumberGrouping(string[] args)
		{
			int _i =
				Math.Min(
					args.Length
					, partGrouping.Length
					);


			for (int i = 0; i < partGrouping.Length; i++)
			{
				partGrouping[i] =
					TXT.Get_Valid_Text(
						txt: (args.Length >= i) ? args[i] : "");
			}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="type">group 01</param>
		/// <param name="part_group">group 02</param>
		/// <param name="part_number">group 03</param>
		/// <param name="code_modification">group 04</param>
		/// <param name="code_color">group 05</param>
		internal PartNumberGrouping(string type, string part_group, string part_number, string code_modification, string code_color)
		{
			partGrouping[(int)Part_Group_Type.TYPE] = TXT.Get_Valid_Text(txt: type).PadRight(3,' ');
			partGrouping[(int)Part_Group_Type.PART_GROUP] = TXT.Get_Valid_Text(txt: part_group);
			partGrouping[(int)Part_Group_Type.PART_NUMBER] = TXT.Get_Valid_Text(txt: part_number);
			partGrouping[(int)Part_Group_Type.MODIFICATION_CODE] = TXT.Get_Valid_Text(txt: code_modification);
			partGrouping[(int)Part_Group_Type.COLOR_CODE] = TXT.Get_Valid_Text(txt: code_color);

		}

		public PartNumberGrouping() { }

		public override bool Equals(object obj)
		{
			bool _out = false;
			PartNumberGrouping _pngIn;

			if ((obj==null)?false:obj.GetType() == typeof(PartNumberGrouping))
			{
				_pngIn =
					(PartNumberGrouping)obj;

				if (_pngIn.Groups.Length == this.Groups.Length)
				{		
					_out = true;

					try
					{
						for (int i = 0; i < this.Groups.Length; i++)
						{
							if (this.Groups[i] != _pngIn.Groups[i])
							{
								_out = false;
							}	
						}
					}
					catch (Exception)
					{
						_out = false;
						Debugger.Break();
					}
				}	
			}

			return _out;
		}

	}
}
