using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Domain.Enum;
using DirtyAppAbp.Services.AddressService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.InstitutionService.Dtos
{
    [AutoMap(typeof(Institution))]
    public class InstitutionInputDto: EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ReflistInstitution Type { get; set; }
        public string Contact { get; set; }
        public AddressDto Address { get; set; }
    }
}
