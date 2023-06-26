using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain
{
    public class StoredFile : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string FileType { get; set; }
        public virtual Byte[] Data { get; set; }

        public virtual Applicant Applicant { get; set; }
    }
}
