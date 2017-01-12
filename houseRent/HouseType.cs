using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace houseRent
{
   public class HouseType
    {
        public HouseType() { }
        private int _id;
        private string _name;
        [DisplayName("户型")]
        [Required(ErrorMessage="请选择{0}")]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
