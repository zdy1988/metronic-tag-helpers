using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers.Untils;

namespace Zdy.Metronic.TagHelpers.Well
{
    [HtmlTargetElement("well")]
    public class WellTagHelper : TagHelper
    {
        public Size Size { get; set; } = Size.None;
        public string ClassNames { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            var classes = CssClassBuilder.Build(
                new CssClassName("well", true),
                new CssClassName($"well-{Size.ToValue()}", Size != Size.None),
                new CssClassName(ClassNames, !string.IsNullOrEmpty(ClassNames)));

            output.TagName = "div";

            output.Attributes.Add("class", classes);

            output.Content.AppendHtml(childContent.GetContent());
        }
    }
}
