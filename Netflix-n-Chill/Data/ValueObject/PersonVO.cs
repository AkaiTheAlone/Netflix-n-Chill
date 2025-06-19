using Netflix_n_Chill.Hypermedia;
using Netflix_n_Chill.Hypermedia.Abstract;
using System.Text.Json.Serialization;

namespace Netflix_n_Chill.Data.ValueObject
{
    //data member does not work anymore on aspnetcore
    public class PersonVO : ISupportHypermedia
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
        public List<HypermediaLink> Links { get; set; } = new();
    }
}
