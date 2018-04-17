namespace Zdy.Metronic.TagHelpers.Untils
{

    public class CssClassName
    {
        public CssClassName(string className, bool isAppend)
        {
            this.ClassName = className;
            this.IsAppend = isAppend;
        }

        public string ClassName { get; set; }
        public bool IsAppend { get; set; }
    }
}
