using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Switch
{
    public class CampaignPhoneBookResponse
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("links")]
        public PhoneBookLinks Links { get; set; }

        [JsonProperty("meta")]
        public PhoneBookMeta Meta { get; set; }
        public class Datum
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("total_number_of_contacts")]
            public int TotalNumberOfContacts { get; set; }

            [JsonProperty("date_created")]
            public string DateCreated { get; set; }

            [JsonProperty("last_updated")]
            public string LastUpdated { get; set; }
        }

        public class PhoneBookLinks
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

        public class PhoneBookMeta
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
