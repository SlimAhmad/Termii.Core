using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch
{
    internal class ExternalSendBulkMessageRequest
    {
        [JsonProperty("to")]
        public List<string> To { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("sms")]
        public string Sms { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }
}
