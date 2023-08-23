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
        public async Task ShouldAddContactToPhoneBookAsync()
        {
            // given
            AddContactToPhoneBook randomAddContactToPhoneBook = CreateRandomAddContactToPhoneBookResponseResult();
            AddContactToPhoneBook inputAddContactToPhoneBook = randomAddContactToPhoneBook;

            ExternalAddContactToPhoneBookRequest AddContactToPhoneBookRequest =
                ConvertToSwitchRequest(inputAddContactToPhoneBook);

            ExternalAddContactToPhoneBookResponse AddContactToPhoneBookResponse =
                            CreateExternalAddContactToPhoneBookResponseResult();

            var randomPhoneBookId = GetRandomString();

            AddContactToPhoneBook expectedAddContactToPhoneBook = inputAddContactToPhoneBook.DeepClone();
            expectedAddContactToPhoneBook = ConvertToSwitchResponse(inputAddContactToPhoneBook, AddContactToPhoneBookResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/phonebooks/{randomPhoneBookId}/contacts")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        AddContactToPhoneBookRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(AddContactToPhoneBookResponse));

            // when
            AddContactToPhoneBook actualResult =
                await this.termiiClient.Switch.SendContactToPhoneBookAsync(inputAddContactToPhoneBook, randomPhoneBookId);

            // then
            actualResult.Should().BeEquivalentTo(expectedAddContactToPhoneBook);
        }
    }
}
