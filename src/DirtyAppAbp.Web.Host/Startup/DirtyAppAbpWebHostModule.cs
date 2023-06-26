using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DirtyAppAbp.Configuration;

namespace DirtyAppAbp.Web.Host.Startup
{
    [DependsOn(
       typeof(DirtyAppAbpWebCoreModule))]
    public class DirtyAppAbpWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public DirtyAppAbpWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DirtyAppAbpWebHostModule).GetAssembly());
        }
    }
}
