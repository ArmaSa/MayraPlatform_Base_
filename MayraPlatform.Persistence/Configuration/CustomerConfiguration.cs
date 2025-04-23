using MayraPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace MayraPlatform.Persistence.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.LastName)
                .HasMaxLength(100);

            builder.Property(c => c.UserId)
                .IsRequired();

            builder.Property(c => c.Status);

            builder.HasOne(c => c.CustomerGroup)
                .WithMany(g => g.Customers) // فرض بر اینه که در CustomerGroup یه ICollection<Customer> Customers هست
                .HasForeignKey(c => c.CustomerGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Addresses)
                .WithMany(a => a.Customers)
                .UsingEntity(j => j.ToTable("CustomerAddresses"));

            builder.HasOne(c => c.ApplicationUser)
                   .WithOne() 
                   .HasForeignKey<Customer>(c => c.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
