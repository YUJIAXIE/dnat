using Web.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Code()
        {
            ValidateCode vCode = new ValidateCode();
            string code;
            byte[] bytes = vCode.CreateVerifyCodeBmp(out code);
            Session["VerifyCode"] = code;
            return File(bytes, @"image/jpeg");
        }
    }
}