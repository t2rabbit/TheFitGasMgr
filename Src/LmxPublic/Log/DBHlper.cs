using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace LmxPublic.Log
{
    class DBHlper
    {

        public static void ExecSqlCmd(string queryString,
                     string connectionString)
        {
            string strConn= ConfigHlper.GetConfig(connectionString);
            using (SqlConnection connection = new SqlConnection(
                       strConn))
            {
                try
                {

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                	
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
