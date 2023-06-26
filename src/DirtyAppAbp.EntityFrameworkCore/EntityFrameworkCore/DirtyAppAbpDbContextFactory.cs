using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DirtyAppAbp.Configuration;
using DirtyAppAbp.Web;

namespace DirtyAppAbp.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class DirtyAppAbpDbContextFactory : IDesignTimeDbContextFactory<DirtyAppAbpDbContext>
    {
        public DirtyAppAbpDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DirtyAppAbpDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DirtyAppAbpDbContextConfigurer.Configure(builder, configuration.GetConnectionString(DirtyAppAbpConsts.ConnectionStringName));

            return new DirtyAppAbpDbContext(builder.Options);
        }
    }
}
