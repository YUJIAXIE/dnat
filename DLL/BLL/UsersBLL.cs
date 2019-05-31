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
        public bool IsValidPhone(string Phone)
        {
            return ud.IsValidPhone(Phone);
        }
        public int InsertUsers(Users users)
        {
            return ud.InsertUsers(users);
        }
        /// <summary>
        /// 登录查询信息
        /// </summary>
        /// <param name="Users"></param>
        /// <returns></returns>
        public DataTable SelectUsers(Users Users)
        {
            return ud.SelectUsers(Users);

        }
        public int UpdatePwd(Users Users)
        {
            return ud.UpdatePwd(Users);
        }
        /// <summary>
        /// 购买修改信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUser(Users user)
        {
            return ud.UpdateUser(user);
        }
    }
}
