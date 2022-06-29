using System.Text.Json.Serialization;

namespace Pokedex.Components.Definitions
{
    public class Field
    {
        /// <summary>
        /// 타입
        /// </summary>
        /// <param name="id">타입 ID</param>
        /// <param name="version">버전</param>
        public Field(string id, string version = "")
        {
            Id = id;
            Version = !string.IsNullOrWhiteSpace(version) ? version : null;
        }

        /// <summary>
        /// 타입 ID
        /// </summary>
        public string Id { get; private set; } = string.Empty;

        /// <summary>
        /// 버전
        /// </summary>
        public string? Version { get; private set; } = null;

        /// <summary>
        /// 타입명
        /// </summary>
        public LanguageModel Name => new LanguageModel(Id);

        /// <summary>
        /// 타입을 가진 포켓몬
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IReadOnlyList<Pokemon>? Pokemons { get; private set; } = null;

        /// <summary>
        /// 타입을 가진 기술
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IReadOnlyList<Move>? Moves { get; private set; } = null;

        /// <summary>
        /// 타입과 일치하는 포켓몬 데이터를 바인드
        /// </summary>
        public void Bind(IEnumerable<Pokemon> pokemons)
        {
            Pokemons = new List<Pokemon>(pokemons);
        }

        /// <summary>
        /// 타입과 일치하는 기술 데이터를 바인드
        /// </summary>
        public void Bind(IEnumerable<Move> moves)
        {
            Moves = new List<Move>(moves);
        }
    }
}