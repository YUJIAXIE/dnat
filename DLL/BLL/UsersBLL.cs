using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL
{
    public class UsersBLL
    {
        DAL.UsersDAL ud = new DAL.UsersDAL();
        public bool IsValidDoMain(string DoMain)
        {
            return ud.IsValidDoMain(DoMain);
        }
    }
}
