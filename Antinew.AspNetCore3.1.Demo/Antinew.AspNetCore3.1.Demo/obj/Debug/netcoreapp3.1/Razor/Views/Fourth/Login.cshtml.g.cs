#pragma checksum "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "db604d15aaf9f12972283894a279be03d1afb1ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fourth_Login), @"mvc.1.0.view", @"/Views/Fourth/Login.cshtml")]
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
#line 1 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\_ViewImports.cshtml"
using Antinew.AspNetCore3._1.Demo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\_ViewImports.cshtml"
using Antinew.AspNetCore3._1.Demo.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db604d15aaf9f12972283894a279be03d1afb1ca", @"/Views/Fourth/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bee11f5dd40aec950af7967a209eedd86efd1d2", @"/Views/_ViewImports.cshtml")]
    public class Views_Fourth_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Antinew.AspNetCore3._1.Demo.Models.CurrentUser>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml"
  
    ViewBag.Title = "登录";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 6 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("。</h2>\r\n<div class=\"row\">\r\n    <div class=\"col-md-8\">\r\n        <section id=\"loginForm\">\r\n");
#nullable restore
#line 10 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml"
             using (Html.BeginForm("Login", "Fourth", new { sid = "123", Account = "Eleven" },
              FormMethod.Post, true, new { @class = "form-horizontal", role = "form" }))
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h4>使用本地帐户登录。</h4>\r\n                <hr />\r\n");
#nullable restore
#line 16 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml"
           Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 18 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml"
               Write(Html.LabelFor(m => m.Name, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 20 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml"
                   Write(Html.TextBoxFor(m => m.Name, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 24 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml"
               Write(Html.LabelFor(m => m.Password, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 26 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml"
                   Write(Html.PasswordFor(m => m.Password, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 30 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml"
               Write(Html.Label("VerifyCode", "VerifyCode", new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 32 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml"
                   Write(Html.TextBox("verify", "", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>
                <div class=""form-group"">
                    <div class=""col-md-10"">
                        <img alt=""验证码图片"" class=""img"" onclick=""refresh(this)"" src=""/Fourth/VerifyCode"" title=""点击刷新"">
                    </div>
                </div>
                <div class=""form-group"">
                    <div class=""col-md-offset-2 col-md-10"">
                        <input type=""submit"" value=""登录"" class=""btn btn-default"" />
                        ");
#nullable restore
#line 43 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml"
                   Write(base.ViewBag.Msg);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 46 "C:\Antinew\Architect\ASP.NET Core3.1\Antinew.AspNetCore3.1.Demo\Antinew.AspNetCore3.1.Demo\Views\Fourth\Login.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </section>\r\n    </div>\r\n</div>\r\n<script>\r\n    function refresh(obj) {\r\n        $(obj).attr(\"src\", \"/fourth/VerifyCode\");\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Antinew.AspNetCore3._1.Demo.Models.CurrentUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
