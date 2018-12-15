using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MovieDB
{
	public class Util
	{
		private SqlConnection conn;

		public SqlConnection OpenConnection()
		{
		//	string connString = @"data source = DESKTOP-DJ7RAJ3; integrated security = true; database = MovieDB";
			string connString = @"data source = DESKTOP-RGPRP90\THOMASSQL; integrated security = true; database = MovieDB";
			conn = new SqlConnection(connString);
			conn.Open();
			return conn;
		}

		public SqlDataAdapter GetAdapter(string query, string movie)
		{
			SqlCommand cmd = new SqlCommand(query)
			{
				CommandType = CommandType.StoredProcedure,
				Connection = OpenConnection()
			};

			cmd.Parameters.AddWithValue("@title", movie);

			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();

			da.Fill(dt);
			return da;
		}

		//public SqlDataReader GetReader(string query)
		//{
		//	SqlCommand cmd = new SqlCommand(query)
		//	{
		//		CommandType = CommandType.StoredProcedure,
		//		Connection = OpenConnection()
		//	};

		//	SqlDataReader rdr = cmd.ExecuteReader();
		//	return rdr;
		//}

		public void CloseConnection()
		{
			if (conn != null && conn.State == ConnectionState.Open)
				conn.Close();
		}
	}
}