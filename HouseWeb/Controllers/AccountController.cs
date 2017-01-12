using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using houseRent;
using HouseBLL;

namespace HouseWeb.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include="LoginName,Password")]User user)
        {
            ModelState.Remove("UserName");
            ModelState.Remove("Telephone");
            ModelState.Remove("RePassword");
            if (ModelState.IsValid)
            {
                UserService service = new UserService();
                if (service.Login(user, out user))
                {
                    Session["admin"] = user;
                    return Redirect("~/Admin");
                }
                else
                {
                    return Content("<script>alert('用户名或密码错误！');history.back();</script>");
                }
            }
            return View(user);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                UserService service = new UserService();
                if (service.Register(user))
                {
                    return Content("<script>alert('注册成功！');location.href='Login';</script>");
                }
                else
                {
                    return Content("<script>alert('用户信息填写有误！');history.back();</script>");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            Session["admin"] = null;
            return RedirectToAction("Login");
        }
    }
}