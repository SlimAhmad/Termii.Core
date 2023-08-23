using FluentAssertions;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;
using Termii.Core.Models.Services.Foundations.Termii.Switch;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Termii.Core.Tests.Acceptance.Clients.Switch
{
    public partial class SwitchClientTests
    {
        [Fact]
        public async Task ShouldRetrieveCampaignsAsync()
        {
            // given
            var apiKey = GetRandomString();

            ExternalFetchCampaignsResponse randomExternalFetchCampaignsResponse =
                CreateExternalFetchCampaignsResponseResult();

            ExternalFetchCampaignsResponse retrievedFetchCampaignsResult =
                randomExternalFetchCampaignsResponse;

            FetchCampaigns expectedFetchCampaignsResponse =
                ConvertToSwitchResponse(retrievedFetchCampaignsResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/api/sms/campaigns")
                    .WithParam("api_key", apiKey))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedFetchCampaignsResult));

            // when
            FetchCampaigns actualResult =
                await this.termiiClient.Switch.RetrieveCampaignsAsync(apiKey);

            // then
            actualResult.Should().BeEquivalentTo(expectedFetchCampaignsResponse);
        }
    }
}
