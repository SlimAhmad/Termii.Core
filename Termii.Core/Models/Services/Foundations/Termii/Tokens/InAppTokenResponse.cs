using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Tokens
{
    public class InAppTokenResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public InAppData Data { get; set; }

        public class InAppData
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
