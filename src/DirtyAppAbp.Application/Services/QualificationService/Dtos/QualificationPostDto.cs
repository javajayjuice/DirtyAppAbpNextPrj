using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.QualificationService.Dtos
{
    [AutoMap(typeof(Qualification))]
    public class QualificationPostDto : EntityDto<Guid>
    {
        public string YearStart { get; set; }
        public string YearEnd { get; set; }
        public string Institution { get; set; }
        public string FieldOfStudy { get; set; }
        public ReflistResult Status { get; set; }
    }
}
