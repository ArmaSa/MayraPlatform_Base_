using MayraPlatform.Domain.Common;
namespace MayraPlatform.Domain.Entities.Invoice
{
    [Auditable]
    public class PurchaseInvoiceItem
    {
        public decimal Price { get; set; }
        public decimal DiscountItem { get; set; }
        public decimal TotalPrice { get; set; }
        public byte ItemCount { get; set; }
        public long ServiceStoreId { get; set; }
        public long ServiceUserId { get; set; }
        public virtual PurchaseInvoice SalesInvoice { get; set; }
    }
}
