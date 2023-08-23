using FluentAssertions;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;
using Termii.Core.Models.Services.Foundations.Termii.Insights;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Termii.Core.Tests.Acceptance.Clients.Insights
{
    public partial class InsightsClientTests
    {
        [Fact]
        public async Task ShouldRetrievePhoneNumberStatusAsync()
        {
            // given
            Status randomStatus = CreateRandomStatusResponseResult();
            Status inputStatus = randomStatus;

            ExternalStatusRequest statusRequest =
                ConvertToInsightsRequest(inputStatus);

            ExternalStatusResponse randomExternalStatusResponse =
                CreateExternalStatusResponseResult();

            ExternalStatusResponse retrievedStatusResult =
                randomExternalStatusResponse;

            Status expectedStatusResponse =
                ConvertToInsightsResponse(inputStatus, retrievedStatusResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/api/insight/number/query")
                    .WithParam("api_key", statusRequest.ApiKey)
                    .WithParam("phone_number", statusRequest.PhoneNumber)
                    .WithParam("country_code", statusRequest.CountryCode))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedStatusResult));

            // when
            Status actualResult =
                await this.termiiClient.Insights.PhoneNumberStatusAsync(inputStatus);

            // then
            actualResult.Should().BeEquivalentTo(expectedStatusResponse);
        }
    }
}
