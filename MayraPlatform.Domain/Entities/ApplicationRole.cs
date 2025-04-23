using MayraPlatform.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace MayraPlatform.Domain.Entities
{
    [Auditable]
    public class ApplicationRole : IdentityRole<long>, IBaseEntity
    {
        public string Description { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
