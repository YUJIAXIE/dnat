using DLL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 验证注册域名是否已注册
        /// </summary>
        /// <param name="DoMain">域名前缀</param>
        /// <returns></returns>
        public ActionResult IsValidName(string DoMain)
        {
            DLL.BLL.UsersBLL ub = new DLL.BLL.UsersBLL();
            var d = ub.IsValidDoMain(DoMain);
            if (d)
                return Content("200");
            else
                return Content("404");
        }
        /// <summary>
        /// 验证手机号是否已注册
        /// </summary>
        /// <param name="Phone">手机号</param>
        /// <returns></returns>
        public ActionResult IsValidPhone(string Phone)
        {
            DLL.BLL.UsersBLL ub = new DLL.BLL.UsersBLL();
            var d = ub.IsValidPhone(Phone);
            if (d)
                return Content("200");
            else
                return Content("404");
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="Users"></param>
        /// <returns></returns>
        public ActionResult Register(Users Users)
        {
            if (Session["VerifyCode"].ToString() == Users.Code.ToUpper())
            {
                DLL.BLL.ConfigBLL cb = new DLL.BLL.ConfigBLL();
                DLL.BLL.UsersBLL ub = new DLL.BLL.UsersBLL();
                Models.DoMain dm = new Models.DoMain();
                dm.Add(Users.DoMain);
                Users.RegDate = DateTime.Now.Date.ToShortDateString();
                Users.EndDate = DateTime.Now.Date.AddDays(Convert.ToInt32(cb.SelectValue("ProbationPeriod"))).ToShortDateString();
                Users.Version = Convert.ToInt32(cb.SelectValue("DefaultVersion"));
                Users.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(Users.PassWord, "MD5");
                Users.ECSId = Convert.ToInt32(cb.SelectValue("DefaultECSId"));
                ub.InsertUsers(Users);
                return Content("200");
            }
            else
            {
                return Content("验证码错误！");
            }
        }

        public ActionResult Login(Users Users)
        {
            Users.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(Users.PassWord, "MD5");
            DLL.BLL.UsersBLL ub = new DLL.BLL.UsersBLL();
            DataTable dt = ub.SelectUsers(Users);
            if (dt .Rows.Count> 0)
            {
                if (Users.Client)
                {
                    return Content(JsonConvert.SerializeObject(dt));
                }
                else
                {
                    Session["Id"] = dt.Rows[0]["Id"];
                    return Content(Url.Action("Index", "Home"));
                }
            }
            else
            {
                return Content("400");
            }


        }

    }
}