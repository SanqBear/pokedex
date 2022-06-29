using System.Text.Json.Serialization;

namespace Pokedex.Components.Definitions
{
    public class Category
    {
        /// <summary>
        /// 카테고리
        /// </summary>
        /// <param name="id">타입 ID</param>
        /// <param name="version">버전</param>
        public Category(string id, string version = "")
        {
            Id = id;
            Version = !string.IsNullOrWhiteSpace(version) ? version : null;
        }

        /// <summary>
        /// 카테고리 ID
        /// </summary>
        public string Id { get; private set; } = string.Empty;

        /// <summary>
        /// 버전
        /// </summary>
        public string? Version { get; private set; } = null;

        /// <summary>
        /// 카테고리명
        /// </summary>
        public LanguageModel Name => new LanguageModel(Id);

        /// <summary>
        /// 카테고리를 가진 기술
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IReadOnlyList<Move>? Moves { get; private set; } = null;

        /// <summary>
        /// 카테고리와 일치하는 기술 데이터를 바인드
        /// </summary>
        public void Bind(IEnumerable<Move> moves)
        {
            Moves = new List<Move>(moves);
        }
    }
}