using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers.Untils;

namespace Zdy.Metronic.TagHelpers.List
{
    [HtmlTargetElement("list")]
    public class ListTagHelper : TagHelper
    {
        public string ClassNames { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var listContext = new ListContext();
            context.Items.Add(typeof(ListTagHelper), listContext);

            await output.GetChildContentAsync();

            if (listContext.Items.Count > 0)
            {
                output.TagName = "ul";

                output.Attributes.Add("class", $"list-group {ClassNames}");

                for (var i = 0; i < listContext.Items.Count; i++)
                {
                    var listItemTag = listContext.Items[i].Item1;

                    var listItem = listContext.Items[i].Item2;

                    var listItemClasses = CssClassBuilder.Build(
                            new CssClassName("list-group-item", true),
                            new CssClassName("disabled", listItemTag.IsDisabled),
                            new CssClassName($"bg-{listItemTag.Color.ToValue()}", listItemTag.Color != Color.None),
                            new CssClassName($"bg-font-{listItemTag.Color.ToValue()}", listItemTag.Color != Color.None),
                            new CssClassName($"list-group-item-{listItemTag.State.ToValue()}", listItemTag.State != State.None && listItemTag.Color == Color.None),
                            new CssClassName(listItemTag.ClassNames, !string.IsNullOrEmpty(listItemTag.ClassNames)));

                    TagBuilder listItemBuilder = new TagBuilder("li");

                    listItemBuilder.AddCssClass(listItemClasses);

                    listItemBuilder.InnerHtml.AppendHtml(listItem);

                    output.Content.AppendHtml(listItemBuilder);
                }
            }
            else
            {
                output.SuppressOutput();
            }
        }
    }
}
