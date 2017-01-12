using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace houseRent
{
    [Serializable]
    public class User
    {
        public User() { }
        private int loginId;
        private string loginName;
        private string userName;
        private string password;
        private string telephone;

        public int LoginId
        {
            get { return this.loginId; }
            set { this.loginId = value; }
        }
        [DisplayName("用户名")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string LoginName
        {
            get { return this.loginName; }
            set { this.loginName = value; }
        }
        [DisplayName("密码")]
        [Required(ErrorMessage="{0}不能为空")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [DisplayName("用户姓名")]
        [Required(ErrorMessage="{0}不能为空")]
        public string UserName
        {
            get { return userName; }
            set { this.userName = value; }
        }
        [DisplayName("电话")]
        [Required(ErrorMessage="{0}不能为空")]
        [RegularExpression(@"^\d{6,20}$",ErrorMessage="{0}格式错误")]
        public string Telephone
        {
            get { return telephone; }
            set { this.telephone = value; }
        }
        [DisplayName("确认密码")]
        [Required(ErrorMessage="{0}不能为空")]
        [Compare("Password",ErrorMessage="两次密码输入不一致")]
        public string RePassword
        {
            get;
            set;
        }
    }
}
