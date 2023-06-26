using AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ApplicantSubjectService.Dtos;
using System;

namespace DirtyAppAbp.Services.ApplicantSubjectService.Mapping
{
    public class ApplicantSubjectMappingProfile: Profile
    {
        public ApplicantSubjectMappingProfile()
        {
            CreateMap<ApplicantSubject, ApplicantSubjectDto>()
                .ForMember(x => x.ApplicantId, m => m.MapFrom(x => x.Applicant != null ? x.Applicant.Id : (Guid?)null))
                .ForMember(x => x.SubjectName, m => m.MapFrom(x => x.Subject != null ? x.Subject.Name : null))
                .ForMember(x => x.SubjectId, m => m.MapFrom(x => x.Subject != null ? x.Subject.Id : (Guid?)null));

            CreateMap<ApplicantSubjectDto, ApplicantSubject>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
