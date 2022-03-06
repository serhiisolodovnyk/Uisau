using Microsoft.EntityFrameworkCore;
using Uisau.Data.Configurations;
using Uisau.Models;

namespace Uisau.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Account> Accounts { get; set; }
    
    public DbSet<Car> Cars { get; set; }
    
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<RepairShop> RepairShops { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}