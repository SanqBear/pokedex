using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Components.Utils
{
    public class LanguageCache
    {
        private static Lazy<LanguageCache> _instance = new Lazy<LanguageCache>(() => new LanguageCache());

        public const string KOREAN_CODE = "koKR";
        public const string ENGLISH_CODE = "enUS";
        public const string JAPANESE_CODE = "jaJP";
        public const string JAPKOREAN_CODE = "koJP";

        public static IReadOnlyDictionary<string, Dictionary<string, string>> Dictionary { get; set; } = new Dictionary<string, Dictionary<string, string>>();
        public static LanguageCache Instance => _instance.Value;
        public bool IsLoaded => Dictionary.Any();

        private LanguageCache()
        {
        }

        public void Load(string jsonPath)
        {
            using (StreamReader sr = new StreamReader(jsonPath))
            {
                LoadJson(sr.ReadToEnd());
            }
        }

        private void LoadJson(string jsonContent)
        {
            jsonContent = jsonContent.Trim();
            Dictionary = new Dictionary<string, Dictionary<string, string>>(System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonContent) ?? new Dictionary<string, Dictionary<string, string>>(), StringComparer.OrdinalIgnoreCase);
        }

        public string Korean(string keyCode, params string[] replacements)
        {
            return Get(keyCode, KOREAN_CODE, replacements);
        }

        public string English(string keyCode, params string[] replacements)
        {
            return Get(keyCode, ENGLISH_CODE, replacements);
        }

        public string Japanese(string keyCode, params string[] replacements)
        {
            return Get(keyCode, JAPANESE_CODE, replacements);
        }

        public string JapanesePron(string keyCode, params string[] replacements)
        {
            return Get(keyCode, JAPKOREAN_CODE, replacements);
        }

        public string Get(string keyCode, string langCode, params string[] replacements)
        {
            if (!TryGetAll(keyCode, out var locales, replacements))
            {
                return string.Empty;
            }
            else
            {
                return locales.TryGetValue(langCode, out string? lang) ? lang : string.Empty;
            }
        }

        private bool TryGetAll(string keyCode, out IReadOnlyDictionary<string, string> locales, params string[] replacements)
        {
            if (Dictionary.ContainsKey(keyCode))
            {
                var preLocales = new Dictionary<string, string>(Dictionary[keyCode], StringComparer.OrdinalIgnoreCase);
                foreach (string key in preLocales.Keys)
                {
                    if (replacements?.Any() ?? false)
                    {
                        preLocales[key] = string.Format(preLocales[key], replacements);
                    }
                }

                locales = preLocales;
                return true;
            }

            locales = new Dictionary<string, string>();
            return false;
        }
    }
}
