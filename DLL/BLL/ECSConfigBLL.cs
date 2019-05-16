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
        /// 
        /// </summary>
        /// <param name="All">true默认，false行转列</param>
        /// <returns></returns>
        public DataTable SelectCommonFrpConfig(int UId, bool All)
        {
            return ed.SelectCommonFrpConfig(UId, All);
        }
    }
}
