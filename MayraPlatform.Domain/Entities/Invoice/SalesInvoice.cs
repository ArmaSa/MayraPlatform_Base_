using MayraPlatform.Domain.Common;
namespace MayraPlatform.Domain.Entities.Invoice
{
    [Auditable]
    public class SalesInvoice
    {
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string DiscountCode { get; set; }
        public decimal TotalPrice { get; set; }
        public long UserId { get; set; }
        public virtual ICollection<SalesInvoiceItem> SalesInvoiceItems { get; set; }
    }
}
