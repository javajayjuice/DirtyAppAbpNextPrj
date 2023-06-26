using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain
{
    public class Application: FullAuditedEntity<Guid>
    {
        public virtual Applicant Applicant { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual long YearOfStudy { get; set; }
        public virtual string FirstChoice { get; set; }
        public virtual string SecondChoice { get; set;}
        public virtual bool IsFullTime { get; set; }
        public virtual string InitialsSurname { get; set;}
        public virtual string Signature { get;set; }
        public virtual DateTime Date { get;set; }
    }
}
