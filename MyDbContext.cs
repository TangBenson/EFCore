using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .ToTable("TbOrder") //指定表名
                .HasKey(o => o.Id); //指定主键

            // 設定表的索引
            modelBuilder.Entity<Order>().HasIndex(o => o.Id);

            // 設定 OrderDate 預設值為 2000-01-01 00:00:00
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate).HasDefaultValue(new DateTime(2000, 1, 1));

            // 設定 Order 和 OrderDetail 之間的關聯關係
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.Ids);
            
            //忽略了OrderDetails屬性。不會被映射到資料庫的表格中
            modelBuilder.Entity<Order>().Ignore(o => o.OrderDetails);

            modelBuilder.Entity<OrderDetail>()
                .ToTable("TbOrderDetail")
                .HasNoKey(); // 指定沒有主鍵
            
            modelBuilder.Entity<Customer>()
                .ToTable("TbCustomer");
            
            modelBuilder.Entity<Product>()
                .ToTable("TbProduct");
            
            modelBuilder.Entity<Supplier>()
                .ToTable("TbSupplier");
        }

    }
}