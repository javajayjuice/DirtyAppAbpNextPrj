using Abp.Application.Services;
using Abp.Domain.Repositories;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ApplicationFormService.Dtos;
using DirtyAppAbp.Services.ApplicationStatusService.Dtos;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace DirtyAppAbp.Services.ApplicationFormService
{
    public class ApplicationAppService: ApplicationService, IApplicationAppService
    {
        private readonly IRepository<Application, Guid> _applicationRepository;
        private readonly IRepository<ApplicationStatus, Guid> _applicationStatusRepository;
        private readonly IRepository<Applicant, Guid> _applicantRepository;
        private readonly IRepository<Institution, Guid> _institutionRepository;

        public ApplicationAppService(IRepository<Application, Guid> applicationRepository, IRepository<ApplicationStatus, Guid> applicationStatusRepository, IRepository<Applicant, Guid> applicantRepository, IRepository<Institution, Guid> institutionRepository)
        {
            _applicationRepository = applicationRepository;
            _applicationStatusRepository = applicationStatusRepository;
            _applicantRepository = applicantRepository;
            _institutionRepository = institutionRepository;
        }

        public async Task<ApplicationInputDto> CreateAsync(ApplicationInputDto input)
        {
            var person = await GetCurrentUserPerson();

            var application = ObjectMapper.Map<Application>(input);

            application.Applicant = await _applicantRepository.GetAsync(person.Id);
            application.Institution = await _institutionRepository.GetAsync(input.InstitutionId);

            await _applicationRepository.InsertAsync(application);
            CurrentUnitOfWork.SaveChanges();

            Send(person.EmailAddress, "Your application was successfully placed at: " + application.Institution.Name + " wait for further instuctions from the institute. You may come to this portal to check the status of your application. \nThank you for use our service.");

            return ObjectMapper.Map<ApplicationInputDto>(application);
        }

        public async Task Delete(Guid id)
        {
            await _applicationRepository.DeleteAsync(id);
        }

        public void Send(string to, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("kejabulani@gmail.com"));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = "User Successfuly Created";
            email.Body = new TextPart(TextFormat.Plain) { Text = body + " was successfuly created." };

            // send email
            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("kejabulani@gmail.com", "qslwwazgqvlsfkkq");
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public async Task<List<ApplicationOutputDto>> GetAllAsync()
        {
            //var x =  _applicationRepository.GetAllIncluding(a => a.Applicant, i => i.Institution, d => d.Applicant.Address, s=>s.Applicant.ApplicantSubjects, sf=>sf.Applicant.StoredFiles, q=>q.Applicant.Qualifications, f => f.Institution.Campuses).ToList();
            var applications = await _applicationRepository.GetAllIncluding(a => a.Applicant, i => i.Institution, d => d.Applicant.Address, f => f.Applicant.ApplicantSubjects, sf => sf.Applicant.StoredFiles, q => q.Applicant.Qualifications)
                .Include(a => a.Applicant.ApplicantSubjects).ThenInclude(s => s.Subject).ToListAsync();
            return ObjectMapper.Map<List<ApplicationOutputDto>>(applications);
        }

        public async Task<List<ApplicationOutputDto>> GetAllApplicationsForCurrentUser()
        {
            var person = await GetCurrentUserPerson();

            var applications = await _applicationRepository.GetAllIncluding(a => a.Applicant, i => i.Institution, d => d.Applicant.Address, f => f.Applicant.ApplicantSubjects, sf => sf.Applicant.StoredFiles, q => q.Applicant.Qualifications)
                .Include(a => a.Applicant.ApplicantSubjects).ThenInclude(s => s.Subject)
                .Where(a => a.Applicant.Id == person.Id)
                .ToListAsync();

            return ObjectMapper.Map<List<ApplicationOutputDto>>(applications);
        }

        public async Task<ApplicationOutputDto> GetById(Guid id)
        {
            var person = await GetCurrentUserPerson();

            var applications = await _applicationRepository.GetAllIncluding(a => a.Applicant, i => i.Institution, d => d.Applicant.Address, f => f.Applicant.ApplicantSubjects, sf => sf.Applicant.StoredFiles, q => q.Applicant.Qualifications)
                .Include(a => a.Applicant.ApplicantSubjects).ThenInclude(s => s.Subject).FirstOrDefaultAsync(a => a.Id == id);

            return ObjectMapper.Map<ApplicationOutputDto>(applications);
        }

        //get person from logged in user
        private async Task<Applicant> GetCurrentUserPerson()
        {
            var currentUserId = AbpSession.UserId;

            if (currentUserId == null)
            {
                throw new ApplicationException("User Invalid!!!");
            }

            var person = await _applicantRepository.GetAllIncluding(p => p.Address)
                    .FirstOrDefaultAsync(p => p.User.Id == currentUserId);

            if (person == null)
            {
                throw new ApplicationException("Person Not Found!!!");
            }

            return person;
        }
    }
}
