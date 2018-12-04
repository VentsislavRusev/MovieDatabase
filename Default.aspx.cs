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
