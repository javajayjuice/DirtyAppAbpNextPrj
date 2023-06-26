using Abp.Application.Services.Dto;
using DirtyAppAbp.Domain.Enum;
using DirtyAppAbp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using DirtyAppAbp.Services.PersonService.Dtos;
using DirtyAppAbp.Services.QualificationService.Dtos;
using DirtyAppAbp.Services.StoredFileService.Dtos;
using DirtyAppAbp.Services.ApplicantSubjectService.Dtos;
using DirtyAppAbp.Services.ParentService.Dtos;

namespace DirtyAppAbp.Services.ApplicantService.Dtos
{
    [AutoMap(typeof(Applicant))]
    public class ApplicantGetDto : PersonGetDto
    {
        public string CurrentActivity { get; set; }
        public string PreviousActivity { get; set; }

        public List<QualificationGetDto> Qualifications { get; set; }
        public List<StoredFileDto> StoredFiles { get; set; }
        public List<ApplicantSubjectDto> ApplicantSubjects { get; set; }
        public ParentGetDto Parent { get; set; }

    }
}
