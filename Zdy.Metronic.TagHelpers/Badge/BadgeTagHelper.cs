using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers.Untils;

namespace Zdy.Metronic.TagHelpers.Badge
{
    [HtmlTargetElement("badge")]
    public class BadgeTagHelper  : TagHelper
    {
        public Color Color { get; set; } = Color.None;
        public Theme Theme { get; set; } = Theme.Default;
        public bool IsRound { get; set; } = false;
        public string ClassNames { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            var classes = CssClassBuilder.Build(
                new CssClassName("badge", true),
                new CssClassName("badge-roundless", IsRound),
                new CssClassName($"bg-{Color.ToValue()}", Color != Color.None),
                new CssClassName($"bg-font-{Color.ToValue()}", Color != Color.None),
                new CssClassName($"badge-{Theme.ToValue()}", Theme != Theme.None),
                new CssClassName(ClassNames, !string.IsNullOrEmpty(ClassNames)));

            output.TagName = "span";

            output.Attributes.Add("class", classes);

            output.Content.AppendHtml(childContent.GetContent());
        }
    }
}
