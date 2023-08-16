﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens
{
    internal class ExternalVoiceCallRequest
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
