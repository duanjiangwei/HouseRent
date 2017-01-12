using HouseDAL;
using houseRent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBLL
{
    public class DistrictService
    {
        private readonly DistrictDal dal = new DistrictDal();
        public DistrictService()
		{}
		#region  Method

        public List<District> GetAll()
        {
            return dal.GetList();
        }

		#endregion  Method
    }
}
