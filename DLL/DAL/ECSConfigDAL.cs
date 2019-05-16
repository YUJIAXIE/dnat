using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.DAL
{
    public class ECSConfigDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="All">true默认，false行转列</param>
        /// <returns></returns>
        public DataTable SelectCommonFrpConfig(int UId, bool All)
        {
            string sql;
            if (All)
            {
                sql = $@"select MappingName,Info,Value from ecsconfig e
join Users u on e.ecsid = u.ECSId
WHERE u.Id = {UId}";
            }
            else
            {
                sql = $@"SELECT 
   MappingName,
    MAX(CASE WHEN Info = 'server_addr' THEN Value ELSE '' END) AS server_addr,
    MAX(CASE WHEN Info = 'server_port ' THEN Value ELSE '' END) AS server_port,
    MAX(CASE WHEN Info = 'token' THEN Value ELSE '' END) AS token,
MAX(CASE WHEN Info = 'admin_addr' THEN Value ELSE '' END) AS admin_addr,
MAX(CASE WHEN Info = 'admin_port' THEN Value ELSE '' END) AS admin_port,
MAX(CASE WHEN Info = 'admin_user' THEN Value ELSE '' END) AS admin_user,
MAX(CASE WHEN Info = 'admin_pwd' THEN Value ELSE '' END) AS admin_pwd
FROM dbo.ECSConfig e
join Users u on e.ECSId=u.ECSId
 WHERE u.Id={UId}
GROUP BY MappingName";
            }
            return SqlHelper.ExecuteDataTable(sql);
        }
    }
}
