using MayraPlatform.Domain.Common;

namespace MayraPlatform.Domain.Entities
{
    public class Store : IBaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string AliesName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public long UserId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<ServiceStore> ServiceStores { get; set; }
        public virtual ICollection<ServiceUser> ServiceUsers { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
