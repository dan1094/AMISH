#pragma checksum "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\FacturasSinGuia.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b061bbaf1abd610214f9c48ea9a7ffa9f1c337dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FacturasSinGuia), @"mvc.1.0.view", @"/Views/Home/FacturasSinGuia.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b061bbaf1abd610214f9c48ea9a7ffa9f1c337dc", @"/Views/Home/FacturasSinGuia.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47eb80677f80a148d76185b5dc6bd6850c174237", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FacturasSinGuia : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BillRequestModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\FacturasSinGuia.cshtml"
  
    ViewData["Title"] = "AmIsH App";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- CONTENT -->
<section class=""app-content"">
    <div class=""col-md-12"">
        <div class=""panel-group accordion"" id=""accordion"" role=""tablist"" aria-multiselectable=""true"">
            <div class=""panel panel-default"">
                <div class=""panel-heading"" role=""tab"" id=""heading-2"">
                    <a class=""accordion-toggle"" role=""button"" data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapse-2"" aria-expanded=""false"" aria-controls=""collapse-2"">
                        <h4 class=""panel-title"">Solicitar Operador</h4>
                        <i class=""fa acc-switch""></i>
                    </a>
                </div>
                <div id=""collapse-2"" class=""panel-collapse collapse"" role=""tabpanel"" aria-labelledby=""heading-2"">
                    <div class=""panel-body"">
                        <div class=""col-md-12"">
                            <div class=""widget p-lg"">
");
#nullable restore
#line 21 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\FacturasSinGuia.cshtml"
                                 using (Html.BeginForm("SolicitarOperador", "Home", FormMethod.Post))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"col-xs-12 col-sm-8 col-sm-offset-1\">\r\n                                        <div class=\"form-group\">\r\n                                            ");
#nullable restore
#line 25 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\FacturasSinGuia.cshtml"
                                       Write(Html.EditorFor(model => model.BillIdSearch, new { htmlAttributes = new { @class = "form-control promo-search-field", @placeholder = "Id de la factura", @type = "search" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </div>
                                    </div>
                                    <div class=""col-xs-12 col-sm-2"">
                                        <input type=""submit"" class=""btn btn-primary btn-block promo-search-submit"" value=""Solicitar Operador"">
                                    </div>
");
#nullable restore
#line 31 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\FacturasSinGuia.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\FacturasSinGuia.cshtml"
                                 if (Model != null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <table class=""table"">
                                        <tr>
                                            <th>#</th>
                                            <th>Id Factura</th>
                                        </tr>
");
#nullable restore
#line 39 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\FacturasSinGuia.cshtml"
                                         foreach (var item in Model.BillModelProperty)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr class=\"active\">\r\n                                                <td>");
#nullable restore
#line 42 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\FacturasSinGuia.cshtml"
                                               Write(item.IdBill);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n");
#nullable restore
#line 44 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\FacturasSinGuia.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </table>\r\n");
#nullable restore
#line 46 "C:\Proyectos\ACAF\hac\Final\AMISH\AmishApp\AmishApp\Views\Home\FacturasSinGuia.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div><!-- .widget -->
                        </div><!-- END column -->
                    </div>
                </div>
            </div>
        </div><!-- panel-group -->
    </div><!-- END column -->
</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BillRequestModel> Html { get; private set; }
    }
}
#pragma warning restore 1591