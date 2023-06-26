using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DirtyAppAbp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.CourseService.Dtos
{
    [AutoMap(typeof(Course))]
    public  class CourseDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string NqfLevel { get; set; }
        public string Duration { get; set; }
        public string MinimumAps { get; set; }
        public string ProgrammeCode { get; set; }
        public Guid FacultyId { get; set; }
    }
}
