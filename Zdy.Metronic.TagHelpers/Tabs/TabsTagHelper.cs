using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers.Untils;

namespace Zdy.Metronic.TagHelpers.Tabs
{
    [HtmlTargetElement("tabs")]
    public class TabsTagHelper : TagHelper
    {
        public TabsMode Mode { get; set; } = TabsMode.Default;
        public Position Position { get; set; } = Position.Top;
        public bool IsReversed { get; set; } = false;
        public bool IsJustified { get; set; } = false;
        public int ActiveIndex { get; set; } = 0;
        public int Limit { get; set; } = 100;
        public string LimitText { get; set; } = "More";
        public string ClassNames { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var tabsContext = new TabsContext();
            context.Items.Add(typeof(TabsTagHelper), tabsContext);

            await output.GetChildContentAsync();

            if (tabsContext.TabContents.Count > 0)
            {
                var classes = CssClassBuilder.Build(
                    new CssClassName($"tabbable-{Mode.ToValue()}", true),
                    new CssClassName("tabs-below", Position == Position.Bottom),
                    new CssClassName("row", Position == Position.Left || Position == Position.Right),
                    new CssClassName("nav-justified", IsJustified && Position != Position.Left && Position != Position.Right),
                    new CssClassName(ClassNames, !string.IsNullOrEmpty(ClassNames)));

                var navClasses = CssClassBuilder.Build(
                    new CssClassName("nav", true),
                    new CssClassName("nav-tabs", Mode != TabsMode.Pills),
                    new CssClassName("nav-pills", Mode == TabsMode.Pills),
                    new CssClassName("tabs-reversed", IsReversed && Position != Position.Left && Position != Position.Right),
                    new CssClassName("nav-justified", IsJustified && Position != Position.Left && Position != Position.Right),
                    new CssClassName($"tabs-{Position.ToValue()}", true));

                var contentClasses = CssClassBuilder.Build(
                    new CssClassName("tab-content", true),
                    new CssClassName($"tabs-{Position.ToValue()}", true));


                output.TagName = "div";

                output.Attributes.Add("class", classes);

                var navs = new TagBuilder("ul");
                navs.AddCssClass(navClasses);

                var contents = new TagBuilder("div");
                contents.AddCssClass(contentClasses);

                var id = Guid.NewGuid().ToString();
                TagBuilder dropdownMenu = null;

                for (var i = 0; i < tabsContext.TabContents.Count; i++)
                {
                    var tabContent = tabsContext.TabContents[i];

                    var tabId = $"tab_{id}_{i}";

                    var navsIsActive = ActiveIndex == i ? "active" : "";
                    var contentsIsActive = ActiveIndex == i ? "active" : "fade";

                    if (Limit > i)
                    {
                        navs.InnerHtml.AppendHtml($@"<li class='{navsIsActive}'>
                                                        <a href='#{tabId}' data-toggle='tab'>{tabContent.Item1}</a>
                                                    </li>");
                    }
                    else
                    {
                        if (dropdownMenu == null)
                        {
                            var dropdown = new TagBuilder("li");
                            dropdown.AddCssClass("dropdown");
                            dropdown.InnerHtml.AppendHtml($@"<a href='javascript:;' class='dropdown-toggle' data-toggle='dropdown'> {LimitText}
                                                                <i class='fa fa-angle-down'></i>
                                                             </a>");
                            dropdownMenu = new TagBuilder("ul");
                            dropdownMenu.AddCssClass("dropdown-menu");
                            dropdownMenu.Attributes.Add("role", "menu");

                            dropdown.InnerHtml.AppendHtml(dropdownMenu);
                            navs.InnerHtml.AppendHtml(dropdown);
                        }
                        dropdownMenu.InnerHtml.AppendHtml($@"<li>
                                                                 <a href='#{tabId}' data-toggle='tab'>{tabContent.Item1}</a>
                                                             </li>");
                    }


                    contents.InnerHtml.AppendHtml($@"<div class='tab-pane {contentsIsActive}' id='{tabId}'>
                                                     {tabContent.Item2.ToHtml()}
                                                     </div>");
                }

                if (Position == Position.Left || Position == Position.Right)
                {
                    var navPositionClasses = CssClassBuilder.Build(
                        new CssClassName("float-left", Position == Position.Left),
                        new CssClassName("float-right", Position == Position.Right),
                        new CssClassName("col-md-3 col-sm-3 col-xs-3", Position == Position.Left || Position == Position.Right));

                    var contentPositionClasses = CssClassBuilder.Build(
                        new CssClassName("col-md-9 col-sm-9 col-xs-9", Position == Position.Left || Position == Position.Right));

                    var navsPositionContainer = new TagBuilder("div");
                    navsPositionContainer.AddCssClass(navPositionClasses);

                    var contentsPositionContainer = new TagBuilder("div");
                    contentsPositionContainer.AddCssClass(contentPositionClasses);

                    navsPositionContainer.InnerHtml.AppendHtml(navs);
                    contentsPositionContainer.InnerHtml.AppendHtml(contents);

                    if (Position == Position.Left)
                    {
                        output.Content.AppendHtml(navsPositionContainer);
                        output.Content.AppendHtml(contentsPositionContainer);
                    }
                    else
                    {
                        output.Content.AppendHtml(contentsPositionContainer);
                        output.Content.AppendHtml(navsPositionContainer);
                    }
                }
                else
                {
                    if (Position == Position.Top)
                    {
                        output.Content.AppendHtml(navs);
                        output.Content.AppendHtml(contents);
                    }
                    else
                    {
                        output.Content.AppendHtml(contents);
                        output.Content.AppendHtml(navs);
                    }
                }
            }
            else
            {
                output.SuppressOutput();
            }
        }
    }
}
