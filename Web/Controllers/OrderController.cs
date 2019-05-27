using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using DLL.BLL;
using DLL.Models;
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

            IAopClient client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", "app_id", "merchant_private_key", "json", "1.0", "RSA2", "alipay_public_key", "GBK", false);
            AlipayTradePrecreateRequest request = new AlipayTradePrecreateRequest();
            request.BizContent = "{" +
            "\"out_trade_no\":\"20150320010101001\"," +
            "\"seller_id\":\"2088102146225135\"," +
            "\"total_amount\":88.88," +
            "\"discountable_amount\":8.88," +
            "\"subject\":\"Iphone6 16G\"," +
            "      \"goods_detail\":[{" +
            "        \"goods_id\":\"apple-01\"," +
            "\"goods_name\":\"ipad\"," +
            "\"quantity\":1," +
            "\"price\":2000," +
            "\"goods_category\":\"34543238\"," +
            "\"categories_tree\":\"124868003|126232002|126252004\"," +
            "\"body\":\"特价手机\"," +
            "\"show_url\":\"http://www.alipay.com/xxx.jpg\"" +
            "        }]," +
            "\"body\":\"Iphone6 16G\"," +
            "\"product_code\":\"FACE_TO_FACE_PAYMENT\"," +
            "\"operator_id\":\"yx_001\"," +
            "\"store_id\":\"NJ_001\"," +
            "\"disable_pay_channels\":\"pcredit,moneyFund,debitCardExpress\"," +
            "\"enable_pay_channels\":\"pcredit,moneyFund,debitCardExpress\"," +
            "\"terminal_id\":\"NJ_T_001\"," +
            "\"extend_params\":{" +
            "\"sys_service_provider_id\":\"2088511833207846\"," +
            "\"industry_reflux_info\":\"{\\\\\\\"scene_code\\\\\\\":\\\\\\\"metro_tradeorder\\\\\\\",\\\\\\\"channel\\\\\\\":\\\\\\\"xxxx\\\\\\\",\\\\\\\"scene_data\\\\\\\":{\\\\\\\"asset_name\\\\\\\":\\\\\\\"ALIPAY\\\\\\\"}}\"," +
            "\"card_type\":\"S0JP0000\"" +
            "    }," +
            "\"timeout_express\":\"90m\"," +
            "\"settle_info\":{" +
            "        \"settle_detail_infos\":[{" +
            "          \"trans_in_type\":\"cardAliasNo\"," +
            "\"trans_in\":\"A0001\"," +
            "\"summary_dimension\":\"A0001\"," +
            "\"settle_entity_id\":\"2088xxxxx;ST_0001\"," +
            "\"settle_entity_type\":\"SecondMerchant、Store\"," +
            "\"amount\":0.1" +
            "          }]" +
            "    }," +
            "\"merchant_order_no\":\"20161008001\"," +
            "\"business_params\":{" +
            "\"campus_card\":\"0000306634\"" +
            "    }," +
            "\"qr_code_timeout_express\":\"90m\"" +
            "  }";
            AlipayTradePrecreateResponse response = client.execute(request);
            Console.WriteLine(response.Body);



            int result = ob.InsertOrder(o);
            if (result > 0)
                return Content(o.OrderId);
            else
                return Content("404");
        }
        public ActionResult DoPay(string code)
        {
            return Content("");
        }
    }
}