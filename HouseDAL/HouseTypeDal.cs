using houseRent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseDAL
{
    public class HouseTypeDal
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<HouseType> GetList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name ");
            strSql.Append(" FROM HouseType ");

            return GetItemsBySql(strSql.ToString());
        }

        private List<HouseType> GetItemsBySql(string safeSql)
        {
            List<HouseType> list = new List<HouseType>();

            DataSet ds = SqlHelper.ExecuteDataSet(SqlHelper.conStr, CommandType.Text, safeSql);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    HouseType item = new HouseType();

                    item.Id = (int)row["Id"];
                    item.Name = (string)row["Name"];

                    list.Add(item);
                }
            }
            return list;
        }
    }
}
