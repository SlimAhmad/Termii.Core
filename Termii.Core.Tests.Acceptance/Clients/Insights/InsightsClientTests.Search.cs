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
        public async Task ShouldSearchPhoneNumberStatusAsync()
        {
            // given
            Search randomSearch = CreateSearchResponseResult();
            Search inputSearch = randomSearch;

            ExternalSearchRequest searchRequest =
                ConvertToInsightsRequest(inputSearch);

            ExternalSearchResponse randomExternalSearchResponse =
                CreateExternalSearchResponseResult();

            ExternalSearchResponse retrievedSearchResult =
                randomExternalSearchResponse;

            Search expectedSearchResponse =
                ConvertToInsightsResponse(inputSearch,retrievedSearchResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/api/check/dnd")
                    .WithParam("api_key", searchRequest.ApiKey)
                    .WithParam("phone_number",searchRequest.PhoneNumber))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedSearchResult));

            // when
            Search actualResult =
                await this.termiiClient.Insights.RetrieveSearchPhoneNumberStatusAsync(inputSearch);

            // then
            actualResult.Should().BeEquivalentTo(expectedSearchResponse);
        }
    }
}
