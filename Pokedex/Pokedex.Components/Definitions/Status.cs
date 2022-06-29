using System.Text.Json.Serialization;

namespace Pokedex.Components.Definitions
{
    public class Status
    {
        /// <summary>
        /// 기초 능력치
        /// </summary>
        public Status()
        { }

        /// <summary>
        /// 체력
        /// </summary>
        [JsonPropertyName("Hp")]
        public int Health { get; set; }

        /// <summary>
        /// 공격력
        /// </summary>
        [JsonPropertyName("Atk")]
        public int Attack { get; set; }

        /// <summary>
        /// 방어력
        /// </summary>
        [JsonPropertyName("Def")]
        public int Defense { get; set; }

        /// <summary>
        /// 특수공격력
        /// </summary>
        [JsonPropertyName("SAtk")]
        public int SpAttack { get; set; }

        /// <summary>
        /// 특수방어력
        /// </summary>
        [JsonPropertyName("SDef")]
        public int SpDefense { get; set; }

        /// <summary>
        /// 스피드
        /// </summary>
        [JsonPropertyName("Spd")]
        public int Speed { get; set; }
    }
}