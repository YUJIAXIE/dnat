using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLL.Models;
using System.Web.Security;

namespace Web.Controllers
{
    public class ClientController : Controller
    {
        // GET: 用于客户端
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult IsValidName(string UserName)
        {
            DLL.BLL.UsersBLL ub = new DLL.BLL.UsersBLL();
            var d = ub.IsValidDoMain(UserName);
            if (d)
                return Content("200");
            else
                return Content("404");
        }
        [HttpPost]
        public ActionResult AddClient(Users Users)
        {
            DLL.BLL.ConfigBLL cb = new DLL.BLL.ConfigBLL();
            DLL.BLL.UsersBLL ub = new DLL.BLL.UsersBLL();
            Users.RegDate = DateTime.Now.Date;
            Users.EndDate = Users.RegDate.AddDays(cb.ProbationPeriod());
            Users.Version = 9;
            Users.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(Users.PassWord, "MD5");
            ub.InsertUsers(Users);
            return View("Register");

        }



        public ActionResult ClientLogin(Users Users)
        {
            DLL.BLL.UsersBLL ub = new DLL.BLL.UsersBLL();
            var f =Convert.ToString( ub.Select(Users));
            return Content(f);
        }
    }
}