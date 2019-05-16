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
        public string SelectValue(string Info)
        {
            string sql = $"select Value from Config where Info='{Info}'";
            return SqlHelper.ExecuteScalar(sql).ToString();
        }
        public DataTable SelectConfig()
        {
            string sql = "select * from Config";
            return SqlHelper.ExecuteDataTable(sql);
        }
    }
}
