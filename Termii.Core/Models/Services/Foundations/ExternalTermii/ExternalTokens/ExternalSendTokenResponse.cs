using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens
{
    internal class ExternalSendTokenResponse
    {
        [JsonProperty("pinId")]
        public string PinId { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("smsStatus")]
        public string SmsStatus { get; set; }
    }
}
