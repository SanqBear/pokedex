using System.Text.Json.Serialization;

namespace Pokedex.Components.Definitions
{
    public class Pokemon
    {
        public Pokemon(string id)
        { 
            Id = id;
        }

        public string Id { get; private set; } = string.Empty;

        public LanguageModel Name => new LanguageModel(Id);

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IReadOnlyList<FieldType>? Types { get; private set; } = null;





    }
}