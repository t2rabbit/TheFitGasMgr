using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LmxPublic
{
    public class DataTableHelper
    {
        /// <summary>
        /// EF MSSQL 语句返回 dataTable
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable MSSqlQueryForDataTatable(Database db,
                 string sql,
                 SqlParameter[] parameters)
        {

            SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = db.Connection.ConnectionString;
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            if (parameters.Length > 0)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        /// <summary>
        /// EF MYSQL 语句返回 dataTable
        /// </summary>
        /// <param name="db"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataTable MYSqlQueryForDataTatable(Database db, string sql, SqlParameter[] parameters)
        {

            MySqlConnection myCon = new MySqlConnection();
            myCon.ConnectionString = db.Connection.ConnectionString;
            if (myCon.State != ConnectionState.Open)
            {
                myCon.Close();
                myCon.Open();
            }
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = myCon;
            cmd.CommandText = sql;

            if (parameters != null && parameters.Length > 0)
            {
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
            }

            DataTable table = new DataTable();
            DataSet ds = new DataSet();
            MySqlDataAdapter myAdapater = new MySqlDataAdapter(cmd);
            myAdapater.Fill(ds);
            if (ds != null)
            {
                table = ds.Tables[0];
            }
            return table;
        }
    }
}
