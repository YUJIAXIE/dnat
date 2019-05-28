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
using QRCoder;

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
            OrderBLL ob = new OrderBLL();
            var datetime = DateTime.Now;
            PriceBLL pb = new PriceBLL();
            Order o = new Order();
            o.OrderId = datetime.ToString("yyyyMMddHHmmssfff");
            o.UserId = (int)Session["Id"];
            o.PriceId = price;
            o.OrderExplain = "购买" + pb.IdSelectPrice(price).Rows[0]["Type"] + "云隧道";
            o.CreateTime = datetime.ToString();
            o.TradingStatus = "待付款";

            IAopClient client = new DefaultAopClient("https://openapi.alipaydev.com/gateway.do", "2016092300579608", "MIIEpAIBAAKCAQEAy6gXs946Jac4A41mLpRXs6U1k5mGmL+tIFYDHPRY37NRXKW6XMzvSHPSZ59oINKio+OKcewGlqjxTdGdhcS3Is0kAw37iTYM8V1zgvtR0GvKPA8NXubKcNo10Y7zq+At2qKD22KcUCUAzLOpLt7zon/FD1RLZMMIKRtAFSNlmCnDUKAUb72nAqRKa2hpjzykoDNWKpJdQ3NxMqkr1N5HcsKMFc2+MfKERVKhCLi2jVkfV4rCdglcOG/6tOgK6nGD2zAhuLSWbij44jpTLsfqs8lB809YjA5STPQsQR8KpSzDtDERP/max6jN+oCAVAVFgxohzYolKFRJs8zT8ZBtQwIDAQABAoIBACzB5WunRDowNNQ7CCDmgxu9DDhC/lyli2PW41pCrSGEpDXrSjjI5TGUGsKhOt4zzICeKjf9Ojl0KYwDrE3QvLrOQMLXGNe/5DpLYm5/0ywt9EUcvcCEkisZGcjTVOQKIamyG65kTpwidbmHJoBhiUPGNsW2rdcYMbvu/DdpDxPQfWL8uV8UikgwbFL+thmRMdRNuksMW6QzSk6Bu+VHZx2S3YXlgl16yUXQsE4SXEtJOlVFH7nF1Qie4qQPEla+F7kfsKhnKWYmo6V7Qqr/iWU+lS31rD+bT6x594AvbBq55/kN/JRDAuwWqnQhQzySPA3m04Aldmkm3Z3ewZatQvkCgYEA7kuPmA8mldlKGsWy7BWgRAjBWAm54gpXUcfaQg5e5Dv6tbetaBL7znLhIq45ddsKptZREVwb9gQK2FTGPS0q6R3MvexGbJD8KYND6hOdbVPOzN81lB+/nwQX5NGOlQX+eOZ6psiTD8JbjdYb+VekFdZIw4EAfvoX+U4ihC+EPg8CgYEA2smyb9UQsEelAX+VOn9UMJMv+BtcEX4y6vgzRrc9/V5z44HH0R4ktsVqZkqqlFRuryIpVviFGrpXiE+SXBztnoEJtKs/1H1RmyF70fNm1/AOLdSUJ+ZMeTz+Z9pevX9dc8F3iafOgBZ/Ifux8dQqkrpB1ea17qcBajW0Rk/w0Y0CgYEAhsm6yVoYiz5DSm11TVDWPGVvZ6rot9D9n0aaUC7swdCjeVISBgJm6FnWutUtr1pc5g3oARfGwRt8Pu2EzGnWEdJHU05ob1R7LcgQDEFYFNUI7p17IvPqYbnhAg7+xZCEZkKIMfrWJF3dh5cKb7mBGNECi4NWknxIPz5RC9AMz0UCgYAf+1PmHRMvcYmhSnEZ9/rqjtl4PyeaNwRibJ2yPJ8HJoNyQkpfOzTKstj20vtUa3Myjp/UYseyPIMHHfqbFG93uA0fJ9lQynDfaGmdKyNhdWndMTHnEzcikdPugnFO6gtTHHjI2orJFoDHCu/cFdOTVz7AcdUuaaM/T1Jm5NCjEQKBgQCdg9NZuC4O1zi6O7eA4tNOEH7eaqT/PGvPExVcMR7Z0MbClfXxXyTLzmQKs8UBBI2WA2AS/UDITZ3hWppSigEK8lWyoOuxWlUa7l8MUQnh8wa/4JvnOV+YN1Ks3lFpHgkihiThEshZ4D2J78iT4HB30dkDu/5h5fi+wxjEEeeP4Q==", "json", "1.0", "RSA2", "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAp9X1KK4CmE1vuVsF/f+Bk3w462ORcr2mtcaQDoEg2cd0YjrO6O3CMnjkSMDms0lJZanIDJLlKsJfZT9X+IjUm6vS9U2e3DmKfIrUc4CmihvogNLTL5IQ0lWbX5SJT/blcVYK7Vjt3M/2Zjc72z95mslY62vCdzZe4/zzDmM5cNp4/MkfGVix4blovdjb0hZRePFzXwRth7UiTYvHr9ECixUX10HIfTE+Bblw4JiOhT3eSeey+YXqOu7H2M6cWr7oRSYOXkzkFSf3lnngichsa3x0PDkMfNAeIre18kUmeTj29LGdl1pkJJoJ/eH49BBu/NxYBObu6Eg71vGf6MH6KwIDAQAB", "GBK", false);
            AlipayTradePrecreateRequest request = new AlipayTradePrecreateRequest();
            request.BizContent = "{" +
            "\"out_trade_no\":\"20150320010101001\"," +
            "\"total_amount\":88.88," +
            "\"subject\":\"Iphone6 16G\"," +
            "\"qr_code_timeout_express\":\"1m\"" +
            "  }";
            AlipayTradePrecreateResponse response = client.Execute(request);
            //var result = response.Body;
            switch (response.Code)
            {
                case "10000":
                    DoWaitProcess(response.QrCode);
                    break;

            }


            int result = ob.InsertOrder(o);
            if (result > 0)
                return Content(o.OrderId);
            else
                return Content("404");
        }


        /// <summary>
        /// 生成二维码并展示到页面上
        /// </summary>
        /// <param name="precreateResult">二维码串</param>
        private void DoWaitProcess(string precreateResult)
        {
            //打印出 preResponse.QrCode 对应的条码
            Bitmap bt;
            string enCodeString = precreateResult;
            QRCodeGenerator qq = new QRCodeGenerator();
            QRCodeData data = qq.CreateQrCode(enCodeString, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            bt = code.GetGraphic(5, Color.Black, Color.White, null, 15, 6, false);
            
            //memo
            //QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            //qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            //qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
            //qrCodeEncoder.QRCodeScale = 3;
            //qrCodeEncoder.QRCodeVersion = 8;
            //bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
            string filename = System.DateTime.Now.ToString("yyyyMMddHHmmss") + "0000" + (new Random()).Next(1, 10000).ToString()
             + ".jpg";
            bt.Save(Server.MapPath("~/images/") + filename);
            //this.Image1.ImageUrl = "~/images/" + filename;

            //轮询订单结果
            //根据业务需要，选择是否新起线程进行轮询
            //ParameterizedThreadStart ParStart = new ParameterizedThreadStart(LoopQuery);
            //Thread myThread = new Thread(ParStart);
            //object o = precreateResult.response.OutTradeNo;
            //myThread.Start(o);

        }
        public ActionResult DoPay(string code)
        {
            return Content("");
        }
    }
}