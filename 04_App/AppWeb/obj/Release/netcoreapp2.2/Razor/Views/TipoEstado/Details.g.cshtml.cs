#pragma checksum "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\TipoEstado\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "016a6420b53a9e08f6527b0ac3be05c11a4cf762"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TipoEstado_Details), @"mvc.1.0.view", @"/Views/TipoEstado/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/TipoEstado/Details.cshtml", typeof(AspNetCore.Views_TipoEstado_Details))]
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
#line 1 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\_ViewImports.cshtml"
using AppWeb;

#line default
#line hidden
#line 2 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\_ViewImports.cshtml"
using AppWeb.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"016a6420b53a9e08f6527b0ac3be05c11a4cf762", @"/Views/TipoEstado/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75a45b59a216ede8d1c1f849b2aeca0bec0c5365", @"/Views/_ViewImports.cshtml")]
    public class Views_TipoEstado_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entidad.Entidad.Maestro.TipoEstado>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\TipoEstado\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(88, 277, true);
            WriteLiteral(@"
<div class=""row page-titles"">
    <div class=""col-md-5 align-self-center"">
        <h3 class=""text-themecolor"">Detalle de Tipo Estado</h3>
    </div>
    <div class=""col-md-7 align-self-center"">
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item""><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 365, "\"", 406, 1);
#line 13 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\TipoEstado\Details.cshtml"
WriteAttributeValue("", 372, Url.Action("Index", "TipoEstado"), 372, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(407, 372, true);
            WriteLiteral(@">Tipo Estado</a></li>
            <li class=""breadcrumb-item active"">Detalle</li>
        </ol>
    </div>
</div>

<div class=""row"">
    <div class=""col-md-12"">
        <div class=""card"">
            <div class=""card-body"">
                <div>

                    <dl class=""row"">
                        <dt class=""col-sm-2"">
                            ");
            EndContext();
            BeginContext(780, 48, false);
#line 27 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\TipoEstado\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.IdTipoEstado));

#line default
#line hidden
            EndContext();
            BeginContext(828, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(938, 44, false);
#line 30 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\TipoEstado\Details.cshtml"
                       Write(Html.DisplayFor(model => model.IdTipoEstado));

#line default
#line hidden
            EndContext();
            BeginContext(982, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(1091, 42, false);
#line 33 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\TipoEstado\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(1133, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(1243, 38, false);
#line 36 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\TipoEstado\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(1281, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(1390, 47, false);
#line 39 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\TipoEstado\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Observacion));

#line default
#line hidden
            EndContext();
            BeginContext(1437, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(1547, 43, false);
#line 42 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\TipoEstado\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Observacion));

#line default
#line hidden
            EndContext();
            BeginContext(1590, 127, true);
            WriteLiteral("\r\n                        </dd>\r\n                    </dl>\r\n                </div>\r\n                <div>\r\n                    ");
            EndContext();
            BeginContext(1718, 69, false);
#line 47 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\TipoEstado\Details.cshtml"
               Write(Html.ActionLink("Modificar", "Edit", new { id = Model.IdTipoEstado }));

#line default
#line hidden
            EndContext();
            BeginContext(1787, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(1811, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "016a6420b53a9e08f6527b0ac3be05c11a4cf7628304", async() => {
                BeginContext(1833, 19, true);
                WriteLiteral("Retornar al listado");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1856, 80, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entidad.Entidad.Maestro.TipoEstado> Html { get; private set; }
    }
}
#pragma warning restore 1591
