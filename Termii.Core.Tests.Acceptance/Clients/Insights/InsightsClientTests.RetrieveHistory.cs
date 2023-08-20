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
        public async Task ShouldRetrieveHistoryAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomApiKey = randomString;
            string inputApiKey = randomApiKey;

            ExternalHistoryResponse randomExternalHistoryResponse =
                CreateExternalHistoryResponseResult();

            ExternalHistoryResponse retrievedHistoryResult =
                randomExternalHistoryResponse;

            History expectedHistoryResponse =
                ConvertToInsightsResponse(retrievedHistoryResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/api/sms/inbox")
                    .WithParam("api_key", inputApiKey))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedHistoryResult));

            // when
            History actualResult =
                await this.termiiClient.Insights.RetrieveHistoryAsync(inputApiKey);

            // then
            actualResult.Should().BeEquivalentTo(expectedHistoryResponse);
        }
    }
}
