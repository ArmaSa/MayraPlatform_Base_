using MayraPlatform.Domain.Common;

namespace MayraPlatform.Domain.Entities
{
    public class Service : IBaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<ServiceStore> ServiceStores { get; set; }
        public virtual ICollection<ServiceUser>  ServiceUsers { get; set; }
    }
}
