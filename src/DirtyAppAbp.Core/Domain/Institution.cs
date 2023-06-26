using Abp.Domain.Entities.Auditing;
using DirtyAppAbp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DirtyAppAbp.Domain
{
    public class Institution : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ReflistInstitution Type { get; set; }
        public virtual string Contact { get; set; }
        public virtual Address Address { get; set; }

        [JsonIgnore]
        public virtual List<Campus> Campuses { get; set; }
    }
}
