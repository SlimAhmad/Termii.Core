using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch
{
    internal class ExternalDeletePhoneBookContactResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
