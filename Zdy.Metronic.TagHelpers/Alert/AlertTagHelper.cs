using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers.Untils;

namespace Zdy.Metronic.TagHelpers.Alert
{
    [HtmlTargetElement("alert")]
    public class AlertTagHelper : TagHelper
    {
        public Color Color { get; set; } = Color.None;
        public State State { get; set; } = State.Success;
        public bool CanClosed { get; set; } = false;
        public string ClassNames { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            var classes = CssClassBuilder.Build(
                new CssClassName("alert", true),
                new CssClassName("alert-dismissable", CanClosed),
                new CssClassName($"bg-{Color.ToValue()}", Color != Color.None),
                new CssClassName($"bg-font-{Color.ToValue()}", Color != Color.None),
                new CssClassName($"alert-{State.ToValue()}", State != State.None && Color == Color.None),
                new CssClassName(ClassNames, !string.IsNullOrEmpty(ClassNames)));

            output.TagName = "div";

            output.Attributes.Add("class", classes);

            if (CanClosed)
            {
                output.Content.AppendHtml("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'></button>");
            }

            output.Content.AppendHtml(childContent.GetContent());
        }
    }
}
