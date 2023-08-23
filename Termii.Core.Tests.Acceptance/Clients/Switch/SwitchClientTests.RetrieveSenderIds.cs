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
        public async Task ShouldRetrieveSenderIdsAsync()
        {
            // given
            var apiKey = GetRandomString();

            ExternalFetchSenderIdsResponse randomExternalFetchSenderIdsResponse =
                CreateExternalFetchSenderIdsResponseResult();

            ExternalFetchSenderIdsResponse retrievedFetchSenderIdsResult =
                randomExternalFetchSenderIdsResponse;

            FetchSenderIds expectedFetchSenderIdsResponse =
                ConvertToSwitchResponse(retrievedFetchSenderIdsResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/api/sender-id")
                    .WithParam("api_key", apiKey))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedFetchSenderIdsResult));

            // when
            FetchSenderIds actualResult =
                await this.termiiClient.Switch.RetrieveSenderIdsAsync(apiKey);

            // then
            actualResult.Should().BeEquivalentTo(expectedFetchSenderIdsResponse);
        }
    }
}
