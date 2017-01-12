using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace houseRent
{
    public class House
    {
        public House() { }
        private int? _houseId;
        private string _title;
        private int _typeId;
        private decimal _floorage;
        private decimal _price;
        private int? _streetId;
        private string _contract;
        private string _description;
        private int _publishUser;
        private DateTime _publishTime = DateTime.Now;

        public HouseType HouseType { get; set; }
        public Street Street { get; set; }
        public User User { get; set; }

        public int? HouseId
        {
            get { return _houseId; }
            set { _houseId = value; }
        }
        [DisplayName("标题")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public int TypeId
        {
            get { return _typeId; }
            set { _typeId = value; }
        }
        [DisplayName("面积")]
        [Required(ErrorMessage="{0}不能为空")]
        public decimal Floorage
        {
            get { return _floorage; }
            set { _floorage = value; }
        }
        [DisplayName("价格")]
        [Required(ErrorMessage="{0}不能为空")]
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public int? StreetId
        {
            get { return _streetId; }
            set { _streetId = value; }
        }
        [DisplayName("联系方式")]
        [Required(ErrorMessage="{0}不能为空")]
        [RegularExpression(@"^\d{5,20}$",ErrorMessage="{0}格式不正确")]
        public string Contract
        {
            get { return _contract; }
            set { _contract = value; }
        }
        [DisplayName("描述")]
        [Required(ErrorMessage = "{0}不能为空")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public int PublishUserId
        {
            get { return _publishUser; }
            set { _publishUser = value; }
        }
        public DateTime PublishTime
        {
            get { return DateTime.Now; }
            set { _publishTime = value; }
        }
        public User PublishUser { get; set; }
    }
}
