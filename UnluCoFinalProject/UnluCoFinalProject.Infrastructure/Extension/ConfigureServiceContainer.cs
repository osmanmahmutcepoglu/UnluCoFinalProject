using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using UnluCoFinalProject.Domain.Settings;

using UnluCoFinalProject.Persistence;
using UnluCoFinalProject.Service.Contract;
using UnluCoFinalProject.Service.Implementation;

namespace UnluCoFinalProject.Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddDbContext(this IServiceCollection serviceCollection,
             IConfiguration configuration, IConfigurationRoot configRoot)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("OnionArchConn") ?? configRoot["ConnectionStrings:OnionArchConn"]
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


        }

        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {

        }
        public static void AddHangfireMapper(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString("Hangfire")));

            serviceCollection.AddHangfireServer();
        }



        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());


        }
        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDateTimeService, DateTimeService>();
            serviceCollection.AddTransient<IAccountService, AccountService>();
        }



        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc(
                    "OpenAPISpecification",
                    new OpenApiInfo()
                    {
                        Title = "Unlu&Co Final Project",
                    });

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = $"Input your Bearer token in this format - Bearer token to access this API",
                });
                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });
            });


        }

        public static void AddMailSetting(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        }

        public static void AddController(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers().AddNewtonsoftJson();
        }
    }
}
