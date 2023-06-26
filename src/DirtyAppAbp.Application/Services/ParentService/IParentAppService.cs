using Abp.Application.Services;
using DirtyAppAbp.Services.ParentService.Dtos;
using DirtyAppAbp.Services.PersonService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ParentService
{
    public interface IParentAppService : IApplicationService
    {
        Task<ParentPostDto> CreateAsync(ParentPostDto input);
        Task<ParentGetDto> GetAsync();
        Task<List<ParentGetDto>> GetAllAsync();
        Task<ParentPostDto> UpdateAsync(ParentPostDto input);
        Task Delete(Guid id);
    }
}
