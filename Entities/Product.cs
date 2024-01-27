using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = "";
        public int Price { get; set; }
        public int SupplierId { get; set; }
    }
}