using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;

namespace DLL.DAL
{
    public class UsersDAL
    {
        public bool IsValidDoMain(string DoMain)
        {
            string sql = $"select domain from Users where domain='{DoMain}'";
            var doMain = SqlHelper.ExecuteScalar(sql);
            if (doMain == null)
                return false;
            else
                return true;
        }
    }
}
