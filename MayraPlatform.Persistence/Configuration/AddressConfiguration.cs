using MayraPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayraPlatform.Persistence.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.City)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Province)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.FullAddress)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(a => a.Floor)
                .IsRequired();

            builder.Property(a => a.Lat)
                .IsRequired();

            builder.Property(a => a.Long)
                .IsRequired();

            builder.HasMany(a => a.Customers)
                   .WithMany(c => c.Addresses)
                   .UsingEntity(j => j.ToTable("CustomerAddresses"));
        }
    }
}
