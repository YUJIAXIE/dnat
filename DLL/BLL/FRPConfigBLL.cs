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
        public DataTable SelectCommonFrpConfig(bool All)
        {
            return fd.SelectCommonFrpConfig(All);
        }
        public DataTable SelectUsersFrpConfig(int Id,bool All)
        {
            return fd.SelectUsersFrpConfig(Id,All);
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
        public bool SelectProt(string UId, string Prot)
        {
            return fd.SelectProt(UId, Prot);
        }
    }
}
