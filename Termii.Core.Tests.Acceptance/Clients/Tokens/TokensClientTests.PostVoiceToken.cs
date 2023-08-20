using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Termii.Core.Tests.Acceptance.Clients.Tokens
{
    public partial class TokensClientTests
    {
        [Fact]
        public async Task ShouldPostVoiceTokenAsync()
        {
            // given
            VoiceToken randomVoiceToken = CreateVoiceTokenResponseResult();
            VoiceToken inputVoiceToken = randomVoiceToken;

            ExternalVoiceTokenRequest VoiceTokenRequest =
                ConvertToTokensRequest(inputVoiceToken);

            ExternalVoiceTokenResponse VoiceTokenResponse =
                            CreateExternalVoiceTokenResponseResult();

            VoiceToken expectedVoiceToken = inputVoiceToken.DeepClone();
            expectedVoiceToken = ConvertToTokensResponse(inputVoiceToken, VoiceTokenResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/sms/otp/send/voice")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        VoiceTokenRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(VoiceTokenResponse));

            // when
            VoiceToken actualResult =
                await this.termiiClient.Tokens.SendVoiceTokenAsync(inputVoiceToken);

            // then
            actualResult.Should().BeEquivalentTo(expectedVoiceToken);

        }
    }
}
