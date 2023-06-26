using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DirtyAppAbp.Authorization;

namespace DirtyAppAbp
{
    [DependsOn(
        typeof(DirtyAppAbpCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class DirtyAppAbpApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<DirtyAppAbpAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(DirtyAppAbpApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
