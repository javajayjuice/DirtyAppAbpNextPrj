using AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ApplicationStatusService.Dtos;
using DirtyAppAbp.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ApplicationStatusService.Mapping
{
    public  class ApplicationMappingProfile:Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<ApplicationStatus, ApplicationStatusInputDto>()
                .ForMember(ds => ds.Status, m => m.MapFrom(s => s.Status.GetEnumDescription())) ;

            CreateMap<ApplicationStatusInputDto, ApplicationStatus>()
                .ForMember(ds => ds.Status, m => m.MapFrom(s => s.Status.GetEnumDescription()));

        }
    }
}
