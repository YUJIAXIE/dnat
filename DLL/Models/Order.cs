using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public int UserId { get; set; }
        public int PriceId { get; set; }
        public string OrderExplain { get; set; }
        public string CreateTime { get; set; }
        public string PayTime { get; set; }
        public string TradingStatus { get; set; }
    }
}
