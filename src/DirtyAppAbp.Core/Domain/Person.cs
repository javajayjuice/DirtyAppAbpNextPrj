using Abp.Domain.Entities.Auditing;
using DirtyAppAbp.Authorization.Users;
using DirtyAppAbp.Domain.Attributes;
using DirtyAppAbp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Domain
{
    [Entity(TypeShortAlias = "Dirty.Person")]
    [Table("Persons")]
    [DescriminatorValue("Dirty.Person")]
    public class Person : FullAuditedEntity<Guid>
    {
        public virtual string UserName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Password { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string IdentityNumber { get; set; }
        public virtual ReflistTitle Title { get; set; }
        public virtual string Initials { get; set; }
        public virtual RefListGender Gender { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual ReflistHomeLanguage HomeLanguage { get; set; }
        public virtual ReflistPopulationGroup PopulationGroup { get; set; }
        public virtual bool Diability { get; set; }
        public virtual ReflistNatureOfDisability NatureOfDisability { get; set; }

        public virtual Address Address { get; set; }

        public User User { get; set; }
        [NotMapped]
        public virtual string[] RoleNames { get; set; }
    }
}
