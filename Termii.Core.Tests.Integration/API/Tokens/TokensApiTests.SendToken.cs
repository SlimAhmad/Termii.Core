using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;

namespace Termii.Core.Tests.Integration.API.Tokens
{
    public partial class TokensApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldPostSendTokenAsync()
        {
            // given
            var request = new SendToken
            {
                Request = new SendTokenRequest
                {
                    ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                    PinType = "NUMERIC",
                    PinTimeToLive = 5,
                    PinLength = 6,
                    PinAttempts = 10,
                    Channel = "generic",
                    From = "E-Wallet",
                    MessageText = "Your pin is < 1234 >",
                    MessageType = "NUMERIC",
                    PinPlaceholder = "< 1234 >",
                    To = "+2347064415311"
                }
            };

            // when
            SendToken retrievedTermiiModel =
              await this.termiiClient.Tokens.SendTokenAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
