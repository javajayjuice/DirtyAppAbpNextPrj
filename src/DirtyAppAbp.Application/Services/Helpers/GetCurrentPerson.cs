using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using DirtyAppAbp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.Helpers
{
    public class GetCurrentPerson:ApplicationService
    {
        private readonly IRepository<Applicant, Guid> _applicantRepository;

        public GetCurrentPerson(IRepository<Applicant, Guid> applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public  async Task<Person> GetCurrentPersonLogged()
        {
            if (AbpSession.UserId == null)
            {
                throw new ApplicationException("User Invalid!!!");
            }

            var person = await _applicantRepository?.FirstOrDefaultAsync(p => p.User.Id == AbpSession.UserId);

            return person;
        }
    }

}
