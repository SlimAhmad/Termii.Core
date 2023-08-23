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
        public async Task ShouldPostVoiceTokenAsync()
        {
            // given
            var request = new VoiceToken
            {
                Request = new VoiceTokenRequest
                {
                    ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                    PhoneNumber = "07064415311",
                    PinAttempts = 2,
                    PinLength = 6,
                    PinTimeToLive = 4
                }
            };

            // when
            VoiceToken retrievedTermiiModel =
              await this.termiiClient.Tokens.SendVoiceTokenAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
