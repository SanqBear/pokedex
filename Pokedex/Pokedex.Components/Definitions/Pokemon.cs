using Pokedex.Components.Resources;
using System.Text.Json.Serialization;

namespace Pokedex.Components.Definitions
{
    public class Pokemon
    {
        /// <summary>
        /// 포켓몬
        /// </summary>
        /// <param name="id">포켓몬 ID</param>
        /// <param name="version">버전</param>
        public Pokemon(string id, string version = "")
        {
            Id = id;
            Version = !string.IsNullOrWhiteSpace(version) ? version : null;
        }

        /// <summary>
        /// 포켓몬 ID
        /// </summary>
        public string Id { get; private set; } = string.Empty;

        /// <summary>
        /// 버전
        /// </summary>
        public string? Version { get; private set; } = null;

        /// <summary>
        /// 포켓몬 이름
        /// </summary>
        public LanguageModel Name => new LanguageModel(Id);

        [JsonIgnore]
        public bool UseDescription { get; set; } = false;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LanguageModel? Description => UseDescription ? new LanguageModel($"{Id}_{Version}_{Constants.SURFIX_DESC}") : null;

        /// <summary>
        /// 포켓몬 타입
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IReadOnlyList<Field>? Types { get; private set; } = null;

        public void Bind(IEnumerable<Field> types)
        {
            Types = new List<Field>(types);
        }

        /// <summary>
        /// 능력치
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Status? Status { get; private set; } = null;

        public void Set(Status status)
        {
            Status = status;
        }

        /// <summary>
        /// 기술
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IReadOnlyDictionary<string, IReadOnlyList<Move>>? Moves
        {
            get
            {
                if (!(LevelUpMoves == null && EggMoves == null && ExtraMoves == null))
                {
                    Dictionary<string, IReadOnlyList<Move>> moves = new Dictionary<string, IReadOnlyList<Move>>();
                    moves.Add(MoveType.LevelUp.ToString().ToCamelCase(), LevelUpMoves ?? new List<Move>());
                    moves.Add(MoveType.EggMove.ToString().ToCamelCase(), EggMoves ?? new List<Move>());
                    moves.Add(MoveType.Extra.ToString().ToCamelCase(), ExtraMoves ?? new List<Move>());
                    return moves;
                }

                return null;
            }
        }

        [JsonIgnore]
        public IReadOnlyList<Move>? LevelUpMoves { get; private set; } = null;

        [JsonIgnore]
        public IReadOnlyList<Move>? EggMoves { get; private set; } = null;

        [JsonIgnore]
        public IReadOnlyList<Move>? ExtraMoves { get; private set; } = null;

        public void Bind(MoveType type, IEnumerable<Move> moves)
        {
            switch (type)
            {
                case MoveType.LevelUp:
                    LevelUpMoves = new List<Move>(moves);
                    break;

                case MoveType.EggMove:
                    EggMoves = new List<Move>(moves);
                    break;

                case MoveType.Extra:
                    ExtraMoves = new List<Move>(moves);
                    break;

                default:
                    break;
            }
        }
    }
}