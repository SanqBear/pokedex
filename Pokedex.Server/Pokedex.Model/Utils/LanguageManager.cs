using System;
namespace Pokedex.Model.Utils
{
	public class LanguageManager
	{
		private static Lazy<LanguageManager> _instance = new Lazy<LanguageManager>(() => new LanguageManager());

		public const string Korean = "koKR";
		public const string English = "enUS";
		public const string Japanese = "jaJP";

		public static IReadOnlyDictionary<string, Dictionary<string, string>> Dictionary { get; set; } = new Dictionary<string, Dictionary<string, string>>();
		public static LanguageManager Instance => _instance.Value;

		private LanguageManager()
		{
		}


		public void Load(string jsonPath)
        {
			using(StreamReader sr = new StreamReader(jsonPath))
            {
				LoadJson(sr.ReadToEnd());
            }
        }

		private void LoadJson(string jsonContent)
        {
			jsonContent = jsonContent.Trim();
            Dictionary = new Dictionary<string, Dictionary<string, string>>(System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(jsonContent) ?? new Dictionary<string, Dictionary<string, string>>(), StringComparer.OrdinalIgnoreCase);
        }

        public string koKR(string keyCode, params string[] replacements)
        {
            return Get(keyCode, Korean, replacements);
        }

        public string enUS(string keyCode, params string[] replacements)
        {
            return Get(keyCode, English, replacements);
        }

        public string jaJP(string keyCode, params string[] replacements)
        {
            return Get(keyCode, Japanese, replacements);
        }

		public string Get(string keyCode, string langCode, params string[] replacements)
        {
			if(!TryGetAll(keyCode, out var locales, replacements))
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

