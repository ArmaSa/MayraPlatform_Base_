using MayraPlatform.Application.Common.Extentions;
using MayraPlatform.Domain.Audit;
using MayraPlatform.Domain.Common;
using MayraPlatform.Domain.Entities;
using MayraPlatform.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MayraPlatform.Persistence.Configuration;

namespace MayraPlatform.Persistence.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long,
    IdentityUserClaim<long>, ApplicationUserRole, IdentityUserLogin<long>,
    IdentityRoleClaim<long>, IdentityUserToken<long>>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ,IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    #region DBSet
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<ApplicationRole> Roles { get; set; }
    public DbSet<ApplicationUserRole> UserRole { get; set; }
    public DbSet<Audit> AuditLogs { get; set; }
    #endregion

    #region override

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationRoleConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationUserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new IdentityUserClaimConfiguration());
        modelBuilder.ApplyConfiguration(new IdentityUserLoginConfiguration());
        modelBuilder.ApplyConfiguration(new IdentityRoleClaimConfiguration());
        modelBuilder.ApplyConfiguration(new IdentityUserTokenConfiguration());
        modelBuilder.ApplyConfiguration(new TenantConfiguration());

        modelBuilder.ApplyConfiguration(new StoreConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerGroupConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceStoreConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceUserConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());


        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
            {
                modelBuilder.Entity(entityType.Name).Property<string>("CreatedBy");
                modelBuilder.Entity(entityType.Name).Property<string>("ModifiedBy");
                modelBuilder.Entity(entityType.Name).Property<DateTime?>("CreatedDateTime");
                modelBuilder.Entity(entityType.Name).Property<DateTime?>("ModifiedDateTime");
            }
        }

        //seed data
        ApplicationDbSeeder.SeedData(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {         
            ChangeTracker.DetectChanges();
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            OnBeforeSaveChanges(userId);

            var timestamp = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity.GetType().GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    entry.Property("ModifiedDateTime").CurrentValue = timestamp;       
                    entry.Property("ModifiedBy").CurrentValue = userId;

                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedDateTime").CurrentValue = timestamp;
                        entry.Property("CreatedBy").CurrentValue = userId;
                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            foreach (var entry in ex.Entries)
            {
                entry.State = EntityState.Detached;
            }
            throw;
        }
    }

    private void OnBeforeSaveChanges(string userId)
    {
        ChangeTracker.DetectChanges();
        var auditEntries = new List<AuditEntry>();
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                continue;
            var auditEntry = new AuditEntry(entry);
            auditEntry.TableName = entry.Entity.GetType().Name;
            auditEntry.UserId = userId;
            auditEntries.Add(auditEntry);
            foreach (var property in entry.Properties)
            {
                string propertyName = property.Metadata.Name;
                if (property.Metadata.IsPrimaryKey())
                {
                    auditEntry.KeyValues[propertyName] = property.CurrentValue;
                    continue;
                }
                switch (entry.State)
                {
                    case EntityState.Added:
                        auditEntry.AuditType = AuditType.Create;
                        auditEntry.NewValues[propertyName] = property.CurrentValue;
                        break;
                    case EntityState.Deleted:
                        auditEntry.AuditType = AuditType.Delete;
                        auditEntry.OldValues[propertyName] = property.OriginalValue;
                        break;
                    case EntityState.Modified:
                        if (property.IsModified)
                        {
                            auditEntry.ChangedColumns.Add(propertyName);
                            auditEntry.AuditType = AuditType.Update;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                        }
                        break;
                }
            }
        }
        foreach (var auditEntry in auditEntries)
        {
            AuditLogs.Add(auditEntry.ToAudit());
        }
    }

    public static class ApplicationDbSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().HasData(
                new Tenant { Id = 1, TenantName = "Admin", Type = TenantType.Admin },
                new Tenant { Id = 2, TenantName = "Customer", Type = TenantType.Customer },
                new Tenant { Id = 3, TenantName = "Supplier", Type = TenantType.Provider },
                new Tenant { Id = 4, TenantName = "Support", Type = TenantType.Support }
                );

            var roles = new List<ApplicationRole>
            {
                new ApplicationRole { 
                    Id = 1, 
                    Name = "Admin",
                    NormalizedName = "ADMIN", 
                    Description = "مدیر سیستم"
                },
                new ApplicationRole { Id = 2, Name = "User", NormalizedName = "USER", Description = "کاربر عادی" }
            };

            modelBuilder.Entity<ApplicationRole>().HasData(roles);

            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                TenantId = 1,
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin123!");

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            var adminUserRole = new ApplicationUserRole
            {
                UserId = 1,
                RoleId = 1
            };
            modelBuilder.Entity<ApplicationUserRole>().HasData(adminUserRole);
        }
    }

    #endregion
}