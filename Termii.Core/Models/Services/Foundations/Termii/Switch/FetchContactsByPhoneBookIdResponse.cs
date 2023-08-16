using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Switch
{
    public class FetchContactsByPhoneBookIdResponse
    {

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("links")]
        public ContactsLinks Links { get; set; }

        [JsonProperty("meta")]
        public ContactsMeta Meta { get; set; }
        public class Datum
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("pid")]
            public int Pid { get; set; }

            [JsonProperty("phone_number")]
            public string PhoneNumber { get; set; }

            [JsonProperty("email_address")]
            public object EmailAddress { get; set; }

            [JsonProperty("message")]
            public object Message { get; set; }

            [JsonProperty("company")]
            public object Company { get; set; }

            [JsonProperty("first_name")]
            public object FirstName { get; set; }

            [JsonProperty("last_name")]
            public object LastName { get; set; }

            [JsonProperty("create_at")]
            public string CreateAt { get; set; }

            [JsonProperty("updated_at")]
            public string UpdatedAt { get; set; }
        }

        public class ContactsLinks
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

        public class ContactsMeta
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
