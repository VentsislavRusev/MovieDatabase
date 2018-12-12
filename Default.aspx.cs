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
			PopulateListView(MovieContainer.DisplayTopTen());
			// Show Top 10

			// Show commercial randomly
			Cmc_lb.Text = GenerateRandomCommercial();


			//	private Commercials[] info = commercial.CommercialInfo();
			// XSLT transform and xml data to DB
			//DayTimerCall();
		}

		protected void Filter_btn_Click(object sender, EventArgs e)
		{
			int timespan = TimeSpanList.SelectedIndex;

			if (timespan != 0)
			{
				if (timespan == 1)
				{
					ClearListView();
					PopulateListView(MovieContainer.DisplayTopTenDay());
				}
				else if (timespan == 2)
				{
					ClearListView();
					PopulateListView(MovieContainer.DisplayTopTenWeek());
				}
				else if (timespan == 3)
				{
					ClearListView();
					PopulateListView(MovieContainer.DisplayTopTenMonth());
				}
				else
				{
					return;
				}
			}

		}

		public void PopulateListView(List<MovieContainer> data)
		{
			List<MovieContainer> MovieInfoList = data;

			TopTenMovies_lw.DataSource = MovieInfoList;
			TopTenMovies_lw.DataBind();
		}

		public void ClearListView()
		{
			TopTenMovies_lw.DataSource = null;
			TopTenMovies_lw.DataBind();
		}

		#region random commercial
		public string GenerateRandomCommercial()
		{
			Random rand = new Random();
			int rnd = rand.Next(0, 4);			
			Commercials c = new Commercials(Path.Combine(HttpRuntime.AppDomainAppPath, "xml/commercials.xml"), "company");
			return c.CommercialInfo()[rnd];
		}
		#endregion

		#region method call once a month
		private static void DayTimerCall()
		{
			System.Diagnostics.Debug.Write("WRITE TO THE OUTPUT");
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
