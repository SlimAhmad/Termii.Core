using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Insights
{
    public class BalanceResponse
    {
        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("balance")]
        public int Balance { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
