using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Part_Number_Info.Control.PartNumberRegex
{
	class RegexPartStandard
	{
		public static readonly Regex Check = new Regex(regexString);
		public static readonly string[] Groups = new string[] { groupType, group01, group02, groupExtra};
		const string regexString = @"(?'Full'(?'Type'^\d{1}[\w]{2})(?#Junk)(?>[ -.]{0,1})(?'G1'(?#Group Main)(?'MG'\w{1})(?#Group Sub)(?'SG'\w{2}))(?#Junk)(?>[ -.]{0,1})(?#Group 2)(?'G2'\w{3})(?#Junk)(?>[ -.]{0,1}[ ]{0,1})(?#G3)(?'Extra'[\w]{1,2}(?>[ -.]{0,1}[ ]{0,1})[\w]{3}|[\w]{3}|[\w]{1,2}}){0,1})";
		//@"(?'Full'(?'Type'^\d{1}[\w]{2})(?#Junk)(?>[ -.]{0,1})(?'G1'(?#Group Main)(?'MG'\w{1})(?#Group Sub)(?'SG'\w{2}))(?#Junk)(?>[ -.]{0,1})(?#Group 2)(?'G2'\w{3})(?#Junk)(?>[ -.]{0,1})(?#G3)(?'Extra'[\w]{1,2}[ -.]{0,1}[\w]{3}|[\w]{1,2}|[\w]{3}}){0,1})";
		//@"(?'Full'(?'Type'^[\d]{1}[\w]{2})(?#Grouping Main)(?<=(?>[\d]{1}[\w]{2}))(?'MG'[\w]{1}){0,1}(?#Grouping Sub)(?>(?<=(?>[\d]{1}[\w]{3}))(?'SG'[\w]{1,2})){0,1}(?#Group 3)(?>(?<=[\d]{1}[\w]{5})(?'No'(?<=[\w]{3})[\w]{3})){0,1}(?#Group 3)(?>(?<=[\d]{1}[\w]{8})(?'Extra'[\w]{1,5})){0,1})";
		internal const string groupType = "Type";
		internal const string groupMain = "MG";
		internal const string groupSub = "SG";
		internal const string group01 = "G1";
		internal const string group02 = "G2";
		internal const string groupExtra = "Extra";


	}
}
