using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using DirtyAppAbp.Authorization.Users;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.ApplicantService.Dtos;
using DirtyAppAbp.Services.ParentService.Dtos;
using DirtyAppAbp.Services.PersonService.Dtos;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace DirtyAppAbp.Services.ApplicantService
{
    public class ApplicantAppService : ApplicationService, IApplicantAppService
    {
        private readonly IRepository<Applicant, Guid> _applicantRepository;
        private readonly IRepository<Qualification, Guid> _qualificationRepository;
        private readonly IRepository<StoredFile, Guid> _storedFileRepository;
        private readonly IRepository<ApplicantSubject, Guid> _applicantSubjectRepository;
        private readonly IRepository<Address, Guid> _addressRepository;
        private readonly IRepository<Parent, Guid> _parentRepository;
        private readonly UserManager _userManager;

        public ApplicantAppService(IRepository<Applicant, Guid> applicantRepository, 
            UserManager userManager, IRepository<Qualification, Guid> qualificationRepositor, 
            IRepository<StoredFile, Guid> storedFileRepository,
            IRepository<ApplicantSubject, Guid> applicantSubjectRepository,
            IRepository<Address, Guid> addressRepository,
            IRepository<Parent, Guid> parentRepository)
        {
            _applicantRepository = applicantRepository;
            _userManager = userManager;
            _qualificationRepository = qualificationRepositor;
            _storedFileRepository = storedFileRepository;
            _applicantSubjectRepository = applicantSubjectRepository;
            _addressRepository = addressRepository;
            _parentRepository = parentRepository;
        }

        public async Task<ApplicantPostDto> CreateAsync(ApplicantPostDto input)
        {
            input.UserName = CreateUniqueUsername(input);
            var person = ObjectMapper.Map<Applicant>(input);
            
            person.User = await CreateUser(input);
            var x = await _applicantRepository.InsertAsync(person);

            var y = ObjectMapper.Map<ApplicantPostDto>(x);

            return y;
        }

        private string CreateUniqueUsername(ApplicantPostDto input)
        {
            string firstInitial = input.Name.Substring(0, 1);
            string lastInitial = input.Surname.Substring(0, 1);

            DateTime currentDate = DateTime.Now;
            string datePart = currentDate.ToString("yyyyMMdd");
            string timePart = currentDate.ToString("HHmm");

            string uniqueUsername = $"{firstInitial}{lastInitial}{datePart}{timePart}";

            return uniqueUsername;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicantGetDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicantGetDto> GetAsync()
        {
            var person = await GetCurrentUserPerson();
            var parent = await _parentRepository.FirstOrDefaultAsync(a => a.Applicant.Id == person.Id);
            var applicant = await _applicantRepository.GetAsync(person.Id);
            applicant.Qualifications = await _qualificationRepository.GetAll().Where(m => m.Applicant.Id == person.Id).ToListAsync();
            applicant.StoredFiles = await _storedFileRepository.GetAll().Where(m => m.Applicant.Id == person.Id).ToListAsync();
            applicant.ApplicantSubjects = await _applicantSubjectRepository.GetAll().Where(m => m.Applicant.Id == person.Id).ToListAsync();
            applicant.Address = person.Address;
            

            var results = ObjectMapper.Map<ApplicantGetDto>(applicant);
            results.Parent = ObjectMapper.Map<ParentGetDto>(parent);

            return results;
        }

        public async Task<ApplicantPostDto> UpdateAsync(ApplicantPostDto input)
        {
            var person = await GetCurrentUserPerson();

            person.PhoneNumber = input.PhoneNumber;
            person.EmailAddress = input.EmailAddress;
            var updated = await _applicantRepository.UpdateAsync(person);

            Send(person.EmailAddress, "Your contact details has been changed. At " + updated.LastModificationTime + "If it is not you contact us.");
            //var person = ObjectMapper.Map<Applicant>(input);
            //var updated = await _applicantRepository.UpdateAsync(person);
            return ObjectMapper.Map<ApplicantPostDto>(updated);
        }

        //
        private async Task<User> CreateUser(PersonPostDto input)
        {
            var user = ObjectMapper.Map<User>(input);
            ObjectMapper.Map(input, user);
            if (!string.IsNullOrEmpty(user.NormalizedUserName) && !string.IsNullOrEmpty(user.NormalizedEmailAddress))
                user.SetNormalizedNames();
            user.TenantId = AbpSession.TenantId;
            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, input.Password));
            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRolesAsync(user, input.RoleNames));
            }

            Send(user.EmailAddress, input.UserName);

            CurrentUnitOfWork.SaveChanges();
            return user;
        }
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        private void Send(string to, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("kejabulani@gmail.com"));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = "User Successfuly Created";
            email.Body = new TextPart(TextFormat.Plain) { Text = body + " was successfuly created. You may now login with your username." };

            // send email
            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("kejabulani@gmail.com", "qslwwazgqvlsfkkq");
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        //get person from logged in user
        private async Task<Applicant> GetCurrentUserPerson()
        {
            var currentUserId = AbpSession.UserId;

            if (currentUserId == null)
            {
                throw new ApplicationException("User Invalid!!!");
            }

            var person = await _applicantRepository
                    .GetAllIncluding(p => p.User, p => p.Address)
                    .FirstOrDefaultAsync(p => p.User.Id == currentUserId);

            if (person == null)
            {
                throw new ApplicationException("Person Not Found!!!");
            }

            return person;
        }
    }
}
