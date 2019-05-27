using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DLL.DAL;
using DLL.Models;

namespace DLL.BLL
{
    public class OrderBLL
    {
        OrderDLL od = new OrderDLL();
        /// <summary>
        /// 查询订单信息
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        public DataTable SelectOrder(string UId)
        {
            return od.SelectOrder(UId);
        }
        /// <summary>
        /// 插入订单信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int InsertOrder(Order order)
        {
            return od.InsertOrder(order);
        }
    }
}
