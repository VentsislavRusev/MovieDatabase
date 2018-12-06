using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieDB
{
	public partial class Movies : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			List<MovieContainer> MovieInfoList = MovieContainer.MovieInfo();
		}

		protected void Search_btn_Click(object sender, EventArgs e)
		{
			if (Genrelist.SelectedValue != "Select Genre" && !string.IsNullOrEmpty(Moviename_tb.Text))
			{
				Moviename_tb.Text = "search genre and movie";
			} 
			else if (Genrelist.SelectedValue != "Select Genre" && string.IsNullOrEmpty(Moviename_tb.Text))
			{
				Moviename_tb.Text = "genre";
			}
			else if (Genrelist.SelectedValue == "Select Genre" && !string.IsNullOrEmpty(Moviename_tb.Text))
			{
				Moviename_tb.Text = "Search movie";
			}
			else
			{
				Moviename_tb.Text = "Nothing selected";
				return;
			}
		}
	}
}