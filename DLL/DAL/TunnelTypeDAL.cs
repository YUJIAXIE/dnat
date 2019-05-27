using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DLL.DAL
{
    public class TunnelTypeDAL
    {
        /// <summary>
        /// 查询所有的隧道类型
        /// </summary>
        /// <returns></returns>
        public DataTable SelectTunnelType()
        {
            string Sql = $"select * from TunnelType";
            return SqlHelper.ExecuteDataTable(Sql);
        }
    }
}
