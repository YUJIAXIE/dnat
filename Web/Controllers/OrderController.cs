using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using DLL.BLL;
using DLL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web.Common;
using ThoughtWorks.QRCode.Codec;
using System.IO;

namespace Web.Controllers
{
    [CheckLoginFilter(nums = CheckLoginType.pro)]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderJson()
        {
            var id = Session["Id"].ToString();
            OrderBLL ob = new OrderBLL();
            var Order = ob.SelectOrder(id);
            var Orderjson = JsonConvert.SerializeObject(Order);
            string JSONstring = string.Empty;
            JSONstring += "{";
            JSONstring += "\"" + "code" + "\":0,";
            JSONstring += "\"" + "msg" + "\":\"\",";
            JSONstring += "\"" + "count" + "\":" + Order.Rows.Count + ",";
            JSONstring += "\"" + "data" + "\"";
            JSONstring += ":";
            JSONstring += Orderjson;
            JSONstring += "}";
            return Content(JSONstring);
        }

        public ActionResult SaveOrder(int price)
        {
            int result = 0;
            var orderId = string.Empty;
            OrderBLL ob = new OrderBLL();
            var datetime = DateTime.Now;
            PriceBLL pb = new PriceBLL();
            ConfigBLL cb = new ConfigBLL();
            if ((int)pb.IdSelectPrice(price).Rows[0]["Price"] > 0)
            {
                Order o = new Order();
                o.OrderId = orderId = datetime.ToString("yyyyMMddHHmmssfff");
                o.UserId = (int)Session["Id"];
                o.PriceId = price;
                o.OrderExplain = "购买" + pb.IdSelectPrice(price).Rows[0]["Type"] + "云隧道";
                o.CreateTime = datetime.ToString();
                o.TradingStatus = "待付款";
                IAopClient client = new DefaultAopClient(cb.SelectValue("serverUrlserverUrl"), cb.SelectValue("app_id"), cb.SelectValue("merchant_private_key"), "json", "1.0", "RSA2", cb.SelectValue("alipay_public_key"), "GBK", false);
                AlipayTradePrecreateRequest request = new AlipayTradePrecreateRequest();
                request.BizContent = "{" +
                "\"out_trade_no\":\"" + o.OrderId + "\"," +
                "\"total_amount\":" + pb.IdSelectPrice(price).Rows[0]["Price"] + "," +
                "\"subject\":\"" + o.OrderExplain + "\"," +
                "\"qr_code_timeout_express\":\"1h\"" +
                "  }";
                AlipayTradePrecreateResponse response = client.Execute(request);
                switch (response.Code)
                {
                    case "10000":
                        DoWaitProcess(response.QrCode, o.OrderId);
                        result = ob.InsertOrder(o);
                        break;
                }
            }
            if (result > 0)
                return Content(orderId);
            else
                return Content("404");
        }


        /// <summary>
        /// 生成二维码并展示到页面上
        /// </summary>
        /// <param name="precreateResult">二维码串</param>
        private void DoWaitProcess(string precreateResult, string Name)
        {
            QRCodeEncoder endocder = new QRCodeEncoder();
            //二维码背景颜色
            endocder.QRCodeBackgroundColor = System.Drawing.Color.White;
            //二维码编码方式
            endocder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            //每个小方格的宽度
            endocder.QRCodeScale = 10;
            //二维码版本号
            endocder.QRCodeVersion = 5;
            //纠错等级
            endocder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            //将json川做成二维码
            Bitmap bitmap = endocder.Encode(precreateResult, System.Text.Encoding.UTF8);
            string strSaveDir = Request.MapPath("/QRcode/");
            if (!Directory.Exists(strSaveDir))
            {
                Directory.CreateDirectory(strSaveDir);
            }
            string strSavePath = Path.Combine(strSaveDir, Name + ".jpg");
            if (!System.IO.File.Exists(strSavePath))
            {
                bitmap.Save(strSavePath);
            }
        }
        public ActionResult DoPay(string code)
        {
            return View();
        }
    }
}