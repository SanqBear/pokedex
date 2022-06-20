using System.Data;
using System.Text.Json.Serialization;

namespace Pokedex.Model.Definitions
{
    public class Pokemon
    {
        public Pokemon()
        {
        }

        public Pokemon(DataRow row)
        {

        }

        public int Id { get; set; }

        public string Gen { get; set; } = string.Empty;

        private string _name = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LanguageResource? Name
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_name) ? new LanguageResource(_name) : null;
            }
        }

        private string _type = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LanguageResource? Type
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_type) ? new LanguageResource(_type) : null;
            }
        }


        public IList<Attribute> Attributes { get; set; } = new List<Attribute>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Status? Status { get; set; } = null;
    }
}