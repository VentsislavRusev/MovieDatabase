﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace MovieDB
{
	public class MovieDisplay
	{
		private string MovieName { get; set; }
		private string Poster { get; set; }

		public MovieDisplay(string movie, string poster)
		{
			MovieName = movie;
			Poster = poster;
		}

		public static List<MovieDisplay> MovieInfo()
		{
			List<MovieDisplay> results = new List<MovieDisplay>();

			using (SqlConnection conn = new SqlConnection(@"data source = DESKTOP-DJ7RAJ3; integrated security = true; database = MovieDB"))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("spMovies_GetTitleAndPoster", conn);
				//SqlCommand cmd = new SqlCommand("SELECT MovieName, PosterUrl FROM Movies WHERE MovieName", conn);
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();

				da.Fill(dt);

				foreach (DataRow row in dt.Rows)
				{
					results.Add(new MovieDisplay(row["MovieName"].ToString(), row["PosterUrl"].ToString()));
				}

				#region comments
				//SqlDataReader rdr = cmd.ExecuteReader();

				//if (rdr.HasRows)
				//{
				//	while (rdr.Read())
				//	{
				//		results.Add(new MovieDisplay(rdr.GetString(0), rdr.GetString(1)));
				//	}
				//}
				//else
				//{
				//	System.Diagnostics.Debug.Write("THE LIST IS EMPTY");
				//}
				#endregion
				conn.Close();
			}
			return results;
		}
	}
}