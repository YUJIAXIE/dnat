using DLL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL
{
    public class PriceBLL
    {
        PriceDAL pd = new PriceDAL();
        /// <summary>
        /// 根据隧道类型id查询
        /// </summary>
        /// <param name="TId"></param>
        /// <returns></returns>
        public DataTable TIdSelectPrice(int TId)
        {
            return pd.TIdSelectPrice(TId);
        }
        /// <summary>
        /// 根据Id查询价格
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable IdSelectPrice(int id)
        {
            return pd.IdSelectPrice(id);
        }
    }
}
