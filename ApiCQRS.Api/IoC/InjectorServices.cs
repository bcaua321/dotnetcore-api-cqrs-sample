using ApiCQRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCQRS.Api.IoC
{
    public static class InjectorServices
    {
        public static void AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName));          
            });
        }
    }
}