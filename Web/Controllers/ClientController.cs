using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}