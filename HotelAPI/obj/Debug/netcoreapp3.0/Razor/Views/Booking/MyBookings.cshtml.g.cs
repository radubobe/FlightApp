#pragma checksum "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fe4012aa21f847068d9ddeb7f4209534b5851ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Booking_MyBookings), @"mvc.1.0.view", @"/Views/Booking/MyBookings.cshtml")]
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
#line 1 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\_ViewImports.cshtml"
using HotelAPI.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
using ConsoleApp2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fe4012aa21f847068d9ddeb7f4209534b5851ac", @"/Views/Booking/MyBookings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea7c903b2af7b04c627f0828ee6063f0e1318cfd", @"/Views/_ViewImports.cshtml")]
    public class Views_Booking_MyBookings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<UserReservedFlightVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteBooking", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Booking", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserFlightView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Flight", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
  
    ViewBag.Title = "My Bookings";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>My bookings</h1>\r\n<br />\r\n\r\n\r\n");
#nullable restore
#line 17 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
 if (Model.Any())
{
    // for each booking the user has, print the details about flight
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
     foreach (var b in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("     ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fe4012aa21f847068d9ddeb7f4209534b5851ac8156", async() => {
                WriteLiteral("\r\n         <div class=\"card\" style=\"width: 18rem;\">\r\n");
#nullable restore
#line 24 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
               var photoPath = "~/images/" + (b.PhotoPath ?? "no_image.png");

#line default
#line hidden
#nullable disable
                WriteLiteral("             ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1fe4012aa21f847068d9ddeb7f4209534b5851ac8786", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
                                      WriteLiteral(photoPath);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#nullable restore
#line 25 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n             <div class=\"card-body\">\r\n                 <h5 class=\"card-title\">");
#nullable restore
#line 27 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
                                   Write(b.PlaneName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n             </div>\r\n             <ul class=\"list-group list-group-flush\">\r\n                 <li class=\"list-group-item\">Route: ");
#nullable restore
#line 30 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
                                               Write(b.Route);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                 <li class=\"list-group-item\">Departure: ");
#nullable restore
#line 31 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
                                                   Write(b.Departure);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                 <li class=\"list-group-item\">Arrive: ");
#nullable restore
#line 32 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
                                                Write(b.Arrive);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                 <li class=\"list-group-item\">Price: ");
#nullable restore
#line 33 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
                                               Write(b.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(" $</li>\r\n                 <li class=\"list-group-item\">Number of seats: ");
#nullable restore
#line 34 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
                                                         Write(b.SeatsReserved);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n             </ul>\r\n             <div class=\"card-body\">\r\n                 ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fe4012aa21f847068d9ddeb7f4209534b5851ac13542", async() => {
                    WriteLiteral("Cancel booking");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-bookingId", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 37 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
                                                                                                    WriteLiteral(b.BookId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["bookingId"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-bookingId", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["bookingId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n             </div>\r\n         </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <br />\r\n");
#nullable restore
#line 42 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
     

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>You have no bookings.</h2>\r\n    <h2>You can ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1fe4012aa21f847068d9ddeb7f4209534b5851ac18064", async() => {
                WriteLiteral("check our flights");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" to make a booking.</h2>\r\n");
#nullable restore
#line 49 "C:\Users\nxf53310\Desktop\Avioane2020\AvioaneBOSSSSS\AvioaneJmek2\HotelAPI\Views\Booking\MyBookings.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<AppUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<AppUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<UserReservedFlightVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591