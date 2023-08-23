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
        public async Task ShouldPostVoiceCallAsync()
        {
            // given
            var request = new VoiceCall
            {
                Request = new VoiceCallRequest
                {
                    ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                    Code = 3344,
                    PhoneNumber = "07064415311",
            
                }
            };

            // when
            VoiceCall retrievedTermiiModel =
              await this.termiiClient.Tokens.SendVoiceCallAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
