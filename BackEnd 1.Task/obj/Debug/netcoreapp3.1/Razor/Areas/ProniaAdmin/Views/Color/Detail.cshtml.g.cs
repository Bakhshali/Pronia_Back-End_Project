#pragma checksum "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Color\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3753104a12d6be89e2b41cd4198533978d22645b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ProniaAdmin_Views_Color_Detail), @"mvc.1.0.view", @"/Areas/ProniaAdmin/Views/Color/Detail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\_ViewImports.cshtml"
using BackEnd_1.Task.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\_ViewImports.cshtml"
using BackEnd_1.Task.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3753104a12d6be89e2b41cd4198533978d22645b", @"/Areas/ProniaAdmin/Views/Color/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed4a9268ca533f917ff6c15d42e82a41335c7efc", @"/Areas/ProniaAdmin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_ProniaAdmin_Views_Color_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Color>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Color\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <div>\r\n        <h3>Id</h3>\r\n        <p>");
#nullable restore
#line 10 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Color\Detail.cshtml"
      Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n     <div>\r\n        <h3>Name</h3>\r\n        <p>");
#nullable restore
#line 14 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Color\Detail.cshtml"
      Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Color> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
