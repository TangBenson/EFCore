using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Entities
{
    public class OrderDetail
    {
        public int Ids { get; set; }
        public string Product { get; set; } = "";
        public int Amount { get; set; }
        public int Price { get; set; }
        public Order Order { get; set; } = new();
    }
}