using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDB
{
	public class LikesAndDislikes
	{
		public string Movie { get; set; }

		Util dbConn = new Util();

		public LikesAndDislikes(string movie)
		{
			Movie = movie;
		}

		public void LikeIncrement()
		{
			dbConn.OpenConnection();

			dbConn.GetAdapter("spMovies_IncrementLike", Movie);

			dbConn.CloseConnection();
		}

		public void DislikeIncrement()
		{
			dbConn.OpenConnection();

			dbConn.GetAdapter("spMovies_IncrementDislike", Movie);

			dbConn.CloseConnection();
		}
	}
}