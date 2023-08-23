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
        public async Task ShouldSendNumberMessageAsync()
        {


            // given
            var request = new NumberMessage
            {
                Request = new NumberMessageRequest
                {
                    ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                    Sms = "Text of a message that would be sent to the destination phone number",
                    To = "+2347064415311"
                }
            };

            // when
            NumberMessage retrievedTermiiModel =
              await this.termiiClient.Switch.SendNumberMessageAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
