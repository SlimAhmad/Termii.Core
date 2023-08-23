using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Insights
{
    public class HistoryResponse
    {

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("links")]
        public HistoryLinks Links { get; set; }

        [JsonProperty("meta")]
        public HistoryMeta Meta { get; set; }

        public class Datum
        {
            [JsonProperty("sender")]
            public string Sender { get; set; }

            [JsonProperty("receiver")]
            public string Receiver { get; set; }

            [JsonProperty("country_code")]
            public string CountryCode { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("reroute")]
            public int Reroute { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("sms_type")]
            public string SmsType { get; set; }

            [JsonProperty("send_by")]
            public string SendBy { get; set; }

            [JsonProperty("media_url")]
            public object MediaUrl { get; set; }

            [JsonProperty("message_id")]
            public string MessageId { get; set; }

            [JsonProperty("notify_url")]
            public object NotifyUrl { get; set; }

            [JsonProperty("notify_id")]
            public object NotifyId { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("sent_at")]
            public DateTime SentAt { get; set; }
        }

        public class HistoryLinks
        {
            [JsonProperty("first")]
            public string First { get; set; }

            [JsonProperty("last")]
            public string Last { get; set; }

            [JsonProperty("prev")]
            public object Prev { get; set; }

            [JsonProperty("next")]
            public string Next { get; set; }
        }

        public class HistoryMeta
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
