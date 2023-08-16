using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens
{
    internal class ExternalInAppTokenResponse
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public ExternalData Data { get; set; }

        public class ExternalData
        {
            [JsonProperty("pin_id")]
            public string PinId { get; set; }

            [JsonProperty("otp")]
            public string Otp { get; set; }

            [JsonProperty("phone_number")]
            public string PhoneNumber { get; set; }

            [JsonProperty("phone_number_other")]
            public string PhoneNumberOther { get; set; }
        }

    }
}
