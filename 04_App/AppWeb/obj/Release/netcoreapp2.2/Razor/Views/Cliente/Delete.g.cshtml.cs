#pragma checksum "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68d41daf97d15c76e037156ce821f8dc188b94e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cliente_Delete), @"mvc.1.0.view", @"/Views/Cliente/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cliente/Delete.cshtml", typeof(AspNetCore.Views_Cliente_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68d41daf97d15c76e037156ce821f8dc188b94e9", @"/Views/Cliente/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75a45b59a216ede8d1c1f849b2aeca0bec0c5365", @"/Views/_ViewImports.cshtml")]
    public class Views_Cliente_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entidad.Entidad.Maestro.Cliente>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(84, 277, true);
            WriteLiteral(@"
<div class=""row page-titles"">
    <div class=""col-md-5 align-self-center"">
        <h3 class=""text-themecolor"">Eliminacion de Cliente</h3>
    </div>
    <div class=""col-md-7 align-self-center"">
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item""><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 361, "\"", 399, 1);
#line 13 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
WriteAttributeValue("", 368, Url.Action("Index", "Cliente"), 368, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(400, 430, true);
            WriteLiteral(@">Cliente</a></li>
            <li class=""breadcrumb-item active"">Eliminar</li>
        </ol>
    </div>
</div>

<div class=""row"">
    <div class=""col-md-12"">
        <div class=""card"">
            <div class=""card-body"">
                <h3>Esta seguro de eliminar el registro?</h3>
                <div>
                    <dl class=""row"">
                        <dt class=""col-sm-2"">
                            ");
            EndContext();
            BeginContext(831, 45, false);
#line 27 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.IdCliente));

#line default
#line hidden
            EndContext();
            BeginContext(876, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(986, 41, false);
#line 30 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.IdCliente));

#line default
#line hidden
            EndContext();
            BeginContext(1027, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(1136, 51, false);
#line 33 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.NumeroDocumento));

#line default
#line hidden
            EndContext();
            BeginContext(1187, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(1297, 47, false);
#line 36 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.NumeroDocumento));

#line default
#line hidden
            EndContext();
            BeginContext(1344, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(1453, 47, false);
#line 39 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.RazonSocial));

#line default
#line hidden
            EndContext();
            BeginContext(1500, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(1610, 43, false);
#line 42 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.RazonSocial));

#line default
#line hidden
            EndContext();
            BeginContext(1653, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(1762, 45, false);
#line 45 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.Direccion));

#line default
#line hidden
            EndContext();
            BeginContext(1807, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(1917, 41, false);
#line 48 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.Direccion));

#line default
#line hidden
            EndContext();
            BeginContext(1958, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(2067, 42, false);
#line 51 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.IdPais));

#line default
#line hidden
            EndContext();
            BeginContext(2109, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(2219, 38, false);
#line 54 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.IdPais));

#line default
#line hidden
            EndContext();
            BeginContext(2257, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(2366, 44, false);
#line 57 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.IdUbigeo));

#line default
#line hidden
            EndContext();
            BeginContext(2410, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(2520, 40, false);
#line 60 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.IdUbigeo));

#line default
#line hidden
            EndContext();
            BeginContext(2560, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(2669, 49, false);
#line 63 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.FechaRegistro));

#line default
#line hidden
            EndContext();
            BeginContext(2718, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(2828, 45, false);
#line 66 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.FechaRegistro));

#line default
#line hidden
            EndContext();
            BeginContext(2873, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(2982, 45, false);
#line 69 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.IdUsuario));

#line default
#line hidden
            EndContext();
            BeginContext(3027, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(3137, 41, false);
#line 72 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.IdUsuario));

#line default
#line hidden
            EndContext();
            BeginContext(3178, 108, true);
            WriteLiteral("\r\n                        </dd>\r\n                        <dt class=\"col-sm-2\">\r\n                            ");
            EndContext();
            BeginContext(3287, 44, false);
#line 75 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayNameFor(model => model.IdEstado));

#line default
#line hidden
            EndContext();
            BeginContext(3331, 109, true);
            WriteLiteral("\r\n                        </dt>\r\n                        <dd class=\"col-sm-10\">\r\n                            ");
            EndContext();
            BeginContext(3441, 40, false);
#line 78 "D:\Proyecto Encuentralo\WebEncuentralo\04_App\AppWeb\Views\Cliente\Delete.cshtml"
                       Write(Html.DisplayFor(model => model.IdEstado));

#line default
#line hidden
            EndContext();
            BeginContext(3481, 82, true);
            WriteLiteral("\r\n                        </dd>\r\n                    </dl>\r\n\r\n                    ");
            EndContext();
            BeginContext(3563, 350, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "68d41daf97d15c76e037156ce821f8dc188b94e914296", async() => {
                BeginContext(3589, 250, true);
                WriteLiteral("\r\n                        <button type=\"submit\" class=\"btn btn-danger\">\r\n                            <i class=\"fa fa-trash-o\" aria-hidden=\"true\"></i>\r\n                            Eliminar\r\n                        </button> |\r\n                        ");
                EndContext();
                BeginContext(3839, 45, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "68d41daf97d15c76e037156ce821f8dc188b94e914946", async() => {
                    BeginContext(3861, 19, true);
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
                BeginContext(3884, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3913, 80, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entidad.Entidad.Maestro.Cliente> Html { get; private set; }
    }
}
#pragma warning restore 1591