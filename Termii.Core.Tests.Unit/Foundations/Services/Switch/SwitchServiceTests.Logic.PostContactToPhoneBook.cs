using FluentAssertions;
using Force.DeepCloner;
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
        public async Task ShouldPostAddContactToPhoneBookWithAddContactToPhoneBookRequestAsync()
        {
            // given 



            dynamic createRandomAddContactToPhoneBookRequestProperties =
              CreateRandomAddContactToPhoneBookRequestProperties();

            dynamic createRandomAddContactToPhoneBookResponseProperties =
                CreateRandomAddContactToPhoneBookResponseProperties();


            var randomExternalAddContactToPhoneBookRequest = new ExternalAddContactToPhoneBookRequest
            {
                ApiKey = createRandomAddContactToPhoneBookRequestProperties.ApiKey,
                Company = createRandomAddContactToPhoneBookRequestProperties.Company,
                CountryCode = createRandomAddContactToPhoneBookRequestProperties.CountryCode,
                EmailAddress = createRandomAddContactToPhoneBookRequestProperties.EmailAddress,
                FirstName = createRandomAddContactToPhoneBookRequestProperties.FirstName,
                LastName = createRandomAddContactToPhoneBookRequestProperties.LastName,
                PhoneNumber = createRandomAddContactToPhoneBookRequestProperties.PhoneNumber,
               


            };

            var randomExternalAddContactToPhoneBookResponse = new ExternalAddContactToPhoneBookResponse
            {

                Data = new ExternalAddContactToPhoneBookResponse.ExternalContactData
                {
                   Company = createRandomAddContactToPhoneBookResponseProperties.Data.Company,
                   PhoneNumber = createRandomAddContactToPhoneBookResponseProperties.Data.PhoneNumber,
                   LastName = createRandomAddContactToPhoneBookResponseProperties.Data.LastName,
                   FirstName = createRandomAddContactToPhoneBookResponseProperties.Data.FirstName,
                   EmailAddress = createRandomAddContactToPhoneBookResponseProperties.Data.EmailAddress,
                   CreateAt = createRandomAddContactToPhoneBookResponseProperties.Data.CreateAt,
                   Id = createRandomAddContactToPhoneBookResponseProperties.Data.Id,
                   Message = createRandomAddContactToPhoneBookResponseProperties.Data.Message,
                   UpdatedAt = createRandomAddContactToPhoneBookResponseProperties.Data.UpdatedAt
                },
              
                   
            };


            var randomAddContactToPhoneBookRequest = new AddContactToPhoneBookRequest
            {
                ApiKey = createRandomAddContactToPhoneBookRequestProperties.ApiKey,
                Company = createRandomAddContactToPhoneBookRequestProperties.Company,
                CountryCode = createRandomAddContactToPhoneBookRequestProperties.CountryCode,
                EmailAddress = createRandomAddContactToPhoneBookRequestProperties.EmailAddress,
                FirstName = createRandomAddContactToPhoneBookRequestProperties.FirstName,
                LastName = createRandomAddContactToPhoneBookRequestProperties.LastName,
                PhoneNumber = createRandomAddContactToPhoneBookRequestProperties.PhoneNumber,

            };

            var randomAddContactToPhoneBookResponse = new AddContactToPhoneBookResponse
            {
                Data = new AddContactToPhoneBookResponse.ExternalContactData
                {
                    Company = createRandomAddContactToPhoneBookResponseProperties.Data.Company,
                    PhoneNumber = createRandomAddContactToPhoneBookResponseProperties.Data.PhoneNumber,
                    LastName = createRandomAddContactToPhoneBookResponseProperties.Data.LastName,
                    FirstName = createRandomAddContactToPhoneBookResponseProperties.Data.FirstName,
                    EmailAddress = createRandomAddContactToPhoneBookResponseProperties.Data.EmailAddress,
                    CreateAt = createRandomAddContactToPhoneBookResponseProperties.Data.CreateAt,
                    Id = createRandomAddContactToPhoneBookResponseProperties.Data.Id,
                    Message = createRandomAddContactToPhoneBookResponseProperties.Data.Message,
                    UpdatedAt = createRandomAddContactToPhoneBookResponseProperties.Data.UpdatedAt
                },
            };


            var randomAddContactToPhoneBook = new AddContactToPhoneBook
            {
                Request = randomAddContactToPhoneBookRequest,
            };

            var phoneBookId = GetRandomString();
            AddContactToPhoneBook inputAddContactToPhoneBook = randomAddContactToPhoneBook;
            AddContactToPhoneBook expectedAddContactToPhoneBook = inputAddContactToPhoneBook.DeepClone();
            expectedAddContactToPhoneBook.Response = randomAddContactToPhoneBookResponse;

            ExternalAddContactToPhoneBookRequest mappedExternalAddContactToPhoneBookRequest =
               randomExternalAddContactToPhoneBookRequest;

            ExternalAddContactToPhoneBookResponse returnedExternalAddContactToPhoneBookResponse =
                randomExternalAddContactToPhoneBookResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostContactToPhoneBookAsync(It.Is(
                      SameExternalAddContactToPhoneBookRequestAs(mappedExternalAddContactToPhoneBookRequest)), It.IsAny<string>()))
                     .ReturnsAsync(returnedExternalAddContactToPhoneBookResponse);

            // when
            AddContactToPhoneBook actualCreateAddContactToPhoneBook =
               await this.switchService.PostContactToPhoneBookRequestAsync(inputAddContactToPhoneBook, phoneBookId);

            // then
            actualCreateAddContactToPhoneBook.Should().BeEquivalentTo(expectedAddContactToPhoneBook);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostContactToPhoneBookAsync(It.Is(
                   SameExternalAddContactToPhoneBookRequestAs(mappedExternalAddContactToPhoneBookRequest)), It.IsAny<string>()),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
