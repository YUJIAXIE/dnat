using DLL.Models;
using System.Data;

namespace DLL.DAL
{
    public class UsersDAL
    {
        /// <summary>
        /// 验证域名
        /// </summary>
        /// <param name="DoMain"></param>
        /// <returns></returns>
        public bool IsValidDoMain(string DoMain)
        {
            string sql = $"select domain from Users where domain='{DoMain}'";
            var doMain = SqlHelper.ExecuteScalar(sql);
            if (doMain == null)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 验证手机号
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public bool IsValidPhone(string Phone)
        {
            string sql = $"select Phone from Users where Phone='{Phone}'";
            var doMain = SqlHelper.ExecuteScalar(sql);
            if (doMain == null)
                return false;
            else
                return true;
        }
        /// <summary>
        /// 插入信息
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public int InsertUsers(Users users)
        {
            string sql = $"INSERT INTO Users VALUES ('{users.DoMain}','{users.PassWord}','{users.Phone}','{users.Email}','{users.RegDate}','{users.EndDate}','{users.Version}',{users.ECSId})";
            return SqlHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 查询信息
        /// </summary>
        /// <param name="Users"></param>
        /// <returns></returns>
        public DataTable SelectUsers(Users Users)
        {
            string sql = $@"select * from Users u join TunnelType t on t.Id=u.TId where domain ='{Users.DoMain}'and PassWord='{Users.PassWord}'";
            return SqlHelper.ExecuteDataTable(sql);

        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="Users"></param>
        /// <returns></returns>
        public int UpdatePwd(Users Users)
        {
            string sql = $"UPDATE Users SET PassWord = {Users.PassWord} WHERE UId = {Users.Id}";
            return SqlHelper.ExecuteNonQuery(sql);

        }
        /// <summary>
        /// 根据ID查询信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable Select(string id)
        {
            string sql = $@"select * from Users where id ='{id}'";
            return SqlHelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 购买修改信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUser(Users user)
        {
            string Sql = $"UPDATE [Users] SET TId='{user.TId}',EndDate='{user.EndDate}' WHERE Id='{user.Id}'";
            return SqlHelper.ExecuteNonQuery(Sql);
        }
    }
}
