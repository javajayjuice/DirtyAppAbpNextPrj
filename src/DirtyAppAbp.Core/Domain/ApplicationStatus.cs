using Abp.Domain.Entities.Auditing;
using DirtyAppAbp.Domain.Enum;
using System;

namespace DirtyAppAbp.Domain
{
    public class ApplicationStatus: FullAuditedEntity<Guid>
    {
        public virtual Application Application { get; set; }
        public virtual ReflistStatus Status { get; set; }
        public virtual string Reason { get; set; } 
    }
}
