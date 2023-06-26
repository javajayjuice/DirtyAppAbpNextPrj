using AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.CampusService.Dtos;
using DirtyAppAbp.Services.CourseService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.CourseService.Mapping
{
    public class CourseMappingProfile: Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(x => x.FacultyId, m => m.MapFrom(x => x.Faculty != null ? x.Faculty.Id : (Guid?)null));

            CreateMap<CourseInputDto, Course>()
                .ForMember(e => e.Id, d => d.Ignore());

        }
    }
}
