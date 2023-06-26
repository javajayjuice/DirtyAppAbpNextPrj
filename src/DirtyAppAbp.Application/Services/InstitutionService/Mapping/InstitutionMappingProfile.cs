using AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.CampusService.Dtos;
using DirtyAppAbp.Services.InstitutionService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.InstitutionService.Mapping
{
    public class InstitutionMappingProfile : Profile
    {
        public InstitutionMappingProfile()
        {
            CreateMap<Institution, InstitutionDto>()
                .ForMember(x => x.Address, m => m.MapFrom(x => x.Address ));

            CreateMap<Address, InstitutionDto>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<InstitutionInputDto, Institution>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
