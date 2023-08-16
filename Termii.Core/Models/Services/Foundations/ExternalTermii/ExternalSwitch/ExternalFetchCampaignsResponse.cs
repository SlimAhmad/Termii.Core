using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch
{
    internal class ExternalFetchCampaignsResponse
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("links")]
        public ExternalCampaignsLinks Links { get; set; }

        [JsonProperty("meta")]
        public ExternalCampaignsMeta CampaignsMeta { get; set; }
        public class Datum
        {
            [JsonProperty("campaign_id")]
            public string CampaignId { get; set; }

            [JsonProperty("phone_book")]
            public string PhoneBook { get; set; }

            [JsonProperty("sender")]
            public string Sender { get; set; }

            [JsonProperty("camp_type")]
            public string CampType { get; set; }

            [JsonProperty("channel")]
            public string Channel { get; set; }

            [JsonProperty("total_recipients")]
            public int TotalRecipients { get; set; }

            [JsonProperty("run_at")]
            public string RunAt { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }

        public class ExternalCampaignsLinks
        {
            [JsonProperty("first")]
            public string First { get; set; }

            [JsonProperty("last")]
            public string Last { get; set; }

            [JsonProperty("prev")]
            public object Prev { get; set; }

            [JsonProperty("next")]
            public object Next { get; set; }
        }

        public class ExternalCampaignsMeta
        {
            [JsonProperty("current_page")]
            public int CurrentPage { get; set; }

            [JsonProperty("from")]
            public int From { get; set; }

            [JsonProperty("last_page")]
            public int LastPage { get; set; }

            [JsonProperty("path")]
            public string Path { get; set; }

            [JsonProperty("per_page")]
            public int PerPage { get; set; }

            [JsonProperty("to")]
            public int To { get; set; }

            [JsonProperty("total")]
            public int Total { get; set; }
        }





    }
}
