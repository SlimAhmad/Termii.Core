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
        public async Task ShouldRetrieveFetchContactsByPhoneBookIdRequestAsync()
        {
            // given 

            dynamic createRandomFetchContactsByPhoneBookIdResponseProperties =
                CreateRandomFetchContactsByPhoneBookIdResponseProperties();

            var randomExternalFetchContactsByPhoneBookResponse = new ExternalFetchContactsByPhoneBookResponse
            {

                Data = ((List<dynamic>)createRandomFetchContactsByPhoneBookIdResponseProperties.Data).Select(data =>
                {
                    return new ExternalFetchContactsByPhoneBookResponse.Datum
                    {
                         Message = data.Message,
                         Company = data.Company,
                         CreateAt = data.CreateAt,
                         EmailAddress = data.EmailAddress,
                         FirstName = data.FirstName,
                         Id = data.Id,
                         LastName = data.LastName,
                         PhoneNumber = data.PhoneNumber,
                         Pid = data.Pid,
                         UpdatedAt = data.UpdatedAt,
                       

                    };
                }).ToList(),

                Links = new ExternalFetchContactsByPhoneBookResponse.ExternalContactsLinks
                {
                    First = createRandomFetchContactsByPhoneBookIdResponseProperties.Links.First,
                    Last = createRandomFetchContactsByPhoneBookIdResponseProperties.Links.Last,
                    Next = createRandomFetchContactsByPhoneBookIdResponseProperties.Links.Next,
                    Prev = createRandomFetchContactsByPhoneBookIdResponseProperties.Links.Prev,
                  
                 
                   
                },
                Meta = new ExternalFetchContactsByPhoneBookResponse.ExternalContactsMeta
                {
                    CurrentPage = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.CurrentPage,
                    From = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.From,
                    LastPage = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.LastPage,
                    Path = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.Path,
                    PerPage = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.PerPage,
                    To = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.To,
                    Total = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.Total,
                  
                   
                },
            };

            var randomExpectedFetchContactsByPhoneBookIdResponse = new FetchContactsByPhoneBookIdResponse
            {

                Data = ((List<dynamic>)createRandomFetchContactsByPhoneBookIdResponseProperties.Data).Select(data =>
                {
                    return new FetchContactsByPhoneBookIdResponse.Datum
                    {
                        Message = data.Message,
                        Company = data.Company,
                        CreateAt = data.CreateAt,
                        EmailAddress = data.EmailAddress,
                        FirstName = data.FirstName,
                        Id = data.Id,
                        LastName = data.LastName,
                        PhoneNumber = data.PhoneNumber,
                        Pid = data.Pid,
                        UpdatedAt = data.UpdatedAt,


                    };
                }).ToList(),

                Links = new FetchContactsByPhoneBookIdResponse.ContactsLinks
                {
                    First = createRandomFetchContactsByPhoneBookIdResponseProperties.Links.First,
                    Last = createRandomFetchContactsByPhoneBookIdResponseProperties.Links.Last,
                    Next = createRandomFetchContactsByPhoneBookIdResponseProperties.Links.Next,
                    Prev = createRandomFetchContactsByPhoneBookIdResponseProperties.Links.Prev,



                },
                Meta = new FetchContactsByPhoneBookIdResponse.ContactsMeta
                {
                    CurrentPage = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.CurrentPage,
                    From = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.From,
                    LastPage = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.LastPage,
                    Path = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.Path,
                    PerPage = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.PerPage,
                    To = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.To,
                    Total = createRandomFetchContactsByPhoneBookIdResponseProperties.Meta.Total,


                },
            };

            var expectedFetchContactsByPhoneBookId = new FetchContactsByPhoneBookId
            {
                Response = randomExpectedFetchContactsByPhoneBookIdResponse
            };


            var apiKey = GetRandomString();
            var contactId = GetRandomString();

            this.termiiBrokerMock.Setup(broker =>
                broker.GetContactsByPhoneBookIdAsync(apiKey, contactId))
                    .ReturnsAsync(randomExternalFetchContactsByPhoneBookResponse);

            // when
            FetchContactsByPhoneBookId actualFetchContactsByPhoneBookId =
               await this.switchService.GetContactsByPhoneBookIdRequestAsync(apiKey, contactId);

            // then
            actualFetchContactsByPhoneBookId.Should().BeEquivalentTo(expectedFetchContactsByPhoneBookId);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetContactsByPhoneBookIdAsync(apiKey, contactId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
