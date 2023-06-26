using Abp.Domain.Entities.Auditing;
using DirtyAppAbp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain
{
    public class Subject : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }        
        public virtual ReflistGrade Level { get; set; }
    }
}
