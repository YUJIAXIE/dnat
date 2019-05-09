using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DLL.DAL
{
    public class FRPConfigDAL
    {
        public DataTable SelectCommonFrpConfig()
        {
            string sql = $@"SELECT 
   MappingName,
    MAX(CASE WHEN Info = 'server_addr' THEN Value ELSE '' END) AS server_addr,
    MAX(CASE WHEN Info = 'server_port ' THEN Value ELSE '' END) AS server_port,
    MAX(CASE WHEN Info = 'token' THEN Value ELSE '' END) AS token
FROM dbo.FRPConfig WHERE UId=0
GROUP BY MappingName";
            return SqlHelper.ExecuteDataTable(sql);
        }
        public DataTable SelectUsersFrpConfig(int Id)
        {
            string sql = $@"SELECT 
   MappingName,
    MAX(CASE WHEN Info = 'type' THEN Value ELSE '' END) AS type,
    MAX(CASE WHEN Info = 'local_ip' THEN Value ELSE '' END) AS local_ip,
    MAX(CASE WHEN Info = 'local_port' THEN Value ELSE '' END) AS local_port,
	MAX(CASE WHEN Info = 'remote_port' THEN Value ELSE '' END) AS remote_port,
    MAX(CASE WHEN Info = 'custom_domains' THEN Value ELSE '' END) AS custom_domains
FROM dbo.FRPConfig WHERE UId={Id} 
GROUP BY MappingName";
            return SqlHelper.ExecuteDataTable(sql);
        }
    }
}
