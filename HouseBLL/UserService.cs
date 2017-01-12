using HouseDAL;
using houseRent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBLL
{
    public class UserService
    {
        static object userLock=new object();
        private readonly UserDal dal = new UserDal();
        public UserService()
		{}
		#region  Method

        public bool Login(User user, out User gettedUser)
        {
             gettedUser = dal.GetModel(user.LoginName);
            if (gettedUser != null && gettedUser.Password == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Register(User user)
        {
            lock(userLock)
            {
                if (dal.Exists(user.LoginName))//用户是否存在
                {
                    return false;

                }
                else
                {
                    if (dal.AddUser(user) > 0)//添加用户成功
                        return true;
                }
            }
            return false;
        }
        #endregion  Method
    }
}
