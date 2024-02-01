using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Entities
{
    public class Customer
    {
        public int Cid { get; set; }
        public string Name { get; set; } = "";
        public string PHone { get; set; } = "";
        public string Address { get; set; } = "";
        public int BuyCount { get; set; }
    }
}