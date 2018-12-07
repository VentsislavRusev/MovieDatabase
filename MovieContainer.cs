using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace MovieDB
{
	public class MovieContainer
	{
		public string MovieName { get; set; }
		public string Poster { get; set; }

		public MovieContainer(string movie, string poster)
		{
			MovieName = movie;
			Poster = poster;
		}

		public static List<MovieContainer> MovieInfo()
		{
			List<MovieContainer> results = new List<MovieContainer>();
			//@"data source = DESKTOP-DJ7RAJ3; integrated security = true; database = MovieDB" -> Laptop
			//@"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB" -> Desktop
			using (SqlConnection conn = new SqlConnection(@"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB"))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand("spMovies_GetTitleAndPoster", conn);
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();

				da.Fill(dt);

				foreach (DataRow row in dt.Rows)
				{
					results.Add(new MovieContainer(row["MovieName"].ToString(), row["PosterUrl"].ToString()));
				}
				
				conn.Close();
			}
			return results;
		}
		
		public static List<MovieContainer> MovieByGenre(int genre)
		{
			List<MovieContainer> results = new List<MovieContainer>();
			//@"data source = DESKTOP-DJ7RAJ3; integrated security = true; database = MovieDB" -> Laptop
			//@"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB" -> Desktop
			using (SqlConnection conn = new SqlConnection(@"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB"))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand
				{
					Connection = conn,
					CommandType = CommandType.StoredProcedure,
					CommandText = "spMovies_GetMoviesByGenre"
				};
				cmd.Parameters.AddWithValue("@genre", genre);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();


				da.Fill(dt);

				foreach (DataRow row in dt.Rows)
				{
					results.Add(new MovieContainer(row["MovieName"].ToString(), row["PosterUrl"].ToString()));
				}

				conn.Close();
			}
			return results;
		}

		public static List<MovieContainer> MovieByName(string title)
		{
			List<MovieContainer> results = new List<MovieContainer>();
			//@"data source = DESKTOP-DJ7RAJ3; integrated security = true; database = MovieDB" -> Laptop
			//@"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB" -> Desktop
			using (SqlConnection conn = new SqlConnection(@"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB"))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand
				{
					Connection = conn,
					CommandType = CommandType.StoredProcedure,
					CommandText = "spMovies_GetMoviesByName"
				};
				cmd.Parameters.AddWithValue("@title", title);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();


				da.Fill(dt);

				foreach (DataRow row in dt.Rows)
				{
					results.Add(new MovieContainer(row["MovieName"].ToString(), row["PosterUrl"].ToString()));
				}

				conn.Close();
			}
			return results;
		}

		public static List<MovieContainer> MovieByNameAndGenre(int genre, string title)
		{
			List<MovieContainer> results = new List<MovieContainer>();

			//@"data source = DESKTOP-DJ7RAJ3; integrated security = true; database = MovieDB" -> Laptop
			//@"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB" -> Desktop
			using (SqlConnection conn = new SqlConnection(@"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB"))
			{
				conn.Open();
				SqlCommand cmd = new SqlCommand
				{
					Connection = conn,
					CommandType = CommandType.StoredProcedure,
					CommandText = "spMovies_GetByNameAndTitle"
				};
				cmd.Parameters.AddWithValue("@genre", genre);
				cmd.Parameters.AddWithValue("@title", title);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();


				da.Fill(dt);

				foreach (DataRow row in dt.Rows)
				{
					results.Add(new MovieContainer(row["MovieName"].ToString(), row["PosterUrl"].ToString()));
				}

				conn.Close();
			}
			return results;
		}
	}
}