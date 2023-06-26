using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain
{
    public class Message:FullAuditedEntity<Guid>
    {
        public virtual string Text { get; set; }
        public virtual Applicant Applicant { get; set; }

    }
}
