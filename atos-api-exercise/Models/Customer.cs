using System.Text.Json.Serialization;

namespace atos_api_exercise.Models
{
    public class Customer : NewCustomer
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        /*[JsonPropertyName("firstname")]
        public string Firstname { get; set; } //= string.Empty;
        [JsonPropertyName("surname")]
        public string Surname { get; set; } //= string.Empty;*/
    }
}
