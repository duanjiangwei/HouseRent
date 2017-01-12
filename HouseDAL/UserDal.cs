using houseRent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HouseDAL
{
    /// <summary>
    /// 用户模块数据访问层
    /// </summary>
    public class UserDal
    {
        /// <summary>
        /// 判断登录名是否存在
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool Exists(string loginName)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(1) from [User]");
            sql.Append(" where LoginName = @LoginName ");
            SqlParameter[] parameters = { 
                new SqlParameter("@LoginName",SqlDbType.NVarChar,20)};
            parameters[0].Value = loginName;
            return Convert.ToBoolean(SqlHelper.ExecuteScalar(SqlHelper.conStr, CommandType.Text, sql.ToString(), parameters));
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(User user)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into [User](");
            sql.Append("LoginName,UserName,Password,Telephone) values(");
            sql.Append("@LoginName,@UserName,@Password,@Telephone)");
            sql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                                            new SqlParameter("@LoginName",SqlDbType.NVarChar,20),
                                            new SqlParameter("@UserName",SqlDbType.NVarChar,10),
                                            new SqlParameter("@Password",SqlDbType.NVarChar,50),
                                            new SqlParameter("@Telephone",SqlDbType.NVarChar,20)
                                        };
            parameters[0].Value = user.LoginName;
            parameters[1].Value = user.UserName;
            parameters[2].Value = user.Password;
            parameters[3].Value = user.Telephone;
            object obj = SqlHelper.ExecuteScalar(SqlHelper.conStr, CommandType.Text, sql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public User GetModel(string LoginName)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select top 1 LoginId,LoginName,UserName,Password,Telephone from [User] ");
            sql.Append(" where LoginName = @LoginName");
            SqlParameter[] paras = { new SqlParameter("@LoginName", SqlDbType.NVarChar, 20) };
            paras[0].Value = LoginName;
            User user = new User();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.conStr, CommandType.Text, sql.ToString(), paras);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return FillModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public User GetModel(int LoginId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LoginId,LoginName,UserName,Password,Telephone from [User] ");
            strSql.Append(" where LoginId=@LoginId");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginId", SqlDbType.Int,4)
};
            parameters[0].Value = LoginId;

            User model = new User();
            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.conStr, CommandType.Text, strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {

                return FillModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        private User FillModel(DataRow dr)
        {
            User model = new User();
            if (dr["LoginId"].ToString() != "")
            {
                model.LoginId = int.Parse(dr["LoginId"].ToString());
            }
            model.LoginName = dr["LoginName"].ToString();
            model.UserName = dr["UserName"].ToString();
            model.Password = dr["Password"].ToString();
            model.Telephone = dr["Telephone"].ToString();
            return model;

        }
    }
}
