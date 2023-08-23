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
        public async Task ShouldSendMessageAsync()
        {
            // given
            SendMessage randomSendMessage = CreateRandomSendMessageResponseResult();
            SendMessage inputSendMessage = randomSendMessage;

            ExternalSendMessageRequest SendMessageRequest =
                ConvertToSwitchRequest(inputSendMessage);

            ExternalSendMessageResponse SendMessageResponse =
                            CreateExternalSendMessageResponseResult();

            SendMessage expectedSendMessage = inputSendMessage.DeepClone();
            expectedSendMessage = ConvertToSwitchResponse(inputSendMessage, SendMessageResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/sms/send")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        SendMessageRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(SendMessageResponse));

            // when
            SendMessage actualResult =
                await this.termiiClient.Switch.SendMessageAsync(inputSendMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedSendMessage);

        }
    }
}
