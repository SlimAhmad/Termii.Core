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
        public async Task ShouldDeletePhoneBookAsync()
        {
            // given
            var apiKey = GetRandomString();

            var phoneBookId = GetRandomString();

            ExternalDeletePhoneBookResponse randomExternalDeletePhoneBookResponse =
                CreateExternalDeletePhoneBookResponseResult();

            ExternalDeletePhoneBookResponse retrievedDeletePhoneBookResult =
                randomExternalDeletePhoneBookResponse;

            DeletePhoneBook expectedDeletePhoneBookResponse =
                ConvertToSwitchResponse(retrievedDeletePhoneBookResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingDelete()
                    .WithPath($"/api/phonebooks/{phoneBookId}")
                    .WithParam("api_key", apiKey))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedDeletePhoneBookResult));

            // when
            DeletePhoneBook actualResult =
                await this.termiiClient.Switch.RemovePhoneBookAsync(apiKey, phoneBookId);

            // then
            actualResult.Should().BeEquivalentTo(expectedDeletePhoneBookResponse);
        }
    }
}
