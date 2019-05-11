using DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DLL.BLL
{
    public class UsersBLL
    {
        DAL.UsersDAL ud = new DAL.UsersDAL();
        public bool IsValidDoMain(string DoMain)
        {
            return ud.IsValidDoMain(DoMain);
        }
        public int InsertUsers(Users users)
        {
            return ud.InsertUsers(users);
        }
        public DataTable SelectUsers(Users Users)
        {
            return ud.SelectUsers(Users);

        }

        public int UpdatePwd(Users Users)
        {
            return ud.UpdatePwd(Users);
        }
    }
}
