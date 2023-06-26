using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DirtyAppAbp.EntityFrameworkCore
{
    public static class DirtyAppAbpDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DirtyAppAbpDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<DirtyAppAbpDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
