using Abp.Domain.Entities.Auditing;
using System;

namespace DirtyAppAbp.Domain
{
    public class InstituteFaculty: FullAuditedEntity<Guid>
    {
        public virtual Campus Campus { get; set; }
        public virtual Faculty Faculty { get; set; }      
    }
}
