using Abp.Application.Services;
using DirtyAppAbp.MultiTenancy.Dto;

namespace DirtyAppAbp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

