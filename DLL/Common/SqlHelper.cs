using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DLL
{
    /// <summary>
    /// 数据库访问通用类
    /// </summary>
    public static class SqlHelper
    {
        /// <summary>
        /// 设定数据库访问字符串
        /// </summary>
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["Condb"].ToString();

        /// <summary>
        /// 执行一个查询，并返回查询结果
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者sql文本命令</param>
        /// <returns>返回查询结果集</returns>
        public static DataTable ExecuteDataTable(string sql, CommandType commandType)
        {
            return ExecuteDataTable(sql, commandType, null);
        }

        /// <summary>
        /// 执行一个查询，并返回结果集
        /// </summary>
        /// <param name="sql">要执行的sql文本命令</param>
        /// <returns>返回查询的结果集</returns>
        public static DataTable ExecuteDataTable(string sql)
        {
            return ExecuteDataTable(sql, CommandType.Text, null);
        }


        /// <summary>
        /// 执行一个查询，并返回查询结果
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="commandtype">要执行查询语句的类型，如存储过程或者sql文本命令</param>
        /// <param name="parameters">Transact-SQL语句或者存储过程参数数组</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, CommandType commandtype, SqlParameter[] parameters)
        {
            DataTable data = new DataTable(); //实例化datatable，用于装载查询结果集
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = commandtype;//设置command的commandType为指定的Commandtype
                    //如果同时传入了参数，则添加这些参数
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                    }
                    //通过包含查询sql的sqlcommand实例来实例化sqldataadapter
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(data);//填充datatable
                }
            }
            return data;
        }

        /// <summary>
        /// 返回一个SqlDataReader对象的实例
        /// </summary>
        /// <param name="sql">要执行的SQl查询命令</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, CommandType.Text, null);
        }

        /// <summary>
        /// 返回一个SqlDataReader对象的实例
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="commandType">要执行查询语句的类型，如存储过程或者SQl文本命令</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, CommandType commandType)
        {
            return ExecuteReader(sql, commandType, null);
        }

        /// <summary>
        /// 返回一个sqldatareader对象的实例
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            con.Open();
            //CommandBehavior.CloseConnection参数指示关闭reader对象时关闭与其关联的Connection对象
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 执行一个查询，返回结果集的首行首列。忽略其他行，其他列
        /// </summary>
        /// <param name="sql">要执行的SQl命令</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, CommandType.Text, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, CommandType commandType)
        {
            return ExecuteScalar(sql, commandType, null);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandType">参数类型</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con) { CommandType = commandType };
            if (parameters != null)
            {
                foreach (SqlParameter parapmeter in parameters)
                {
                    cmd.Parameters.Add(parapmeter);
                }
            }
            con.Open();
            var result = cmd.ExecuteScalar();
            con.Close();
            cmd.Parameters.Clear();
            return result;
        }

        /// <summary>
        /// 对数据库进行增删改的操作
        /// </summary>
        /// <param name="sql">要执行的sql命令</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, CommandType.Text, null);
        }

        /// <summary>
        /// 对数据库进行增删改的操作
        /// </summary>
        /// <param name="sql">对数据库进行操作的sql命令</param>
        /// <param name="commandType">要执行查询语句的类型，如存储过程或者sql文本命令</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, CommandType commandType)
        {
            return ExecuteNonQuery(sql, commandType, null);
        }

        /// <summary>
        /// 对数据库进行增删改的操作
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="commandType">要执行的查询语句类型，如存储过程或者sql文本命令</param>
        /// <param name="parameters">Transact-SQL语句或者存储过程的参数数组</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con) { CommandType = commandType };
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            con.Open();
            var count = cmd.ExecuteNonQuery();
            con.Close();
            return count;
        }

        /// <summary>
        /// 返回当前连接的数据库中所有用户创建的数据表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTables()
        {
            DataTable table;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                table = con.GetSchema("Tables");

            }
            return table;
        }
    }
}
