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
        public async Task ShouldPostVerifyTokenAsync()
        {
            // given
            var request = new VerifyToken
            {
                Request = new VerifyTokenRequest
                {
                    ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                    Pin = "248140",
                    PinId = "a621ea48-8d32-49c4-af40-92e215e68064",
                  
                }
            };

            // when
            VerifyToken retrievedTermiiModel =
              await this.termiiClient.Tokens.SendVerifyTokenAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
