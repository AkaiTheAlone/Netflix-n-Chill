using Netflix_n_Chill.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;
using System.Text.Json.Serialization;

namespace Netflix_n_Chill.Data.ValueObject
{
    //data member does not work anymore on aspnetcore
    public class PersonVO
    {
        [JsonPropertyName("IdentifierCode")]
        public long Id { get; set; }
        [JsonPropertyName("Name")]
        public string? FirstName { get; set; }
        [JsonPropertyName("Surname")]
        public string? LastName { get; set; }
        [JsonIgnore]
        public string? Address { get; set; }
        [JsonPropertyName("Sex")]
        public string? Gender { get; set; }
    }
}
