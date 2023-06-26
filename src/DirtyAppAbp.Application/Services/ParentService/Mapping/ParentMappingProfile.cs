using AutoMapper;
using DirtyAppAbp.Authorization.Users;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ParentService.Dtos;
using DirtyAppAbp.Services.PersonService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ParentService.Mapping
{
    internal class ParentMappingProfile : Profile
    {
        public ParentMappingProfile()
        {
            CreateMap<Parent, ParentGetDto>()
                .ForMember(x => x.Id, m => m.MapFrom(x => x.Applicant != null ? x.Applicant.Id : (Guid?)null));            

            CreateMap<ParentPostDto, Address>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<ParentPostDto, Parent>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
