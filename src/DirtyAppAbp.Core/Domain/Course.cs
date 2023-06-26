using Abp.Domain.Entities.Auditing;
using System;

namespace DirtyAppAbp.Domain
{
    public class Course: FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string NqfLevel { get; set;}
        public virtual string Duration { get; set; }
        public virtual string MinimumAps { get; set; }
        public virtual string ProgrammeCode { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
