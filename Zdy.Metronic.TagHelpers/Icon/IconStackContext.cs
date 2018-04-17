using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zdy.Metronic.TagHelpers
{
    public class IconStackContext
    {
        public List<TagBuilder> Icons { get; set; } = new List<TagBuilder>();
    }
}
