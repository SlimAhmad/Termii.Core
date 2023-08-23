using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Switch
{
    public class SendMessageResponse
    {
        [JsonProperty("message_id")]
        public string MessageId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }
    }
}
