using MayraPlatform.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace MayraPlatform.Domain.Entities
{

    [Auditable]
    public class ApplicationUser : IdentityUser<long>, IBaseEntity
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; } = true;
        public long TenantId { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual Tenant UserTenant { get; set; }
    }
}