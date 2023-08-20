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
        public async Task ShouldRetrieveFetchCampaignsRequestAsync()
        {
            // given 

            dynamic createRandomFetchCampaignsResponseProperties =
                CreateRandomFetchCampaignsResponseProperties();

            var randomExternalFetchCampaignResponse = new ExternalFetchCampaignsResponse
            {

                Data = ((List<dynamic>)createRandomFetchCampaignsResponseProperties.Data).Select(data =>
                {
                    return new ExternalFetchCampaignsResponse.Datum
                    {
                        CampaignId = data.CampaignId,
                        Channel = data.Channel,
                        CampType = data.CampType,
                        CreatedAt = data.CreatedAt,
                        PhoneBook = data.PhoneBook,
                        RunAt = data.RunAt,
                        Sender = data.Sender,
                        TotalRecipients = data.TotalRecipients,
                        Status = data.Status,

                    };
                }).ToList(),

                Links = new ExternalFetchCampaignsResponse.ExternalCampaignsLinks
                {
                    First = createRandomFetchCampaignsResponseProperties.Links.First,
                    Last = createRandomFetchCampaignsResponseProperties.Links.Last,
                    Next = createRandomFetchCampaignsResponseProperties.Links.Next,
                    Prev = createRandomFetchCampaignsResponseProperties.Links.Prev
                   
                },
                CampaignsMeta = new ExternalFetchCampaignsResponse.ExternalCampaignsMeta
                {
                    CurrentPage = createRandomFetchCampaignsResponseProperties.Meta.CurrentPage,
                    From = createRandomFetchCampaignsResponseProperties.Meta.From,
                    LastPage = createRandomFetchCampaignsResponseProperties.Meta.LastPage,
                    Path = createRandomFetchCampaignsResponseProperties.Meta.Path,
                    PerPage = createRandomFetchCampaignsResponseProperties.Meta.PerPage,
                    To = createRandomFetchCampaignsResponseProperties.Meta.To,
                    Total = createRandomFetchCampaignsResponseProperties.Meta.Total
                   
                },
            };

            var randomExpectedFetchCampaignResponse = new FetchCampaignsResponse
            {

                Data = ((List<dynamic>)createRandomFetchCampaignsResponseProperties.Data).Select(data =>
                {
                    return new FetchCampaignsResponse.Datum
                    {
                        CampaignId = data.CampaignId,
                        Channel = data.Channel,
                        CampType = data.CampType,
                        CreatedAt = data.CreatedAt,
                        PhoneBook = data.PhoneBook,
                        RunAt = data.RunAt,
                        Sender = data.Sender,
                        TotalRecipients = data.TotalRecipients,
                        Status = data.Status,

                    };
                }).ToList(),

                Links = new FetchCampaignsResponse.CampaignsLinks
                {
                    First = createRandomFetchCampaignsResponseProperties.Links.First,
                    Last = createRandomFetchCampaignsResponseProperties.Links.Last,
                    Next = createRandomFetchCampaignsResponseProperties.Links.Next,
                    Prev = createRandomFetchCampaignsResponseProperties.Links.Prev

                },
                Meta = new FetchCampaignsResponse.CampaignsMeta
                {
                    CurrentPage = createRandomFetchCampaignsResponseProperties.Meta.CurrentPage,
                    From = createRandomFetchCampaignsResponseProperties.Meta.From,
                    LastPage = createRandomFetchCampaignsResponseProperties.Meta.LastPage,
                    Path = createRandomFetchCampaignsResponseProperties.Meta.Path,
                    PerPage = createRandomFetchCampaignsResponseProperties.Meta.PerPage,
                    To = createRandomFetchCampaignsResponseProperties.Meta.To,
                    Total = createRandomFetchCampaignsResponseProperties.Meta.Total

                },
            };

            var expectedFetchCampaign = new FetchCampaigns
            {
                Response = randomExpectedFetchCampaignResponse
            };


            var apiKey = GetRandomString();

            this.termiiBrokerMock.Setup(broker =>
                broker.GetCampaignsAsync(apiKey))
                    .ReturnsAsync(randomExternalFetchCampaignResponse);

            // when
            FetchCampaigns actualFetchCampaign =
               await this.switchService.GetCampaignsRequestAsync(apiKey);

            // then
            actualFetchCampaign.Should().BeEquivalentTo(expectedFetchCampaign);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetCampaignsAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
