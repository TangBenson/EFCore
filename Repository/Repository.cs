using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repository
{
    public class Repository : IRepository
    {
        private readonly MyDbContext _context;
        public Repository(MyDbContext context)
        {
            _context = context;
        }
        public string SelectData(int id)
        {
            Console.WriteLine("-----------------------------------------------");
            if (id == 0)
            {
                var data = _context.Products;
                Console.WriteLine("尚未去資料庫取資料，只有SQL語法");
                foreach (var p in data)
                {
                    Console.WriteLine(p.ProductName);
                }
            }
            else if (id == 1)
            {
                var data = _context.Products.Where(p => p.Price > 1000).Select(p => p.ProductName);
                Console.WriteLine("尚未去資料庫取資料，只有SQL語法");
                foreach (var p in data)
                {
                    Console.WriteLine(p);
                }
            }
            else if (id == 2)
            {
                var data = _context.Products.Where(p => p.Price > 1000).Select(p => p.ProductName).ToList();
                Console.WriteLine("已經去資料庫取資料");
                data.ForEach(p => Console.WriteLine(p));
            }
            else
            {
                return "Error";
            }

            return "SelectData";
        }

        public async Task<string> InsertData(object data)
        {
            //依照傳入的資料型別，將資料轉換成對應的Entity並寫入資料庫
            if (data is Order)
            {
                //truncate table 有錯誤
                // using (var transaction = _context.Database.BeginTransaction())
                // {
                //     // 禁用外鍵約束
                //     _context.Database.ExecuteSqlRaw("ALTER TABLE TbOrderDetail NOCHECK CONSTRAINT FK_TbOrderDetail_TbOrder_OrderId");

                //     // efcore的刪除資料方式
                //     // _context.Set<Order>().RemoveRange(_context.Set<Order>());
                //     // _context.SaveChanges();

                //     _context.Database.ExecuteSqlRaw("TRUNCATE TABLE TbOrder");

                //     // 重新啟用外鍵約束
                //     _context.Database.ExecuteSqlRaw("ALTER TABLE TbOrderDetail CHECK CONSTRAINT FK_TbOrderDetail_TbOrder_OrderId");
                //     transaction.Commit();
                // }

                // 刪除表中的所有資料，效能較好，適合大資料
                // _context.Database.ExecuteSqlRaw("DELETE FROM TbOrderDetail"); //或TRUNCATE TABLE TbOrderDetail

                List<Order> orders = new(){
                    new(){Status = "已出貨", TotalPrice = 2000},//吊帶
                    new(){Status = "未出貨", TotalPrice = 2500},//+八字環
                    new(){Status = "已出貨", TotalPrice = 2500},//+d環
                    new(){Status = "未出貨", TotalPrice = 4000},//+jumar
                    new(){Status = "已出貨", TotalPrice = 3500},//+vt
                    new(){Status = "未出貨", TotalPrice = 4000},//+女友
                    new(){OrderDate = new DateTime(2024, 7, 1), Status = "已出貨", TotalPrice = 10000000},//幸福
                    new(){OrderDate = new DateTime(2025, 8, 1), Status = "未出貨", TotalPrice = 2000},//吊帶
                    new(){OrderDate = new DateTime(2026, 9, 1), Status = "已出貨", TotalPrice = 500},//八字環
                    new(){OrderDate = new DateTime(2027, 10, 1), Status = "未出貨", TotalPrice = 500}//d環
                };
                List<OrderDetail> orderDetails = new(){
                    new(){OrderId = 1,Product = "吊帶", Amount = 1},
                    new(){OrderId = 2,Product = "吊帶", Amount = 1},
                    new(){OrderId = 2,Product = "八字環", Amount = 1},
                    new(){OrderId = 3,Product = "吊帶", Amount = 1},
                    new(){OrderId = 3,Product = "d環", Amount = 1},
                    new(){OrderId = 4,Product = "吊帶", Amount = 1},
                    new(){OrderId = 4,Product = "jumar", Amount = 1},
                    new(){OrderId = 5,Product = "吊帶", Amount = 1},
                    new(){OrderId = 5,Product = "vt", Amount = 1},
                    new(){OrderId = 6,Product = "吊帶", Amount = 2},
                    new(){OrderId = 6,Product = "女友", Amount = 1},
                    new(){OrderId = 7,Product = "幸福", Amount = 1},
                    new(){OrderId = 8,Product = "吊帶", Amount = 1},
                    new(){OrderId = 9,Product = "八字環", Amount = 1},
                    new(){OrderId = 10,Product = "d環", Amount = 1}
                };

                await _context.Orders.AddRangeAsync(orders!);
                await _context.OrderDetails.AddRangeAsync(orderDetails!);
                await _context.SaveChangesAsync();
                return "Order新增成功";
            }
            else if (data is Customer)
            {
                var customerData = data as Customer;
                await _context.Customers.AddAsync(customerData!);
                await _context.SaveChangesAsync();
                return "Customer新增成功";
            }
            else if (data is Product)
            {
                List<Product> productData = new(){
                    new(){ProductName = "吊帶", Price = 2000},
                    new(){ProductName = "八字環", Price = 500},
                    new(){ProductName = "d環", Price = 500},
                    new(){ProductName = "jumar", Price = 2000},
                    new(){ProductName = "vt", Price = 1500},
                    new(){ProductName = "女友", Price = 0},
                    new(){ProductName = "幸福", Price = 10000000}
                };
                await _context.Products.AddRangeAsync(productData!);
                await _context.SaveChangesAsync();
                return "Product新增成功";
            }
            else
            {
                return "Error";
            }
        }
    }
}