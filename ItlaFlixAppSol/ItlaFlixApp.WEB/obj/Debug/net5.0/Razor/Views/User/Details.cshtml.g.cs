#pragma checksum "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7971c0ef33fe3b01e45a606e30d1db906ed63c21"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Details), @"mvc.1.0.view", @"/Views/User/Details.cshtml")]
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
#line 1 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\_ViewImports.cshtml"
using ItlaFlixApp.WEB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\_ViewImports.cshtml"
using ItlaFlixApp.WEB.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7971c0ef33fe3b01e45a606e30d1db906ed63c21", @"/Views/User/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c22e10f0b14937d49808988d548cb33cebedd72", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_User_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ItlaFlixApp.WEB.Models.UserModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>User Details: ");
#nullable restore
#line 7 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
             Write(Model.txt_nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div>\r\n    <h4>UserModel</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cod_usuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.cod_usuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.txt_nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.txt_nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.txt_apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.txt_apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.txt_user));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.txt_user));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.nro_doc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.nro_doc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.cod_rol));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.cod_rol));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.sn_activo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.sn_activo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
       Write(Html.DisplayFor(model => model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 64 "C:\projects\ItlaFlixApp\ItlaFlixAppSol\ItlaFlixApp.WEB\Views\User\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.cod_usuario }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7971c0ef33fe3b01e45a606e30d1db906ed63c219516", async() => {
                WriteLiteral("Back to List");
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
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ItlaFlixApp.WEB.Models.UserModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591