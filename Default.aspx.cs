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
			#region XSLT
			// if xml uses a namespace xslt must refer to this namespace
			string sourcefile = HttpContext.Current.Server.MapPath("xml/Project4.xml");
			string xslfile = HttpContext.Current.Server.MapPath("xslt/commercial.xslt");
			string destinationFile = HttpContext.Current.Server.MapPath("xml/commercials.xml");

			//xml
			FileStream fs = new FileStream(destinationFile, FileMode.Create);
			XslCompiledTransform xct = new XslCompiledTransform();
			xct.Load(xslfile);
			//xml
			xct.Transform(sourcefile, null, fs);
			fs.Close();
			#endregion
		}
	}
}