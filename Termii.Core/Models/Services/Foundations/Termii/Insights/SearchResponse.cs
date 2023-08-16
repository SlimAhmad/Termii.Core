using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Insights
{
    public class SearchResponse
    {
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("network_code")]
        public string NetworkCode { get; set; }
    }
}
