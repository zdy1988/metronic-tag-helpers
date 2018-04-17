using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers.Untils;

namespace Zdy.Metronic.TagHelpers
{
    [HtmlTargetElement("icon-stack")]
    [RestrictChildren("icon")]
    public class IconStackTagHelper : TagHelper
    {
        public IconSize Size { get; set; } = IconSize.None;
        public string ClassNames { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var iconStackContext = new IconStackContext();
            context.Items.Add(typeof(IconStackTagHelper), iconStackContext);

            await output.GetChildContentAsync();

            if (iconStackContext.Icons.Count > 0)
            {
                var classes = CssClassBuilder.Build(
                    new CssClassName("fa-stack", true),
                    new CssClassName($"fa-{Size.ToValue()}", Size != IconSize.None),
                    new CssClassName(ClassNames, !string.IsNullOrEmpty(ClassNames)));

                output.TagName = "span";

                output.Attributes.Add("class", classes);

                var i = iconStackContext.Icons.Count;
                while (i > 0)
                {
                    var icon = iconStackContext.Icons[i - 1];
                    icon.AddCssClass($"fa-stack-{i}x");
                    output.Content.AppendHtml(icon);
                    i--;
                }
            }
            else
            {
                output.SuppressOutput();
            }
        }
    }
}
