using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch
{
    internal class ExternalTemplatedMessageRequest
    {

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("data")]
        public ExternalData Data { get; set; }

        public class ExternalData
        {
            [JsonProperty("product_name")]
            public string ProductName { get; set; }

            [JsonProperty("otp")]
            public int Otp { get; set; }

            [JsonProperty("expiry_time")]
            public string ExpiryTime { get; set; }
        }


    }

}
