#pragma checksum "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\DisplayDetails\Display.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "032bd17e939c616ebf03da6ecbeeb6d72ee4d5b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DisplayDetails_Display), @"mvc.1.0.view", @"/Views/DisplayDetails/Display.cshtml")]
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
#line 1 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\_ViewImports.cshtml"
using BudgetWebApp19010155;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\_ViewImports.cshtml"
using BudgetWebApp19010155.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"032bd17e939c616ebf03da6ecbeeb6d72ee4d5b1", @"/Views/DisplayDetails/Display.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25b9a8087ea1f653340b95055d5ba0d204ffb9da", @"/Views/_ViewImports.cshtml")]
    public class Views_DisplayDetails_Display : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "BasicInfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Options", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("background-image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<style>
    .background-image {
        background-image: url(background.png);
        background-repeat: no-repeat;
        background-size: contain;
    }

    .home-shadow {
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    }

    .home-container {
        background-color: lightgray;
    }
</style>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "032bd17e939c616ebf03da6ecbeeb6d72ee4d5b15557", async() => {
                WriteLiteral(@"
    <div class=""text-center"">
        <h1 style=""font-family:'Trebuchet MS'; text-decoration:underline; text-transform:uppercase"" class=""display-4"">Welcome to the Budget Calculator</h1>
        <br />
        <h3 style=""color:red; font-family:'Segoe UI'; text-decoration:underline"">Your Details:</h3>
        <h5 class=""text-danger"">");
#nullable restore
#line 22 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\DisplayDetails\Display.cshtml"
                           Write(ViewBag.DisplayError);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n\r\n        <div class=\"home-container\">\r\n            <div><h5>Gross Income, Tax, &amp; Basic Expenses:</h5></div>\r\n            <ul style=\"list-style-type:none;\">\r\n");
#nullable restore
#line 27 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\DisplayDetails\Display.cshtml"
                 foreach (var disp in ViewBag.UserExp)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <li>\r\n                        ");
#nullable restore
#line 30 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\DisplayDetails\Display.cshtml"
                   Write(disp);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </li>\r\n");
#nullable restore
#line 32 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\DisplayDetails\Display.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </ul>\r\n        </div>\r\n\r\n        <br />\r\n\r\n        <div class=\"home-container\">\r\n            <div><h5>Property Expenses &amp; Loan Repayment:</h5></div>\r\n            <ul style=\"list-style-type:none\">\r\n");
#nullable restore
#line 41 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\DisplayDetails\Display.cshtml"
                 foreach (var disp in ViewBag.PropertyExp)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <li>\r\n                        ");
#nullable restore
#line 44 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\DisplayDetails\Display.cshtml"
                   Write(disp);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </li>\r\n");
#nullable restore
#line 46 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\DisplayDetails\Display.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </ul>\r\n        </div>\r\n\r\n        <br />\r\n\r\n        <div class=\"home-container\">\r\n            <div><h5>Vehicle Expenses &amp; Loan Repayment:</h5></div>\r\n            <ul style=\"list-style-type:none\">\r\n");
#nullable restore
#line 55 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\DisplayDetails\Display.cshtml"
                 foreach (var disp in ViewBag.VehicleExp)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <li>\r\n                        ");
#nullable restore
#line 58 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\DisplayDetails\Display.cshtml"
                   Write(disp);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </li>\r\n");
#nullable restore
#line 60 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\DisplayDetails\Display.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </ul>\r\n        </div>\r\n\r\n        <br />\r\n        <p style=\"color: #d13030\">");
#nullable restore
#line 65 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\DisplayDetails\Display.cshtml"
                             Write(ViewBag.Warning);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        <div class=\"home-container\">\r\n            <div><h5>Total:</h5></div>\r\n            <ul style=\"list-style-type:none; padding-right:3em\">\r\n                R ");
#nullable restore
#line 69 "C:\Users\Nabeel\source\repos\BudgetWebApp19010155\Views\DisplayDetails\Display.cshtml"
             Write(ViewBag.Total);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </ul>\r\n        </div>\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "032bd17e939c616ebf03da6ecbeeb6d72ee4d5b110351", async() => {
                    WriteLiteral("CHANGE VALUES");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "032bd17e939c616ebf03da6ecbeeb6d72ee4d5b111912", async() => {
                    WriteLiteral("BACK TO OPTIONS");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "032bd17e939c616ebf03da6ecbeeb6d72ee4d5b113257", async() => {
                    WriteLiteral("LOGOUT");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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