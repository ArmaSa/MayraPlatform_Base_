using MayraPlatform.Domain.Common;
namespace MayraPlatform.Domain.Entities
{
    [Auditable]
    public class Address : IBaseEntity
    {
        public long Id { get; set; }
        public string AliesName{ get; set; }
        public string Name{ get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string FullAddress{ get; set; }
        public byte section { get; set; }
        public byte Floor { get; set; }
        public float Lat{ get; set; }
        public float Long { get; set; }
        public virtual ICollection<Customer>  Customers { get; set; }
    }
}
