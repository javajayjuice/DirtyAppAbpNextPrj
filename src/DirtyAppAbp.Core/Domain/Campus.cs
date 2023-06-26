using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DirtyAppAbp.Domain
{
    public class Campus : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual Address Address { get; set; }
        public virtual Institution Institutions { get; set;}
        [JsonIgnore]
        public virtual List<InstituteFaculty> InstituteFaculties { get; set; }
    }
}
