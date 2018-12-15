using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MovieDB
{
	public partial class Movies : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Session.Clear();
			if (!Page.IsPostBack)
			{
				PopulateListView(MovieContainer.MovieInfo());
			}
				
		}

		protected void Search_btn_Click(object sender, EventArgs e)
		{
			if (Genrelist.SelectedValue != "Select Genre" && !string.IsNullOrEmpty(Moviename_tb.Text))
			{
				ClearListView();

				int genre = Genrelist.SelectedIndex;
				string title = Moviename_tb.Text;
				MovieContainer.MovieInfo().Clear();
				PopulateListView(MovieContainer.MovieByNameAndGenre(genre, title));
			} 
			else if (Genrelist.SelectedValue != "Select Genre" && string.IsNullOrEmpty(Moviename_tb.Text))
			{
				ClearListView();

				int genre = Genrelist.SelectedIndex;
				MovieContainer.MovieInfo().Clear();
				PopulateListView(MovieContainer.MovieByGenre(genre));
			}
			else if (Genrelist.SelectedValue == "Select Genre" && !string.IsNullOrEmpty(Moviename_tb.Text))
			{
				ClearListView();

				string title = Moviename_tb.Text;
				MovieContainer.MovieInfo().Clear();
				PopulateListView(MovieContainer.MovieByName(title));
			}
			else
			{
				return;
			}
		}

		public void SingleMovie_Click(object sender, EventArgs args)
		{
			var href = ((System.Web.UI.HtmlControls.HtmlAnchor)sender).HRef;
			Session["value"] = href;

			// Insert timestamp of clicked movie into DetailedViews
			using (SqlConnection conn = new SqlConnection(@"data source = DESKTOP-DJ7RAJ3; integrated security = true; database = MovieDB"))
			{
				//string query = "SELECT Movies.MovieName, Movies.TrailerUrl, Movies.Resume, Movies.Actors, Movies.Rating, Movies.Genre FROM Movies WHERE Movies.MovieName = '" + movie + "'";
				string query = "spMovies_UpdateDetailedViews";
				conn.Open();
				SqlCommand cmd = new SqlCommand
				{
					Connection = conn,
					CommandType = CommandType.StoredProcedure,
					CommandText = query
				};

				cmd.Parameters.AddWithValue("@title", href);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();

				da.Fill(dt);

				conn.Close();
			}
			Response.Redirect("SingleMovie.aspx");
		}

		public void PopulateListView(List<MovieContainer> data)
		{
			List<MovieContainer> MovieInfoList = data;

			MovieList_lw.DataSource = MovieInfoList;
			MovieList_lw.DataBind();
		}

		public void ClearListView()
		{
			MovieList_lw.DataSource = null;
			MovieList_lw.DataBind();
		}
	}
}