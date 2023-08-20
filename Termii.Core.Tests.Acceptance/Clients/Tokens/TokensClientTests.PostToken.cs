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
        public async Task ShouldPostTokenAsync()
        {
            // given
            SendToken randomSendToken = CreateSendTokenResponseResult();
            SendToken inputSendToken = randomSendToken;

            ExternalSendTokenRequest SendTokenRequest =
                ConvertToTokensRequest(inputSendToken);

            ExternalSendTokenResponse SendTokenResponse =
                            CreateExternalSendTokenResponseResult();

            SendToken expectedSendToken = inputSendToken.DeepClone();
            expectedSendToken = ConvertToTokensResponse(inputSendToken, SendTokenResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/sms/otp/send")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        SendTokenRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(SendTokenResponse));

            // when
            SendToken actualResult =
                await this.termiiClient.Tokens.SendTokenAsync(inputSendToken);

            // then
            actualResult.Should().BeEquivalentTo(expectedSendToken);

        }
    }
}
