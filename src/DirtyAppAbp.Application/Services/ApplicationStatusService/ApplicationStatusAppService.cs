using Abp.Application.Services;
using Abp.Domain.Repositories;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ApplicationStatusService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ApplicationStatusService
{
    public class ApplicationStatusAppService: ApplicationService, IApplicationStatusAppService
    {
        private readonly IRepository<ApplicationStatus, Guid> _statusRepository;
        private readonly IRepository<Application, Guid> _applicationRepository;

        public ApplicationStatusAppService(IRepository<ApplicationStatus, Guid> statusRepository, IRepository<Application, Guid> applicationRepository)
        {
            _statusRepository = statusRepository;
            _applicationRepository = applicationRepository;

        }

        public async Task<ApplicationStatusInputDto> UpdateAsync(ApplicationStatusInputDto input)
        {
            var statusUpdate = await _statusRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, statusUpdate);
            return ObjectMapper.Map<ApplicationStatusInputDto>(statusUpdate);
        }

        public async Task<List<ApplicationStatusDto>> GetAllAsync()
        {
            return ObjectMapper.Map<List<ApplicationStatusDto>>( _statusRepository.GetAllIncluding(a => a.Application)).ToList();
        }

        public async Task<ApplicationStatusInputDto> CreateAsync(ApplicationStatusInputDto input)
        {
            var newStatus = ObjectMapper.Map<ApplicationStatus>(input);
            newStatus.Application = await _applicationRepository.GetAsync(input.ApplicationId);
            return ObjectMapper.Map<ApplicationStatusInputDto>(await _statusRepository.InsertAsync(newStatus));
        }

    }
}
