using System.Reflection;
using ApiCQRS.Api.IoC;
using ApiCQRS.Core.UserContext;
using ApiCQRS.Infrastructure.Data.Repositories;
using ApiCQRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CQRS API"
                });
            });
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
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            if (env.EnvironmentName == "Docker")
            {
                using (var serviceScope = app.Services.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                }
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}