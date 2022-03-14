using BlazorApp.Entities.Common;
using BlazorApp.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.HttpRepository
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<Response<AuthResponseDto>> Login(UserForAuthenticationDto userForAuthentication); 
        Task Logout();
    }
}
