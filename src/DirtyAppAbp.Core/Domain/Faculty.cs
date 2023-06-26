using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

namespace DirtyAppAbp.Domain
{
    public class Faculty: FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
