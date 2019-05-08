using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;
using DLL.Models;

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

        public int InsertUsers(Users users)
        {
            string sql = $"INSERT INTO Users VALUES ('{users.DoMain}','{users.PassWord}','{users.Phone}','{users.Email}','{users.RegDate}','{users.EndDate}','{users.Version}')";
            return SqlHelper.ExecuteNonQuery(sql);
        }

        public object Select(Users Users)
        {
            string sql = $"select login from Users where domain='{Users.DoMain}'and PassWord='{Users.PassWord}'";
            return SqlHelper.ExecuteScalar(sql);

        }
    }
}
