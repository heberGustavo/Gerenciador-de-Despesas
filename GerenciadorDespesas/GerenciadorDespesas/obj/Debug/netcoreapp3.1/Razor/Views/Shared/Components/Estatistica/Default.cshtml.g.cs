#pragma checksum "C:\Users\SuporteSQ-06\Desktop\projetos_heber\Git\GerenciadorDeDespesas\GerenciadorDespesas\GerenciadorDespesas\Views\Shared\Components\Estatistica\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8291f43d55732a03f0786ddc7fe6ed2249ca6bd1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Estatistica_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Estatistica/Default.cshtml")]
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
#line 1 "C:\Users\SuporteSQ-06\Desktop\projetos_heber\Git\GerenciadorDeDespesas\GerenciadorDespesas\GerenciadorDespesas\Views\_ViewImports.cshtml"
using GerenciadorDespesas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\SuporteSQ-06\Desktop\projetos_heber\Git\GerenciadorDeDespesas\GerenciadorDespesas\GerenciadorDespesas\Views\_ViewImports.cshtml"
using GerenciadorDespesas.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8291f43d55732a03f0786ddc7fe6ed2249ca6bd1", @"/Views/Shared/Components/Estatistica/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e664b9738aca7e4a1bde60a9118593ebe932cfa2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Estatistica_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GerenciadorDespesas.ViewModels.EstatisticaViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<p>Despesas Cadastradas: ");
#nullable restore
#line 3 "C:\Users\SuporteSQ-06\Desktop\projetos_heber\Git\GerenciadorDeDespesas\GerenciadorDespesas\GerenciadorDespesas\Views\Shared\Components\Estatistica\Default.cshtml"
                    Write(Model.QuantidadeDespesas);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Menor Despesa: ");
#nullable restore
#line 4 "C:\Users\SuporteSQ-06\Desktop\projetos_heber\Git\GerenciadorDeDespesas\GerenciadorDespesas\GerenciadorDespesas\Views\Shared\Components\Estatistica\Default.cshtml"
             Write(Model.MenorDespesa);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Maior Despesa: ");
#nullable restore
#line 5 "C:\Users\SuporteSQ-06\Desktop\projetos_heber\Git\GerenciadorDeDespesas\GerenciadorDespesas\GerenciadorDespesas\Views\Shared\Components\Estatistica\Default.cshtml"
             Write(Model.MaiorDespesa);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GerenciadorDespesas.ViewModels.EstatisticaViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
