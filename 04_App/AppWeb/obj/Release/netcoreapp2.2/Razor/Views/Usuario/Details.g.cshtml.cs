#pragma checksum "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e22efe19fc3ce26f313f3ae485e604dfc555c513"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Details), @"mvc.1.0.view", @"/Views/Usuario/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Usuario/Details.cshtml", typeof(AspNetCore.Views_Usuario_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e22efe19fc3ce26f313f3ae485e604dfc555c513", @"/Views/Usuario/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75a45b59a216ede8d1c1f849b2aeca0bec0c5365", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entidad.Entidad.Seguridad.Usuario>
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
            BeginContext(42, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(87, 273, true);
            WriteLiteral(@"
<div class=""row page-titles"">
    <div class=""col-md-5 align-self-center"">
        <h3 class=""text-themecolor"">Detalle de Usuario</h3>
    </div>
    <div class=""col-md-7 align-self-center"">
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item""><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 360, "\"", 398, 1);
#line 13 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
WriteAttributeValue("", 367, Url.Action("Index", "Usuario"), 367, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(399, 370, true);
            WriteLiteral(@">Usuario</a></li>
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
            BeginContext(770, 45, false);
#line 28 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.IdUsuario));

#line default
#line hidden
            EndContext();
            BeginContext(815, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(925, 41, false);
#line 31 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayFor(model => model.IdUsuario));

#line default
#line hidden
            EndContext();
            BeginContext(966, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(1075, 44, false);
#line 34 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(1119, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(1229, 40, false);
#line 37 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(1269, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(1378, 47, false);
#line 40 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Contrasenia));

#line default
#line hidden
            EndContext();
            BeginContext(1425, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(1535, 43, false);
#line 43 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Contrasenia));

#line default
#line hidden
            EndContext();
            BeginContext(1578, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(1687, 42, false);
#line 46 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(1729, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(1839, 38, false);
#line 49 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(1877, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(1986, 51, false);
#line 52 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.ApellidoPaterno));

#line default
#line hidden
            EndContext();
            BeginContext(2037, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(2147, 47, false);
#line 55 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayFor(model => model.ApellidoPaterno));

#line default
#line hidden
            EndContext();
            BeginContext(2194, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(2303, 51, false);
#line 58 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.ApellidoMaterno));

#line default
#line hidden
            EndContext();
            BeginContext(2354, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(2464, 47, false);
#line 61 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayFor(model => model.ApellidoMaterno));

#line default
#line hidden
            EndContext();
            BeginContext(2511, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(2620, 44, false);
#line 64 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayNameFor(model => model.IdEstado));

#line default
#line hidden
            EndContext();
            BeginContext(2664, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(2774, 40, false);
#line 67 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
                       Write(Html.DisplayFor(model => model.IdEstado));

#line default
#line hidden
            EndContext();
            BeginContext(2814, 127, true);
            WriteLiteral("\r\n                        </dd>\r\n                    </dl>\r\n                </div>\r\n                <div>\r\n                    ");
            EndContext();
            BeginContext(2942, 66, false);
#line 72 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Usuario\Details.cshtml"
               Write(Html.ActionLink("Modificar", "Edit", new { id = Model.IdUsuario }));

#line default
#line hidden
            EndContext();
            BeginContext(3008, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(3032, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e22efe19fc3ce26f313f3ae485e604dfc555c51312181", async() => {
                BeginContext(3054, 19, true);
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
            BeginContext(3077, 80, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entidad.Entidad.Seguridad.Usuario> Html { get; private set; }
    }
}
#pragma warning restore 1591
