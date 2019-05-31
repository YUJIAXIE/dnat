using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL
{
    public class ECSConfigBLL
    {
        DAL.ECSConfigDAL ed = new DAL.ECSConfigDAL();
        /// <summary>
        /// 查询服务器信息
        /// </summary>
        /// <param name="All">true 行转列，false默认</param>
        /// <returns></returns>
        public DataTable SelectCommonFrpConfig(string UId, bool All)
        {
            return ed.SelectCommonFrpConfig(UId, All);
        }
    }
}
