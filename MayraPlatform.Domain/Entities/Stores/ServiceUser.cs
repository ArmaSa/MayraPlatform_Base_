using MayraPlatform.Domain.Common;
using MayraPlatform.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayraPlatform.Domain.Entities
{
    public class ServiceUser : IBaseEntity
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public long StoreId { get; set; }
        public long UserId { get; set; }
        public bool Availble { get; set; }//فعال یا غیر فعال
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public bool UserServiceStatus { get; set; }//برای اون شخص در دسترسه یا نه
        public virtual Service Service { get; set; }
        public virtual Store Store { get; set; }
    }
}
