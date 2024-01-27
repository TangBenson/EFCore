using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; } = "";
    }
}