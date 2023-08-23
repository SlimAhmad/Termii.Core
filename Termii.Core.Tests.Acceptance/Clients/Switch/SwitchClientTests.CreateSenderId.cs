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
        public async Task ShouldCreateSenderIdAsync()
        {
            // given
            CreateSenderId randomCreateSenderId = CreateRandomSenderIdResponseResult();
            CreateSenderId inputCreateSenderId = randomCreateSenderId;

            ExternalCreateSenderIdRequest CreateSenderIdRequest =
                ConvertToSwitchRequest(inputCreateSenderId);

            ExternalCreateSenderIdResponse CreateSenderIdResponse =
                            CreateExternalCreateSenderIdResponseResult();

            CreateSenderId expectedCreateSenderId = inputCreateSenderId.DeepClone();
            expectedCreateSenderId = ConvertToSwitchResponse(inputCreateSenderId, CreateSenderIdResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/sender-id/request")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        CreateSenderIdRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(CreateSenderIdResponse));

            // when
            CreateSenderId actualResult =
                await this.termiiClient.Switch.CreateSenderIdAsync(inputCreateSenderId);

            // then
            actualResult.Should().BeEquivalentTo(expectedCreateSenderId);

        }
    }
}
