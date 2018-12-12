using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.IO;
using System.Xml;

namespace MovieDB
{
	public class XmlManipulating
	{
		public void ReadDataToXMLFromOmdb()
		{
			//string ConnString = @"data source = DESKTOP-S37VJ5K\MSSQLSERVER01; integrated security = true; database = MovieDB";
			string connString = @"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB";
			//string connString = @"data source = DESKTOP-DJ7RAJ3; integrated security = true; database = MovieDB";

			SqlConnection conn = new SqlConnection(connString);
			SqlCommand cmd = new SqlCommand
			{
				Connection = conn,
				CommandType = CommandType.Text,
				CommandText = "SELECT MovieName FROM Movies"
			};
			SqlDataAdapter da = null;
			DataTable dt = new DataTable();


			da = new SqlDataAdapter()
			{
				SelectCommand = cmd
			};

			da.Fill(dt);
			WebClient client = new WebClient();

			foreach (DataRow row in dt.Rows)
			{
				string title = "";
				string actors = "";
				string poster = "";
				string rating = "";
				string plot = "";
				title = row["MovieName"].ToString();
				string reformattedName = title.Replace(" ", "%20");

				string url = "http://www.omdbapi.com/?t=" + reformattedName + "&r=xml&apikey=" + ApiTokens.omdb;
				string result = client.DownloadString(url);

				//File.WriteAllText(Server.MapPath("~/xml/Movies.xml"), result);
				XmlDocument xmlD = new XmlDocument();
				xmlD.LoadXml(result);


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
				}
				else
				{
					title = "Nothing found";
				}

				// Take each movie property and save in the DB	
				UpdateDbWithDataFromXml(connString, dt, title, poster, plot, actors, rating);
			}
		}

		public void UpdateDbWithDataFromXml(string connString, DataTable dt, string title, string poster, string plot, string actors, string rating)
		{
			SqlConnection conn = new SqlConnection(connString);

			SqlDataAdapter da = new SqlDataAdapter();
			//string sql = "UPDATE Movies SET [PosterUrl] = NULL, [Resume] = NULL, [Actors] = NULL, [Rating] = NULL WHERE [MovieName] = @title";
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
			updateCmd.Parameters.AddWithValue("@title", title);

			da.UpdateCommand = updateCmd;
			da.UpdateCommand.ExecuteNonQuery();
			//da.Update(dt);

			conn.Close();
		}
	}
}