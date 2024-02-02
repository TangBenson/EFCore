using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        /// <summary>
        /// 外鍵，對應Order.Id，命名規則要符合EFCore的預設規則，否則他不爽會幫你另新增一個欄位
        /// </summary>
        /// <value></value>
        public int OrderId { get; set; }
        public string Product { get; set; } = "";
        public int Amount { get; set; }
        public Order Order { get; set; } = new();
    }
}