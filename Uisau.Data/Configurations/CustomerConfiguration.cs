using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uisau.Models;

namespace Uisau.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(customer => customer.Id);

        builder
            .HasOne(customer => customer.Account)
            .WithOne()
            .HasForeignKey<Customer>(customer => customer.AccountId);
    }
}