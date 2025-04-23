using MayraPlatform.Domain.Common;
using MayraPlatform.Domain.Enums;

namespace MayraPlatform.Domain.Audit
{
    public class Audit: IBaseEntity
    {
        public long Id { get; set; }    
        public string UserId { get; set; }
        public AuditType Type { get; set; }
        public string TableName { get; set; }
        public DateTime DateTime { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string AffectedColumns { get; set; }
        public string PrimaryKey { get; set; }
    }
}
