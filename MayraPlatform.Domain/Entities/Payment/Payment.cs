using MayraPlatform.Domain.Entities.Invoice;
using MayraPlatform.Domain.Enums;

namespace MayraPlatform.Domain.Entities.Payment
{
    public class Payment
    {
        public decimal PricePayed { get; set; }
        public long SalesInvoiceId { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public virtual SalesInvoice SalesInvoice { get; set; }
    }
}
