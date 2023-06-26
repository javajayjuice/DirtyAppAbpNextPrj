using Abp.Domain.Entities.Auditing;
using DirtyAppAbp.Domain.Attributes;
using DirtyAppAbp.Domain.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain
{
    [Entity(TypeShortAlias = "Dirty.Applicant")]
    [DescriminatorValue("Dirty.Applicant")]
    public class Applicant : Person
    {
        public virtual ReflistActivity CurrentActivity { get; set; }
        public virtual ReflistActivity PreviousActivity { get; set; }
        [JsonIgnore]
        public virtual List<Qualification> Qualifications { get; set; }
        [JsonIgnore]
        public virtual List<StoredFile> StoredFiles { get; set; }
        [JsonIgnore]
        public virtual List<ApplicantSubject> ApplicantSubjects { get; set; }

    }
}
