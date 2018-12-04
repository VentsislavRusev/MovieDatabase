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

			System.Threading.Timer Timer = new System.Threading.Timer(DayTimerCall, null, 0, days);
		}

		#region method called every 7 days
		private static void DayTimerCall(object o)
		{
			//System.Diagnostics.Debug.Write(WRITE TO THE OUTPUT);

			TransformUsingXslt();

			XmlManipulating manipulate = new XmlManipulating();
			manipulate.ReadDataToXMLFromOmdb();
		}
		#endregion

		#region XSLT Transform
		public static void TransformUsingXslt()
		{
			
			string sourcefile = Path.Combine(HttpRuntime.AppDomainAppPath, "xml/Project4.xml");
			string xsltfile = Path.Combine(HttpRuntime.AppDomainAppPath, "xslt/commercial.xslt");
			string destination = Path.Combine(HttpRuntime.AppDomainAppPath, "xml/commercials.xml"); 

			TransformXslt transform = new TransformXslt(sourcefile, xsltfile, destination);
			transform.TransformXml();
		}
		#endregion
	}
}
