using System.Text.Json.Serialization;

namespace atos_api_exercise.Models
{
    public class NewCustomer
    {
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; } = string.Empty;
        [JsonPropertyName("surname")]
        public string Surname { get; set; } = string.Empty;
    }
}
