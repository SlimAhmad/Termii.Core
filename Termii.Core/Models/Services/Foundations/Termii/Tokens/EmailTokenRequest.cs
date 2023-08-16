using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Tokens
{
    public class EmailTokenRequest
    {
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("email_configuration_id")]
        public string EmailConfigurationId { get; set; }
    }
}
