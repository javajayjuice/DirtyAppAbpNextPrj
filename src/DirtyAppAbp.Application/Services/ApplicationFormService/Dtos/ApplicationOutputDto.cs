using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ApplicantService.Dtos;
using DirtyAppAbp.Services.InstitutionService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ApplicationFormService.Dtos
{
    [AutoMap(typeof(Application))]
    public class ApplicationOutputDto : FullAuditedEntityDto<Guid>
    {
        public ApplicantGetDto Applicant { get; set; }
        public InstitutionInputDto Institution { get; set; }
        public long YearOfStudy { get; set; }
        public string FirstChoice { get; set; }
        public string SecondChoice { get; set; }
        public bool IsFullTime { get; set; }
        public string InitialsSurname { get; set; }
        public string Signature { get; set; }
        public DateTime Date { get; set; }
    }
}
