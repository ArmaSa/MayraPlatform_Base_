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
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.AliesName)
                   .HasMaxLength(100);

            builder.Property(s => s.Description)
                   .HasMaxLength(500);

            builder.Property(s => s.IsActive);

            builder.Property(s => s.UserId)
                   .IsRequired();

            builder.HasOne(s => s.Address)
                   .WithMany()
                   .HasForeignKey("AddressId")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.ApplicationUser)
                   .WithMany()
                   .HasForeignKey(s => s.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany<ServiceUser>()
                   .WithOne(su => su.Store)
                   .HasForeignKey(su => su.StoreId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany<ServiceStore>()
                   .WithOne(ss => ss.Store)
                   .HasForeignKey(ss => ss.StoreId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
