using System.Text.Json.Serialization;

namespace Pokedex.Model.Definitions
{
    public class Attribute
    {
        public Attribute()
        {
        }

        public Attribute(string name, string desc)
        {
            _name = name;
            _desc = desc;
        }

        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        private string _name = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LanguageResource? Name
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_name) ? new LanguageResource(_name) : null;
            }
        }

        private string _desc = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LanguageResource? Description
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_desc) ? new LanguageResource(_desc) : null;
            }
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsHidden { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Pokemon>? Pokemons { get; set; } = null;
    }
}