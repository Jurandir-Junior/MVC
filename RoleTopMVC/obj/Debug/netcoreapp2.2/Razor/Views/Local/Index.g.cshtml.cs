#pragma checksum "C:\Users\51855643855\Documents\MVC\RoleTopMVC\Views\Local\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a726ce192fac52fc2dd13e1f4428fffc53a0476c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Local_Index), @"mvc.1.0.view", @"/Views/Local/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Local/Index.cshtml", typeof(AspNetCore.Views_Local_Index))]
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
#line 1 "C:\Users\51855643855\Documents\MVC\RoleTopMVC\Views\_ViewImports.cshtml"
using RoleTopMVC;

#line default
#line hidden
#line 2 "C:\Users\51855643855\Documents\MVC\RoleTopMVC\Views\_ViewImports.cshtml"
using RoleTopMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a726ce192fac52fc2dd13e1f4428fffc53a0476c", @"/Views/Local/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fae5be29b1d0446bbdb7fe81a11990f47b34647", @"/Views/_ViewImports.cshtml")]
    public class Views_Local_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 38, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"pt-br\">\r\n");
            EndContext();
            BeginContext(38, 289, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a726ce192fac52fc2dd13e1f4428fffc53a0476c3338", async() => {
                BeginContext(44, 276, true);
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta http-equiv=""X-UA-Compatible"" content=""ie=edge"">
    <title>O Local - Rolê Top</title>
    <link rel=""stylesheet"" type=""text/css"" href=""css/style-local.css"">
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(327, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(329, 2735, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a726ce192fac52fc2dd13e1f4428fffc53a0476c4810", async() => {
                BeginContext(335, 178, true);
                WriteLiteral("\r\n    <main>\r\n            <div id=\"mySidenav\" class=\"sidenav\">\r\n                <a href=\"javascript:void(0)\" class=\"closebtn\" onclick=\"closeNav()\">&times;</a>\r\n                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 513, "\'", 555, 2);
#line 14 "C:\Users\51855643855\Documents\MVC\RoleTopMVC\Views\Local\Index.cshtml"
WriteAttributeValue("", 520, Url.Action("Index", "Local"), 520, 29, false);

#line default
#line hidden
                WriteAttributeValue("", 549, "#local", 549, 6, true);
                EndWriteAttribute();
                BeginContext(556, 47, true);
                WriteLiteral(" class=\"sidenav1\">Local</a>\r\n                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 603, "\'", 649, 2);
#line 15 "C:\Users\51855643855\Documents\MVC\RoleTopMVC\Views\Local\Index.cshtml"
WriteAttributeValue("", 610, Url.Action("Index", "Local"), 610, 29, false);

#line default
#line hidden
                WriteAttributeValue("", 639, "#estrutura", 639, 10, true);
                EndWriteAttribute();
                BeginContext(650, 62, true);
                WriteLiteral(" class=\"sidenav2\">Tamanho e Capacidade</a>\r\n                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 712, "\'", 755, 2);
#line 16 "C:\Users\51855643855\Documents\MVC\RoleTopMVC\Views\Local\Index.cshtml"
WriteAttributeValue("", 719, Url.Action("Index", "Local"), 719, 29, false);

#line default
#line hidden
                WriteAttributeValue("", 748, "#planta", 748, 7, true);
                EndWriteAttribute();
                BeginContext(756, 65, true);
                WriteLiteral(" class=\"sidenav3\">Planta/Mapa de Montagem</a>\r\n                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 821, "\'", 862, 2);
#line 17 "C:\Users\51855643855\Documents\MVC\RoleTopMVC\Views\Local\Index.cshtml"
WriteAttributeValue("", 828, Url.Action("Index", "Local"), 828, 29, false);

#line default
#line hidden
                WriteAttributeValue("", 857, "#maps", 857, 5, true);
                EndWriteAttribute();
                BeginContext(863, 2194, true);
                WriteLiteral(@" class=""sidenav4"">Distancia</a>
            </div>
            
            <span style=""font-size:30px;cursor:pointer"" onclick=""openNav()"">&#9776; </span>
            
            <script>
                function openNav() {
                document.getElementById(""mySidenav"").style.width = ""300px"";
            }
            
            function closeNav() {
                document.getElementById(""mySidenav"").style.width = ""0"";
            }
            </script>

        <div id=""geral"">
            <section id=""local"">
                <div>
                    <h3>Endereço</h3>
                    <p>Av. Barão de Limeira, 539 - Santa Cecília</p>
                    <br />
                    <h3>Ponto de Referência</h3>
                    <p>Referencia</p>
                </div>
            </section>
            <br />
            <section id=""estrutura"">
                <div>
                    <h3>Tamanho e Capacidade</h3>
                    <p>150x40 com capacidade pa");
                WriteLiteral(@"ra até 300 pessoas e 200 cadeiras</p>
                </div>
            </section>
            <br />
            <section id=""planta"">
                <div>
                    <h3>Planta</h3>
                    <img id=""img-planta"" src=""img/EXPO PDF PB.jpg"">
                    <br />
                    <h3>Mapa de Montagem</h3>
                    <img id=""img-planta2"" src=""img/EXPO PDF COLOR.jpg"">
                </div>
            </section>
            <br />
            <section id=""maps"">
                <div>
                    <h3>Como Chegar</h3>
                    <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3657.886996150563!2d-46.64847708502264!3d-23.53656648469521!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94ce5843deade6e3%3A0x124f377d06c7e71f!2sAlameda%20Bar%C3%A3o%20de%20Limeira%2C%20539%20-%20Campos%20El%C3%ADseos%2C%20S%C3%A3o%20Paulo%20-%20SP%2C%2001202-001!5e0!3m2!1spt-BR!2sbr!4v1568035137174!5m2!1spt-BR!2sbr"" width=""600"" height=""450"" f");
                WriteLiteral("rameborder=\"0\" style=\"border:0;\" allowfullscreen=\"\"></iframe>\r\n                </div>\r\n            </section>\r\n        </div>\r\n    </main>\r\n    \r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3064, 9, true);
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
