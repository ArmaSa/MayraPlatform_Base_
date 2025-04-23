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
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Description)
                .HasMaxLength(500);

            builder.HasMany(s => s.ServiceStores)
                   .WithOne(ss => ss.Service)
                   .HasForeignKey(ss => ss.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.ServiceUsers)
                   .WithOne(su => su.Service)
                   .HasForeignKey(su => su.ServiceId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }    
}
