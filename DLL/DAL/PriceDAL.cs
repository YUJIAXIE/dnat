using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DLL.DAL
{
    public class PriceDAL
    {
        /// <summary>
        /// 根据隧道类型id查询
        /// </summary>
        /// <param name="TId"></param>
        /// <returns></returns>
        public DataTable TIdSelectPrice(int TId)
        {
            string Sql = $"select * from Price where TId='{TId}'";
            return SqlHelper.ExecuteDataTable(Sql);
        }
        /// <summary>
        /// 根据Id查询价格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable IdSelectPrice(int id)
        {
            string Sql = $"select * from Price where Id='{id}'";
            return SqlHelper.ExecuteDataTable(Sql);
        }
    }
}
