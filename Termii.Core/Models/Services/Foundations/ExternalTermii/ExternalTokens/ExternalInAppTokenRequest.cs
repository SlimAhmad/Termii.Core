using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens
{
    internal class ExternalInAppTokenRequest
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("pin_type")]
        public string PinType { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("pin_attempts")]
        public int PinAttempts { get; set; }

        [JsonProperty("pin_time_to_live")]
        public int PinTimeToLive { get; set; }

        [JsonProperty("pin_length")]
        public int PinLength { get; set; }
    }
}
