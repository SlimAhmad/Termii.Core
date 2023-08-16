using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch
{
    internal class ExternalCreateSenderIdRequest
    {

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("sender_id")]
        public string SenderId { get; set; }

        [JsonProperty("usecase")]
        public string Usecase { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }
    }
}
