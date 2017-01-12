using HouseDAL;
using houseRent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBLL
{
    public class HouseTypeService
    {
         private readonly HouseTypeDal dal = new HouseTypeDal();
         public HouseTypeService()
		{}
		#region  Method
        public List<HouseType> GetAll()
        {
            return dal.GetList();
        }

		#endregion  Method
    }
}
