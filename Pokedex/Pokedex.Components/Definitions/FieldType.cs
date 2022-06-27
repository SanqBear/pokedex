using System.Text.Json.Serialization;

namespace Pokedex.Components.Definitions
{
    public class FieldType
    {
        public FieldType(string id) 
        { 
            Id = id;
        }

        public string Id { get; private set; } = string.Empty;

        public LanguageModel Name => new LanguageModel(Id);

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IReadOnlyList<Pokemon>? Pokemons { get; private set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IReadOnlyList<Move>? Moves { get; private set; } = null;


        public void Bind(IEnumerable<Pokemon> pokemons)
        {
            Pokemons = new List<Pokemon>(pokemons);
        }

        public void Bind(IEnumerable<Move> moves)
        {
            Moves = new List<Move>(moves);
        }

    }
}