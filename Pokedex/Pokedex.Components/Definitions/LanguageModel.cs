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
                if (string.IsNullOrEmpty(JapanesePron)) JapanesePron = null;
            }
        }

        public LanguageModel(string korean, string english, string japanese, string pron)
        {
            Korean = korean;
            English = english;
            Japanese = japanese;
            JapanesePron = pron;
        }

        /// <summary>
        /// 한국어
        /// </summary>
        [JsonPropertyName("ko")]
        public string Korean { get; set; } = string.Empty;

        /// <summary>
        /// 영어
        /// </summary>
        [JsonPropertyName("en")]
        public string English { get; set; } = string.Empty;

        /// <summary>
        /// 일본어
        /// </summary>
        [JsonPropertyName("jp")]
        public string Japanese { get; set; } = string.Empty;

        /// <summary>
        /// 일본어의 한국어 음차
        /// </summary>
        [JsonPropertyName("jpv")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? JapanesePron { get; set; } = null;
    }
}