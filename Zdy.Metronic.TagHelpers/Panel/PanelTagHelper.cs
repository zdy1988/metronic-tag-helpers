using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers.Untils;

namespace Zdy.Metronic.TagHelpers.Panel
{
    [HtmlTargetElement("panel")]
    public class PanelTagHelper : TagHelper
    {
        public Theme Theme { get; set; } = Theme.Default;
        public string Title { get; set; }
        public string ClassNames { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var panelContext = new PanelContext();
            context.Items.Add(typeof(PanelTagHelper), panelContext);

            var childContent = await output.GetChildContentAsync();

            var classes = CssClassBuilder.Build(
                new CssClassName("panel", true),
                new CssClassName($"panel-{Theme.ToValue()}", Theme != Theme.None),
                new CssClassName(ClassNames, !string.IsNullOrEmpty(ClassNames)));

            output.TagName = "div";

            output.Attributes.Add("class", classes);

            if (!string.IsNullOrEmpty(Title))
            {
                output.Content.AppendHtml($@"<div class='panel-heading'>
                                                <h3 class='panel-title'>{Title}</h3>
                                             </div>");
            }

            output.Content.AppendHtml($@"<div class='panel-body'>
                                            {childContent.GetContent()}
                                         </div>");

            if (panelContext.Footer != null)
            {
                output.Content.AppendHtml($@"<div class='panel-footer'>
                                                {panelContext.Footer.ToHtml()}
                                             </div>");
            }
        }
    }
}
