using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Switch
{
    public class UpdateCampaignPhoneBookRequest
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("phonebook_name")]
        public string PhonebookName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
