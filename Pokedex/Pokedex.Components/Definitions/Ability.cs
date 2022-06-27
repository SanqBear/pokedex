using Pokedex.Components.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Components.Definitions
{
    public class Ability
    {
        /// <summary>
        /// 특성
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="version">버전 (optional)</param>
        public Ability(string id, string version = "") 
        { 
            Id = id;
            Version = !string.IsNullOrWhiteSpace(version) ? version : null;
        }

        /// <summary>
        /// 특성 ID
        /// </summary>
        public string Id { get; private set; } = string.Empty;

        /// <summary>
        /// 버전
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Version { get; private set; } = null;

        /// <summary>
        /// 특성 이름
        /// </summary>
        public LanguageModel Name => new LanguageModel(Id);

        /// <summary>
        /// 특성 설명 Serialize 여부
        /// </summary>
        [JsonIgnore]
        public bool UseDescription { get; set; } = false;

        /// <summary>
        /// 특성 설명
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LanguageModel? Description => UseDescription ? new LanguageModel($"{Id}_{Constants.SURFIX_DESC}") : null;

        /// <summary>
        /// 숨겨진 특성 여부
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IsHidden { get; set; } = null;
    }
}
