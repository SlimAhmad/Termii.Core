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
        public async Task ShouldDeletePhoneBookContactContactAsync()
        {
            // given
            var apiKey = GetRandomString();

            var contactId = GetRandomString();

            ExternalDeletePhoneBookContactResponse randomExternalDeletePhoneBookContactResponse =
                CreateExternalDeletePhoneBookContactResponseResult();

            ExternalDeletePhoneBookContactResponse retrievedDeletePhoneBookContactResult =
                randomExternalDeletePhoneBookContactResponse;

            DeletePhoneBookContact expectedDeletePhoneBookContactResponse =
                ConvertToSwitchResponse(retrievedDeletePhoneBookContactResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingDelete()
                    .WithPath($"/api/phonebook/contact/{contactId}")
                    .WithParam("api_key", apiKey))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedDeletePhoneBookContactResult));

            // when
            DeletePhoneBookContact actualResult =
                await this.termiiClient.Switch.RemovePhoneBookContactAsync(apiKey, contactId);

            // then
            actualResult.Should().BeEquivalentTo(expectedDeletePhoneBookContactResponse);
        }
    }
}
