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
        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("receiver")]
        public string Receiver { get; set; }

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
        public string CreatedAt { get; set; }
    }
}
