using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Tokens
{
    public class SendTokenRequest
    {

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("message_type")]
        public string MessageType { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("pin_attempts")]
        public int PinAttempts { get; set; }

        [JsonProperty("pin_time_to_live")]
        public int PinTimeToLive { get; set; }

        [JsonProperty("pin_length")]
        public int PinLength { get; set; }

        [JsonProperty("pin_placeholder")]
        public string PinPlaceholder { get; set; }

        [JsonProperty("message_text")]
        public string MessageText { get; set; }

        [JsonProperty("pin_type")]
        public string PinType { get; set; }
    }
}
