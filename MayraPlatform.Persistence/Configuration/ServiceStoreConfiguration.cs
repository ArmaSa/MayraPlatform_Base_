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
    public class ServiceStoreConfiguration : IEntityTypeConfiguration<ServiceStore>
    {
        public void Configure(EntityTypeBuilder<ServiceStore> builder)
        {
            builder.ToTable("ServiceStores");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.StoreDiscount)
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.ServiceTimes)
                .HasMaxLength(1000);

            builder.HasOne(s => s.Service)
                .WithMany(s => s.ServiceStores)
                .HasForeignKey(s => s.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Store)
                .WithMany(c=> c.ServiceStores)
                .HasForeignKey(s => s.StoreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
