using System.Text.Json.Serialization;

namespace Pokedex.Model.Definitions
{
    public class Attribute
    {
        public Attribute()
        {
        }

        public int Id { get; set; }

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