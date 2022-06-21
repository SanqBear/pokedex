namespace Pokedex.Model.Definitions
{
    public class Tag
    {
        public Tag()
        {
        }

        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        public string _name = string.Empty;

        public LanguageResource? Name
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_name) ? new LanguageResource(_name) : null;
            }
        }

        public string _desc = string.Empty;

        public LanguageResource? Description
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_desc) ? new LanguageResource(_desc) : null;
            }
        }
    }
}