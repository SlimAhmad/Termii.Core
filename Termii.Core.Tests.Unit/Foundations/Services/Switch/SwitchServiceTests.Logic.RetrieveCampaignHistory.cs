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
        public async Task ShouldRetrieveFetchCampaignHistoryRequestAsync()
        {
            // given 

            dynamic createRandomFetchCampaignsHistoryResponseProperties =
                CreateRandomFetchCampaignsHistoryResponseProperties();

            var randomExternalFetchCampaignHistoryResponse = new ExternalFetchCampaignsHistoryResponse
            {

                Data = ((List<dynamic>)createRandomFetchCampaignsHistoryResponseProperties.Data).Select(data =>
                {
                    return new ExternalFetchCampaignsHistoryResponse.Datum
                    {
                        Amount = data.Amount,
                        Channel = data.Channel,
                        DateCreated = data.DateCreated,
                        Id = data.Id,
                        LastUpdated = data.LastUpdated,
                        Message = data.Message,
                        MessageAbbreviation = data.MessageAbbreviation,
                        MessageId = data.MessageId,
                        Receiver = data.Receiver,
                        Sender = data.Sender,
                        SmsType = data.SmsType,
                        Status = data.Status,

                    };
                }).ToList(),

                Links = new ExternalFetchCampaignsHistoryResponse.ExternalHistoryLinks
                {
                    First = createRandomFetchCampaignsHistoryResponseProperties.Links.First,
                    Last = createRandomFetchCampaignsHistoryResponseProperties.Links.Last,
                    Next = createRandomFetchCampaignsHistoryResponseProperties.Links.Next,
                    Prev = createRandomFetchCampaignsHistoryResponseProperties.Links.Prev
                },
                Meta = new ExternalFetchCampaignsHistoryResponse.ExternalHistoryMeta
                {
                    CurrentPage = createRandomFetchCampaignsHistoryResponseProperties.Meta.CurrentPage,
                    From = createRandomFetchCampaignsHistoryResponseProperties.Meta.From,
                    LastPage = createRandomFetchCampaignsHistoryResponseProperties.Meta.LastPage,
                    Path = createRandomFetchCampaignsHistoryResponseProperties.Meta.Path,
                    PerPage = createRandomFetchCampaignsHistoryResponseProperties.Meta.PerPage,
                    To = createRandomFetchCampaignsHistoryResponseProperties.Meta.To,
                   
                },
            };

            var randomExpectedFetchCampaignHistoryResponse = new FetchCampaignsHistoryResponse
            {

                Data = ((List<dynamic>)createRandomFetchCampaignsHistoryResponseProperties.Data).Select(data =>
                {
                    return new FetchCampaignsHistoryResponse.Datum
                    {
                        Amount = data.Amount,
                        Channel = data.Channel,
                        DateCreated = data.DateCreated,
                        Id = data.Id,
                        LastUpdated = data.LastUpdated,
                        Message = data.Message,
                        MessageAbbreviation = data.MessageAbbreviation,
                        MessageId = data.MessageId,
                        Receiver = data.Receiver,
                        Sender = data.Sender,
                        SmsType = data.SmsType,
                        Status = data.Status,

                    };
                }).ToList(),

                Links = new FetchCampaignsHistoryResponse.HistoryLinks
                {
                    First = createRandomFetchCampaignsHistoryResponseProperties.Links.First,
                    Last = createRandomFetchCampaignsHistoryResponseProperties.Links.Last,
                    Next = createRandomFetchCampaignsHistoryResponseProperties.Links.Next,
                    Prev = createRandomFetchCampaignsHistoryResponseProperties.Links.Prev
                },
                Meta = new FetchCampaignsHistoryResponse.HistoryMeta
                {
                    CurrentPage = createRandomFetchCampaignsHistoryResponseProperties.Meta.CurrentPage,
                    From = createRandomFetchCampaignsHistoryResponseProperties.Meta.From,
                    LastPage = createRandomFetchCampaignsHistoryResponseProperties.Meta.LastPage,
                    Path = createRandomFetchCampaignsHistoryResponseProperties.Meta.Path,
                    PerPage = createRandomFetchCampaignsHistoryResponseProperties.Meta.PerPage,
                    To = createRandomFetchCampaignsHistoryResponseProperties.Meta.To,

                },
            };

            var expectedFetchCampaignHistory = new FetchCampaignsHistory
            {
                Response = randomExpectedFetchCampaignHistoryResponse
            };


            var apiKey = GetRandomString();
            var campaignId = GetRandomString();

            this.termiiBrokerMock.Setup(broker =>
                broker.GetCampaignsHistoryAsync(apiKey,campaignId))
                    .ReturnsAsync(randomExternalFetchCampaignHistoryResponse);

            // when
            FetchCampaignsHistory actualFetchCampaignHistory =
               await this.switchService.GetCampaignsHistoryRequestAsync(apiKey, campaignId);

            // then
            actualFetchCampaignHistory.Should().BeEquivalentTo(expectedFetchCampaignHistory);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetCampaignsHistoryAsync(apiKey, campaignId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
