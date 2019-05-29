using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string DoMain { get; set; }
        public string PassWord { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string RegDate { get; set; }
        public string EndDate { get; set; }
        public int Version { get; set; }
        public int ECSId { get; set; }
        public int TId { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 是否为C/S登录
        /// </summary>
        public bool Client { get; set; }
    }
}
