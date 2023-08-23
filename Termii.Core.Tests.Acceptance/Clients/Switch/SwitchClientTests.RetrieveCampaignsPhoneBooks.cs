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
        public async Task ShouldRetrieveCampaignsPhoneBookAsync()
        {
            // given
            var apiKey = GetRandomString();

            ExternalCampaignPhoneBookResponse randomExternalCampaignPhoneBookResponse =
                CreateExternalCampaignPhoneBookResponseResult();

            ExternalCampaignPhoneBookResponse retrievedCampaignPhoneBookResult =
                randomExternalCampaignPhoneBookResponse;

            CampaignPhoneBook expectedCampaignPhoneBookResponse =
                ConvertToSwitchResponse(retrievedCampaignPhoneBookResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/api/phonebooks")
                    .WithParam("api_key", apiKey))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedCampaignPhoneBookResult));

            // when
            CampaignPhoneBook actualResult =
                await this.termiiClient.Switch.RetrievePhoneBooksAsync(apiKey);

            // then
            actualResult.Should().BeEquivalentTo(expectedCampaignPhoneBookResponse);
        }
    }
}
