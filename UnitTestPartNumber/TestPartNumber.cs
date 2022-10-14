using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Part_Number_Info;
using System.Diagnostics;

namespace UnitTestPartNumber
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void Test_Supply_Woodruff_Key()
		{
			string _pn = "N012703";
			string _pnDot = "N  .012.703";

			Part_Number pn = new Part_Number(_pn);
			Assert.AreEqual(_pnDot,pn.Text_Dotted);
		}
		[TestMethod]
		public void Test_Supply_Cleaning_Chemical()
		{
			string _pn = "ZVW902101";
			string _pnDot = "ZVW.902.101";

			Part_Number pn = new Part_Number(_pn);
			Assert.AreEqual(_pnDot, pn.Text_Dotted);
			Debug.WriteLine(pn.Text_Dotted);
		}
		[TestMethod]
		public void Test_Supply_Seal_Ring()
		{
			string _pn = "WHT010054";
			string _pnDot = "WHT.010.054";

			Part_Number pn = new Part_Number(_pn);
			Assert.AreEqual(_pnDot, pn.Text_Dotted);
		}
		[TestMethod]
		public void Test_Std_Hose()
		{
			string _pn = "4H0121445";
			string _pnDot = "4H0.121.445";

			Part_Number pn = new Part_Number(_pn);
			Assert.AreEqual(_pnDot, pn.Text_Dotted);
		}
		[TestMethod]
		public void Test_Std_Relay()
		{
			string _pn = "021919101";
			string _pnDot = "021.919.101";

			Part_Number pn = new Part_Number(_pn);
			Assert.AreEqual(_pnDot, pn.Text_Dotted);
		}
		[TestMethod]
		public void Test_Equal_PartNumber_True()
		{
			string _pn = "021919101";	   

			Part_Number pn = new Part_Number(_pn);
			Assert.IsTrue(pn.Equals(pn));
		}
		[TestMethod]
		public void Test_Equal_PartNumber_Text_True()
		{
			string _pn = "021919101";

			Part_Number pn = new Part_Number(_pn);
			Assert.IsTrue(pn.Equals(_pn));
		}
		[TestMethod]
		public void Test_Equal_PartNumber_Text_False()
		{
			string _pn = "4H0121445";

			Part_Number pn = new Part_Number(_pn);
			Assert.IsTrue(pn.Equals(_pn));
		}
		[TestMethod]
		public void Test_Equal_PartNumber_PartNumberInfo_True()
		{
			string _pn = "021919101";

			Part_Number pn = new Part_Number(_pn);
			PartNumberInfo pni = new PartNumberInfo(_pn);
			Assert.IsTrue(pn.Equals(pni));
		}
		[TestMethod]
		public void Test_Std_Ver_Color()
		{
			string _pn = "4G0035503JGRU";
			string _pnDash = "4G0-035-503-J-GRU";

			Part_Number pn = new Part_Number(_pn);
			Assert.AreEqual(_pnDash, pn.Text_Dashed);
			Debug.WriteLine(pn.Text_Dashed);
		}
		[TestMethod]
		public void Test_Bulk()
		{
			string[] _test = new string[] {
				"WHT-003-856-A"
				,"8K0-837-020-G-1GK"
				,"4L0-035-503-N-GRU"
				,"8U0-857-562-61S"
				,"4G8-898-283-B-DL2"
				,"N-017-753-5"
				,"8R0-959-829-6PS"
				,"4L1-864-207-N-12T"
				,"N-104-455-02"
				,"4G0-919-565-6PS"
				,"N-017-753-5"
				,"4G0-857-552-A-HF6"
				,"8T0-881-969-B-XUM"
				,"4L0-881-405-M-UQT"
				,"4G0-857-551-A-HF6"
				,"8K0-959-613-A-ET1"
				,"8V3-867-409-A-RI2"
				,"4G5-827-113-9B9"
				,"8F0-868-432-1CT"
				,"4G0-035-503-J-GRU"
				,"4G8-898-173-4PK"
				,"8U0-857-562-J50"
				,"N-017-752-2"
				,"443-857-561-H-4PK"
				,"443-857-847-B-4PK"
				,"8R1-857-410-L-01C"
				,"N-017-752-2"
				,"4G0-035-503-J-GRU"
				,"4F0-837-220-AG-INF"
				,"4G0-419-091-T-INU"
				,"4H1-061-221-041"
				,"N-017-725-2"
				,"N-017-752-2"
				,"8R0-857-607-H-EP5"
				,"4L1-864-207-N-40X"
				,"8K0-857-755-G-01C"
				,"N-105-915-01"
				,"N-105-915-01"
				,"8K0-867-409-L-AR8"
				,"4L0-419-091-AE-1KT"
				,"4F0-959-851-F-5PR"
				,"8U0-857-562-A-QE2"
				,"N-105-915-01"
				,"8U0-857-562-A-4PK"
				,"N-103-201-02"

			};

			bool _out = true;
			Part_Number pn;
			string[] _textDebug = new string[3];

			for (int i = 0; i < _test.Length; i++)
			{
				pn = new Part_Number(_test[i].Replace("-",""));


				if (!pn.Equals(_test[i]))
				{
					_out = false;
					_textDebug[0] = "Part_Numbers ERROR:    ";	
				}
				else
				{
					_textDebug[0] = "Part_Numbers Match:    ";
				}

				_textDebug[1] = pn.Text_Dashed.PadLeft(18,' ');
				_textDebug[2] = "".PadLeft(_textDebug[0].Length,' ')+_test[i].PadLeft(18, ' ');

				Debug.WriteLine($""
					+$"{_textDebug[0]}{_textDebug[1]}"
					+$"\n{_textDebug[2]}");
			}
			Assert.IsTrue(_out);	
		}
	}
}
