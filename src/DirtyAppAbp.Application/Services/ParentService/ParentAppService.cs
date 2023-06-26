using Abp.Application.Services;
using Abp.Domain.Repositories;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ParentService.Dtos;
using DirtyAppAbp.Services.PersonService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ParentService
{
    public class ParentAppService : ApplicationService, IParentAppService
    {
        private readonly IRepository<Parent, Guid> _parentRepository;
        private readonly IRepository<Applicant, Guid> _applicantRepository;

        public ParentAppService(IRepository<Parent, Guid> parentRepository, IRepository<Applicant,Guid> applicantRepository)
        {
            _parentRepository = parentRepository;   
            _applicantRepository = applicantRepository;
        }

        public async Task<ParentPostDto> CreateAsync(ParentPostDto input)
        {

            var currentUserId = AbpSession.UserId;

            var person = await _applicantRepository.FirstOrDefaultAsync(p => p.User.Id == currentUserId);

            if (currentUserId == null)
            {
                throw new ApplicationException("User Invalid!!!");
            }
            if (person == null)
            {
                throw new ApplicationException("Person Not Found!!!");
            }

            var parent = ObjectMapper.Map<Parent>(input);
            parent.Applicant = await _applicantRepository.GetAsync(person.Id);
            await _parentRepository.InsertAsync(parent);
            CurrentUnitOfWork.SaveChanges();

            
            return ObjectMapper.Map<ParentPostDto>(parent);
        }

        public async Task Delete(Guid id)
        {
            await _parentRepository.DeleteAsync(id);
        }

        public async Task<List<ParentGetDto>> GetAllAsync()
        {
            return ObjectMapper.Map<List<ParentGetDto>>(await _parentRepository.GetAllListAsync());
        }

        public async Task<ParentGetDto> GetAsync()
        {
            var currentUserId = AbpSession.UserId;

            var applicant = await _applicantRepository?.FirstOrDefaultAsync(p => p.User.Id == currentUserId);

            var parent = await _parentRepository.FirstOrDefaultAsync(p => p.Applicant.Id == applicant.Id);

            if (parent == null)
            {
                throw new ApplicationException("Parent not found.");
            }

            return ObjectMapper.Map<ParentGetDto>(parent);
        }

        public async Task<ParentGetDto> GetByApplicantIdAsync(Guid appId)
        {
            var parent = await _parentRepository.FirstOrDefaultAsync(p => p.Applicant.Id == appId);

            if (parent == null)
            {
                throw new ApplicationException("Parent not found.");
            }

            return ObjectMapper.Map<ParentGetDto>(parent);
        }

        public async Task<ParentPostDto> UpdateAsync(ParentPostDto input)
        {
            var parent = await _parentRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, parent);
            return ObjectMapper.Map<ParentPostDto>(parent);
        }
    }
}
