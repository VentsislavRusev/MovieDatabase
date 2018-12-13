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
			PopulateListView(MovieContainer.MovieInfo());
		}

		protected void Search_btn_Click(object sender, EventArgs e)
		{
			if (Genrelist.SelectedValue != "Select Genre" && !string.IsNullOrEmpty(Moviename_tb.Text))
			{
				ClearListView();

				int genre = Genrelist.SelectedIndex;
				string title = Moviename_tb.Text;

				PopulateListView(MovieContainer.MovieByNameAndGenre(genre, title));
			} 
			else if (Genrelist.SelectedValue != "Select Genre" && string.IsNullOrEmpty(Moviename_tb.Text))
			{
				ClearListView();

				int genre = Genrelist.SelectedIndex;
				
				PopulateListView(MovieContainer.MovieByGenre(genre));
			}
			else if (Genrelist.SelectedValue == "Select Genre" && !string.IsNullOrEmpty(Moviename_tb.Text))
			{
				ClearListView();

				string title = Moviename_tb.Text;

				PopulateListView(MovieContainer.MovieByName(title));
			}
			else
			{
				return;
			}
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

		public void SingleMovie_Click(object sender, EventArgs args)
		{
			var href = ((System.Web.UI.HtmlControls.HtmlAnchor)sender).HRef;
			Session["value"] = href;

			System.Diagnostics.Debug.Write("WRITE TO THE OUTPUT " + Session["value"]);
		}
	}
}