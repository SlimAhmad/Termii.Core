using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Termii.Core.Models.Services.Foundations.Termii
{
    public class NotFoundSearchResponse
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("dnd_active")]
        public string DndActive { get; set; }
        [JsonPropertyName("network")]
        public string Network { get; set; }
        [JsonPropertyName("network_code")]
        public string NetworkCode { get; set; }
    }
}
