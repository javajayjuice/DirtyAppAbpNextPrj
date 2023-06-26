using Abp.Application.Services.Dto;
using DirtyAppAbp.Domain.Enum;
using DirtyAppAbp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using DirtyAppAbp.Services.AddressService.Dtos;
using DirtyAppAbp.Services.ParentService.Dtos;

namespace DirtyAppAbp.Services.PersonService.Dtos
{
    [AutoMap(typeof(Person))]
    public class PersonGetDto : EntityDto<Guid>
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string IdentityNumber { get; set; }
        public string Title { get; set; }
        public string Initials { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HomeLanguage { get; set; }
        public string PopulationGroup { get; set; }
        public bool Diability { get; set; }
        public string NatureOfDisability { get; set; }
        public Guid AddessId { get; set; }

        public AddressDto Address { get; set; }
        public ParentGetDto Parent { get; set; }

        public long UserId { get; set; }
    }
}
