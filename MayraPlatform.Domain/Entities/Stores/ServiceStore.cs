using MayraPlatform.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayraPlatform.Domain.Entities
{
    public class ServiceStore : IBaseEntity
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public long StoreId { get; set; }
        public bool Availble { get; set; }//فعال یا غیر فعال
        public decimal Price { get; set; }
        public decimal StoreDiscount { get; set; }
        public bool StoreServiceStatus { get; set; }//برای اون فروشگاه در دسترسه یا نه
        public string ServiceTimes { get; set; }//براساس روزهای هفته و ساعات فعالیت
        public virtual Service Service { get; set; }
        public virtual Store Store { get; set; }
    }
}
