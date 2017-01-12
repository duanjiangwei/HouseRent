using HouseDAL;
using houseRent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBLL
{
    public class StreetService
    {
        private readonly  StreetDal dal = new StreetDal();
        public StreetService()
		{}

		#region  Method
        public List<Street> GetAll()
        {
            return dal.GetList();
        }

        public List<Street> GetList(int distinctId)
        {
            return dal.GetList(distinctId);
        }

		#endregion  Method
    }
}
