#pragma checksum "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "597b154a2faac5714327277dfdaa75126b364c22"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\_ViewImports.cshtml"
using AmishApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\_ViewImports.cshtml"
using AmishApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"597b154a2faac5714327277dfdaa75126b364c22", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47eb80677f80a148d76185b5dc6bd6850c174237", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "AmIsH App";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- CONTENT -->\r\n<section class=\"app-content\">\r\n    <div class=\"col-md-12\">\r\n        <div class=\"panel-group accordion\" id=\"accordion\" role=\"tablist\" aria-multiselectable=\"true\">\r\n            ");
#nullable restore
#line 9 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\Index.cshtml"
       Write(Html.ActionLink("Buscar Guia", "BuscarGuia", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 10 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\Index.cshtml"
       Write(Html.ActionLink("Solicitar Operador", "FacturasSinGuia", "Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div><!-- panel-group -->\r\n    </div><!-- END column -->\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
