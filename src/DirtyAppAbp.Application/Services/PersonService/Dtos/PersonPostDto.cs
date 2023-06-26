using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Authorization.Users;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.PersonService.Dtos
{
    [AutoMap(typeof(Person))]
    public class PersonPostDto : EntityDto<Guid>
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string IdentityNumber { get; set; }
        public ReflistTitle Title { get; set; }
        public string Initials { get; set; }
        public RefListGender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ReflistHomeLanguage HomeLanguage { get; set; }
        public ReflistPopulationGroup PopulationGroup { get; set; }
        public bool Diability { get; set; }
        public ReflistNatureOfDisability NatureOfDisability { get; set; }

        public long UserId { get; set; }
        [NotMapped]
        public string[] RoleNames { get; set; }
    }
}
