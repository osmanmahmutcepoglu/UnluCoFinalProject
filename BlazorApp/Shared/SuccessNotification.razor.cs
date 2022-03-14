using Microsoft.AspNetCore.Components;

namespace BlazorApp.Shared
{
    public partial class SuccessNotification
    {
        private string _modalDisplay;
        private string _modalClass;
        private bool _showBackdrop;
        private string _navUrl = "";

        [Inject]
        public NavigationManager Navigation { get; set; }

        public void Show(string url)
        {
            _modalDisplay = "block;";
            _modalClass = "show";
            _showBackdrop = true;
            _navUrl = url;
            StateHasChanged();
        }

        private void Hide()
        {
            _modalDisplay = "none;";
            _modalClass = "";
            _showBackdrop = false;
            StateHasChanged();
            Navigation.NavigateTo("/"+_navUrl);
        }
    }
}
