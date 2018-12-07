using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace MovieDB
{
	public class Commercials
	{
		private static string Xmlfile { get; set; }
		private static string Xmlfield { get; set; }

		public Commercials(string xml, string fieldOne)
		{
			Xmlfile = xml;
			Xmlfield = fieldOne;
		}

		public string[] CommercialInfo()
		{
			XElement root = XElement.Load(Xmlfile);
			string[] descriptions = root.Descendants(Xmlfield).Select(element => element.Value).ToArray();

			return descriptions;
		}
	}
}
