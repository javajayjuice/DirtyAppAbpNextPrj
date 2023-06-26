using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.AddressService.Dtos
{
    [AutoMap(typeof(Address))]
    public class AddressDto : EntityDto<Guid>
    {
        public  string Street { get; set; }
        public  string Town { get; set; }
        public  string City { get; set; }
        public  string Suburb { get; set; }
        public  ReflistProvince Province { get; set; }
        public  long PostalCode { get; set; }
    }
}
