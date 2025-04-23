using MayraPlatform.Domain.Common;
using MayraPlatform.Domain.Entities.Contact;

namespace MayraPlatform.Domain.Entities
{
    [Auditable]
    public class Customer : IBaseEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long UserId { get; set; }
        public bool Status { get; set; }
        public long CustomerGroupId { get; set; }
        public virtual CustomerGroup CustomerGroup { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}