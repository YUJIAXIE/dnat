using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DLL.Models;

namespace DLL.DAL
{
    public class FRPConfigDAL
    {

        public DataTable SelectUsersFrpConfig(int UId, bool All)
        {
            string sql;
            if (All)
            {
                sql = $"select MappingName,Info,Value from FRPConfig WHERE UId='{UId}'";
            }
            else
            {
                sql = $@"SELECT 
   MappingName,
    MAX(CASE WHEN Info = 'type' THEN Value ELSE '' END) AS type,
    MAX(CASE WHEN Info = 'local_ip' THEN Value ELSE '' END) AS local_ip,
    MAX(CASE WHEN Info = 'local_port' THEN Value ELSE '' END) AS local_port,
	MAX(CASE WHEN Info = 'remote_port' THEN Value ELSE '' END) AS remote_port,
    MAX(CASE WHEN Info = 'custom_domains' THEN Value ELSE '' END) AS custom_domains
FROM dbo.FRPConfig WHERE UId={UId} 
GROUP BY MappingName";
            }
            return SqlHelper.ExecuteDataTable(sql);
        }

        public int DeleteUsersFrpConfig(FrpConfig frp)
        {
            string sql = $"delete FRPConfig where UId='{frp.UId}' and MappingName='{frp.MappingName}'";
            return SqlHelper.ExecuteNonQuery(sql);
        }

        public int InsertUsersFrpConfig(FrpConfig frp)
        {
            string sql = $"INSERT INTO FRPConfig VALUES ('{frp.UId}','{frp.MappingName}','{frp.Info}','{frp.Value}')";
            return SqlHelper.ExecuteNonQuery(sql);
        }

        public string SelectMax(string UId)
        {
            string sql = $"select MAX(MappingName)+1 as MappingName from FRPConfig WHERE  UId ={UId}";
            var Max = SqlHelper.ExecuteScalar(sql).ToString();
            if (Max == "")
            {
                return "1";
            }
            else
            {
                return Max.ToString();
            }
        }
        /// <summary>
        /// 根据类型查询数量
        /// </summary>
        /// <param name="Type">类型</param>
        /// <param name="Uid">客户id</param>
        /// <returns>数量</returns>
        public int SelectCount(string Type,string UId)
        {
            string sql = $"select count(*) from FRPConfig where value='{Type}' and UId='{UId}'";
            return (int)SqlHelper.ExecuteScalar(sql);
        }
    }
}
