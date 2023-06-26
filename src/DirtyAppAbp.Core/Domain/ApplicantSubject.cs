using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain
{
    public class ApplicantSubject : FullAuditedEntity<Guid>
    {
        public virtual Applicant Applicant { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual long Aps { get; set; }

    }
}
