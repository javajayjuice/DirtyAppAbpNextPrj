using AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ApplicantService.Dtos;
using DirtyAppAbp.Services.ApplicationFormService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ApplicationFormService.Mapping
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Application, ApplicationOutputDto>()
                .ForMember(x => x.Applicant, m => m.MapFrom(x => x.Applicant))
                .ForMember(x => x.Institution, m => m.MapFrom(x => x.Institution));

            CreateMap<ApplicationInputDto, Application>()
                .ForMember(e => e.Id, d => d.Ignore());

        }
    }
}