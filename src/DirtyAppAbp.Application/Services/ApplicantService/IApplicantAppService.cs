using Abp.Application.Services;
using DirtyAppAbp.Services.ApplicantService.Dtos;
using DirtyAppAbp.Services.ParentService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirtyAppAbp.Services.ApplicantService
{
    public interface IApplicantAppService : IApplicationService
    {
        Task<ApplicantPostDto> CreateAsync(ApplicantPostDto input);
        Task<ApplicantGetDto> GetAsync();
        Task<List<ApplicantGetDto>> GetAllAsync();
        Task<ApplicantPostDto> UpdateAsync(ApplicantPostDto input);
        Task Delete(Guid id);
    }
}
