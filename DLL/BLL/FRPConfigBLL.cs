using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DLL.BLL
{
   public class FRPConfigBLL
    {
        DLL.DAL.FRPConfigDAL fd = new DAL.FRPConfigDAL();
        public DataTable SelectCommonFrpConfig()
        {
            return fd.SelectCommonFrpConfig();
        }
        public DataTable SelectUsersFrpConfig(int Id)
        {
            return fd.SelectUsersFrpConfig(Id);
        }
    }
}
