using System;
using System.Text.Json.Serialization;

namespace Pokedex.Model.Definitions
{
	public class Move
	{
		public Move()
		{
		}

        public Move(string name, string desc)
        {
			_name = name;
			_desc = desc;
        }

		public int Id { get; set; }

		public string Gen { get; set; } = string.Empty;

		public int Pp { get; set; }

		public int Power { get; set; }

		public string Class { get; set; } = string.Empty;

		public string Type { get; set; } = string.Empty;

		private string _name = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public LanguageResource? Name
		{
			get
			{
				return !string.IsNullOrWhiteSpace(_name) ? new LanguageResource(_name) : null;
			}
		}

		private string _desc = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public LanguageResource? Description
        {
            get
            {
				return !string.IsNullOrWhiteSpace(_desc) ? new LanguageResource(_desc) : null;
            }
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Level { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IList<Pokemon>? Pokemons { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public IList<Tag>? Tags { get; set; } = null;
	}
}

