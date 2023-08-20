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
        public async Task ShouldRetrieveDeletePhoneBookRequestAsync()
        {
            // given 

            dynamic createRandomDeletePhoneBookResponseProperties =
                CreateRandomDeletePhoneBookResponseProperties();

            var randomExternalDeletePhoneBookResponse = new ExternalDeletePhoneBookResponse
            {

                Message = createRandomDeletePhoneBookResponseProperties.Message,
            };

            var randomExpectedDeletePhoneBookResponse = new DeletePhoneBookResponse
            {

                Message = createRandomDeletePhoneBookResponseProperties.Message,
            };

            var expectedDeletePhoneBook = new DeletePhoneBook
            {
                Response = randomExpectedDeletePhoneBookResponse
            };


            var apiKey = GetRandomString();
            var phoneBookId = GetRandomString();

            this.termiiBrokerMock.Setup(broker =>
                broker.DeletePhoneBookAsync(apiKey, phoneBookId))
                    .ReturnsAsync(randomExternalDeletePhoneBookResponse);

            // when
            DeletePhoneBook actualDeletePhoneBook =
               await this.switchService.DeletePhoneBookRequestAsync(apiKey, phoneBookId);

            // then
            actualDeletePhoneBook.Should().BeEquivalentTo(expectedDeletePhoneBook);

            this.termiiBrokerMock.Verify(broker =>
                broker.DeletePhoneBookAsync(apiKey, phoneBookId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
