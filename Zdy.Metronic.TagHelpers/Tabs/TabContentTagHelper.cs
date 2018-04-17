using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zdy.Metronic.TagHelpers.Tabs
{
    [HtmlTargetElement("tab-content", ParentTag = "tabs")]
    public class TabContentTagHelper : TagHelper
    {
        public string TabName { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var tabsContext = (TabsContext)context.Items[typeof(TabsTagHelper)];
            tabsContext.TabContents.Add(new Tuple<string, IHtmlContent>(TabName, childContent));
            output.SuppressOutput();
        }
    }
}
