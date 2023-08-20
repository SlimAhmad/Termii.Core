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
        public async Task ShouldRetrieveBalanceAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomApiKey = randomString;
            string inputApiKey = randomApiKey;

            ExternalBalanceResponse randomExternalBalanceResponse =
                CreateExternalBalanceResponseResult();

            ExternalBalanceResponse retrievedBalanceResult =
                randomExternalBalanceResponse;

            Balance expectedBalanceResponse =
                ConvertToInsightsResponse(retrievedBalanceResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/api/get-balance")
                    .WithParam("api_key", inputApiKey))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBalanceResult));

            // when
            Balance actualResult =
                await this.termiiClient.Insights.RetrieveBalanceAsync(inputApiKey);

            // then
            actualResult.Should().BeEquivalentTo(expectedBalanceResponse);
        } 
    }
}
