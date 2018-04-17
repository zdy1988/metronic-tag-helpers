using System;
using System.Collections.Generic;
using System.Text;

namespace Zdy.Metronic.TagHelpers.Untils
{
    public class Colour
    {
        public static Dictionary<string, ColourValue> All = new Dictionary<string, ColourValue>(new List<KeyValuePair<string, ColourValue>>
        {
              new KeyValuePair<string, ColourValue>("white", new ColourValue{ColorName="white",BaseColor= "#ffffff", FontColor= "#666"}),
              new KeyValuePair<string, ColourValue>("black", new ColourValue{ColorName="black",BaseColor= "#000000", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("default", new ColourValue{ColorName="default",BaseColor= "#e1e5ec", FontColor= "#666"}),
              new KeyValuePair<string, ColourValue>("dark", new ColourValue{ColorName="dark",BaseColor= "#2f353b", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("blue", new ColourValue{ColorName="blue",BaseColor= "#3598dc", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("blue-madison", new ColourValue{ColorName="blue-madison",BaseColor= "#578ebe", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("blue-chambray", new ColourValue{ColorName="blue-chambray",BaseColor= "#2C3E50", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("blue-ebonyclay", new ColourValue{ColorName="blue-ebonyclay",BaseColor= "#22313F", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("blue-hoki", new ColourValue{ColorName="blue-hoki",BaseColor= "#67809F", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("blue-steel", new ColourValue{ColorName="blue-steel",BaseColor= "#4B77BE", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("blue-soft", new ColourValue{ColorName="blue-soft",BaseColor= "#4c87b9", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("blue-dark", new ColourValue{ColorName="blue-dark",BaseColor= "#5e738b", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("blue-sharp", new ColourValue{ColorName="blue-sharp",BaseColor= "#5C9BD1", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("blue-oleo", new ColourValue{ColorName="blue-oleo",BaseColor= "#94A0B2", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("green", new ColourValue{ColorName="green",BaseColor= "#32c5d2", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("green-meadow", new ColourValue{ColorName="green-meadow",BaseColor= "#1BBC9B", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("green-seagreen", new ColourValue{ColorName="green-seagreen",BaseColor= "#1BA39C", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("green-turquoise", new ColourValue{ColorName="green-turquoise",BaseColor= "#36D7B7", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("green-haze", new ColourValue{ColorName="green-haze",BaseColor= "#44b6ae", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("green-jungle", new ColourValue{ColorName="green-jungle",BaseColor= "#26C281", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("green-soft", new ColourValue{ColorName="green-soft",BaseColor= "#3faba4", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("green-dark", new ColourValue{ColorName="green-dark",BaseColor= "#4DB3A2", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("green-sharp", new ColourValue{ColorName="green-sharp",BaseColor= "#2ab4c0", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("green-steel", new ColourValue{ColorName="green-steel",BaseColor= "#29b4b6", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("grey", new ColourValue{ColorName="grey",BaseColor= "#E5E5E5", FontColor= "#333333"}),
              new KeyValuePair<string, ColourValue>("grey-steel", new ColourValue{ColorName="grey-steel",BaseColor= "#e9edef", FontColor= "#80898e"}),
              new KeyValuePair<string, ColourValue>("grey-cararra", new ColourValue{ColorName="grey-cararra",BaseColor= "#fafafa", FontColor= "#333333"}),
              new KeyValuePair<string, ColourValue>("grey-gallery", new ColourValue{ColorName="grey-gallery",BaseColor= "#555555", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("grey-cascade", new ColourValue{ColorName="grey-cascade",BaseColor= "#95A5A6", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("grey-silver", new ColourValue{ColorName="grey-silver",BaseColor= "#BFBFBF", FontColor= "#FAFCFB"}),
              new KeyValuePair<string, ColourValue>("grey-salsa", new ColourValue{ColorName="grey-salsa",BaseColor= "#ACB5C3", FontColor= "#FAFCFB"}),
              new KeyValuePair<string, ColourValue>("grey-salt", new ColourValue{ColorName="grey-salt",BaseColor= "#bfcad1", FontColor= "#FAFCFB"}),
              new KeyValuePair<string, ColourValue>("grey-mint", new ColourValue{ColorName="grey-mint",BaseColor= "#525e64", FontColor= "#FFFFFF"}),
              new KeyValuePair<string, ColourValue>("red", new ColourValue{ColorName="red",BaseColor= "#e7505a", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("red-pink", new ColourValue{ColorName="red-pink",BaseColor= "#E08283", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("red-sunglo", new ColourValue{ColorName="red-sunglo",BaseColor= "#E26A6A", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("red-intense", new ColourValue{ColorName="red-intense",BaseColor= "#e35b5a", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("red-thunderbird", new ColourValue{ColorName="red-thunderbird",BaseColor= "#D91E18", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("red-flamingo", new ColourValue{ColorName="red-flamingo",BaseColor= "#EF4836", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("red-soft", new ColourValue{ColorName="red-soft",BaseColor= "#d05454", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("red-haze", new ColourValue{ColorName="red-haze",BaseColor= "#f36a5a", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("red-mint", new ColourValue{ColorName="red-mint",BaseColor= "#e43a45", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("yellow", new ColourValue{ColorName="yellow",BaseColor= "#c49f47", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("yellow-gold", new ColourValue{ColorName="yellow-gold",BaseColor= "#E87E04", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("yellow-casablanca", new ColourValue{ColorName="yellow-casablanca",BaseColor= "#f2784b", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("yellow-crusta", new ColourValue{ColorName="yellow-crusta",BaseColor= "#f3c200", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("yellow-lemon", new ColourValue{ColorName="yellow-lemon",BaseColor= "#F7CA18", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("yellow-saffron", new ColourValue{ColorName="yellow-saffron",BaseColor= "#F4D03F", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("yellow-soft", new ColourValue{ColorName="yellow-soft",BaseColor= "#c8d046", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("yellow-haze", new ColourValue{ColorName="yellow-haze",BaseColor= "#c5bf66", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("yellow-mint", new ColourValue{ColorName="yellow-mint",BaseColor= "#c5b96b", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("purple", new ColourValue{ColorName="purple",BaseColor= "#8E44AD", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("purple-plum", new ColourValue{ColorName="purple-plum",BaseColor= "#8775a7", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("purple-medium", new ColourValue{ColorName="purple-medium",BaseColor= "#BF55EC", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("purple-studio", new ColourValue{ColorName="purple-studio",BaseColor= "#8E44AD", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("purple-wisteria", new ColourValue{ColorName="purple-wisteria",BaseColor= "#9B59B6", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("purple-seance", new ColourValue{ColorName="purple-seance",BaseColor= "#9A12B3", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("purple-intense", new ColourValue{ColorName="purple-intense",BaseColor= "#8775a7", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("purple-sharp", new ColourValue{ColorName="purple-sharp",BaseColor= "#796799", FontColor= "#ffffff"}),
              new KeyValuePair<string, ColourValue>("purple-soft", new ColourValue{ColorName="purple-soft",BaseColor= "#8877a9", FontColor= "#ffffff"})
        });

        public static ColourValue Get(string name)
        {
            return All[name];
        }
    }
}
