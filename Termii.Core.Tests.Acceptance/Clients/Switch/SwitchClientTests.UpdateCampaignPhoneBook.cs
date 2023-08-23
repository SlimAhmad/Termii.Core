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
        public async Task ShouldRetrieveUpdateCampaignPhoneBookAsync()
        {
            // given
            UpdateCampaignPhoneBook randomUpdateCampaignPhoneBook = CreateRandomUpdateCampaignPhoneBookResponseResult();
            UpdateCampaignPhoneBook inputUpdateCampaignPhoneBook = randomUpdateCampaignPhoneBook;

            ExternalUpdateCampaignPhoneBookRequest UpdateCampaignPhoneBookRequest =
                ConvertToSwitchRequest(inputUpdateCampaignPhoneBook);

            ExternalUpdateCampaignPhoneBookResponse UpdateCampaignPhoneBookResponse =
                            CreateExternalUpdateCampaignPhoneBookResponseResult();

            var randomPhoneBookId = GetRandomString();

            UpdateCampaignPhoneBook expectedUpdateCampaignPhoneBook = inputUpdateCampaignPhoneBook.DeepClone();
            expectedUpdateCampaignPhoneBook = ConvertToSwitchResponse(inputUpdateCampaignPhoneBook, UpdateCampaignPhoneBookResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPut()
                    .WithPath($"/api/phonebooks/{randomPhoneBookId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        UpdateCampaignPhoneBookRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(UpdateCampaignPhoneBookResponse));

            // when
            UpdateCampaignPhoneBook actualResult =
                await this.termiiClient.Switch.UpdatePhoneBookAsync(randomPhoneBookId, inputUpdateCampaignPhoneBook);

            // then
            actualResult.Should().BeEquivalentTo(expectedUpdateCampaignPhoneBook);
        }
    }
}
