using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights
{
    internal class ExternalStatusResponse
    {
        [JsonProperty("result")]
        public List<StatusResult> Result { get; set; }

        public class CountryDetail
        {
            [JsonProperty("countryCode")]
            public string CountryCode { get; set; }

            [JsonProperty("mobileCountryCode")]
            public string MobileCountryCode { get; set; }

            [JsonProperty("iso")]
            public string Iso { get; set; }
        }

        public class OperatorDetail
        {
            [JsonProperty("operatorCode")]
            public string OperatorCode { get; set; }

            [JsonProperty("operatorName")]
            public string OperatorName { get; set; }

            [JsonProperty("mobileNumberCode")]
            public string MobileNumberCode { get; set; }

            [JsonProperty("mobileRoutingCode")]
            public string MobileRoutingCode { get; set; }

            [JsonProperty("carrierIdentificationCode")]
            public string CarrierIdentificationCode { get; set; }

            [JsonProperty("lineType")]
            public string LineType { get; set; }
        }

        public class StatusResult
        {
            [JsonProperty("routeDetail")]
            public RouteDetail RouteDetail { get; set; }

            [JsonProperty("countryDetail")]
            public CountryDetail CountryDetail { get; set; }

            [JsonProperty("operatorDetail")]
            public OperatorDetail OperatorDetail { get; set; }

            [JsonProperty("status")]
            public int Status { get; set; }
        }





        public class RouteDetail
        {
            [JsonProperty("number")]
            public string Number { get; set; }

            [JsonProperty("ported")]
            public int Ported { get; set; }
        }
    }
}
