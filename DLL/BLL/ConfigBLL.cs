using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DLL.BLL
{
    public class ConfigBLL
    {
        DAL.ConfigDAL cd = new DAL.ConfigDAL();
        public string SelectValue(string Info)
        {
            return cd.SelectValue(Info);
        }
        public DataTable SelectConfig()
        {
            return cd.SelectConfig();
        }
    }
}
