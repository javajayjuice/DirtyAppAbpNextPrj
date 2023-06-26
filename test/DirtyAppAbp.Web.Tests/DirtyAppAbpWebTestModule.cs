using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DirtyAppAbp.EntityFrameworkCore;
using DirtyAppAbp.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace DirtyAppAbp.Web.Tests
{
    [DependsOn(
        typeof(DirtyAppAbpWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class DirtyAppAbpWebTestModule : AbpModule
    {
        public DirtyAppAbpWebTestModule(DirtyAppAbpEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DirtyAppAbpWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(DirtyAppAbpWebMvcModule).Assembly);
        }
    }
}