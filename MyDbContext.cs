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

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //設定Id為識別欄位
            modelBuilder.Entity<Order>()
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Order>()
                .ToTable("TbOrder") //指定表名
                .HasKey(o => o.Id); //指定主键，其實預設就是抓Id欄位，除非你的主鍵不是叫Id

            // 設定表的索引
            modelBuilder.Entity<Order>().HasIndex(o => o.Id);

            // 設定 OrderDate 預設值為 2000-01-01 00:00:00
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate).HasDefaultValue(new DateTime(2000, 1, 1));

            // 設定 Order 和 OrderDetail 之間的關聯關係
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);
            
            //忽略了OrderDetails屬性。不會被映射到資料庫的表格中
            modelBuilder.Entity<Order>().Ignore(o => o.OrderDetails);

            //efcore若不設定主鍵(設定HasNoKey)，會無法對table追蹤，也就不能做增刪改查
            modelBuilder.Entity<OrderDetail>()
                .ToTable("TbOrderDetail")
                .HasKey(od => od.Id);
                // .HasNoKey();
            
            modelBuilder.Entity<Customer>()
                .ToTable("TbCustomer")
                .HasKey(o => o.Cid);

            modelBuilder.Entity<Customer>()
                .Property(o => o.Cid)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Product>()
                .ToTable("TbProduct")
                .HasKey(o => o.Pid);
            
            modelBuilder.Entity<Product>()
                .Property(o => o.Pid)
                .ValueGeneratedOnAdd();
            
        }

    }
}