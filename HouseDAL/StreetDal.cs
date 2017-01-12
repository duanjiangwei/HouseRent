using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using houseRent;
using System.Data;
namespace HouseDAL
{
   public class StreetDal
    {
        public StreetDal() { }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Street> GetList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name ");
            strSql.Append(" FROM Street ");

            return GetItemsBySql(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Street> GetList(int distinctId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name ");
            strSql.Append(" FROM Street ");
            strSql.Append(" where DistrictId= " + distinctId);
            return GetItemsBySql(strSql.ToString());
        }

        private List<Street> GetItemsBySql(string safeSql)
        {
            List<Street> list = new List<Street>();

            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.conStr, CommandType.Text, safeSql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    Street item = new Street();

                    item.Id = (int)row["Id"];
                    item.Name = (string)row["Name"];

                    list.Add(item);
                }
            }

            return list;
        }
    }
}
