using System.Text.Json.Serialization;

namespace Pokedex.Model.Definitions
{
    public class FieldType
    {
        public FieldType()
        {
        }

        public string Id { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Gen { get; set; } = null;


        public LanguageResource? Name
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Id) ? new LanguageResource(Id) : null;
            }
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Pokemon>? Pokemons { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Move>? Moves { get; set; } = null;
    }
}