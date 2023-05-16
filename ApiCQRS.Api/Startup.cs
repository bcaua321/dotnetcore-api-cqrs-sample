using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ApiCQRS.Api;
using ApiCQRS.Api.IoC;
using ApiCQRS.Core.UserContext;
using ApiCQRS.Infrastructure.Data.Repositories;

namespace Commerce.Api
{
    public class Startup : ApiCQRS.Api.Interfaces.IStartup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration) 
        {
            this.Configuration = configuration; 
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var applicationAssemblyName = Assembly.GetExecutingAssembly()
            .GetReferencedAssemblies()
            .FirstOrDefault(x => x.Name == "ApiCQRS.Application");
            Assembly applicationAssembly = Assembly.Load(applicationAssemblyName);

            services.AddDbContextServices(Configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddMediatR(m => m.RegisterServicesFromAssembly(applicationAssembly));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}