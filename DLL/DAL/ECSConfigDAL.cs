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
        /// 查询服务器信息
        /// </summary>
        /// <param name="All">true 行转列，false默认</param>
        /// <returns></returns>
        public DataTable SelectCommonFrpConfig(string UId, bool All)
        {
            string sql;
            if (All)
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
FROM ECSConfig e
join TunnelType t on t.EcsId=e.ECSId
join Users u on u.TId=t.Id
 WHERE u.Id={UId}
GROUP BY MappingName";

            }
            else
            {
                sql = $@"select MappingName,Info,Value FROM ECSConfig e
join TunnelType t on t.EcsId=e.ECSId
join Users u on u.TId=t.Id
WHERE u.Id = {UId}";
            }
            return SqlHelper.ExecuteDataTable(sql);
        }
    }
}
