#pragma checksum "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\Categorys.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a84be56f60321be4bd9d084f284e840bd77d974b"
// <auto-generated/>
#pragma warning disable 1591
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
#line 2 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\Categorys.razor"
using UnluCoFinalProject.Domain.Entities;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Category")]
    public partial class Categorys : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Kategoriler</h1>");
#nullable restore
#line 9 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\Categorys.razor"
 if (categorys == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "<p><em>Loading...</em></p>");
#nullable restore
#line 12 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\Categorys.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "table");
            __builder.AddAttribute(3, "class", "table");
            __builder.AddMarkupContent(4, "<thead><tr><th>Kategori Adı</th>\r\n                <th>Kategori Açıklaması</th></tr></thead>\r\n        ");
            __builder.OpenElement(5, "tbody");
#nullable restore
#line 23 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\Categorys.razor"
             foreach (var category in categorys)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(6, "tr");
            __builder.OpenElement(7, "td");
#nullable restore
#line 26 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\Categorys.razor"
__builder.AddContent(8, category.CategoryName);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n                    ");
            __builder.OpenElement(10, "td");
#nullable restore
#line 27 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\Categorys.razor"
__builder.AddContent(11, category.Description);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 29 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\Categorys.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 32 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\Categorys.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 34 "C:\Users\lce_b\OneDrive\Masaüstü\Repo\UnluCoFinalProject\BlazorApp\Pages\Categorys.razor"
       
    private List<Category> categorys;

    protected override async Task OnInitializedAsync()
    {

        categorys = await Http.GetFromJsonAsync<List<Category>>("Category");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
