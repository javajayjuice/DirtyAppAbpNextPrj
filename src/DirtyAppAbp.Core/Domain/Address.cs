using Abp.Domain.Entities.Auditing;
using DirtyAppAbp.Domain.Enum;
using System;

namespace DirtyAppAbp.Domain
{
    public class Address : FullAuditedEntity<Guid>
    {
        public virtual string Street { get; set; }
        public virtual string Town { get; set; }
        public virtual string City { get; set; }
        public virtual string Suburb { get; set; }
        public virtual ReflistProvince Province { get; set; }
        public virtual long PostalCode { get; set; }
    }
}
