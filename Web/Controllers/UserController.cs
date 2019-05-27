using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLL.Models;
using System.Web.Security;
using Newtonsoft.Json;
using System.Data;
using DLL.BLL;
using Web.Common;

namespace Web.Controllers
{
    [CheckLoginFilter(nums = CheckLoginType.pro)]
    public class UserController : Controller
    {
        //主页
        public ActionResult Main()
        {
            var id = Session["Id"].ToString();
            FRPConfigBLL fb = new FRPConfigBLL();
            ViewBag.http = fb.SelectCount("http", id);
            ViewBag.tcp = fb.SelectCount("tcp", id);
            return View();
        }

        public ActionResult Detail()
        {
            var id = Session["Id"].ToString();
            UsersBLL ub = new UsersBLL();
            var User = ub.Select(id);
            return View(User);
        }
    }
}