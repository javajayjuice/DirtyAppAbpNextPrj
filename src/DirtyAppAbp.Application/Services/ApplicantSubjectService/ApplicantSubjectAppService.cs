using Abp.Application.Services;
using Abp.Domain.Repositories;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ApplicantSubjectService.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ApplicantSubjectService
{
    public class ApplicantSubjectAppService : ApplicationService, IApplicantSubjectAppService
    {
        private readonly IRepository<ApplicantSubject, Guid> _applicantSubjectRepository;
        private readonly IRepository<Applicant, Guid> _applicantRepository;
        private readonly IRepository<Subject, Guid> _subjectRepository;

        public ApplicantSubjectAppService(IRepository<ApplicantSubject, Guid> applicantSubjectRepository, IRepository<Applicant, Guid> applicantRepository, IRepository<Subject, Guid> subjectRepository)
        {
            _applicantSubjectRepository = applicantSubjectRepository;
            _applicantRepository = applicantRepository;
            _subjectRepository = subjectRepository;
        }

        public async Task<ApplicantSubjectDto> CreateAsync(ApplicantSubjectDto input)
        {
            var person = await GetCurrentUserPerson();

            var subject = ObjectMapper.Map<ApplicantSubject>(input);

            subject.Subject = await _subjectRepository.GetAsync(input.SubjectId);

            subject.Applicant = await _applicantRepository.GetAsync(person.Id);
            await _applicantSubjectRepository.InsertAsync(subject);
            CurrentUnitOfWork.SaveChanges();

            return ObjectMapper.Map<ApplicantSubjectDto>(subject);
        }

        public async Task Delete(Guid id)
        {
            await _applicantSubjectRepository.DeleteAsync(id);
        }

        public async Task<List<ApplicantSubjectDto>> GetAllAsync()
        {
            var person = await GetCurrentUserPerson();
            var subjects = await _applicantSubjectRepository.GetAll()
                .Where(q => q.Applicant.Id == person.Id)
                .Include(q => q.Subject)
                .ToListAsync();

            if (subjects == null)
            {
                throw new ApplicationException("No Subjects Available!!!");
            }

            return ObjectMapper.Map<List<ApplicantSubjectDto>>(subjects);
        }

        public async Task<ApplicantSubjectDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ApplicantSubjectDto>(await _applicantSubjectRepository.GetAsync(id));
        }

        public async Task<ApplicantSubjectDto> UpdateAsync(ApplicantSubjectDto input)
        {
            var movie = await _applicantSubjectRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, movie);
            return ObjectMapper.Map<ApplicantSubjectDto>(movie);
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
