using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;
using System.Data;
using System.Net;
using System.Timers;

namespace MovieDB
{
	public partial class Default : System.Web.UI.Page
	{
		// If Needed
		// HttpContext.Current.Server.MapPath("xml / Project4.xml")
		protected void Page_Load(object sender, EventArgs e)
		{
			int days = 1000 * 60 * 60 * 24 * 7;
			var timer = new System.Threading.Timer(DayTimerCall, null, 0, days);
		}
		#region Method being called every 7 day
		private static void DayTimerCall(object o)
		{
			// Test in the Output window
			// System.Diagnostics.Debug.WriteLine(DateTime.Now);

			// Method to call XSLT for reformatting XML
			TransformUsingXslt();

			// manipulate xml and sent to DB
			XmlManipulating manipulate = new XmlManipulating();
			manipulate.ReadDataToXMLFromOmdb();
		}
		#endregion

		#region XSLT Transform
		public static void TransformUsingXslt()
		{
			string sourcefile = HttpContext.Current.Server.MapPath("xml/Project4.xml");
			string xsltfile = HttpContext.Current.Server.MapPath("xslt/commercial.xslt");
			string destination = HttpContext.Current.Server.MapPath("xml/commercials.xml");

			TransformXslt transform = new TransformXslt(sourcefile, xsltfile, destination);
			transform.TransformXml();
		}
		#endregion

	}
}