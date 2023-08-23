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
        public async Task ShouldSendBulkMessageAsync()
        {


            // given
            var request = new SendBulkMessage
            {
                Request = new SendBulkMessageRequest
                {
                    ApiKey = "TLvP5oclsN6KPnJ8VPKXYtH7qCUSTrHkADiX1xs6G29yExzw2sNTvxWPTz10Qv",
                    Channel = "generic",
                    From = "E-Wallet",
                    Sms = "generic",
                    To = new List<string>()
                   {
                      "+2347064415311",
                      "+2348058382350"
                   },
                    Type = "plain"
                }
            };
          
            // when
            SendBulkMessage retrievedTermiiModel =
              await this.termiiClient.Switch.SendBulkMessagesAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
