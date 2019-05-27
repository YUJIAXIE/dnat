using DLL.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL
{
    public class TunnelTypeBLL
    {
        TunnelTypeDAL ttd = new TunnelTypeDAL();
        /// <summary>
        /// 查询所有的隧道类型
        /// </summary>
        /// <returns></returns>
        public DataTable SelectTunnelType()
        {
            return ttd.SelectTunnelType();
        }
    }
}
