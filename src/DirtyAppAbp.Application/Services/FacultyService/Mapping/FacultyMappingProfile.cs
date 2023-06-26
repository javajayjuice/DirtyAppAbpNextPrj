using AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ApplicantService.Dtos;
using DirtyAppAbp.Services.FacultyService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.FacultyService.Mapping
{
    public  class FacultyMappingProfile : Profile
    {
        public FacultyMappingProfile()
        {
            CreateMap<Faculty, FacultyDto>()
                .ForMember(x => x.Courses, m => m.MapFrom(x => x.Courses ?? null));

            CreateMap<FacultyInputDto, Faculty>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
