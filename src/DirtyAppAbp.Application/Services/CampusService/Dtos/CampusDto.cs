using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.AddressService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.CampusService.Dtos
{
    [AutoMap(typeof(Campus))]
    public class CampusDto: EntityDto<Guid>
    {
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public Guid InstitutionsId { get; set; }
    }
}
