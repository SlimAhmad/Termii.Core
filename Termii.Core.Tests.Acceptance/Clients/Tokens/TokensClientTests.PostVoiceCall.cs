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
        public async Task ShouldPostVoiceCallAsync()
        {
            // given
            VoiceCall randomVoiceCall = CreateVoiceCallResponseResult();
            VoiceCall inputVoiceCall = randomVoiceCall;

            ExternalVoiceCallRequest VoiceCallRequest =
                ConvertToTokensRequest(inputVoiceCall);

            ExternalVoiceCallResponse VoiceCallResponse =
                            CreateExternalVoiceCallResponseResult();

            VoiceCall expectedVoiceCall = inputVoiceCall.DeepClone();
            expectedVoiceCall = ConvertToTokensResponse(inputVoiceCall, VoiceCallResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/sms/otp/call")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        VoiceCallRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(VoiceCallResponse));

            // when
            VoiceCall actualResult =
                await this.termiiClient.Tokens.SendVoiceCallAsync(inputVoiceCall);

            // then
            actualResult.Should().BeEquivalentTo(expectedVoiceCall);

        }
    }
}
