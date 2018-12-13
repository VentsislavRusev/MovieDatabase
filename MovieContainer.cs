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
		public string Rating { get; set; }
		public string ReleaseYear { get; set; }

		public MovieContainer(string movie, string poster)
		{
			MovieName = movie;
			Poster = poster;
		}

		public MovieContainer(string movie, string rating, string year)
		{
			MovieName = movie;
			Rating = rating;
			ReleaseYear = year;
		}
		
		public static List<MovieContainer> DisplayTopTen()
		{
			List<MovieContainer> results = new List<MovieContainer>();
			using (SqlConnection conn = new SqlConnection(@"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB"))
			{
				string query = "SELECT TOP 10 Movies.MovieID, Movies.MovieName, Movies.ReleaseYear, Movies.Rating, COUNT(DetailedViews.MovieID) as TotalCount FROM Movies, DetailedViews WHERE DetailedViews.MovieID = Movies.MovieID GROUP BY DetailedViews.MovieID, Movies.MovieID, Movies.MovieName, Movies.ReleaseYear, Movies.Rating ORDER BY COUNT(DetailedViews.MovieID) desc";
				conn.Open();
				SqlCommand cmd = new SqlCommand
				{
					Connection = conn,
					CommandType = CommandType.Text,
					CommandText = query
				};
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();

				da.Fill(dt);

				foreach (DataRow row in dt.Rows)
				{
					results.Add(new MovieContainer(row["MovieName"].ToString(), row["Rating"].ToString(), row["ReleaseYear"].ToString()));
				}

				conn.Close();
			}
			return results;
		}

		public static List<MovieContainer> DisplayTopTenDay()
		{
			List<MovieContainer> results = new List<MovieContainer>();
			using (SqlConnection conn = new SqlConnection(@"data source = DESKTOP - RGPRP90\THOMASSQL; integrated security = true; database = MovieDB"))
			{
				string query = "SELECT TOP 10 Movies.MovieID, Movies.MovieName, Movies.ReleaseYear, Movies.Rating, COUNT(DetailedViews.DisplayedTime) as TotalCount FROM Movies, DetailedViews WHERE DetailedViews.MovieID = Movies.MovieID AND DetailedViews.DisplayedTime BETWEEN DATEADD(DAY, -1, GETDATE()) AND GETDATE() GROUP BY DetailedViews.MovieID, Movies.MovieID, Movies.MovieName, Movies.ReleaseYear, Movies.Rating ORDER BY COUNT(DetailedViews.DisplayedTime) desc";
				conn.Open();
				SqlCommand cmd = new SqlCommand
				{
					Connection = conn,
					CommandType = CommandType.Text,
					CommandText = query
				};
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();

				da.Fill(dt);

				foreach (DataRow row in dt.Rows)
				{
					results.Add(new MovieContainer(row["MovieName"].ToString(), row["Rating"].ToString(), row["ReleaseYear"].ToString()));
				}

				conn.Close();
			}
			return results;
		}

		public static List<MovieContainer> DisplayTopTenWeek()
		{
			List<MovieContainer> results = new List<MovieContainer>();
			using (SqlConnection conn = new SqlConnection(@"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB"))
			{
				string query = "SELECT TOP 10 Movies.MovieID, Movies.MovieName, Movies.ReleaseYear, Movies.Rating, COUNT(DetailedViews.DisplayedTime) as TotalCount FROM Movies, DetailedViews WHERE DetailedViews.MovieID = Movies.MovieID AND DetailedViews.DisplayedTime BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE() GROUP BY DetailedViews.MovieID, Movies.MovieID, Movies.MovieName, Movies.ReleaseYear, Movies.Rating ORDER BY COUNT(DetailedViews.DisplayedTime) desc";
				conn.Open();
				SqlCommand cmd = new SqlCommand
				{
					Connection = conn,
					CommandType = CommandType.Text,
					CommandText = query
				};
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();

				da.Fill(dt);

				foreach (DataRow row in dt.Rows)
				{
					results.Add(new MovieContainer(row["MovieName"].ToString(), row["Rating"].ToString(), row["ReleaseYear"].ToString()));
				}

				conn.Close();
			}
			return results;
		}

		public static List<MovieContainer> DisplayTopTenMonth()
		{
			List<MovieContainer> results = new List<MovieContainer>();
			using (SqlConnection conn = new SqlConnection(@"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB"))
			{
				string query = "SELECT TOP 10 Movies.MovieID, Movies.MovieName, Movies.ReleaseYear, Movies.Rating, COUNT(DetailedViews.DisplayedTime) as TotalCount FROM Movies, DetailedViews WHERE DetailedViews.MovieID = Movies.MovieID AND DetailedViews.DisplayedTime BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE() GROUP BY DetailedViews.MovieID, Movies.MovieID, Movies.MovieName, Movies.ReleaseYear, Movies.Rating ORDER BY COUNT(DetailedViews.DisplayedTime) desc";
				conn.Open();
				SqlCommand cmd = new SqlCommand
				{
					Connection = conn,
					CommandType = CommandType.Text,
					CommandText = query
				};
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();

				da.Fill(dt);

				foreach (DataRow row in dt.Rows)
				{
					results.Add(new MovieContainer(row["MovieName"].ToString(), row["Rating"].ToString(), row["ReleaseYear"].ToString()));
				}

				conn.Close();
			}
			return results;
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
			using (SqlConnection conn = new SqlConnection(@"data source = DESKTOP-DJ7RAJ3; integrated security = true; database = MovieDB"))
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