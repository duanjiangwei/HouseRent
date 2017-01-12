using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace HouseDAL
{
    public class SqlHelper
    {
        //获得数据库的链接字符串
        public static string conStr = ConfigurationManager.ConnectionStrings["House"].ConnectionString;
        /// <summary>
        /// 设置一个等待执行的SqlCommand对象
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="commandType"></param>
        /// <param name="conn"></param>
        /// <param name="commandText"></param>
        /// <param name="cmdParams"></param>
        private static void PrepareCommand(SqlCommand cmd, CommandType commandType, SqlConnection conn, string commandText, SqlParameter[] cmdParams)
        {
            //打开链接
            if (conn.State != ConnectionState.Open)
                conn.Open();
            //设置sqlCommand对象
            cmd.Connection = conn;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (cmdParams != null)
            {
                foreach (SqlParameter param in cmdParams)
                    cmd.Parameters.Add(param);
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection con, string spName, params object[] parameterValues)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cmd);
            cmd.Parameters.RemoveAt(0);
            if (parameterValues != null)
            {
                for (int i = 0; i < cmd.Parameters.Count; i++)
                {
                    cmd.Parameters[i].Value = parameterValues[i];
                }
            }
        }
        /// <summary>
        /// 执行非查询语句
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, commandType, conn,commandText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                return val;
            }
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="connectionStr"></param>
        /// <param name="spName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionStr, string spName, params object[] values)
        {
            using (SqlConnection con = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, con, spName, values);
                int val = cmd.ExecuteNonQuery();
                return val;
            }
        }
        /// <summary>
        /// 执行查询，返回reader
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="type"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string connectionString, CommandType type, string sql, params SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, type, con, sql, parameters);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch
            {
                
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 执行存储过程，返回reader
        /// </summary>
        /// <param name="conStr"></param>
        /// <param name="spName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string conStr, string spName, params object[] values)
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, con, spName, values);
                SqlDataReader reader = cmd.ExecuteReader();
                return reader;
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// 执行存储过程，返回数据集
        /// </summary>
        /// <param name="conStr"></param>
        /// <param name="spName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string conStr, string spName, params object[] values)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, con, spName, values);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回结果集
        /// </summary>
        /// <param name="conStr"></param>
        /// <param name="type"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string conStr, CommandType type, string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, type,conn, sql, parameters);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
        }
        /// <summary>
        /// 执行查询语句，返回一个结果
        /// </summary>
        /// <param name="conStr"></param>
        /// <param name="type"></param>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string conStr, CommandType type, string sql, params SqlParameter[] parameter)
        {
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, type, conn, sql, parameter);
                object val = cmd.ExecuteScalar();
                return val;
            }
        }
        /// <summary>
        /// 执行存储过程，返回一个结果
        /// </summary>
        /// <param name="conStr"></param>
        /// <param name="spName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string conStr, string spName, params object[] values)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, con, spName, values);
                object val = cmd.ExecuteScalar();
                return val;
            }
        }
    }
}
