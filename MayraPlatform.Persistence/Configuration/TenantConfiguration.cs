using MayraPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayraPlatform.Persistence.Configuration
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("Tenant");
            builder.HasMany(t => t.Users)
                .WithOne(u => u.UserTenant)
                .HasForeignKey(u => u.TenantId);
        }
    }
}
