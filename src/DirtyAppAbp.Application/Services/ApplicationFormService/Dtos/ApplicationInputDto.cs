using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ApplicationFormService.Dtos
{
    [AutoMap(typeof(Application))]
    public  class ApplicationInputDto : EntityDto<Guid>
    {
        public Guid ApplicantID { get; set; }
        public Guid InstitutionId { get; set; }
        public long YearOfStudy { get; set; }
        public Guid FirstChoice { get; set; }
        public Guid SecondChoice { get; set; }
        public bool IsFullTime { get; set; }
        public string InitialsSurname { get; set; }
        public string Signature { get; set; }
        public DateTime Date { get; set; }
    }
}
