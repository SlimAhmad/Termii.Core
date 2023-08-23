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
        public async Task ShouldSendBulkMessageAsync()
        {

            // given
            SendBulkMessage randomSendBulkMessage = CreateRandomSendBulkMessageResponseResult();
            SendBulkMessage inputSendBulkMessage = randomSendBulkMessage;

            ExternalSendBulkMessageRequest SendBulkMessageRequest =
                ConvertToSwitchRequest(inputSendBulkMessage);

            ExternalSendBulkMessageResponse SendBulkMessageResponse =
                            CreateExternalSendBulkMessageResponseResult();

            SendBulkMessage expectedSendBulkMessage = inputSendBulkMessage.DeepClone();
            expectedSendBulkMessage = ConvertToSwitchResponse(inputSendBulkMessage, SendBulkMessageResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/sms/send/bulk")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        SendBulkMessageRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(SendBulkMessageResponse));

            // when
            SendBulkMessage actualResult =
                await this.termiiClient.Switch.SendBulkMessagesAsync(inputSendBulkMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedSendBulkMessage);
        }
    }
}
