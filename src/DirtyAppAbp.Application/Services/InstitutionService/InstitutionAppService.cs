using Abp.Application.Services;
using Abp.Domain.Repositories;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.CampusService.Dtos;
using DirtyAppAbp.Services.InstitutionService.Dtos;
using DirtyAppAbp.Services.SubjectService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.InstitutionService
{
    public class InstitutionAppService : ApplicationService, IInstitutionAppService
    {
        private readonly IRepository<Institution, Guid> _institutionRepository;
        private readonly IRepository<Address, Guid> _addressRepository;

        public InstitutionAppService(IRepository<Institution, Guid> repository, IRepository<Address, Guid> addressRepository)
        {
            this._institutionRepository = repository;
            _addressRepository = addressRepository;
        }

        public async Task<InstitutionInputDto> CreateAsync(InstitutionInputDto input)
        {
            var x = await _institutionRepository.InsertAsync(ObjectMapper.Map<Institution>(input));
            return ObjectMapper.Map<InstitutionInputDto>(x);
        }

        public async Task<InstitutionDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<InstitutionDto>(await _institutionRepository.GetAsync(id));
        }

        public async Task<List<InstitutionDto>> GetAllAsync()
        {
            var institutions = await _institutionRepository.GetAllIncluding(x => x.Address).ToListAsync();
            return ObjectMapper.Map<List<InstitutionDto>>(institutions);
        }
    }
}
