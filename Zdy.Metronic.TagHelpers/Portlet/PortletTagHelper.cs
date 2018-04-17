using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers.Untils;

namespace Zdy.Metronic.TagHelpers.Portlet
{
    [HtmlTargetElement("portlet")]
    public class PortletTagHelper : TagHelper
    {
        public string PortletClass { get; set; } = "";

        public string Title { get; set; } = "Default Title";

        public string TitleClass { get; set; } = "sbold uppercase";

        public Icon TitleIcon { get; set; } = Icon.Envira;

        public string TitleIconClass { get; set; } = "";

        public string Mode { get; set; } = "light";

        public bool IsFit { get; set; } = false;

        public bool IsForm { get; set; } = false; 

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            var portletClasses = CssClassBuilder.Build(
                new CssClassName("portlet", true),
                new CssClassName(Mode.ToLower(), true),
                new CssClassName("portlet-fit", IsFit),
                new CssClassName("portlet-form", IsForm),
                new CssClassName(PortletClass, !string.IsNullOrEmpty(PortletClass)));

            var titleIconClasses = CssClassBuilder.Build(
                new CssClassName($"fa fa-{TitleIcon.ToValue()}", TitleIcon != Icon.None),
                new CssClassName(TitleIconClass, !string.IsNullOrEmpty(TitleIconClass)));

            var iconContent = TitleIcon != Icon.None ? $"<i class='{titleIconClasses}'></i>" : "";

            output.TagName = "div";

            output.Attributes.Add("class", portletClasses);

            var content = $@"<div class='portlet-title'>
                                 <div class='caption'>
                                     {iconContent}
                                     <span class='caption-subject {TitleClass}'>{Title}</span>
                                 </div>
                                 <div class='actions'>
                                     <a class='btn btn-circle btn-icon-only btn-default' href='javascript:;'>
                                         <i class='icon-cloud-upload'></i>
                                     </a>
                                     <a class='btn btn-circle btn-icon-only btn-default' href='javascript:;'>
                                         <i class='icon-wrench'></i>
                                     </a>
                                     <a class='btn btn-circle btn-icon-only btn-default' href='javascript:;'>
                                         <i class='icon-trash'></i>
                                     </a>
                                 </div>
                             </div>
                             <div class='portlet-body'>{childContent.GetContent()}</div>";

            output.Content.SetHtmlContent(content);
        }
    }
}
