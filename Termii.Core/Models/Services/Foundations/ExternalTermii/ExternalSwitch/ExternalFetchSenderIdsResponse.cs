using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch
{
    internal class ExternalFetchSenderIdsResponse
    {


        [JsonProperty("current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("first_page_url")]
        public string FirstPageUrl { get; set; }

        [JsonProperty("from")]
        public int From { get; set; }

        [JsonProperty("last_page")]
        public int LastPage { get; set; }

        [JsonProperty("last_page_url")]
        public string LastPageUrl { get; set; }

        [JsonProperty("next_page_url")]
        public string NextPageUrl { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("prev_page_url")]
        public object PrevPageUrl { get; set; }

        [JsonProperty("to")]
        public int To { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        public class Datum
        {
            [JsonProperty("sender_id")]
            public string SenderId { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("company")]
            public string Company { get; set; }

            [JsonProperty("usecase")]
            public object Usecase { get; set; }

            [JsonProperty("country")]
            public object Country { get; set; }

            [JsonProperty("created_at")]
            public string CreatedAt { get; set; }
        }






    }
}
