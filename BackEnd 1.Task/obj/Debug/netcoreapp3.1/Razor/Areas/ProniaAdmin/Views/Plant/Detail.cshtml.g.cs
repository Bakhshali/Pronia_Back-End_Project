#pragma checksum "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Plant\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "586fae8870179712ccc850ecbbaff97ca576d30f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ProniaAdmin_Views_Plant_Detail), @"mvc.1.0.view", @"/Areas/ProniaAdmin/Views/Plant/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"586fae8870179712ccc850ecbbaff97ca576d30f", @"/Areas/ProniaAdmin/Views/Plant/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82555acb3fa2d5b9c080299b12c4a01df6d5a4f5", @"/Areas/ProniaAdmin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_ProniaAdmin_Views_Plant_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Plant>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:150px; height:120px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n     <div>\r\n        <h4>Id</h4>\r\n        <p>");
#nullable restore
#line 9 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
      Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n     <div>\r\n        <h4>Image</h4>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "586fae8870179712ccc850ecbbaff97ca576d30f4256", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 226, "~/assets/images/website-images/", 226, 31, true);
#nullable restore
#line 13 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
AddHtmlAttributeValue("", 257, Model.PlantImages.FirstOrDefault(i=>i.IsMain==true).ImagePath, 257, 62, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        <h4>Name</h4>\r\n        <p>");
#nullable restore
#line 17 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
      Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n     <div>\r\n        <h4>Price</h4>\r\n        <p>");
#nullable restore
#line 21 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
      Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n     <div>\r\n        <h4>Description</h4>\r\n        <p>");
#nullable restore
#line 25 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
      Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n     <div>\r\n        <h4>SKUCode</h4>\r\n        <p>");
#nullable restore
#line 29 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
      Write(Model.SKUCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n     <div>\r\n        <h3>Request</h3>\r\n        <p>");
#nullable restore
#line 33 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
      Write(Model.Request);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n     <div>\r\n        <h3>Shipping</h3>\r\n        <p>");
#nullable restore
#line 37 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
      Write(Model.Shipping);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n     <div>\r\n        <h3>Guarantee</h3>\r\n        <p>");
#nullable restore
#line 41 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
      Write(Model.Guarantee);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    <div>\r\n        <h3>Color</h3>\r\n        <p>");
#nullable restore
#line 45 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
      Write(Model.Color);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n      <div>\r\n        <h3>Size</h3>\r\n        <p>");
#nullable restore
#line 49 "C:\Users\Ali\source\repos\BackEnd 1.Task\BackEnd 1.Task\Areas\ProniaAdmin\Views\Plant\Detail.cshtml"
      Write(Model.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n    \r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Plant> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
