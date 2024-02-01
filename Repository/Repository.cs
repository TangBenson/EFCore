using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Entities;

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
                var orderData = data as Order;
                await _context.Orders.AddAsync(orderData!);
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