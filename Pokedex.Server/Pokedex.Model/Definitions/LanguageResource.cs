using Pokedex.Model.Utils;

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

        public string Korean { get; private set; }

        public string English { get; private set; }

        public string Japanese { get; private set; }
    }
}