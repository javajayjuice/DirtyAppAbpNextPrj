using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace DirtyAppAbp.Controllers
{
    public abstract class DirtyAppAbpControllerBase: AbpController
    {
        protected DirtyAppAbpControllerBase()
        {
            LocalizationSourceName = DirtyAppAbpConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
