using MayraPlatform.Domain.Common;
namespace MayraPlatform.Domain.Entities.Invoice
{
    [Auditable]
    public class PurchaseInvoice
    {
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public long StoreId { get; set; }
        public virtual ICollection<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; }
    }
}
