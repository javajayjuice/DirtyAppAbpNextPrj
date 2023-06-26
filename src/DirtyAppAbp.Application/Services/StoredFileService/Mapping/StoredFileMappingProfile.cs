using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.InstitutionService.Dtos;
using DirtyAppAbp.Services.StoredFileService.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.StoredFileService.Mapping
{
    public class StoredFileMappingProfile : Profile
    {
        public StoredFileMappingProfile()
        {
            CreateMap<StoredFile, StoredFileDto>()
                .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
            .ForMember(x => x.ApplicantId, m => m.MapFrom(x => x.Applicant.Id));
        }
    }
}
