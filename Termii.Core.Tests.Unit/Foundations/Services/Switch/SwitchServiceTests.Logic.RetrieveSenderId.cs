using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;
using Termii.Core.Models.Services.Foundations.Termii.Switch;

namespace Termii.Core.Tests.Unit.Foundations.Services.Switch
{
    public partial class SwitchServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveFetchSenderIdsRequestAsync()
        {
            // given 

            dynamic createRandomFetchSenderIdsResponseProperties =
                CreateRandomFetchSenderIdResponseProperties();

            var randomExternalFetchSenderIdsResponse = new ExternalFetchSenderIdsResponse
            {

                Data = ((List<dynamic>)createRandomFetchSenderIdsResponseProperties.Data).Select(data =>
                {
                    return new ExternalFetchSenderIdsResponse.Datum
                    {
                        Company = data.Company,
                        Country = data.Country,
                        CreatedAt = data.CreatedAt,
                        SenderId = data.SenderId,
                        Usecase = data.Usecase,
                        Status = data.Status,

                    };
                }).ToList(),
                CurrentPage = createRandomFetchSenderIdsResponseProperties.CurrentPage,
                FirstPageUrl = createRandomFetchSenderIdsResponseProperties.FirstPageUrl,
                From = createRandomFetchSenderIdsResponseProperties.From,
                LastPage = createRandomFetchSenderIdsResponseProperties.LastPage,
                LastPageUrl = createRandomFetchSenderIdsResponseProperties.LastPageUrl,
                NextPageUrl = createRandomFetchSenderIdsResponseProperties.NextPageUrl,
                Path = createRandomFetchSenderIdsResponseProperties.Path
            };

            var randomExpectedFetchSenderIdsResponse = new FetchSenderIdsResponse
            {


                Data = ((List<dynamic>)createRandomFetchSenderIdsResponseProperties.Data).Select(data =>
                {
                    return new FetchSenderIdsResponse.Datum
                    {
                        Company = data.Company,
                        Country = data.Country,
                        CreatedAt = data.CreatedAt,
                        SenderId = data.SenderId,
                        Usecase = data.Usecase,
                        Status = data.Status,

                    };
                }).ToList(),
                CurrentPage = createRandomFetchSenderIdsResponseProperties.CurrentPage,
                FirstPageUrl = createRandomFetchSenderIdsResponseProperties.FirstPageUrl,
                From = createRandomFetchSenderIdsResponseProperties.From,
                LastPage = createRandomFetchSenderIdsResponseProperties.LastPage,
                LastPageUrl = createRandomFetchSenderIdsResponseProperties.LastPageUrl,
                NextPageUrl = createRandomFetchSenderIdsResponseProperties.NextPageUrl,
                Path = createRandomFetchSenderIdsResponseProperties.Path
            };

            var expectedFetchSenderIds = new FetchSenderIds
            {
                Response = randomExpectedFetchSenderIdsResponse
            };


            var apiKey = GetRandomString();

            this.termiiBrokerMock.Setup(broker =>
                broker.GetSenderIdsAsync(apiKey))
                    .ReturnsAsync(randomExternalFetchSenderIdsResponse);

            // when
            FetchSenderIds actualFetchSenderIds =
               await this.switchService.GetSenderIdsRequestAsync(apiKey);

            // then
            actualFetchSenderIds.Should().BeEquivalentTo(expectedFetchSenderIds);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetSenderIdsAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
