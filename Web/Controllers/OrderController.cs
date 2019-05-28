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
using System.Threading;

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
            if (Convert.ToInt32(pb.IdSelectPrice(price).Rows[0]["Price"]) > 0)
            {
                Order o = new Order();
                o.OrderId = orderId = datetime.ToString("yyyyMMddHHmmssfff");
                o.UserId = (int)Session["Id"];
                o.PriceId = price;
                o.OrderExplain = "购买" + pb.IdSelectPrice(price).Rows[0]["Type"] + "云隧道";
                o.CreateTime = datetime.ToString();
                o.TradingStatus = "待付款";
                IAopClient client = new DefaultAopClient(cb.SelectValue("serverUrl"), cb.SelectValue("appId"), cb.SelectValue("merchant_private_key"), "json", "1.0", "RSA2", cb.SelectValue("alipay_public_key"), "GBK", false);
                AlipayTradePrecreateRequest request = new AlipayTradePrecreateRequest();
                request.BizContent = "{" +
                "\"out_trade_no\":\"" + o.OrderId + "\"," +
                "\"total_amount\":" + pb.IdSelectPrice(price).Rows[0]["Price"] + "," +
                "\"subject\":\"" + o.OrderExplain + "\"," +
                "\"timeout_express\":\"1h\"" +
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
            else
            {
                Order o = new Order();
                o.OrderId = orderId = datetime.ToString("yyyyMMddHHmmssfff");
                o.UserId = (int)Session["Id"];
                o.PriceId = price;
                o.OrderExplain = "购买" + pb.IdSelectPrice(price).Rows[0]["Type"] + "云隧道";
                o.CreateTime = datetime.ToString();
                o.TradingStatus = "已付款";
                result = ob.InsertOrder(o);
                ///这里修改免费版到期时间
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

            //轮询订单结果
            //根据业务需要，选择是否新起线程进行轮询
            ParameterizedThreadStart ParStart = new ParameterizedThreadStart(LoopQuery);
            Thread myThread = new Thread(ParStart);
            object o = code;
            myThread.Start(o);

            return View();
        }

        /// <summary>
        /// 轮询
        /// </summary>
        /// <param name="o">订单号</param>
        public void LoopQuery(object o)
        {
            ConfigBLL cb = new ConfigBLL();

            int count = 100;
            int interval = 10000;
            IAopClient client = new DefaultAopClient(cb.SelectValue("serverUrl"), cb.SelectValue("appId"), cb.SelectValue("merchant_private_key"), "json", "1.0", "RSA2", cb.SelectValue("alipay_public_key"), "GBK", false);
            AlipayTradeQueryRequest request = new AlipayTradeQueryRequest();
            request.BizContent = "{" +
            "\"out_trade_no\":\"" + o.ToString() + "\"," +
            "\"trade_no\":\"'\"," +
            "  }";
            for (int i = 1; i <= count; i++)
            {
                Thread.Sleep(interval);
                AlipayTradeQueryResponse response = client.Execute(request);
                //queryResult = serviceClient.tradeQuery(out_trade_no);
                //if (queryResult != null)
                //{
                    if (response.TradeStatus == "TRADE_SUCCESS")
                    {
                        DoSuccessProcess(o.ToString());
                        return;
                    }
                //}
            }
            DoFailedProcess(o.ToString());
            
            
            
  
        }

        /// <summary>
        /// 请添加支付成功后的处理
        /// </summary>
        private void DoSuccessProcess(string no)
        {
            //支付成功，请更新相应单据
        }
        /// <summary>
        /// 请添加支付失败后的处理
        /// </summary>
        private void DoFailedProcess(string no)
        {

            //支付失败，请更新相应单据
            
        }
    }
}