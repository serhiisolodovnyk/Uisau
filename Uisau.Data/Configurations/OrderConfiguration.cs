using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uisau.Models;

namespace Uisau.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(order => order.Id);

        builder
            .HasOne(order => order.Car)
            .WithMany(car => car.Orders)
            .HasForeignKey(order => order.CarId);

        builder
            .HasOne(order => order.RepairShop)
            .WithMany(shop => shop.Orders)
            .HasForeignKey(order => order.RepairShopId);
    }
}