using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Auth;
using UnluCoFinalProject.Domain.Common;
using UnluCoFinalProject.Domain.Enum;
using UnluCoFinalProject.Domain.Settings;
using UnluCoFinalProject.Service.Contract;
using UnluCoFinalProject.Service.Exceptions;

namespace UnluCoFinalProject.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly JWTSettings _jwtSettings;
        private readonly IDateTimeService _dateTimeService;
        private readonly IFeatureManager _featureManager;
        public AccountService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<JWTSettings> jwtSettings,
            IDateTimeService dateTimeService,
            SignInManager<ApplicationUser> signInManager,
            IEmailService emailService,
            IFeatureManager featureManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _dateTimeService = dateTimeService;
            _signInManager = signInManager;
            _emailService = emailService;
            _featureManager = featureManager;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new ApiException($"No Accounts Registered with {request.Email}.");
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: true);
            if (!result.Succeeded)
            {
                await _userManager.AccessFailedAsync(user);
                throw new ApiException($"Invalid Credentials for '{request.Email}'.");
            }
            if (result.IsLockedOut)
            {
                BackgroundJob.Schedule(() => _emailService.SendEmailAsync(new MailRequest { ToEmail = user.Email, From = user.Email, Subject = "Hatalı giriş", Body = "Sitemize 3 kere hatalı parola işlemindne sonra hesap banlanmaktadır." }), TimeSpan.Zero);
                throw new ApiException($"This account has been banned '{request.Email}'.");
            }
            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
            AuthenticationResponse response = new AuthenticationResponse();
            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            return new Response<AuthenticationResponse>(response, $"Authenticated {user.FirstName}");
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = RandomTokenString()
            };
            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.BASIC.ToString());
                    // Hangfire ile async mail gönderimi.
                    BackgroundJob.Schedule(() => _emailService.SendEmailAsync(new MailRequest { ToEmail = user.Email, From = user.Email, Subject = "Hoşgeldiniz", Body = "Sitemize Üye olduğunuz için teşekkür ederiz." }), TimeSpan.Zero);
                    return new Response<string>(user.Id, message: $"User Registered.");
                }
                else
                {
                    throw new ApiException($"{result.Errors.ToList()[0].Description}");
                }
            }
            else
            {
                throw new ApiException($"Email {request.Email } is already registered.");
            }
        }

        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }

}
