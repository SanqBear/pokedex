using System.Text.Json.Serialization;

namespace Pokedex.Model.Definitions
{
    public class Pokemon
    {
        public Pokemon()
        {
        }

        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Gen { get; set; } = null;

        private string _name = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LanguageResource? Name
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_name) ? new LanguageResource(_name) : null;
            }
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<LanguageResource>? Types { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Attribute>? Attributes { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Status? Status { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Tag>? Tags { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Move>? Moves { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? EvolveCondition { get; set; } = null;
    }
}