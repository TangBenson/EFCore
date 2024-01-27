using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class Output_OrderData : Output_Common
    {
        public string OrderId { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
    }
}