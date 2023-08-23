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
        public async Task ShouldRetrieveContactsByPhoneBookIdAsync()
        {
            // given
            var apiKey = GetRandomString();

            var contactId = GetRandomString();

            ExternalFetchContactsByPhoneBookResponse randomExternalFetchContactsByPhoneBookResponse =
                CreateExternalFetchContactsByPhoneBookIdResponseResult();

            ExternalFetchContactsByPhoneBookResponse retrievedFetchContactsByPhoneBookResult =
                randomExternalFetchContactsByPhoneBookResponse;

            FetchContactsByPhoneBookId expectedFetchContactsByPhoneBookResponse =
                ConvertToSwitchResponse(retrievedFetchContactsByPhoneBookResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/api/phonebooks/{contactId}/contacts")
                    .WithParam("api_key", apiKey))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedFetchContactsByPhoneBookResult));

            // when
            FetchContactsByPhoneBookId actualResult =
                await this.termiiClient.Switch.RetrieveContactsByPhoneBookIdAsync(apiKey,contactId);

            // then
            actualResult.Should().BeEquivalentTo(expectedFetchContactsByPhoneBookResponse);
        }
    }
}
