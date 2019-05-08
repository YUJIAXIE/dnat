using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.BLL
{
    public class ConfigBLL
    {
        DAL.ConfigDAL cd = new DAL.ConfigDAL();
        public int ProbationPeriod()
        {
            return cd.ProbationPeriod();
        }
    }
}
