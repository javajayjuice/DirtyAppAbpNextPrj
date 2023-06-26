using System.Threading.Tasks;
using Abp.Application.Services;
using DirtyAppAbp.Sessions.Dto;

namespace DirtyAppAbp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
