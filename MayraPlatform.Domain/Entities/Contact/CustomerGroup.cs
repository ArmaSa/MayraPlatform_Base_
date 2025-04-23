using MayraPlatform.Domain.Common;
using MayraPlatform.Domain.Enums;

namespace MayraPlatform.Domain.Entities.Contact
{
    [Auditable]
    public class CustomerGroup : IBaseEntity
    { 
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public CustomerGroupEnum GroupType { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }       
    }
}
