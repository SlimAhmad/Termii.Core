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
        public async Task ShouldSendCampaignAsync()
        {
           
                // given
                SendCampaign randomSendCampaign = CreateRandomSendCampaignResponseResult();
                SendCampaign inputSendCampaign = randomSendCampaign;

                ExternalSendCampaignRequest SendCampaignRequest =
                    ConvertToSwitchRequest(inputSendCampaign);

                ExternalSendCampaignResponse SendCampaignResponse =
                                CreateExternalSendCampaignResponseResult();

                SendCampaign expectedSendCampaign = inputSendCampaign.DeepClone();
                expectedSendCampaign = ConvertToSwitchResponse(inputSendCampaign, SendCampaignResponse);

                var jsonSerializationSettings = new JsonSerializerSettings();
                jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

                this.wireMockServer.Given(
                    Request.Create()
                    .UsingPost()
                        .WithPath($"/api/sms/campaigns/send")
                        .WithHeader("Authorization", $"Bearer {this.apiKey}")
                        .WithHeader("Content-Type", "application/json; charset=utf-8")
                        .WithBody(JsonConvert.SerializeObject(
                            SendCampaignRequest,
                            jsonSerializationSettings)))
                    .RespondWith(
                        Response.Create()
                        .WithBodyAsJson(SendCampaignResponse));

                // when
                SendCampaign actualResult =
                    await this.termiiClient.Switch.CreateCampaignAsync(inputSendCampaign);

                // then
                actualResult.Should().BeEquivalentTo(expectedSendCampaign);

            
        }
    }
}
