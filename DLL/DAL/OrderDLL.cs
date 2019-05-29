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
            string Sql = $@"SELECT * FROM [Order] o JOIN Price p ON o.PriceId = P.Id JOIN TunnelType t on p.TId = t.Id WHERE o.UserId = '{UId}' ORDER BY CreateTime DESC";
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
        /// <summary>
        /// 修改订单信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int UpdateOrder(Order order)
        {
            string Sql = $"UPDATE [Order] SET PayTime='{order.PayTime}',TradingStatus='{order.TradingStatus}' WHERE OrderId='{order.OrderId}'";
            return SqlHelper.ExecuteNonQuery(Sql);
        }
        
        /// <summary>
        /// 查询订单表
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataTable SelectOrder(Order order)
        {
            string Sql = $"select o.PayTime,p.Days,p.TId,o.UserId,u.EndDate FROM [Order] o JOIN Price p on o.PriceId = p.Id JOIN Users u on o.UserId = u.Id  WHERE OrderId = '{order.OrderId}'";
            return SqlHelper.ExecuteDataTable(Sql);
        }
    }
}
