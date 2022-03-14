using System.Threading.Tasks;
using UnluCoFinalProject.Domain.Auth;
using UnluCoFinalProject.Domain.Common;

namespace UnluCoFinalProject.Service.Contract
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
    }
}
