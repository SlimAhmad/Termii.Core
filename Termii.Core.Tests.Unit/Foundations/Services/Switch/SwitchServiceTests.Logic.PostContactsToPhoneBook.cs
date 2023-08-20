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
        public async Task ShouldPostAddMultipleContactsToPhoneBookWithAddMultipleContactsToPhoneBookRequestAsync()
        {
            // given 



            dynamic createRandomAddMultipleContactsToPhoneBookRequestProperties =
              CreateRandomAddMultipleContactsToPhoneBookRequestProperties();

            dynamic createRandomAddMultipleContactsToPhoneBookResponseProperties =
                CreateRandomAddMultipleContactsToPhoneBookResponseProperties();


            var randomExternalAddMultipleContactsToPhoneBookRequest = new ExternalAddMultipleContactsToPhoneBookRequest
            {
                ApiKey = createRandomAddMultipleContactsToPhoneBookRequestProperties.ApiKey,
                ContactFile = createRandomAddMultipleContactsToPhoneBookRequestProperties.ContactFile,
                CountryCode = createRandomAddMultipleContactsToPhoneBookRequestProperties.CountryCode
               


            };

            var randomExternalAddMultipleContactsToPhoneBookResponse = new ExternalAddMultipleContactsToPhoneBookResponse
            {

               Message = createRandomAddMultipleContactsToPhoneBookResponseProperties.Message
              
                   
            };


            var randomAddMultipleContactsToPhoneBookRequest = new AddMultipleContactsToPhoneBookRequest
            {
                ApiKey = createRandomAddMultipleContactsToPhoneBookRequestProperties.ApiKey,
                ContactFile = createRandomAddMultipleContactsToPhoneBookRequestProperties.ContactFile,
                CountryCode = createRandomAddMultipleContactsToPhoneBookRequestProperties.CountryCode

            };

            var randomAddMultipleContactsToPhoneBookResponse = new AddMultipleContactsToPhoneBookResponse
            {
                Message = createRandomAddMultipleContactsToPhoneBookResponseProperties.Message
            };


            var randomAddMultipleContactsToPhoneBook = new AddMultipleContactsToPhoneBook
            {
                Request = randomAddMultipleContactsToPhoneBookRequest,
            };

            var phoneBookId = GetRandomString();
            AddMultipleContactsToPhoneBook inputAddMultipleContactsToPhoneBook = randomAddMultipleContactsToPhoneBook;
            AddMultipleContactsToPhoneBook expectedAddMultipleContactsToPhoneBook = inputAddMultipleContactsToPhoneBook.DeepClone();
            expectedAddMultipleContactsToPhoneBook.Response = randomAddMultipleContactsToPhoneBookResponse;

            ExternalAddMultipleContactsToPhoneBookRequest mappedExternalAddMultipleContactsToPhoneBookRequest =
               randomExternalAddMultipleContactsToPhoneBookRequest;

            ExternalAddMultipleContactsToPhoneBookResponse returnedExternalAddMultipleContactsToPhoneBookResponse =
                randomExternalAddMultipleContactsToPhoneBookResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostContactsToPhoneBookAsync(It.Is(
                      SameExternalAddMultipleContactsToPhoneBookRequestAs(mappedExternalAddMultipleContactsToPhoneBookRequest)), It.IsAny<string>()))
                     .ReturnsAsync(returnedExternalAddMultipleContactsToPhoneBookResponse);

            // when
            AddMultipleContactsToPhoneBook actualCreateAddMultipleContactsToPhoneBook =
               await this.switchService.PostContactsToPhoneBookRequestAsync(inputAddMultipleContactsToPhoneBook, phoneBookId);

            // then
            actualCreateAddMultipleContactsToPhoneBook.Should().BeEquivalentTo(expectedAddMultipleContactsToPhoneBook);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostContactsToPhoneBookAsync(It.Is(
                   SameExternalAddMultipleContactsToPhoneBookRequestAs(mappedExternalAddMultipleContactsToPhoneBookRequest)), It.IsAny<string>()),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
