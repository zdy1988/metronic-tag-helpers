using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers.Untils;

namespace Zdy.Metronic.TagHelpers.Accordion
{
    [HtmlTargetElement("accordion")]
    public class AccordionTagHelper : TagHelper
    {
        public int ActiveIndex { get; set; } = 0;
        public bool IsShowAccordionToggleStyled { get; set; } = false;
        public bool IsScrollable { get; set; } = false;
        public string ClassNames { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var accordionContext = new AccordionContext();
            context.Items.Add(typeof(AccordionTagHelper), accordionContext);

            await output.GetChildContentAsync();

            if (accordionContext.AccordionPanels.Count > 0)
            {
                var id = Guid.NewGuid().ToString();

                output.TagName = "div";

                var classes = CssClassBuilder.Build(
                    new CssClassName("panel-group accordion", true),
                    new CssClassName("scrollable", IsScrollable),
                    new CssClassName(ClassNames, !string.IsNullOrEmpty(ClassNames)));

                output.Attributes.Add("class", classes);

                output.Attributes.Add("id", $"accordion_{id}");

                for (var i = 0; i < accordionContext.AccordionPanels.Count; i++)
                {
                    var accordionPanelTag = accordionContext.AccordionPanels[i].Item1;

                    var accordionPanel = accordionContext.AccordionPanels[i].Item2;

                    var accordionPanelId = $"accordion_panel_{id}_{i}";

                    var accordionPanelClasses = CssClassBuilder.Build(
                        new CssClassName("panel", true),
                        new CssClassName($"panel-{accordionPanelTag.Theme.ToValue()}", accordionPanelTag.Theme != Theme.None),
                        new CssClassName(accordionPanelTag.ClassNames, !string.IsNullOrEmpty(accordionPanelTag.ClassNames)));

                    TagBuilder accordionPanelBuilder = new TagBuilder("div");
                    accordionPanelBuilder.AddCssClass(accordionPanelClasses);

                    var iconHtml = "";
                    if (accordionPanelTag.Icon != Icon.None)
                    {
                        iconHtml = $"<i class='fa fa-{accordionPanelTag.Icon.ToValue()} fa-fw'></i> ";
                    }

                    var isActive = ActiveIndex == i ? "in" : "collapse";

                    var isShowAccordionToggleStyled = IsShowAccordionToggleStyled ? (ActiveIndex == i) ? "accordion-toggle-styled" : "accordion-toggle-styled collapsed" : "";

                    accordionPanelBuilder.InnerHtml.AppendHtml($@"
                        <div class='panel-heading'>
                            <h4 class='panel-title'>
                                <a class='accordion-toggle {isShowAccordionToggleStyled}' data-toggle='collapse' data-parent='#accordion_{id}' href='#{accordionPanelId}'> 
                                     {iconHtml}
                                     {accordionPanelTag.Title}
                                </a>
                            </h4>
                        </div>");

                    accordionPanelBuilder.InnerHtml.AppendHtml($@"
                        <div id='{accordionPanelId}' class='panel-collapse {isActive}'>
                            <div class='panel-body'>
                                {accordionPanel.ToHtml()}
                            </div>
                        </div>");

                    output.Content.AppendHtml(accordionPanelBuilder);
                }
            }
            else
            {
                output.SuppressOutput();
            }
        }
    }
}
