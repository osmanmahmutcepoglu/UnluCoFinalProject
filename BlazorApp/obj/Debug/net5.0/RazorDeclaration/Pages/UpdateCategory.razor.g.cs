// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\_Imports.razor"
using BlazorApp.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\_Imports.razor"
using BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\_Imports.razor"
using BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\_Imports.razor"
using BlazorApp.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\UpdateCategory.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\UpdateCategory.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\UpdateCategory.razor"
using UnluCoFinalProject.Domain.Entities;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/UpdateCategory")]
    public partial class UpdateCategory : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 56 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\UpdateCategory.razor"
       
    private List<Category> categorys;
    private UpdateCategoryDto _updateCategoryDto = new UpdateCategoryDto();
    private SuccessNotification _notification;

    protected override async Task OnInitializedAsync()
    {
        categorys = await Http.GetFromJsonAsync<List<Category>>("Category");
    }

    private void GetCategory(ChangeEventArgs e)
    {
        var select = categorys.SingleOrDefault(x => x.Id.ToString() == e.Value.ToString());
        _updateCategoryDto.Id = select.Id;
        _updateCategoryDto.CategoryName = select.CategoryName;
        _updateCategoryDto.Description = select.Description;
    }

    private async Task Update()
    {
        var content = JsonSerializer.Serialize(_updateCategoryDto);
        var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
        string uri = "Category/" + _updateCategoryDto.Id.ToString();
        var registrationResult = await Http.PutAsync(uri, bodyContent);
        _notification.Show("Category");
    }

    private class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
