using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch
{
    internal class ExternalNumberMessageRequest
    {
        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("sms")]
        public string Sms { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }
}
