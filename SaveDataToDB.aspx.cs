using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.IO;
using System.Xml;

namespace MovieDB
{
	public partial class test : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			ReadDataToJSON();
		}

		public void ReadDataToJSON()
		{
			//string ConnString = @"data source = DESKTOP-S37VJ5K\MSSQLSERVER01; integrated security = true; database = MovieDB";
			string ConnString = @"data source = DESKTOP-DJ7RAJ3; integrated security = true; database = MovieDB";
			SqlConnection conn = new SqlConnection(ConnString);
			SqlCommand cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = "SELECT MovieName FROM Movies"
			};
			SqlDataAdapter da = null;
			DataTable dt = new DataTable();

			try
			{
				da = new SqlDataAdapter()
				{
					SelectCommand = cmd
				};

				da.Fill(dt);
				WebClient client = new WebClient();

				foreach (DataRow row in dt.Rows)
				{
					msg_lb.Text = row["MovieName"].ToString();
					string reformattedName = msg_lb.Text.Replace(" ", "%20");

					string url = "http://www.omdbapi.com/?t=" + reformattedName + "&r=xml&apikey=" + Omdb.token;
					string result = client.DownloadString(url);

					File.WriteAllText(Server.MapPath("~/xml/Movies.xml"), result);
					XmlDocument xmlD = new XmlDocument();
					xmlD.LoadXml(result);

					string actors = "";
					string poster = "";
					string rating = "";
					string plot = "";

					if (xmlD.SelectSingleNode("/root/@response").InnerText == "True")
					{
						XmlNodeList xmlNodes = xmlD.SelectNodes("/root/movie");
						foreach (XmlNode node in xmlNodes)
						{
							actors = node.SelectSingleNode("@actors").InnerText;
							poster = node.SelectSingleNode("@poster").InnerText;
							rating = node.SelectSingleNode("@imdbRating").InnerText;
							plot = node.SelectSingleNode("@plot").InnerText;
							break;

						}
						actors_lb.Text = actors;
						poster_lb.Text = poster;
						rating_lb.Text = rating;
						plot_lb.Text = plot;
					}
					else
					{
						msg_lb.Text = "Nothing found";
					}

					break;
					// Take each movie property and save in the DB		

				}
			}
			catch (Exception ex)
			{
				msg_lb.Text = ex.Message;
			}
			finally
			{
				conn.Close();
			}
		}	
	}
}