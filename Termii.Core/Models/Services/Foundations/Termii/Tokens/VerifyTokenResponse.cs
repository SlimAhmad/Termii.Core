using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Tokens
{
    public class VerifyTokenResponse
    {
        [JsonProperty("pinId")]
        public string PinId { get; set; }

        [JsonProperty("verified")]
        public string Verified { get; set; }

        [JsonProperty("msisdn")]
        public string Msisdn { get; set; }
    }
}
