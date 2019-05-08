using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class Users
    {
        public string DoMain { get; set; }
        public string PassWord { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Version { get; set; }
    }
}
