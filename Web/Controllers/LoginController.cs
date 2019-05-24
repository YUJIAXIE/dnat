using OrderNetWork.Common;
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
            //Session["ValidateCode"] = code;
            //byte[] bytes = vCode.CreateValidateGraphic(code);
            //return File(bytes, @"image/jpeg");
            byte[] bytes = vCode.CreateVerifyCodeBmp(out code);
            //Bitmap newbmp = new Bitmap(bmp, 108, 36);
            Session["VerifyCode"] = code;
            //byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
    }
}