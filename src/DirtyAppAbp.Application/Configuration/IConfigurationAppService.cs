using System.Threading.Tasks;
using DirtyAppAbp.Configuration.Dto;

namespace DirtyAppAbp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
