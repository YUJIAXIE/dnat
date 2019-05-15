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
        public DataTable SelectConfig()
        {
            string sql = "select * from Config";
            return SqlHelper.ExecuteDataTable(sql);
        }
    }
}
