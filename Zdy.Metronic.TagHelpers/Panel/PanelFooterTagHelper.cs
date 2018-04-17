using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Zdy.Metronic.TagHelpers.Panel
{
    [HtmlTargetElement("panel-footer", ParentTag = "panel")]
    public class PanelFooterTagHelper: TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var panelContext = (PanelContext)context.Items[typeof(PanelTagHelper)];
            panelContext.Footer = childContent;
            output.SuppressOutput();
        }
    }
}
