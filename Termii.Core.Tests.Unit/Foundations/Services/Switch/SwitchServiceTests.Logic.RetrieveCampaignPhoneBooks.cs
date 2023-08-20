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
        public async Task ShouldRetrieveCampaignPhoneBookRequestAsync()
        {
            // given 

            dynamic createRandomCampaignPhoneBookResponseProperties =
                CreateCampaignPhoneBookProperties();

            var randomExternalCampaignPhoneBookResponse = new ExternalCampaignPhoneBookResponse
            {

                Data = ((List<dynamic>)createRandomCampaignPhoneBookResponseProperties.Data).Select(data =>
                {
                    return new ExternalCampaignPhoneBookResponse.Datum
                    {
                        DateCreated = data.DateCreated,
                        Id = data.Id,
                        LastUpdated = data.LastUpdated,
                        Name = data.Name,
                        TotalNumberOfContacts = data.TotalNumberOfContacts,
                        

                    };
                }).ToList(),

                Links = new ExternalCampaignPhoneBookResponse.ExternalLinks
                {
                    First = createRandomCampaignPhoneBookResponseProperties.Links.First,
                    Last = createRandomCampaignPhoneBookResponseProperties.Links.Last,
                    Next = createRandomCampaignPhoneBookResponseProperties.Links.Next,
                    Prev = createRandomCampaignPhoneBookResponseProperties.Links.Prev,
                 
                  
                },
                Meta = new ExternalCampaignPhoneBookResponse.ExternalMeta
                {
                    CurrentPage = createRandomCampaignPhoneBookResponseProperties.Meta.CurrentPage,
                    From = createRandomCampaignPhoneBookResponseProperties.Meta.From,
                    LastPage = createRandomCampaignPhoneBookResponseProperties.Meta.LastPage,
                    Path = createRandomCampaignPhoneBookResponseProperties.Meta.Path,
                    PerPage = createRandomCampaignPhoneBookResponseProperties.Meta.PerPage,
                    To = createRandomCampaignPhoneBookResponseProperties.Meta.To,
                    Total = createRandomCampaignPhoneBookResponseProperties.Meta.Total,
                    
                    
                   
                },
            };

            var randomExpectedCampaignPhoneBookResponse = new CampaignPhoneBookResponse
            {


                Data = ((List<dynamic>)createRandomCampaignPhoneBookResponseProperties.Data).Select(data =>
                {
                    return new CampaignPhoneBookResponse.Datum
                    {
                        DateCreated = data.DateCreated,
                        Id = data.Id,
                        LastUpdated = data.LastUpdated,
                        Name = data.Name,
                        TotalNumberOfContacts = data.TotalNumberOfContacts,


                    };
                }).ToList(),

                Links = new CampaignPhoneBookResponse.PhoneBookLinks
                {
                    First = createRandomCampaignPhoneBookResponseProperties.Links.First,
                    Last = createRandomCampaignPhoneBookResponseProperties.Links.Last,
                    Next = createRandomCampaignPhoneBookResponseProperties.Links.Next,
                    Prev = createRandomCampaignPhoneBookResponseProperties.Links.Prev,


                },
                Meta = new CampaignPhoneBookResponse.PhoneBookMeta
                {
                    CurrentPage = createRandomCampaignPhoneBookResponseProperties.Meta.CurrentPage,
                    From = createRandomCampaignPhoneBookResponseProperties.Meta.From,
                    LastPage = createRandomCampaignPhoneBookResponseProperties.Meta.LastPage,
                    Path = createRandomCampaignPhoneBookResponseProperties.Meta.Path,
                    PerPage = createRandomCampaignPhoneBookResponseProperties.Meta.PerPage,
                    To = createRandomCampaignPhoneBookResponseProperties.Meta.To,
                    Total = createRandomCampaignPhoneBookResponseProperties.Meta.Total,



                },
            };

            var expectedCampaignPhoneBook = new CampaignPhoneBook
            {
                Response = randomExpectedCampaignPhoneBookResponse
            };


            var apiKey = GetRandomString();

            this.termiiBrokerMock.Setup(broker =>
                broker.GetCampaignsPhoneBooksAsync(apiKey))
                    .ReturnsAsync(randomExternalCampaignPhoneBookResponse);

            // when
            CampaignPhoneBook actualCampaignPhoneBook =
               await this.switchService.GetCampaignsPhoneBooksRequestAsync(apiKey);

            // then
            actualCampaignPhoneBook.Should().BeEquivalentTo(expectedCampaignPhoneBook);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetCampaignsPhoneBooksAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
