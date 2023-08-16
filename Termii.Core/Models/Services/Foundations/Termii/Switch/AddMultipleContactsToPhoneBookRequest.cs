using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Switch
{
    public class AddMultipleContactsToPhoneBookRequest
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("contact_file")]
        public string ContactFile { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
    }
}
