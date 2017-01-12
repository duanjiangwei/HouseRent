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
    public class Street
    {
        public Street() { }
        private int? _id;
        private string _name;
        private int _districtId;
        [DisplayName("街道")]
        [Required(ErrorMessage="{请选择0}")]
        public int? Id
        {
            get { return _id; }
            set { this._id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int DistrictId
        {
            get { return _districtId; }
            set { this._districtId = value; }
        }
        public District District
        {
            get;
            set;
        }
    }
}
