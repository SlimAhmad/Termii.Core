using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
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


                Data = ((List<dynamic>)createRandomHistoryResponseProperties.Data).Select(data =>
                {
                    return new ExternalHistoryResponse.Datum
                    {
                        Amount = data.Amount,
                        CountryCode = data.CountryCode,
                        CreatedAt = data.CreatedAt,
                        MediaUrl = data.MediaUrl,
                        Message = data.Message,
                        MessageId = data.MessageId,
                        NotifyId = data.NotifyId,
                        NotifyUrl = data.NotifyUrl,
                        Receiver = data.Receiver,
                        Reroute = data.Reroute,
                        SendBy = data.SendBy,
                        Sender = data.Sender,
                        SentAt = data.SentAt,
                        SmsType = data.SmsType,
                        Status = data.Status,

                    };
                }).ToList(),
                Links = new ExternalHistoryResponse.ExternalHistoryLinks
                {
                    First = createRandomHistoryResponseProperties.Links.First,
                    Last = createRandomHistoryResponseProperties.Links.Last,
                    Next = createRandomHistoryResponseProperties.Links.Next,
                    Prev = createRandomHistoryResponseProperties.Links.Prev,

                },
                Meta = new ExternalHistoryResponse.ExternalHistoryMeta
                {
                    CurrentPage = createRandomHistoryResponseProperties.Meta.CurrentPage,
                    From = createRandomHistoryResponseProperties.Meta.From,
                    LastPage = createRandomHistoryResponseProperties.Meta.LastPage,
                    Path = createRandomHistoryResponseProperties.Meta.Path,
                    PerPage = createRandomHistoryResponseProperties.Meta.PerPage,
                    To = createRandomHistoryResponseProperties.Meta.To,
                    Total = createRandomHistoryResponseProperties.Meta.Total,
                }
            };

            var randomExpectedHistoryResponse = new HistoryResponse
            {

                Data = ((List<dynamic>)createRandomHistoryResponseProperties.Data).Select(data =>
                {
                    return new HistoryResponse.Datum
                    {
                        Amount = data.Amount,
                        CountryCode = data.CountryCode,
                        CreatedAt = data.CreatedAt,
                        MediaUrl = data.MediaUrl,
                        Message = data.Message,
                        MessageId = data.MessageId,
                        NotifyId = data.NotifyId,
                        NotifyUrl = data.NotifyUrl,
                        Receiver = data.Receiver,
                        Reroute = data.Reroute,
                        SendBy = data.SendBy,
                        Sender = data.Sender,
                        SentAt = data.SentAt,
                        SmsType = data.SmsType,
                        Status = data.Status,

                    };
                }).ToList(),
                Links = new HistoryResponse.HistoryLinks
                {
                    First = createRandomHistoryResponseProperties.Links.First,
                    Last = createRandomHistoryResponseProperties.Links.Last,
                    Next = createRandomHistoryResponseProperties.Links.Next,
                    Prev = createRandomHistoryResponseProperties.Links.Prev,

                },
                Meta = new HistoryResponse.HistoryMeta
                {
                    CurrentPage = createRandomHistoryResponseProperties.Meta.CurrentPage,
                    From = createRandomHistoryResponseProperties.Meta.From,
                    LastPage = createRandomHistoryResponseProperties.Meta.LastPage,
                    Path = createRandomHistoryResponseProperties.Meta.Path,
                    PerPage = createRandomHistoryResponseProperties.Meta.PerPage,
                    To = createRandomHistoryResponseProperties.Meta.To,
                    Total = createRandomHistoryResponseProperties.Meta.Total,
                }
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
