using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zdy.Metronic.TagHelpers.Untils;

namespace Zdy.Metronic.TagHelpers.Progress
{
    public class ProgressBarTagHelper: TagHelper
    {
        public State State { get; set; } = State.Success;
        public string Title { get; set; }
        public bool IsShowValue { get; set; } = false;
        public int Max { get; set; } = 100;
        public int Min { get; set; } = 0;
        public int Step { get; set; } = 1;
        public int Value { get; set; } = 0;
        public ProgressStriped Striped { get; set; } = ProgressStriped.None;
        public string ClassNames { get; set; }

        public double Progress
        {
            get
            {
                var len = Max - Min;
                var val = Value - Min;
                var step = Math.Pow(10, Step);
                return Math.Round((100 * step * val) / len) / step;
            }
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            var classes = CssClassBuilder.Build(
                new CssClassName("progress", true),
                new CssClassName("progress-striped", Striped != ProgressStriped.None),
                new CssClassName("active", Striped == ProgressStriped.Active),
                new CssClassName(ClassNames, !string.IsNullOrEmpty(ClassNames)));

            var barClasses = CssClassBuilder.Build(
                new CssClassName("progress-bar", true),
                new CssClassName($"progress-bar-{State.ToValue()}", State != State.None));

            output.TagName = "div";

            output.Attributes.Add("class", classes);

            var valueHtml = IsShowValue ? $"{Progress}%" : "";

            var barHtml = $@"<div class='{barClasses}' role='progressbar' style='width: {Progress}%'>
                               <span>
                                 {valueHtml}
                                 {Title}
                               </span>
                             </div>";

            output.Content.AppendHtml(barHtml);
        }
    }
}
