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
using ThoughtWorks.QRCode.Codec.Data;
using System.Drawing.Drawing2D;

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
            UsersBLL ub = new UsersBLL();
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
                o.PayTime = datetime.ToString();
                o.TradingStatus = "支付成功";
                result = ob.InsertOrder(o);
                ///免费版
                var tunnel = ob.SelectOrder(o);
                Users u = new Users();
                u.Id = (int)tunnel.Rows[0]["UserId"];
                u.TId = (int)tunnel.Rows[0]["TId"];
                u.EndDate = Convert.ToDateTime(tunnel.Rows[0]["EndDate"]).AddDays((int)tunnel.Rows[0]["Days"]).ToString();
                ub.UpdateUser(u);
            }
            if (result > 0)
                return Content(orderId);
            else
                return Content("404");
        }
        #region 生成图片

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
            //Bitmap bitmap = endocder.Encode(precreateResult, System.Text.Encoding.UTF8);
            System.Drawing.Image image = endocder.Encode(precreateResult);

            CombinImage(image, Server.MapPath("~/QRcode/1226612.png")).Save(Server.MapPath("~/QRcode/") + Name + ".jpg");

        }
        /// <summary>    
        /// 调用此函数后使此两种图片合并，类似相册，有个    
        /// 背景图，中间贴自己的目标图片    
        /// </summary>    
        /// <param name="imgBack">粘贴的源图片</param>    
        /// <param name="destImg">粘贴的目标图片</param>    
        public static System.Drawing.Image CombinImage(System.Drawing.Image imgBack, string destImg)
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(destImg);        //照片图片      
            if (img.Height != 65 || img.Width != 65)
            {
                img = KiResizeImage(img, 65, 65, 0);
            }
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);     

            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }

        /// <summary>    
        /// Resize图片    
        /// </summary>    
        /// <param name="bmp">原始Bitmap</param>    
        /// <param name="newW">新的宽度</param>    
        /// <param name="newH">新的高度</param>    
        /// <param name="Mode">保留着，暂时未用</param>    
        /// <returns>处理以后的图片</returns>    
        public static System.Drawing.Image KiResizeImage(System.Drawing.Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                System.Drawing.Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量    
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }

        #endregion
        public ActionResult DoPay(string code)
        {
            ViewBag.img = code + ".jpg";
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
            "\"trade_no\":\"\"," +
            "\"org_pid\":\"\"" +
            " }";
            AlipayTradeQueryResponse response = new AlipayTradeQueryResponse();
            for (int i = 1; i <= count; i++)
            {
                Thread.Sleep(interval);
                response = client.Execute(request);
                //queryResult = serviceClient.tradeQuery(out_trade_no);
                //if (queryResult != null)
                //{
                if (response.TradeStatus == "TRADE_SUCCESS")
                {
                    DoSuccessProcess(response);
                    return;
                }
                //}
            }
            DoFailedProcess(response);
        }

        /// <summary>
        /// 请添加支付成功后的处理
        /// </summary>
        private void DoSuccessProcess(AlipayTradeQueryResponse no)
        {
            //var id = Session["Id"].ToString();
            //支付成功，请更新相应单据
            OrderBLL ob = new OrderBLL();
            UsersBLL ub = new UsersBLL();
            Order o = new Order();
            o.PayTime = no.SendPayDate;
            o.TradingStatus = "支付成功";
            o.OrderId = no.OutTradeNo;
            //o.UserId = (int)id;
            ob.UpdateOrder(o);
            var tunnel = ob.SelectOrder(o);

            Users u = new Users();
            u.Id = (int)tunnel.Rows[0]["UserId"];
            u.TId = (int)tunnel.Rows[0]["TId"];
            var userTid = (int)ub.SelectUsers(u).Rows[0]["TId"];
            if (u.TId == userTid)
            {
                if (tunnel.Rows[0]["PayTime"].ToString()=="")
                {
                    u.EndDate = Convert.ToDateTime(tunnel.Rows[0]["EndDate"]).AddDays((int)tunnel.Rows[0]["Days"]).ToString();
                }
                
            }
            else
            {
                u.EndDate = DateTime.Now.AddDays((int)tunnel.Rows[0]["Days"]).ToString();

            }
            ub.UpdateUser(u);
        }
        /// <summary>
        /// 请添加支付失败后的处理
        /// </summary>
        private void DoFailedProcess(AlipayTradeQueryResponse no)
        {
            //支付失败，请更新相应单据
            OrderBLL ob = new OrderBLL();
            Order o = new Order();
            o.PayTime = no.SendPayDate;
            o.TradingStatus = "交易关闭";
            o.OrderId = no.OutTradeNo;
            //o.UserId = (int)id;
            ob.UpdateOrder(o);
        }
    }
}