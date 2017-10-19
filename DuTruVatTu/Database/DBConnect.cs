using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DuTruVatTu.Database
{
    public class DBConnect
    {
        static string DatabaseConnectionString =
            ConfigurationManager.ConnectionStrings["QuanLyVatTu"].ConnectionString;

        public static void SqlExecute(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static object SqlReturn(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                object result = (object)cmd.ExecuteScalar();
                return result;
            }
        }

        public static DataTable SqlDataTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Connection.Open();
                DataTable TempTable = new DataTable();
                TempTable.Load(cmd.ExecuteReader());
                return TempTable;
            }
        }

        public static DataTable SqlStoredProcedure(string spNam, Object[] par)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(spNam, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(par);
                cmd.Connection.Open();
                DataTable obj = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    obj.Load(dr);
                }
                return obj;
            }
        }

        public static DataTable SqlStoredProcedure(string spNam)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(spNam, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                DataTable obj = new DataTable();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    obj.Load(dr);
                }
                return obj;
            }
        }
    }
}