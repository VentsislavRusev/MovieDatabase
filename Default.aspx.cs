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

namespace MovieDB
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// Method to call XSLT for reformatting XML
			//TransformUsingXslt();
		}

		#region XSLT Transform
		public void TransformUsingXslt()
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