using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Switch
{
    public class AddContactToPhoneBookResponse
    {
        [JsonProperty("data")]
        public ExternalContactData Data { get; set; }
        public class ExternalContactData
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("phone_number")]
            public string PhoneNumber { get; set; }

            [JsonProperty("email_address")]
            public string EmailAddress { get; set; }

            [JsonProperty("message")]
            public object Message { get; set; }

            [JsonProperty("company")]
            public string Company { get; set; }

            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("create_at")]
            public string CreateAt { get; set; }

            [JsonProperty("updated_at")]
            public string UpdatedAt { get; set; }
        }
    }
}
