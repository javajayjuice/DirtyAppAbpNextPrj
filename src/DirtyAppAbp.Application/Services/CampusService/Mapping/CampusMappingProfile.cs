using AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.CampusService.Dtos;
using DirtyAppAbp.Services.ParentService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.CampusService.Mapping
{
    public class CampusMappingProfile: Profile
    {
        public CampusMappingProfile()
        {
            CreateMap<Campus, CampusDto>()
                .ForMember(x => x.Address, m => m.MapFrom(x => x.Address != null ? x.Address: null))
                .ForMember(x => x.InstitutionsId, m => m.MapFrom(x => x.Institutions != null ? x.Institutions.Id : (Guid?)null));

            CreateMap<Address, CampusDto>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<CampusDto, Campus>()
               .ForMember(e => e.Id, d => d.Ignore());

        }
    }
}
