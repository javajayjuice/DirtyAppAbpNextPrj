using Abp.Domain.Entities.Auditing;
using DirtyAppAbp.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain
{
    [Entity(TypeShortAlias = "Dirty.Parent")]
    [DescriminatorValue("Dirty.Parent")]
    public class Parent : Person
    {
        public virtual Applicant Applicant { get; set; }
  
    }
}
