using MayraPlatform.Domain.Common;
using MayraPlatform.Domain.Enums;

namespace MayraPlatform.Domain.Entities
{
    public class Tenant: IBaseEntity
    {
        public long Id { get; set; }

        public string TenantName { get; set; }
        public TenantType Type { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
