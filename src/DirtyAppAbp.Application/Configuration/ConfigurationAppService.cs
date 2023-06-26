using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using DirtyAppAbp.Configuration.Dto;

namespace DirtyAppAbp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : DirtyAppAbpAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
