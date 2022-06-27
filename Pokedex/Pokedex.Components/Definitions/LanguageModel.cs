using Pokedex.Components.Utils;
using System.Text.Json.Serialization;

namespace Pokedex.Components.Definitions
{
    public class LanguageModel
    {
        public LanguageModel()
        { }

        public LanguageModel(string keyCode, params string[] replacement)
        {
            if (LanguageCache.Instance.IsLoaded)
            {
                Korean = LanguageCache.Instance.Korean(keyCode, replacement);
                English = LanguageCache.Instance.English(keyCode, replacement);
                Japanese = LanguageCache.Instance.Japanese(keyCode, replacement);
                JapanesePron = LanguageCache.Instance.JapanesePron(keyCode, replacement);
            }
        }

        public LanguageModel(string korean, string english, string japanese, string pron)
        {
            Korean = korean;
            English = english;
            Japanese = japanese;
            JapanesePron= pron;
        }

        [JsonPropertyName("ko")]
        public string Korean { get; set; } = string.Empty;

        [JsonPropertyName("en")]
        public string English { get; set; } = string.Empty;

        [JsonPropertyName("jp")]
        public string Japanese { get; set; } = string.Empty;

        [JsonPropertyName("jpv")]
        public string JapanesePron { get; set; } = string.Empty;
    }
}