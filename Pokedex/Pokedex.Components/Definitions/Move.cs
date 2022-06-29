using Pokedex.Components.Resources;
using System.Text.Json.Serialization;

namespace Pokedex.Components.Definitions
{
    public class Move
    {
        public Move(string id, string version = "")
        {
            Id = id;
            Version = !string.IsNullOrWhiteSpace(version) ? version : null;
        }

        public string Id { get; private set; } = string.Empty;

        /// <summary>
        /// 버전
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Version { get; private set; } = null;

        public LanguageModel Name => new LanguageModel(Id);

        [JsonIgnore]
        public bool UseDescription { get; set; } = false;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LanguageModel? Description => UseDescription ? new LanguageModel($"{Id}_{Version}_{Constants.SURFIX_DESC}") : null;

        public Field? Type { get; set; } = null;

        public Category? Category { get; set; } = null;

        public int? Power { get; set; } = null;

        public int? PP { get; set; } = null;

        public int? Accuracy { get; set; } = null;

        public int? Chance { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Level { get; set; } = null;

        [JsonIgnore]
        public bool UseGainDescription { get; set; } = false;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LanguageModel? HowToGain => UseGainDescription ? new LanguageModel($"{Id}_{Version}_{Constants.SURFIX_GAIN}") : null;
    }
}