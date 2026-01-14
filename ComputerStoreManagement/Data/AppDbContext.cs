using Microsoft.EntityFrameworkCore;
using ComputerStoreManagement.Models;

namespace ComputerStoreManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Import> Imports { get; set; }
        public DbSet<ImportDetail> ImportDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints
            modelBuilder.Entity<User>()
                .HasOne(u => u.Employee)
                .WithMany(e => e.Users)
                .HasForeignKey(u => u.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Employee)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Import>()
                .HasOne(i => i.Supplier)
                .WithMany(s => s.Imports)
                .HasForeignKey(i => i.SupplierId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Import>()
                .HasOne(i => i.Employee)
                .WithMany(e => e.Imports)
                .HasForeignKey(i => i.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ImportDetail>()
                .HasOne(id => id.Import)
                .WithMany(i => i.ImportDetails)
                .HasForeignKey(id => id.ImportId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ImportDetail>()
                .HasOne(id => id.Product)
                .WithMany(p => p.ImportDetails)
                .HasForeignKey(id => id.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure decimal precision
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.CostPrice)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.SellPrice)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.Subtotal)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.DiscountPercent)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.DiscountAmount)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(15, 2);

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.UnitPrice)
                .HasPrecision(15, 2);

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.Subtotal)
                .HasPrecision(15, 2);

            modelBuilder.Entity<Import>()
                .Property(i => i.TotalAmount)
                .HasPrecision(15, 2);

            modelBuilder.Entity<ImportDetail>()
                .Property(id => id.UnitPrice)
                .HasPrecision(15, 2);

            modelBuilder.Entity<ImportDetail>()
                .Property(id => id.Subtotal)
                .HasPrecision(15, 2);
        }
    }
}
