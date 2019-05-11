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
        public int Login { get; set; }
    }
}
