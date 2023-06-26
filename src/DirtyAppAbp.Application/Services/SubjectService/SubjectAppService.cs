using Abp.Application.Services;
using Abp.Domain.Repositories;
using DirtyAppAbp.Domain;
using System;

namespace DirtyAppAbp.Services.SubjectService
{
    public class SubjectAppService : AsyncCrudAppService<Subject, SubjectDto, Guid>, ISubjectAppService
    {
        private readonly IRepository<Subject, Guid> _subjectRepository;

        public SubjectAppService(IRepository<Subject, Guid> repository) : base(repository)
        {
            this._subjectRepository = repository;
        }
    }
}
