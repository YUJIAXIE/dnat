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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="All">true默认，false行转列</param>
        /// <returns></returns>
        public DataTable SelectCommonFrpConfig(bool All)
        {
            string sql;
            if (All)
            {
                sql = $"select MappingName,Info,Value from FRPConfig WHERE UId=0";
            }
            else
            {
                sql = $@"SELECT 
   MappingName,
    MAX(CASE WHEN Info = 'server_addr' THEN Value ELSE '' END) AS server_addr,
    MAX(CASE WHEN Info = 'server_port ' THEN Value ELSE '' END) AS server_port,
    MAX(CASE WHEN Info = 'token' THEN Value ELSE '' END) AS token
FROM dbo.FRPConfig WHERE UId=0
GROUP BY MappingName";
            }
            return SqlHelper.ExecuteDataTable(sql);
        }
        public DataTable SelectUsersFrpConfig(int Id, bool All)
        {
            string sql;
            if (All)
            {
                sql = $"select MappingName,Info,Value from FRPConfig WHERE UId='{Id}'";
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
FROM dbo.FRPConfig WHERE UId={Id} 
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
        public bool SelectProt(string UId, string Prot)
        {
            string sql = $"select MappingName from FRPConfig where UId='{UId}' AND Value='{Prot}' AND Info='remote_port'";
            var Max = SqlHelper.ExecuteScalar(sql);
            if (Max == "" || Max == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
