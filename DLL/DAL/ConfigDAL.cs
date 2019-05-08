using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DLL.DAL
{
    public class ConfigDAL
    {
        public int ProbationPeriod()
        {
            string sql = $"select Value from Config where Info='ProbationPeriod'";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql));
        }
    }
}
