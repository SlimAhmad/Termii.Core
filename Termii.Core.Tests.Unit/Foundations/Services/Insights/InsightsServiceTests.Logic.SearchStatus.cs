using FluentAssertions;
using Force.DeepCloner;
using Moq;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Insights;

namespace Termii.Core.Tests.Unit.Foundations.Services.Insights
{
    public partial class InsightsServiceTests
    {
        [Fact]
        public async Task ShouldPostSearchWithSearchRequestAsync()
        {
            // given 



            dynamic createRandomSearchRequestProperties =
              CreateRandomSearchRequestProperties();

            dynamic createRandomSearchResponseProperties =
                CreateRandomSearchResponseProperties();


            var randomExternalSearchRequest = new ExternalSearchRequest
            {
                ApiKey = createRandomSearchRequestProperties.ApiKey,
                PhoneNumber = createRandomSearchRequestProperties.PhoneNumber,

            };

            var randomExternalSearchResponse = new ExternalSearchResponse
            {

                Network = createRandomSearchResponseProperties.Network,
                NetworkCode = createRandomSearchResponseProperties.NetworkCode,
                Number = createRandomSearchResponseProperties.Number,
                Status = createRandomSearchResponseProperties.Status,
            };


            var randomSearchRequest = new SearchRequest
            {
                ApiKey = createRandomSearchRequestProperties.ApiKey,
                PhoneNumber = createRandomSearchRequestProperties.PhoneNumber,

            };

            var randomSearchResponse = new SearchResponse
            {
                Network = createRandomSearchResponseProperties.Network,
                NetworkCode = createRandomSearchResponseProperties.NetworkCode,
                Number = createRandomSearchResponseProperties.Number,
                Status = createRandomSearchResponseProperties.Status,

            };


            var randomSearch = new Search
            {
                Request = randomSearchRequest,
            };

            Search inputSearch = randomSearch;
            Search expectedSearch = inputSearch.DeepClone();
            expectedSearch.Response = randomSearchResponse;

            ExternalSearchRequest mappedExternalSearchRequest =
               randomExternalSearchRequest;

            ExternalSearchResponse returnedExternalSearchResponse =
                randomExternalSearchResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.GetSearchPhoneNumberStatusAsync(It.Is(
                      SameExternalSearchRequestAs(mappedExternalSearchRequest))))
                     .ReturnsAsync(returnedExternalSearchResponse);

            // when
            Search actualCreateSearch =
               await this.insightsService.GetSearchPhoneNumberStatusAsync(inputSearch);

            // then
            actualCreateSearch.Should().BeEquivalentTo(expectedSearch);

            this.termiiBrokerMock.Verify(broker =>
               broker.GetSearchPhoneNumberStatusAsync(It.Is(
                   SameExternalSearchRequestAs(mappedExternalSearchRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
