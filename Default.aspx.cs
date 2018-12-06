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
		protected void Page_Load(object sender, EventArgs e)
		{
			// XSLT transform and xml data to DB
			// DayTimerCall();
		}

		#region method called every 7 days
		private static void DayTimerCall()
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
