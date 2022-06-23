using Pokedex.Model.Utils;
using System.Text.Json.Serialization;

namespace Pokedex.Model.Definitions
{
    public class LanguageResource
    {
        public LanguageResource()
        {
            Korean = string.Empty;
            English = string.Empty;
            Japanese = string.Empty;
        }

        public LanguageResource(string keyCode)
        {
            if (LanguageManager.Instance.IsLoaded)
            {
                Korean = LanguageManager.Instance.koKR(keyCode);
                English = LanguageManager.Instance.enUS(keyCode);
                Japanese = LanguageManager.Instance.jaJP(keyCode);
            }
            else
            {
                Korean = string.Empty;
                English = string.Empty;
                Japanese = string.Empty;
            }
        }

        [JsonPropertyName("ko")]
        public string Korean { get; private set; }

        [JsonPropertyName("en")]
        public string English { get; private set; }

        [JsonPropertyName("jp")]
        public string Japanese { get; private set; }
    }
}