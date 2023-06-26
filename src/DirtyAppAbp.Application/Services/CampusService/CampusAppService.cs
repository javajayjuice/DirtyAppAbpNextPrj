using Abp.Application.Services;
using Abp.Domain.Repositories;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ApplicantSubjectService.Dtos;
using DirtyAppAbp.Services.CampusService.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.CampusService
{
    public class CampusAppService: ApplicationService,ICampusAppService
    {
        private readonly IRepository<Campus, Guid> _campusRepository;
        private readonly IRepository<Address, Guid> _addressAddress;
        private readonly IRepository<Institution, Guid> _institutionRepository;

        public CampusAppService(IRepository<Campus, Guid> campusRepository, IRepository<Address, Guid> addressAddress, IRepository<Institution, Guid> institutionRepository)
        {
            _institutionRepository = institutionRepository;
            _campusRepository = campusRepository;
            _addressAddress = addressAddress;
        }

        public async Task<CampusDto> CreateAsync(CampusDto input)
        {
            var campus = ObjectMapper.Map<Campus>(input);
            campus.Institutions = await _institutionRepository.GetAsync(input.InstitutionsId); // Assuming InstitutionId is the property that holds the ID of the institution

            return ObjectMapper.Map<CampusDto>(await _campusRepository.InsertAsync(campus));
        }


        public async Task<CampusDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CampusDto>(await _campusRepository.GetAsync(id));
        }

        public async Task<List<CampusDto>> GetAllAsync()
        {
            var campuses = await _campusRepository.GetAllIncluding(x => x.Address).ToListAsync();
            return ObjectMapper.Map<List<CampusDto>>(campuses);
        }

        public async Task<List<CampusDto>> GetAllByInstituteAsync(Guid institutesId)
        {
            var campuses = await _campusRepository.GetAll()
                .Where(q => q.Institutions.Id == institutesId)
                .Include(q => q.Address)
                .Include(q => q.Institutions)
                .ToListAsync();

            if (campuses == null)
            {
                throw new ApplicationException("No Campuses Available!!!");
            }

            return ObjectMapper.Map<List<CampusDto>>(campuses);
        }
    }
}
