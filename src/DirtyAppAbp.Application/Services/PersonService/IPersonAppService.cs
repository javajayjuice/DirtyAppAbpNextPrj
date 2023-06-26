using Abp.Application.Services;
using DirtyAppAbp.Services.PersonService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.PersonService
{
    public interface IPersonAppService : IApplicationService
    {
        Task<PersonPostDto> CreateAsync(PersonPostDto input);
        Task<PersonGetDto> GetAsync(Guid id);
        Task<List<PersonGetDto>> GetAllAsync();
        Task<PersonPostDto> UpdateAsync(PersonPostDto input);
        Task Delete(Guid id);
    }
}
