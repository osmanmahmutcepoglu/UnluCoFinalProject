using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Text;
using UnluCoFinalProject.Domain.Auth;
using UnluCoFinalProject.Domain.Common;
using UnluCoFinalProject.Domain.Settings;
using UnluCoFinalProject.Persistence;
using UnluCoFinalProject.Service.Contract;
using UnluCoFinalProject.Service.Implementation;
using UnluCoFinalProject.Service.Validation;

namespace UnluCoFinalProject.Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            // or you can use assembly in Extension method in Infra layer with below command
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IEmailService, MailService>();
        }

        public static void AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("IdentityConnection"),
                b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));

            //AddPasswordValidator ile custom parola kuralı ekliyoruz (20 karakterden fazla olamaz).
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders()
                .AddPasswordValidator<CustomIdentityPasswordValidator>(); ;

            // Projemize Identity'i dahil ediyoruz.
            // Minimum karakter sayısını 8 olarak belirliyoruz.
            // Maksimum karakter sayısı için custom validator ekliyoruz.
            //3 kere hatalı oturum açma işleminde hesabı 365 günlüğüne banlıyoruz.

            services.Configure<IdentityOptions>(options =>
            {

                // Password settings.
                options.Password.RequiredLength = 8;
                options.SignIn.RequireConfirmedAccount = false;
                options.Lockout.AllowedForNewUsers = false;
                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(365);
                options.Lockout.MaxFailedAccessAttempts = 3;

                
                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                options.User.RequireUniqueEmail = true;

            });
            #region Services
            services.AddTransient<IAccountService, AccountService>();
            #endregion
            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JWTSettings:Issuer"],
                        ValidAudience = configuration["JWTSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                    };
                    o.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = c =>
                        {
                            c.NoResult();
                            c.Response.StatusCode = 500;
                            c.Response.ContentType = "text/plain";
                            return c.Response.WriteAsync(c.Exception.ToString());
                        },
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(new Response<string>("You are not Authorized"));
                            return context.Response.WriteAsync(result);
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = 403;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(new Response<string>("You are not authorized to access this resource"));
                            return context.Response.WriteAsync(result);
                        },
                    };
                });
        }
    }
}

