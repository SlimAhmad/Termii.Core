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
        public async Task ShouldRetrieveCampaignHistoryAsync()
        {
            // given
            var apiKey = GetRandomString();
            var campaignId = GetRandomString();

            ExternalFetchCampaignsHistoryResponse randomExternalFetchCampaignsHistoryResponse =
                CreateExternalFetchCampaignsHistoryResponseResult();

            ExternalFetchCampaignsHistoryResponse retrievedFetchCampaignsHistoryResult =
                randomExternalFetchCampaignsHistoryResponse;

            FetchCampaignsHistory expectedFetchCampaignsHistoryResponse =
                ConvertToSwitchResponse(retrievedFetchCampaignsHistoryResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/api/sms/campaigns/{campaignId}")
                    .WithParam("api_key", apiKey))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedFetchCampaignsHistoryResult));

            // when
            FetchCampaignsHistory actualResult =
                await this.termiiClient.Switch.RetrieveCampaignsHistoryAsync(apiKey, campaignId);

            // then
            actualResult.Should().BeEquivalentTo(expectedFetchCampaignsHistoryResponse);
        }
    }
}
