using System;
using System.Data;
using System.Text.Json.Serialization;

namespace Pokedex.Model.Definitions
{
	public class Attribute
	{
		public Attribute()
		{
		}

		public Attribute(DataRow row)
        {

        }

		public int Id { get; set; }

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

		public LanguageResource? Description
        {
            get
            {
				return !string.IsNullOrWhiteSpace(_desc) ? new LanguageResource(_desc) : null;
            }
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public bool? IsHidden { get; set; } = null;
	}
}

