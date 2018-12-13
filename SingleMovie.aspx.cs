using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace MovieDB
{
	public partial class SingleMovie : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("WRITE TO THE OUTPUT " + Session["value"]);

			if (Session["value"] != null)
			{
				string movie = Session["value"].ToString();
				PopulateListView(MovieContainer.GetSpecificMovieInfo(movie));
			}
		}

		public void PopulateListView(List<MovieContainer> data)
		{
			List<MovieContainer> MovieInfoList = data;

			SingleMovie_lw.DataSource = MovieInfoList;
			SingleMovie_lw.DataBind();
		}

	}
}
		