using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using DirtyAppAbp.Authorization.Users;
using DirtyAppAbp.Domain;
using DirtyAppAbp.Services.PersonService.Dtos;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace DirtyAppAbp.Services.PersonService
{
    public class PersonAppService : ApplicationService, IPersonAppService
    {
        private readonly IRepository<Person, Guid> _PersonRepository;
        private readonly UserManager _userManager;
        public PersonAppService(IRepository<Person, Guid> personRepository, UserManager userManager)
        {
            _PersonRepository = personRepository;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<PersonPostDto> CreateAsync(PersonPostDto input)
        {
            var person = ObjectMapper.Map<Person>(input);
            person.User = await CreateUser(input);
            return ObjectMapper.Map<PersonPostDto>(  await _PersonRepository.InsertAsync(person));
        }
        [HttpGet]
        public async Task<List<PersonGetDto>> GetAllAsync()
        {
            var query = _PersonRepository.GetAllIncluding(m => m.User, a =>a.Address).ToList();
            return ObjectMapper.Map<List<PersonGetDto>>(query);
        }
        [HttpGet]
        public async Task<PersonGetDto> GetAsync(Guid id)
        {
            var query = _PersonRepository.GetAllIncluding(m => m.User).FirstOrDefault(x => x.Id == id);
            return ObjectMapper.Map<PersonGetDto>(query);
        }
        [HttpPut]
        public async Task<PersonPostDto> UpdateAsync(PersonPostDto input)
        {
            var person = _PersonRepository.Get(input.Id);
            var updt = await _PersonRepository.UpdateAsync(ObjectMapper.Map(input, person));
            return ObjectMapper.Map<PersonPostDto>(updt);
        }
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _PersonRepository.DeleteAsync(id);
        }
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
            email.Body = new TextPart(TextFormat.Plain) { Text = body + " was successfuly created." };

            // send email
            var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("kejabulani@gmail.com", "qslwwazgqvlsfkkq");
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public async Task<PersonGetDto> GetAsyncPerson(long id)
        {
            var person = _PersonRepository.FirstOrDefault(p => p.User.Id == id);
            if (person == null)
            {
                return null;
            }

            return ObjectMapper.Map<PersonGetDto>(person);
        }

        [HttpGet]
        public async Task<PersonGetDto> GetPersonAsync(long id)

        {
            var query = _PersonRepository.GetAllIncluding(m => m.User).FirstOrDefault(x => x.User.Id == id);
            return ObjectMapper.Map<PersonGetDto>(query);
        }

    }
}
