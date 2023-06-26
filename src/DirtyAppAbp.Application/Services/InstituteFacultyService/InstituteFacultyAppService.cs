using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ApplicantSubjectService.Dtos;
using DirtyAppAbp.Services.CourseService.Dtos;
using DirtyAppAbp.Services.FacultyService.Dtos;
using DirtyAppAbp.Services.InstituteFacultyService.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.InstituteFacultyService
{
    public class InstituteFacultyAppService : ApplicationService
    {
        private readonly IRepository<InstituteFaculty, Guid> _instituteFacultyRepository;
        private readonly IRepository<Campus, Guid> _campusRepository;
        private readonly IRepository<Faculty, Guid> _facultyRepository;
        private readonly IRepository<Course, Guid> _courseRepository;

        public InstituteFacultyAppService(IRepository<InstituteFaculty, Guid> instituteFacultyRepository, IRepository<Campus, Guid> campustRepository, IRepository<Faculty, Guid> facultyRepository, IRepository<Course, Guid> courseRepository)
        {
            _instituteFacultyRepository = instituteFacultyRepository;
            _campusRepository = campustRepository;
            _facultyRepository = facultyRepository;
            _courseRepository = courseRepository;
        }

        public async Task<InstituteFacultyDto> CreateAsync(InstituteFacultyDto input)
        {
            var campus = await _campusRepository.GetAsync(input.CampusId);

            var instituteFaculty = ObjectMapper.Map<InstituteFaculty>(input);

            instituteFaculty.Campus = await _campusRepository.GetAsync(input.CampusId);
            instituteFaculty.Faculty = await _facultyRepository.GetAsync(input.FacultyId);
            await _instituteFacultyRepository.InsertAsync(instituteFaculty);
            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<InstituteFacultyDto>(instituteFaculty);
        }

        public async Task<List<FacultyDto>> GetFacultiesByCampusIdAsync(Guid campusId)
        {
            var faculties = await _instituteFacultyRepository.GetAllIncluding(x => x.Faculty)
                .Where(x => x.Campus.Id == campusId)
                .Select(x => x.Faculty)
                .ToListAsync();

            return ObjectMapper.Map<List<FacultyDto>>(faculties);
        }

    }
}


//public async Task<List<FacultyDto>> GetFacultiesByCampusIdAsync(Guid campusId)
//{
//    var faculties = await _instituteFacultyRepository.GetAllIncluding(x => x.Faculty)
//        .Where(x => x.Campus.Id == campusId)
//        .Select(x => new
//        {
//            x.Faculty,
//            Courses = _courseRepository.GetAllList(a => a.Faculty.Id == x.Faculty.Id)
//        })
//        .ToListAsync();

//    var facultyDtos = new List<FacultyDto>();

//    foreach (var facultyData in faculties)
//    {
//        var facultyDto = ObjectMapper.Map<FacultyDto>(facultyData.Faculty);
//        facultyDto.Courses = ObjectMapper.Map<List<CourseDto>>(facultyData.Courses);
//        facultyDtos.Add(facultyDto);
//    }

//    return facultyDtos;
//}


//public async Task<List<InstituteFacultyDto>> GetAllFromCampusAsync(Guid CampusId)
//{

//    var faculties = await _instituteFacultyRepository.GetAll()
//        .Where(q => q.Campus.Id == CampusId)
//        .ToListAsync();

//    if (faculties == null)
//    {
//        throw new ApplicationException("No Faculties Available!!!");
//    }

//    var facultiesDto = faculties.Select(s => new InstituteFacultyDto
//    {
//        Id = s.Id,
//        CampusId = s.Campus.Id,
//        FacultyId = s.Faculty.Id,
//    }).ToList();

//    return facultiesDto;
//}
