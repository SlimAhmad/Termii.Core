using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;
using Termii.Core.Models.Services.Foundations.Termii.Insights;

namespace Termii.Core.Tests.Unit.Foundations.Services.Insights
{
    public partial class InsightsServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveHistoryRequestAsync()
        {
            // given 

            dynamic createRandomHistoryResponseProperties =
                CreateRandomHistoryResponseProperties();

            var randomExternalHistoryResponse = new ExternalHistoryResponse
            {

                Amount = createRandomHistoryResponseProperties.Amount,
                CreatedAt = createRandomHistoryResponseProperties.CreatedAt,
                MediaUrl = createRandomHistoryResponseProperties.MediaUrl,
                Message = createRandomHistoryResponseProperties.Message,
                MessageId = createRandomHistoryResponseProperties.MessageId,
                NotifyId = createRandomHistoryResponseProperties.NotifyId,
                NotifyUrl = createRandomHistoryResponseProperties.NotifyUrl,
                Receiver = createRandomHistoryResponseProperties.Receiver,
                Reroute = createRandomHistoryResponseProperties.Reroute,
                SendBy = createRandomHistoryResponseProperties.SendBy,
                Sender = createRandomHistoryResponseProperties.Sender,
                SmsType = createRandomHistoryResponseProperties.SmsType,
                Status = createRandomHistoryResponseProperties.Status,
            };

            var randomExpectedHistoryResponse = new HistoryResponse
            {

                Amount = createRandomHistoryResponseProperties.Amount,
                CreatedAt = createRandomHistoryResponseProperties.CreatedAt,
                MediaUrl = createRandomHistoryResponseProperties.MediaUrl,
                Message = createRandomHistoryResponseProperties.Message,
                MessageId = createRandomHistoryResponseProperties.MessageId,
                NotifyId = createRandomHistoryResponseProperties.NotifyId,
                NotifyUrl = createRandomHistoryResponseProperties.NotifyUrl,
                Receiver = createRandomHistoryResponseProperties.Receiver,
                Reroute = createRandomHistoryResponseProperties.Reroute,
                SendBy = createRandomHistoryResponseProperties.SendBy,
                Sender = createRandomHistoryResponseProperties.Sender,
                SmsType = createRandomHistoryResponseProperties.SmsType,
                Status = createRandomHistoryResponseProperties.Status,
            };

            var expectedHistory = new History
            {
                Response = randomExpectedHistoryResponse
            };


            var apiKey = GetRandomString();

            this.termiiBrokerMock.Setup(broker =>
                broker.GetHistoryAsync(apiKey))
                    .ReturnsAsync(randomExternalHistoryResponse);

            // when
            History actualHistory =
               await this.insightsService.GetHistoryAsync(apiKey);

            // then
            actualHistory.Should().BeEquivalentTo(expectedHistory);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetHistoryAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
