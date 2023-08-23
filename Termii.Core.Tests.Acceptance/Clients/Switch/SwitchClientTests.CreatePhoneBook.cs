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
        public async Task ShouldCreatePhoneBookAsync()
        {
            // given
            CreateCampaignPhoneBook randomCreateCampaignPhoneBook = CreateRandomCampaignPhoneBookResponseResult();
            CreateCampaignPhoneBook inputCreateCampaignPhoneBook = randomCreateCampaignPhoneBook;

            ExternalCreateCampaignPhoneBookRequest CreateCampaignPhoneBookRequest =
                ConvertToSwitchRequest(inputCreateCampaignPhoneBook);

            ExternalCreateCampaignPhoneBookResponse CreateCampaignPhoneBookResponse =
                            CreateExternalCreateCampaignPhoneBookResponseResult();

            CreateCampaignPhoneBook expectedCreateCampaignPhoneBook = inputCreateCampaignPhoneBook.DeepClone();
            expectedCreateCampaignPhoneBook = ConvertToSwitchResponse(inputCreateCampaignPhoneBook, CreateCampaignPhoneBookResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/api/phonebooks")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        CreateCampaignPhoneBookRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(CreateCampaignPhoneBookResponse));

            // when
            CreateCampaignPhoneBook actualResult =
                await this.termiiClient.Switch.CreatePhoneBookAsync(inputCreateCampaignPhoneBook);

            // then
            actualResult.Should().BeEquivalentTo(expectedCreateCampaignPhoneBook);
        }
    }
}
