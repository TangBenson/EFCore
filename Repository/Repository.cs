using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Entities;

namespace EFCore.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext _context;
        public Repository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<string> InsertOther(T data)
        {
            //依照傳入的資料型別，將資料轉換成對應的Entity並寫入資料庫
            if (data is Customer)
            {
                var customerData = data as Customer;
                await _context.Customers.AddAsync(customerData!);
                await _context.SaveChangesAsync();
                return "Customer新增成功";
            }
            else if (data is Product)
            {
                var productData = data as Product;
                await _context.Products.AddAsync(productData!);
                await _context.SaveChangesAsync();
                return "Product新增成功";
            }
            else if (data is Supplier)
            {
                var supplierData = data as Supplier;
                await _context.Suppliers.AddAsync(supplierData!);
                await _context.SaveChangesAsync();
                return "Supplier新增成功";
            }
            else
            {
                return "Error";
            }
        }
    }
}