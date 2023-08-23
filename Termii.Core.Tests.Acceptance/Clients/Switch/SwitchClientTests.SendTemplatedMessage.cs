using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;
using Termii.Core.Models.Services.Foundations.Termii.Switch;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Termii.Core.Tests.Acceptance.Clients.Switch
{
    public partial class SwitchClientTests
    {
        [Fact]
        public async Task ShouldSendTemplatedMessageAsync()
        {
            // given
            TemplatedMessage randomTemplatedMessage = CreateRandomTemplatedMessageResponseResult();
            TemplatedMessage inputTemplatedMessage = randomTemplatedMessage;

            ExternalTemplatedMessageRequest TemplatedMessageRequest =
                ConvertToSwitchRequest(inputTemplatedMessage);

            ExternalTemplatedMessageResponse TemplatedMessageResponse =
                            CreateExternalTemplatedMessageResponseResult();

            TemplatedMessage expectedTemplatedMessage = inputTemplatedMessage.DeepClone();
            expectedTemplatedMessage = ConvertToSwitchResponse(inputTemplatedMessage, TemplatedMessageResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/send/template")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        TemplatedMessageRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(TemplatedMessageResponse));

            // when
            TemplatedMessage actualResult =
                await this.termiiClient.Switch.SendTemplatedMessageAsync(inputTemplatedMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedTemplatedMessage);

        }
    }
}
