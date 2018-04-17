using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zdy.Metronic.TagHelpers.Accordion
{
    public class AccordionContext
    {
        public List<Tuple<AccordionPanelTagHelper, IHtmlContent>> AccordionPanels { get; set; } = new List<Tuple<AccordionPanelTagHelper, IHtmlContent>>();
    }
}
