using System.ComponentModel;

namespace MayraPlatform.Domain.Enums
{
    public enum AuditType
    {
        None = 0,
        Create = 1,
        Update = 2,
        Delete = 3
    }

    public enum TenantType
    {
        Admin = 0,
        Customer = 1,
        Provider = 2,
        Support = 3
    }

    public enum DiscountTypeEnum
    {
        [Description("توسط فروشگاه ایجاد شده")]
        StoreCreator = 0,
        [Description("توسط کمپانی ایجاد شده")]
        CompanyCreator = 1,
        [Description("تخفیف زمان دار")]
        TimeRemaining = 2
    }

    public enum CustomerGroupEnum
    {
        Bronze = 0,
        Silver = 1,
        Golden = 2
    }

    public enum PaymentStatusEnum
    {
        Payed = 1,
        Failed = 2,
        Gone = 3
    }

    public enum PaymentTypeEnum
    {
        Online = 1,
        BankTransfer = 2,
        Cash = 3,
        Card = 4
    }
}