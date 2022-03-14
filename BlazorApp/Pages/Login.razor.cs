using BlazorApp.Entities.DTO;
using BlazorApp.HttpRepository;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorApp.Pages
{
    public partial class Login
    {
        private UserForAuthenticationDto _userForAuthentication = new UserForAuthenticationDto();

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public bool ShowAuthError { get; set; }
        public string Error { get; set; }

        public async Task ExecuteLogin()
        {
            ShowAuthError = false;

            var result = await AuthenticationService.Login(_userForAuthentication);
            if (result.Data.JWToken == null)
            {
                Error = result.Message;
                ShowAuthError = true;
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
