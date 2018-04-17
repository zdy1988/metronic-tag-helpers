using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers.Untils;

namespace Zdy.Metronic.TagHelpers.Button
{
    [HtmlTargetElement("button")]
    public class ButtonTagHelper: TagHelper
    {
        public string Type { get; set; } = "button";
        public Color Color { get; set; } = Color.None;
        public Theme Theme { get; set; } = Theme.Default;
        public bool IsStripe { get; set; } = false;
        public bool IsRound { get; set; } = false;
        public bool IsOutline { get; set; } = false;
        public Size Size { get; set; } = Size.None;
        public bool IsFullWidth { get; set; } = false;
        public bool IsDisabled { get; set; } = false;
        public string ClassNames { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            var classes = CssClassBuilder.Build(
                new CssClassName("btn", true),
                new CssClassName(Color.ToValue(), Color != Color.None && !IsStripe),
                new CssClassName($"btn-{Theme.ToValue()}", Theme != Theme.None && Color == Color.None && !IsStripe),
                new CssClassName($"{Color.ToValue()}-stripe", Color != Color.None && IsStripe),
                new CssClassName("circle", IsRound),
                new CssClassName("btn-outline", IsOutline),
                new CssClassName($"btn-{Size.ToValue()}", Size != Size.None),
                new CssClassName("btn-block", IsFullWidth),
                new CssClassName("disabled", IsDisabled),
                new CssClassName(ClassNames, !string.IsNullOrEmpty(ClassNames)));

            output.TagName = "button";

            output.Attributes.Add("class", classes);
            output.Attributes.Add("type", Type);

            if (IsDisabled)
            {
                output.Attributes.Add("disabled", "disabled");
            }

            output.Content.SetHtmlContent(childContent.GetContent());
        }
    }
}
