using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uisau.Models;

namespace Uisau.Data.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(car => car.Id);
        builder.HasIndex(car => car.VinCode).IsUnique();

        builder
            .HasOne(car => car.Customer)
            .WithMany(customer => customer.Cars)
            .HasForeignKey(car => car.CustomerId);
    }
}