using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ApplicantSubjectService.Dtos
{
    [AutoMap(typeof(ApplicantSubject))]
    public class ApplicantSubjectDto: EntityDto<Guid>
    {
        public Guid SubjectId { get; set; }
        public Guid ApplicantId { get; set; }
        public string SubjectName { get; set; }
        public long Aps { get; set; }
    }
}
