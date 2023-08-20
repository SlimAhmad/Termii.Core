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
        public async Task ShouldPostVerifyTokenAsync()
        {
            // given
            VerifyToken randomVerifyToken = CreateRandomVerifyTokenResponseResult();
            VerifyToken inputVerifyToken = randomVerifyToken;

            ExternalVerifyTokenRequest VerifyTokenRequest =
                ConvertToTokensRequest(inputVerifyToken);

            ExternalVerifyTokenResponse VerifyTokenResponse =
                            CreateExternalVerifyTokenResponseResult();

            VerifyToken expectedVerifyToken = inputVerifyToken.DeepClone();
            expectedVerifyToken = ConvertToTokensResponse(inputVerifyToken, VerifyTokenResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/sms/otp/verify")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        VerifyTokenRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(VerifyTokenResponse));

            // when
            VerifyToken actualResult =
                await this.termiiClient.Tokens.SendVerifyTokenAsync(inputVerifyToken);

            // then
            actualResult.Should().BeEquivalentTo(expectedVerifyToken);

        }
    }
}
