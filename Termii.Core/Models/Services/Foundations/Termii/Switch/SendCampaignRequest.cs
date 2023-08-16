using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Switch
{
    public class SendCampaignRequest
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("sender_id")]
        public string SenderId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("message_type")]
        public string MessageType { get; set; }

        [JsonProperty("phonebook_id")]
        public string PhonebookId { get; set; }

        [JsonProperty("delimiter")]
        public string Delimiter { get; set; }

        [JsonProperty("remove_duplicate")]
        public string RemoveDuplicate { get; set; }

        [JsonProperty("campaign_type")]
        public string CampaignType { get; set; }

        [JsonProperty("schedule_time")]
        public string ScheduleTime { get; set; }

        [JsonProperty("schedule_sms_status")]
        public string ScheduleSmsStatus { get; set; }
    }
}
