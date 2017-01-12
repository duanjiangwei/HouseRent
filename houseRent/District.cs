using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace houseRent
{
    public class District
    {
        public District() { }
        private int _id;
        private string name;
        [DisplayName("区域")]
        [Required(ErrorMessage="请选择{0}")]
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
    }
}
