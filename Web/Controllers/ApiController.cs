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

        public ActionResult FrpConfig(string UId, int Id, bool All)
        {
            string Json;
            DLL.BLL.FRPConfigBLL fb = new DLL.BLL.FRPConfigBLL();
            DLL.BLL.ECSConfigBLL eb = new DLL.BLL.ECSConfigBLL();
            if (Id == 0)
            {
                Json = JsonConvert.SerializeObject(eb.SelectCommonFrpConfig(UId, All));

            }
            else
            {
                Json = JsonConvert.SerializeObject(fb.SelectUsersFrpConfig(UId, All));

            }
            return Content(Json);
        }

        public ActionResult DeleteFrp(FrpConfig frp)
        {
            DLL.BLL.FRPConfigBLL fb = new DLL.BLL.FRPConfigBLL();
            fb.DeleteUsersFrpConfig(frp);
            return Content("true");
        }
        public ActionResult InsertFrp(string Tunnel)
        {
            string result = "true";
            DLL.BLL.FRPConfigBLL fb = new DLL.BLL.FRPConfigBLL();
            DataTable dt = Models.Json.Json2DataTable(Tunnel);
            var MappingName = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            foreach (DataRow dr in dt.Rows)
            {
                FrpConfig fc = new FrpConfig();
                fc.UId = dr["UId"].ToString();
                fc.MappingName = fc.UId + "-" + MappingName;
                fc.Info = dr["Info"].ToString();
                fc.Value = dr["Value"].ToString();
                fb.InsertUsersFrpConfig(fc);
            }
            return Content(result);
        }

        public ActionResult UpdatePwd(int Id, string PassWord)
        {
            Users u = new Users();
            u.Id = Id;
            u.PassWord = PassWord;
            DLL.BLL.UsersBLL ub = new DLL.BLL.UsersBLL();
            if (ub.UpdatePwd(u) == 1)
                return Content("true");
            else
                return Content("false");
        }

    }
}