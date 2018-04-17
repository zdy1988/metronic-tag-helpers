using System;
using System.Linq;

namespace Zdy.Metronic.TagHelpers.Untils
{
    public class CssClassBuilder
    {
        public static string Build(params CssClassName[] classNames)
        {
            var classes = classNames.Where(t => t.IsAppend == true).Select(t => t.ClassName);
            return classes.Count() > 0 ? String.Join(" ", classes) : "";
        }
    }
}
