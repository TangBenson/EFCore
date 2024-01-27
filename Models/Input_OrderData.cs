using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models
{
    //訂單資訊
    public class Input_OrderData
    {
        public List<string> Product { get; set; } = new();
        public string Status { get; set; } = "";
        public string Amount { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public string CustomerPhone { get; set; } = "";
        public string CustomerAddress { get; set; } = "";

    }
}