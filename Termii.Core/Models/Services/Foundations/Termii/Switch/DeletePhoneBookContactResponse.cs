using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termii.Core.Models.Services.Foundations.Termii.Switch
{
    public class DeletePhoneBookContactResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
