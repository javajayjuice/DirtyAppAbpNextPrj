using AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ApplicantService.Dtos;
using DirtyAppAbp.Services.Helpers;
using DirtyAppAbp.Services.ParentService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ApplicantService.Mapping
{
    public class ApplicantMappingProfile: Profile
    {
        public ApplicantMappingProfile()
        {
            CreateMap<Applicant, ApplicantGetDto>()
                .ForMember(x => x.Qualifications, m => m.MapFrom(x => x.Qualifications ?? null))
                .ForMember(x => x.CurrentActivity, m => m.MapFrom(x => x.CurrentActivity.GetEnumDescription()))
                .ForMember(x => x.PreviousActivity, m => m.MapFrom(x => x.PreviousActivity.GetEnumDescription()))
                .ForMember(x => x.ApplicantSubjects, m => m.MapFrom(x => x.ApplicantSubjects ?? null))
                .ForMember(x => x.StoredFiles, m => m.MapFrom(x => x.StoredFiles ?? null));

            CreateMap<ApplicantPostDto, Applicant>()
                .ForMember(e => e.Id, d => d.Ignore());

        }
    }
}
