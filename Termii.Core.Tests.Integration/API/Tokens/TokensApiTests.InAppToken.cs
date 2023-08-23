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
        public async Task ShouldPostInAppTokenAsync()
        {
            // given
            var request = new InAppToken
            {
                Request = new InAppTokenRequest
                {
                    ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                    PhoneNumber = "07064415311",
                    PinAttempts = 2,
                    PinLength = 4,
                    PinTimeToLive = 1,
                    PinType = "NUMERIC"
                }
            };

            // when
            InAppToken retrievedTermiiModel =
              await this.termiiClient.Tokens.SendInAppTokenAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
