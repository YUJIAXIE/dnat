using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;
using DLL.Models;
using System.Data;

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
            string sql = $"INSERT INTO Users VALUES ('{users.DoMain}','{users.PassWord}','{users.Phone}','{users.Email}','{users.RegDate}','{users.EndDate}','{users.Version}',{users.Login})";
            return SqlHelper.ExecuteNonQuery(sql);
        }

        public DataTable SelectUsers(Users Users)
        {
            string sql = $@"select u.id,u.DoMain,u.RegDate,u.EndDate,u.Login,c.Value,c1.Value as DoMainName from Users u
join config c on u.version=c.id
join config c1 on c1.info='DomainName' where domain ='{Users.DoMain}'and PassWord='{Users.PassWord}'";
            return SqlHelper.ExecuteDataTable(sql);

        }
    }
}
