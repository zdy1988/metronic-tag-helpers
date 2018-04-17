using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers.Untils;

namespace Zdy.Metronic.TagHelpers
{
    [HtmlTargetElement("icon")]
    public class IconTagHelper : TagHelper
    {
        public Icon Name { get; set; }
        public Color Color { get; set; } = Color.None;
        public IconSize Size { get; set; } = IconSize.None;
        public bool IsPulse { get; set; } = false;
        public bool IsSpin { get; set; } = false;
        public bool IsBordered { get; set; } = false;
        public bool IsFixedWidth { get; set; } = false;
        public IconRotate Rotate { get; set; } = IconRotate.None;
        public IconFlip Filp { get; set; } = IconFlip.None;
        public string ClassNames { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await output.GetChildContentAsync();

            var classes = CssClassBuilder.Build(
                new CssClassName("fa", true),
                new CssClassName($"fa-{Name.ToValue()}", true),
                new CssClassName("fa-fw", IsFixedWidth),
                new CssClassName($"font-{Color.ToValue()}", Color != Color.None),
                new CssClassName($"fa-{Size.ToValue()}", Size != IconSize.None),
                new CssClassName("fa-pulse", IsPulse),
                new CssClassName("fa-spin", IsSpin),
                new CssClassName("fa-border", IsBordered),
                new CssClassName($"fa-rotate-{Rotate.ToValue()}", Rotate != IconRotate.None),
                new CssClassName($"fa-flip-{Filp.ToValue()}", Filp != IconFlip.None),
                new CssClassName(ClassNames, !string.IsNullOrEmpty(ClassNames)));

            output.TagName = "i";

            output.Attributes.Add("class", classes);

            if (context.Items.ContainsKey(typeof(IconStackTagHelper)))
            {
                output.SuppressOutput();

                var iconStackContext = (IconStackContext)context.Items[typeof(IconStackTagHelper)];

                TagBuilder iconBuilder = new TagBuilder("i");
                iconBuilder.AddCssClass(classes);

                iconStackContext.Icons.Add(iconBuilder);
            }
        }
    }
}
