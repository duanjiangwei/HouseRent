using houseRent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseDAL
{
    public class DistrictDal
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<District> GetList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name ");
            strSql.Append(" FROM District ");

            return GetItemsBySql(strSql.ToString());
        }
        private List<District> GetItemsBySql(string safeSql)
        {
            List<District> list = new List<District>();

            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.conStr, CommandType.Text, safeSql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    District item = new District();

                    item.Id = (int)row["Id"];
                    item.Name = (string)row["Name"];

                    list.Add(item);
                }
            }

            return list;
        }
    }
}
