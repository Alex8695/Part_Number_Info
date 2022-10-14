using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNG = Part_Number_Info.Model.PartNumberGrouping;

namespace Part_Number_Info
{
    public class PartNumberInfo
    {
		//Reference: https://blog.europaparts.com/audi-vw-part-numbers-demystified/


		#region OBJECT PUBLIC

		/// <summary>
		/// N  .123.456
		/// </summary>
		public string Text_Dotted { get { return partNumberFormated("."); } }


		/// <summary>
		/// N  -123-456
		/// </summary>
		public string Text_Dashed { get { return partNumberFormated("-"); } }
		/// <summary>
		/// N  123 456
		/// </summary>

		public string Text_Space { get { return partNumberFormated(" "); } }

		/// <summary>
		/// N123456
		/// </summary>
		public string Text { get { return partNumberFormated(""); } }


		#endregion

		#region OBJECT INTERNAL


		#endregion

		#region OBJECT PROTECTED


		#endregion

		#region OBJECT PRIVATE

		private PNG png;
		


		#endregion

		#region METHOOD PRIVATE

		private bool isValid()
		{

			return (png.Group01 == string.Empty)
				?false
				:char.IsLetterOrDigit(png.Group01[0]);
		}

		string partNumberFormated(string delimeter)
		{
			string _out = string.Empty;
			string[] _strings = new string[] { };

			if (isValid())
			{
				_out =
					string.Join(
						separator: delimeter
						, value: png.Groups.Where(w => w != string.Empty).ToArray());
			}			 
			return _out;
		}

		#endregion

		#region METHOOD PROTECTED


		#endregion

		#region METHOOD INTERNAL


		#endregion

		#region METHOOD PUBLIC

		public PartNumberInfo() {
			png =
				new PNG();
		}
		public PartNumberInfo(string from_text)
		{
			png =
				Control.Part_Number_Magic.Text_To_Part_Number_Grouping(
					text: from_text);
		}


		public override bool Equals(object obj)
		{
			PartNumberInfo _pnIn;
			Type _type;

			bool _out = false;

			if (obj != null)
			{
				_type = 
					obj.GetType();	 							

				if (_type.IsSubclassOf(typeof(PartNumberInfo)) || _type.UnderlyingSystemType == typeof(PartNumberInfo))
				{
					_pnIn =
						(PartNumberInfo)obj;

					if (_pnIn.png.Equals(this.png))
					{
						_out = true;
					}
				}
				else if (_type == typeof(string))
				{
					_pnIn = 
						new PartNumberInfo(
							obj.ToString());

					if (_pnIn.png.Equals(this.png))
					{
						_out = true;
					}
				}
			}
			return _out;
		}



		#endregion

	}
}
