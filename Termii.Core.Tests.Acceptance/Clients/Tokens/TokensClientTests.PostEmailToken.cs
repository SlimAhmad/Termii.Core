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
        public async Task ShouldPostEmailTokenAsync()
        {
            // given
            EmailToken randomEmailToken = CreateEmailTokenResponseResult();
            EmailToken inputEmailToken = randomEmailToken;

            ExternalEmailTokenRequest EmailTokenRequest =
                ConvertToTokensRequest(inputEmailToken);

            ExternalEmailTokenResponse EmailTokenResponse =
                            CreateExternalEmailTokenResponseResult();

            EmailToken expectedEmailToken = inputEmailToken.DeepClone();
            expectedEmailToken = ConvertToTokensResponse(inputEmailToken, EmailTokenResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/email/otp/send")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        EmailTokenRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(EmailTokenResponse));

            // when
            EmailToken actualResult =
                await this.termiiClient.Tokens.SendEmailTokenAsync(inputEmailToken);

            // then
            actualResult.Should().BeEquivalentTo(expectedEmailToken);

        }
    }
}
