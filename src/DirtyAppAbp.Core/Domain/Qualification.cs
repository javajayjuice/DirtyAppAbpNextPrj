using Abp.Domain.Entities.Auditing;
using DirtyAppAbp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain
{
    public class Qualification : FullAuditedEntity<Guid>
    {
        public virtual string YearStart { get; set; }
        public virtual string YearEnd { get; set; }
        public virtual string Institution { get; set; }
        public virtual string FieldOfStudy { get; set; }
        public virtual ReflistResult Status { get; set; }

        public virtual Applicant Applicant { get; set; }
    }
}
