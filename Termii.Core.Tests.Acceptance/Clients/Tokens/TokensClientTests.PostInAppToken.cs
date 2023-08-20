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
        public async Task ShouldPostInAppTokenAsync()
        {
            // given
            InAppToken randomInAppToken = CreateRandomInAppTokenResponseResult();
            InAppToken inputInAppToken = randomInAppToken;

            ExternalInAppTokenRequest InAppTokenRequest =
                ConvertToTokensRequest(inputInAppToken);

            ExternalInAppTokenResponse InAppTokenResponse =
                            CreateExternalInAppTokenResponseResult();

            InAppToken expectedInAppToken = inputInAppToken.DeepClone();
            expectedInAppToken = ConvertToTokensResponse(inputInAppToken, InAppTokenResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/sms/otp/generate")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        InAppTokenRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(InAppTokenResponse));

            // when
            InAppToken actualResult =
                await this.termiiClient.Tokens.SendInAppAsync(inputInAppToken);

            // then
            actualResult.Should().BeEquivalentTo(expectedInAppToken);

        }
    }
}
