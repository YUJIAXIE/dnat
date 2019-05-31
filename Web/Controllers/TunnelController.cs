using DLL.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Common;

namespace Web.Controllers
{
    [CheckLoginFilter(nums = CheckLoginType.pro)]
    public class TunnelController : Controller
    {
        // GET: Tunnel 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            TunnelTypeBLL ttb = new TunnelTypeBLL();
            var tunneltype = ttb.SelectTunnelType();
            return View(tunneltype);
        }

        public ActionResult ListJson()
        {
            var id = Session["id"].ToString();
            FRPConfigBLL fb = new FRPConfigBLL();
            var frp = fb.SelectUsersFrpConfig(id, true);
            var frpjson = JsonConvert.SerializeObject(frp);
            string JSONstring = string.Empty;
            JSONstring += "{";
            JSONstring += "\"" + "code" + "\":0,";
            JSONstring += "\"" + "msg" + "\":\"\",";
            JSONstring += "\"" + "count" + "\":" + frp.Rows.Count + ",";
            JSONstring += "\"" + "data" + "\"";
            JSONstring += ":";
            JSONstring += frpjson;
            JSONstring += "}";
            return Content(JSONstring);
        }

        public ActionResult Add(int Id)
        {
            PriceBLL pb = new PriceBLL();
            var price = pb.TIdSelectPrice(Id);
            return View(price);
        }
    }
}