using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Part_Number_Info.Control.PartNumberRegex
{
	class RegexPartSupply
	{
		public static readonly Regex Check = new Regex(regexString);
		public static readonly string[] Groups = new string[] { groupType, group01, group02, group03, group04 };

		const string regexString = @"(?'Full'\b(?'Type'(?>[A-Z]{1})(?>(?>[A-Z]{2})|(?>[ ]){0,2}){0,1})(?>[ -.]{0,1})(?'G1'(?'prtcat'[A-Z0-9]{1})(?'prtsub'\d{2}))(?>[ -.]{0,1})(?'G2'\d{3})(?>[ -.]{0,1})(?'G3'[A-Z0-9]{1,2}){0,1}(?'G4'(?>[ -.]{0,1})[A-Z0-9]{3}){0,1}\b)";
		//@"(?'Full'(?'Type'^[A-Z]{1,3}){1}(?>[ ]{1,2}|[ -.]{0,1})(?=\d{3})(?>[ ]{1,2}|[ -.]{0,1})(?'G1'\w{3}){1}(?>[ ]{1,2}|[ -.]{0,1})(?'G2'\w{3}){1}(?>[ ]{1,2}|[ -.]{0,1})(?'G3'\w{1,2}){0,1}(?>[ ]{1,2}|[ -.]{0,1})(?'G4'\w{3}){0,1})"; 
		//@"(?'Type'^[a-zA-Z]{1,3})\s{0,2}?(?'No'(?'G1'(?<=[a-zA-Z])[\w]{1,3})(?'G2'(?<=[A-Z0-9])[A-Z0-9]{1,3})(?'G3'(?<=[\w])[\w]{1,2})?(?'G4'(?<=[\w])[\w]{0,3}){0,1})"; 
		//@"(?'Type'^[a-zA-Z]{1,3})\s*?(?'No'(?'G1'(?<=[a-zA-Z])[\w]{1,3})(?'G2'(?<=[\w]3)[\w]{1,3})?(?'G3'(?<=[\w]6)[\w]{1,3})?)?";
		public const string groupType = "Type";
		public const string group01 = "G1";
		public const string group02 = "G2";
		public const string group03 = "G3";
		public const string group04 = "G4";
	}
}
