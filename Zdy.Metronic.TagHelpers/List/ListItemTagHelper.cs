using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zdy.Metronic.TagHelpers.List
{
    [HtmlTargetElement("list-item", ParentTag = "list")]
    public class ListItemTagHelper : TagHelper
    {
        public Color Color { get; set; }
        public State State { get; set; }
        public bool IsDisabled { get; set; }
        public string ClassNames { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var listContext = (ListContext)context.Items[typeof(ListTagHelper)];
            var childContent = await output.GetChildContentAsync();
            listContext.Items.Add(new Tuple<ListItemTagHelper, IHtmlContent>(this, childContent));
            output.SuppressOutput();
        }
    }
}
