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
			ReadDataToXML();
		}

		public void ReadDataToXML()
		{
			//string ConnString = @"data source = DESKTOP-S37VJ5K\MSSQLSERVER01; integrated security = true; database = MovieDB";
			string connString = @"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB";
			SqlConnection conn = new SqlConnection(connString);
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

					string url = "http://www.omdbapi.com/?t=" + reformattedName + "&r=xml&apikey=" + ApiTokens.omdb;
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

					// Take each movie property and save in the DB	
					UpdateDbWithDataFromXml(connString, poster, plot, actors, rating);
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
		public void UpdateDbWithDataFromXml(string connString, string poster, string plot, string actors, string rating)
		{
			SqlConnection conn = new SqlConnection(connString);
			SqlDataAdapter da = new SqlDataAdapter();
			//string sql = "UPDATE Movies SET [PosterUrl] = @poster, [Resume] = @plot, [Actors] = @actors, [Rating] = @rating WHERE [MovieName] = @title";
			string sql = "spMovies_UpdateColsInDB";
			SqlCommand updateCmd = new SqlCommand(sql, conn)
			{
				CommandType = CommandType.StoredProcedure
			};

			conn.Open();
			updateCmd.Parameters.AddWithValue("@poster", poster);
			updateCmd.Parameters.AddWithValue("@plot", plot);
			updateCmd.Parameters.AddWithValue("@actors", actors);
			updateCmd.Parameters.AddWithValue("@rating", rating);
			updateCmd.Parameters.AddWithValue("@title", msg_lb.Text);

			da.UpdateCommand = updateCmd;
			da.UpdateCommand.ExecuteNonQuery();

			conn.Close();
		}
	}
}