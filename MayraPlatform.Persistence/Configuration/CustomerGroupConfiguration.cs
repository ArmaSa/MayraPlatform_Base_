using MayraPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MayraPlatform.Domain.Entities.Contact;

namespace MayraPlatform.Persistence.Configuration
{
    public class CustomerGroupConfiguration : IEntityTypeConfiguration<CustomerGroup>
    {
        public void Configure(EntityTypeBuilder<CustomerGroup> builder)
        {
            builder.ToTable("CustomerGroups");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(g => g.Status)
                   .IsRequired();

            builder.Property(g => g.GroupType)
                   .HasConversion<int>()
                   .IsRequired();

            builder.HasMany(g => g.Customers)
                   .WithOne(c => c.CustomerGroup)
                   .HasForeignKey(c => c.CustomerGroupId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
