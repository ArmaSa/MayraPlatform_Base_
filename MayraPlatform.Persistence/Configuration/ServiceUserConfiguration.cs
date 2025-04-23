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
    public class ServiceUserConfiguration : IEntityTypeConfiguration<ServiceUser>
    {
        public void Configure(EntityTypeBuilder<ServiceUser> builder)
        {
            builder.ToTable("ServiceUsers");

            builder.HasKey(su => su.Id);

            builder.Property(su => su.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(su => su.Discount)
                .HasColumnType("decimal(18,2)");

            builder.Property(su => su.DiscountType)
                .IsRequired();

            builder.HasOne(su => su.Service)
                   .WithMany(s => s.ServiceUsers)
                   .HasForeignKey(su => su.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(su => su.Store)
                   .WithMany(c=>c.ServiceUsers) 
                   .HasForeignKey(su => su.StoreId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
