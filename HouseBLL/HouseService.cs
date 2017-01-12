using HouseDAL;
using houseRent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBLL
{
    public class HouseService
    {
        private readonly HouseDal dal = new HouseDal();
        public HouseService()
        { }
        #region  Method

        public List<House> GetAll()
        {
            return dal.GetList();
        }

        public House GetHouse(int houseId)
        {
            return dal.GetModel(houseId);
            
        }

        public bool Add(House house)
        {
            EditHelp(house);
            return dal.Add(house) > 0;
        }

        public bool Update(House house)
        {
            EditHelp(house);
            return dal.Update(house);
        }

        private void EditHelp(House house)
        {
            house.TypeId = house.HouseType.Id;
            house.StreetId = house.Street.Id;
        }

        public bool Delete(int houseId)
        {
            return dal.Delete(houseId);
        }
        #endregion
    }
}
