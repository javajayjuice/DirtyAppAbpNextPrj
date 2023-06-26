using Abp.Application.Services;
using Abp.Domain.Repositories;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.CourseService.Dtos;
using DirtyAppAbp.Services.FacultyService.Dtos;
using DirtyAppAbp.Services.SubjectService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.CourseService
{
    public  class CourseAppService: ApplicationService, ICourseAppService
    {
        private readonly IRepository<Course, Guid> _courseRepository;
        private readonly IRepository<Faculty, Guid> _facultyRepository;
        private readonly IRepository<ApplicantSubject, Guid> _applicantSubjectRepository;
        private readonly IRepository<Applicant, Guid> _applicantRepository;

        public CourseAppService(IRepository<Course, Guid> courseRepository, IRepository<Faculty, Guid> facultyRepository, IRepository<ApplicantSubject, Guid> applicantSubjectRepository, IRepository<Applicant, Guid> applicantRepository) 
        {
            _courseRepository = courseRepository;
            _facultyRepository = facultyRepository;
            _applicantRepository = applicantRepository;
            _applicantSubjectRepository = applicantSubjectRepository;
        }

        public async Task<CourseDto> CreateAsync(CourseDto input)
        {
            var faculty = await _facultyRepository.GetAsync(input.FacultyId);
            var course = ObjectMapper.Map<Course>(input);
            course.Faculty = faculty;

            return ObjectMapper.Map<CourseDto>(await _courseRepository.InsertAsync(course));
        }

        public async Task<CourseDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CourseDto>(await _courseRepository.GetAsync(id));
        }

        public async Task<List<CourseDto>> GetAllAsync()
        {
            return ObjectMapper.Map<List<CourseDto>>(await _courseRepository.GetAllListAsync());
        }

        public async Task<List<CourseDto>> GetAllByFacultyIdAsync(Guid id)
        {
            //return ObjectMapper.Map<List<CourseDto>>(await _courseRepository.GetAll().Where(a => a.Faculty.Id == id).Include(f => f.Faculty).ToListAsync());
            ; // Get the task

            var courses = await _courseRepository.GetAll()
                .Include(f => f.Faculty)
                .Where(a => a.Faculty.Id == id && CalculateTotalAps().Result >= Convert.ToInt32(a.MinimumAps))
                .ToListAsync();

            return ObjectMapper.Map<List<CourseDto>>(courses);
        }

        [HttpGet]
        public async Task<int> CalculateTotalAps()
        {
            var person = await GetCurrentUserPerson();
            var totalAps = await _applicantSubjectRepository.GetAll()
                .Where(q => q.Applicant.Id == person.Id)
                .SumAsync(q => q.Aps);

            return (int)totalAps;
        }

        //get person from logged in user
        private async Task<Applicant> GetCurrentUserPerson()
        {
            var currentUserId = AbpSession.UserId;

            if (currentUserId == null)
            {
                throw new ApplicationException("User Invalid!!!");
            }

            var person = await _applicantRepository.FirstOrDefaultAsync(p => p.User.Id == currentUserId);

            if (person == null)
            {
                throw new ApplicationException("Person Not Found!!!");
            }

            return person;
        }
    }
}
