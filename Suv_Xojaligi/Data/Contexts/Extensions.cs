using Microsoft.EntityFrameworkCore;

namespace Suv_Xojaligi.Data.Contexts
{
    public static class Extensions
    {
        public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();
            var sqlConnectionString = configuration.GetConnectionString("Sql");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString);
            });

            return services;
        }
    }
}
