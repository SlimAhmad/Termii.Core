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
        public async Task ShouldAddMultipleContactsToPhoneBookAsync()
        {
            // given
            AddMultipleContactsToPhoneBook randomAddMultipleContactsToPhoneBook = CreateRandomAddMultipleContactsToPhoneBookResponseResult();
            AddMultipleContactsToPhoneBook inputAddMultipleContactsToPhoneBook = randomAddMultipleContactsToPhoneBook;

            ExternalAddMultipleContactsToPhoneBookRequest AddMultipleContactsToPhoneBookRequest =
                ConvertToSwitchRequest(inputAddMultipleContactsToPhoneBook);

            ExternalAddMultipleContactsToPhoneBookResponse AddMultipleContactsToPhoneBookResponse =
                            CreateExternalAddMultipleContactsToPhoneBookResponseResult();

            var randomPhoneBookId = GetRandomString();

            AddMultipleContactsToPhoneBook expectedAddMultipleContactsToPhoneBook = inputAddMultipleContactsToPhoneBook.DeepClone();
            expectedAddMultipleContactsToPhoneBook = ConvertToSwitchResponse(inputAddMultipleContactsToPhoneBook, AddMultipleContactsToPhoneBookResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/phonebooks/{randomPhoneBookId}/contacts")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        AddMultipleContactsToPhoneBookRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(AddMultipleContactsToPhoneBookResponse));

            // when
            AddMultipleContactsToPhoneBook actualResult =
                await this.termiiClient.Switch.SendContactsToPhoneBookAsync(inputAddMultipleContactsToPhoneBook, randomPhoneBookId);

            // then
            actualResult.Should().BeEquivalentTo(expectedAddMultipleContactsToPhoneBook);
        }
    }
}
