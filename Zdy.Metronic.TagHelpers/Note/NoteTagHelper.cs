using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers.Untils;

namespace Zdy.Metronic.TagHelpers.Note
{
    [HtmlTargetElement("note")]
    public class NoteTagHelper: TagHelper
    {
        public Color Color { get; set; } = Color.None;
        public State State { get; set; } = State.Success;
        public string Title { get; set; }
        public string ClassNames { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            var classes = CssClassBuilder.Build(
                new CssClassName("note", true),
                new CssClassName($"bg-{Color.ToValue()}", Color != Color.None),
                new CssClassName($"bg-font-{Color.ToValue()}", Color != Color.None),
                new CssClassName($"note-{State.ToValue()}", State != State.None),
                new CssClassName(ClassNames, !string.IsNullOrEmpty(ClassNames)));

            output.TagName = "div";

            output.Attributes.Add("class", classes);

            if (!string.IsNullOrEmpty(Title))
            {
                output.Content.AppendHtml($"<h4 class='block'>{Title}</h4>");
            }

            output.Content.AppendHtml(childContent.GetContent());
        }
    }
}
