using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DLL.Models;

namespace DLL.DAL
{
    public class OrderDLL
    {
        /// <summary>
        /// 用户查询订单
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        public DataTable SelectOrder(string UId)
        {
            string Sql = $@"SELECT * FROM [Order] o
JOIN Price p ON o.PriceId = P.Id
JOIN TunnelType t on p.TId = t.Id
WHERE o.UserId = '{UId}'";
            return SqlHelper.ExecuteDataTable(Sql);
        }
        /// <summary>
        /// 插入订单信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int InsertOrder(Order order)
        {
            string Sql = $"INSERT INTO [Order] VALUES ('{order.OrderId}','{order.UserId}','{order.PriceId}','{order.OrderExplain}','{order.CreateTime}','{order.PayTime}','{order.TradingStatus}')";
            return SqlHelper.ExecuteNonQuery(Sql);
        }
    }
}
