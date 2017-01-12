using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HouseBLL;
using houseRent;
using HouseWeb.Helpers;
namespace HouseWeb.Areas.Admin.Controllers
{
    public class HouseController : Controller
    {
        //
        // GET: /Admin/House/
        const int pageSize = 5;
        private HouseService houseService = new HouseService();
        private StreetService streetService = new StreetService();
        public ActionResult Index(int pageIndex=1)
        {
            var houseData = houseService.GetAll();
            var pageList = new PagedList<House>(houseData, pageIndex, pageSize);
            return View(pageList);
        }

        public ActionResult Edit(int id = -1)
        {
            if (id > 0)
            {
                //获取房屋信息
                var house = houseService.GetHouse(id);
                //根据房子所在区获得街道
                var streets = streetService.GetList(house.Street.District.Id);
                ViewBag.Streets = streets;
                ViewBag.House = house;
                return View(house);
            }
            return View();
        }
        //删除房子
        public ActionResult Delete(int id)
        {
            string msg = houseService.Delete(id) ? "删除成功！" : "删除失败！";
            return Content("<script>alert('"+msg+"');location.href='/Admin';</script>");
        }
        //ajax获取街道数据
        public JsonResult GetStreet(int id){
            var data = streetService.GetList(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(House house)
        {
            if (ModelState.IsValid)
            {
                int id = house.HouseId ?? -1;
                bool ret = false;
                if (id > 0)
                {
                    ret = houseService.Update(house);
                }
                else
                {
                    house.PublishUserId = (Session["admin"] as User).LoginId;
                    ret = houseService.Add(house);
                }
                string msg = ret ? "编辑成功！" : "编辑失败！";
                return Content("<script>alert('" + msg + "');location.href='/Admin';</script>");
            }
            return View(house);
        }
	}
}