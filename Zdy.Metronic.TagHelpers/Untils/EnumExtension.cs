using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Zdy.Metronic.TagHelpers.Untils
{
    public static class EnumExtension
    {
        public static string ToValue(this object value)
        {                
            return value.ToString().ParseValue().ToLower();
        }

        private static string ParseValue(this string value)
        {
            if (value.StartsWith("_"))
            {
                value = value.Substring(1);
            }
            StringBuilder result = new StringBuilder();
            var chars = value.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                var c = chars[i];
                if (i != 0)
                {
                    if (c >= 'A' && c <= 'Z')
                    {
                        result.Append('-');
                    }
                }
                result.Append(c);
            }
            return result.ToString();
        }
    }
}
