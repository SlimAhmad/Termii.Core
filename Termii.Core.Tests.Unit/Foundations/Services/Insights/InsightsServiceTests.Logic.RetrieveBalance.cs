using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;
using Termii.Core.Models.Services.Foundations.Termii.Insights;

namespace Termii.Core.Tests.Unit.Foundations.Services.Insights
{
    public partial class InsightsServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveBalanceRequestAsync()
        {
            // given 

            dynamic createRandomBalancesProperties =
                CreateRandomBalanceResponseProperties();

            var randomExternalBalanceResponse = new ExternalBalanceResponse
            {

                Balance = createRandomBalancesProperties.Balance,
                Currency = createRandomBalancesProperties.Currency,
                User = createRandomBalancesProperties.User,
            };

            var randomExpectedBalanceResponse = new BalanceResponse
            {

                Balance = createRandomBalancesProperties.Balance,
                Currency = createRandomBalancesProperties.Currency,
                User = createRandomBalancesProperties.User,
            };

            var expectedBalances = new Balance
            {
                Response = randomExpectedBalanceResponse
            };


            var apiKey = GetRandomString();

            this.termiiBrokerMock.Setup(broker =>
                broker.GetBalanceAsync(apiKey))
                    .ReturnsAsync(randomExternalBalanceResponse);

            // when
            Balance actualBalances =
               await this.insightsService.GetBalanceAsync(apiKey);

            // then
            actualBalances.Should().BeEquivalentTo(expectedBalances);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
