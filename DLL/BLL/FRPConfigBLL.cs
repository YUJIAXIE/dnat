using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DLL.Models;

namespace DLL.BLL
{
   public class FRPConfigBLL
    {
        DLL.DAL.FRPConfigDAL fd = new DAL.FRPConfigDAL();
       
        public DataTable SelectUsersFrpConfig(int UId,bool All)
        {
            return fd.SelectUsersFrpConfig(UId, All);
        }

        public int DeleteUsersFrpConfig(FrpConfig frp)
        {
            return fd.DeleteUsersFrpConfig(frp);
        }

        public int InsertUsersFrpConfig(FrpConfig frp)
        {
            return fd.InsertUsersFrpConfig(frp);
        }
        public string SelectMax(string UId)
        {
            return fd.SelectMax(UId);
        }
    }
}
