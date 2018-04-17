using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers;

namespace Zdy.Metronic.TagHelpers.Accordion
{
    [HtmlTargetElement("accordion-panel", ParentTag = "accordion")]
    public class AccordionPanelTagHelper : TagHelper
    {
        public string Title { get; set; } = "Accordion Item Title";
        public Theme Theme { get; set; } = Theme.Default;
        public Icon Icon { get; set; } = Icon.None;
        public string ClassNames { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var accordionContext = (AccordionContext)context.Items[typeof(AccordionTagHelper)];
            var childContent = await output.GetChildContentAsync();
            accordionContext.AccordionPanels.Add(new Tuple<AccordionPanelTagHelper, IHtmlContent>(this, childContent));
            output.SuppressOutput();
        }
    }
}
