using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System.Data.Common;

namespace Master.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure<TDbContext>(
            DbContextOptionsBuilder<TDbContext> dbContextOptions, 
            string connectionString
            )
            where TDbContext : AbpDbContext
        {
            dbContextOptions.UseSqlite(connectionString);
            //dbContextOptions.UseLazyLoadingProxies().UseMySql(connectionString).ConfigureWarnings(warnnngs => { warnnngs.Log(CoreEventId.LazyLoadOnDisposedContextWarning); warnnngs.Log(CoreEventId.DetachedLazyLoadingWarning); })
                //.UseLoggerFactory(MyLoggerFactory)
                ;
            //builder.UseSqlServer(connectionString,b=>b.UseRowNumberForPaging());
        }
        public static void Configure<TDbContext>(DbContextOptionsBuilder<TDbContext> dbContextOptions, DbConnection connection)
            where TDbContext : AbpDbContext
        {
            dbContextOptions.UseSqlite(connection);
            //dbContextOptions.UseLazyLoadingProxies().UseMySql(connection).ConfigureWarnings(warnnngs => { warnnngs.Log(CoreEventId.LazyLoadOnDisposedContextWarning); warnnngs.Log(CoreEventId.DetachedLazyLoadingWarning); })
                //.UseLoggerFactory(MyLoggerFactory)
                ;
            //builder.UseSqlServer(connection, b => b.UseRowNumberForPaging());
        }
    }
}
