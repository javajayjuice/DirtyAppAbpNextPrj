using Abp.Application.Services;
using Abp.Domain.Repositories;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.CampusService.Dtos;
using DirtyAppAbp.Services.FacultyService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.FacultyService
{
    public class FacultyAppService : ApplicationService, IFacultyAppService
    {
        private readonly IRepository<Faculty, Guid> _facultyRepository;
        private readonly IRepository<Institution, Guid> _institutionRepository;

        public FacultyAppService(IRepository<Faculty, Guid> facultyRepository, IRepository<Institution, Guid> institutionRepository)
        {
            _facultyRepository = facultyRepository;
            _institutionRepository = institutionRepository;
        }

        public async Task<FacultyInputDto> CreateAsync(FacultyInputDto input)
        {
            return ObjectMapper.Map<FacultyInputDto>(await _facultyRepository.InsertAsync(ObjectMapper.Map<Faculty>(input)));
        }

        public async Task<FacultyDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<FacultyDto>(await _facultyRepository.GetAsync(id));
        }

        public async Task<List<FacultyDto>> GetAllAsync()
        {
            return ObjectMapper.Map<List<FacultyDto>>(await _facultyRepository.GetAllListAsync());
        }

        //public async Task<List<FacultyDto>> GetAllFromInstitutionAsync(Guid institutionId)
        //{
        //    var institution = await _institutionRepository.GetAsync(institutionId);
        //    var faculties = await _facultyRepository.GetAllIncluding(f => f.Courses)
        //        .Where(f => f.Courses.Any(c => c.InstituteFaculties.Any(i => i.Campus.Institutions.Id == institution.Id)))
        //        .ToListAsync();


        //    return ObjectMapper.Map<List<FacultyDto>>(await _facultyRepository.GetAllListAsync());
        //}
    }
}
