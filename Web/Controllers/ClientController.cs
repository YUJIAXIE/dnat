using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLL.Models;
using System.Web.Security;
using Newtonsoft.Json;
using System.Data;

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
            Users.RegDate = DateTime.Now.Date.ToShortDateString();
            Users.EndDate = DateTime.Now.Date.AddDays(cb.ProbationPeriod()).ToShortDateString();
            Users.Version = 9;
            Users.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(Users.PassWord, "MD5");
            Users.Login = 1;
            ub.InsertUsers(Users);
            return View("Register");

        }

        public ActionResult ClientLogin(Users Users)
        {
            DLL.BLL.UsersBLL ub = new DLL.BLL.UsersBLL();
            var Json = JsonConvert.SerializeObject(ub.SelectUsers(Users));
            return Content(Json);
        }
        public ActionResult FrpConfig(int UId, int Id,bool All)
        {
            string Json;
            DLL.BLL.FRPConfigBLL fb = new DLL.BLL.FRPConfigBLL();
            if (Id == 0)
            {
                Json = JsonConvert.SerializeObject(fb.SelectCommonFrpConfig(All));

            }
            else
            {
                Json = JsonConvert.SerializeObject(fb.SelectUsersFrpConfig(UId,All));

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
            string MappingName = fb.SelectMax(dt.Rows[1][0].ToString());
            var IsProt = fb.SelectProt(dt.Rows[0][0].ToString(), dt.Rows[3][2].ToString());
            if (IsProt)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FrpConfig fc = new FrpConfig();
                    fc.UId = dr["UId"].ToString();
                    fc.MappingName = MappingName;
                    fc.Info = dr["Info"].ToString();
                    fc.Value = dr["Value"].ToString();
                    fb.InsertUsersFrpConfig(fc);
                }
            }
            else
            {
                result= "false";
            }
            return Content(result);
        }
    }
}