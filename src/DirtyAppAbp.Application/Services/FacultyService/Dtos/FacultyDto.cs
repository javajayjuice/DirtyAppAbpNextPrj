using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.CourseService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.FacultyService.Dtos
{
    [AutoMap(typeof(Faculty))]
    public class FacultyDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
