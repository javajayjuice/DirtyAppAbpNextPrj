using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.SubjectService
{
    [AutoMap(typeof(Subject))]
    public class SubjectDto: EntityDto<Guid>
    {
        public  string Name { get; set; }
        public  string Description { get; set; }
        public ReflistGrade Level { get; set; }
    }
}
