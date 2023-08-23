using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Switch;

namespace Termii.Core.Tests.Integration.API.Switch
{
    public partial class SwitchApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldSendMessageAsync()
        {


            // given
            var request = new SendMessage
            {
                Request = new SendMessageRequest
                {
                    ApiKey = "TLvP5oclsN6KPnJ8VPKXYtH7qCUSTrHkADiX1xs6G29yExzw2sNTvxWPTz10Qv",
                    Channel = "generic",
                    From = "E-Wallet",
                    Sms = "generic",
                    To = "+2347064415311",
                    Type = "plain",
                    Media = new SendMessageRequest.MessageMedia
                    {
                       Caption = null,
                       Url = null
                    }
                    
                }
            };

            // when
            SendMessage retrievedTermiiModel =
              await this.termiiClient.Switch.SendMessageAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
