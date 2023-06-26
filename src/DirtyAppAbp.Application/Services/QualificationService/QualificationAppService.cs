using Abp.Application.Services;
using Abp.Domain.Repositories;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.Helpers;
using DirtyAppAbp.Services.QualificationService.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.QualificationService
{
    public class QualificationAppService: ApplicationService, IQualificationAppService
    {
        private readonly IRepository<Qualification, Guid> _qualificationRepository;
        private readonly IRepository<Applicant, Guid> _applicantRepository;


        public QualificationAppService(IRepository<Qualification, Guid> qualificationRepository, IRepository<Applicant, Guid> applicantRepository)
        {
            _qualificationRepository = qualificationRepository;
            _applicantRepository = applicantRepository;
        }

        public async Task<QualificationPostDto> CreateAsync(QualificationPostDto input)
        {
            var person = await GetCurrentUserPerson();

            var qualification = ObjectMapper.Map<Qualification>(input);
            qualification.Applicant = await _applicantRepository.GetAsync(person.Id);
            await _qualificationRepository.InsertAsync(qualification);
            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<QualificationPostDto>(qualification);
        }

        public async Task<List<QualificationGetDto>> GetAllQualificationsOfPerson()
        {
            var person = await GetCurrentUserPerson();
            var qualifications = await _qualificationRepository.GetAllListAsync(q => q.Applicant.Id == person.Id);
            return ObjectMapper.Map<List<QualificationGetDto>>(qualifications);
        }

        public async Task Delete(Guid id)
        {
            await _qualificationRepository.DeleteAsync(id);
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
