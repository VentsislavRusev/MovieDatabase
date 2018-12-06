using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MovieDB
{
	public class DbUtility
	{
		private SqlConnection conn;

		public SqlConnection GetConnection()
		{
			//Connect to Database
			string connString = @"data source = DESKTOP-DJ7RAJ3; integrated security = true; database = MovieDB";
			conn = new SqlConnection(connString);
			conn.Open();
			return conn;
		}

		public SqlDataReader GetReader(string query)
		{
			//Create a command with command type text
			SqlCommand cmd = new SqlCommand(query);
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = this.GetConnection();

			//Read from the database
			SqlDataReader rdr = cmd.ExecuteReader();
			return rdr;
		}

		public void CloseConnection()
		{
			if (conn != null && conn.State == ConnectionState.Open)
			{
				this.conn.Close();
			}
		}
	}
}