using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using System;
using System.IO;
using UnluCoFinalProject.Domain.Settings;
using UnluCoFinalProject.Infrastructure.Extension;
using UnluCoFinalProject.Persistence;
using UnluCoFinalProject.Service;

namespace UnluCoFinalProject
{
    public class Startup
    {
        private readonly IConfigurationRoot configRoot;
        private AppSettings AppSettings { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configRoot = builder.Build();

            AppSettings = new AppSettings();
            Configuration.Bind(AppSettings);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddController();

            services.AddDbContext(Configuration, configRoot);

            services.AddIdentityService(Configuration);

            services.AddAutoMapper();

            services.AddScopedServices();

            services.AddTransientServices();

            services.AddSwaggerOpenAPI();

            services.AddMailSetting(Configuration);

            services.AddServiceLayer();

            services.AddFeatureManagement();

            services.AddHangfireMapper(Configuration);
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UnluCo.Final.Project v1"));
            }
            app.UseHttpsRedirection();

            app.UseCors(options =>
                 options.WithOrigins("https://localhost:44313")
                 .AllowAnyHeader()
                 .AllowAnyMethod());

            app.ConfigureCustomExceptionMiddleware();



            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            app.ConfigureSwagger();
            app.UseHangfireDashboard();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
