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
        public async Task ShouldSendNumberMessageAsync()
        {

            // given
            NumberMessage randomNumberMessage = CreateRandomNumberMessageResponseResult();
            NumberMessage inputNumberMessage = randomNumberMessage;

            ExternalNumberMessageRequest NumberMessageRequest =
                ConvertToSwitchRequest(inputNumberMessage);

            ExternalNumberMessageResponse NumberMessageResponse =
                            CreateExternalNumberMessageResponseResult();

            NumberMessage expectedNumberMessage = inputNumberMessage.DeepClone();
            expectedNumberMessage = ConvertToSwitchResponse(inputNumberMessage, NumberMessageResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/sms/number/send")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        NumberMessageRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(NumberMessageResponse));

            // when
            NumberMessage actualResult =
                await this.termiiClient.Switch.SendNumberMessageAsync(inputNumberMessage);

            // then
            actualResult.Should().BeEquivalentTo(expectedNumberMessage);
        }
    }
}
