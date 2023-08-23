using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Insights;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;

namespace Termii.Core.Tests.Integration.API.Tokens
{
    public partial class TokensApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldPostEmailTokenAsync()
        {
            // given
            var request = new EmailToken
            {
                Request = new EmailTokenRequest
                {
                    ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                    Code = "12345",
                    EmailAddress = "slimahmad6@gmail.com",
                    EmailConfigurationId = "11147dee-8878-46bd-8cc6-b2d2d6e0d4fd"
                }
            };

            // when
            EmailToken retrievedTermiiModel =
              await this.termiiClient.Tokens.SendEmailTokenAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
