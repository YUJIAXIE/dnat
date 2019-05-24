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
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult ClientLogin(Users Users)
        {
            DLL.BLL.UsersBLL ub = new DLL.BLL.UsersBLL();
            var Json = JsonConvert.SerializeObject(ub.SelectUsers(Users));
            return Content(Json);
        }
        public ActionResult FrpConfig(int UId, int Id, bool All)
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
        public ActionResult ResetPassWord()
        {
            return Content("暂未开放！");
        }
    }
}