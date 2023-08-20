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
        public async Task ShouldRetrieveDeletePhoneBookContactRequestAsync()
        {
            // given 

            dynamic createRandomDeletePhoneBookContactResponseProperties =
                CreateRandomDeletePhoneContactResponseProperties();

            var randomExternalDeletePhoneContactResponse = new ExternalDeletePhoneBookContactResponse
            {

               Message = createRandomDeletePhoneBookContactResponseProperties.Message
            };

            var randomExpectedDeletePhoneContactResponse = new DeletePhoneBookContactResponse
            {

               Message = createRandomDeletePhoneBookContactResponseProperties.Message
            };

            var expectedDeletePhoneContact = new DeletePhoneBookContact
            {
                Response = randomExpectedDeletePhoneContactResponse
            };


            var apiKey = GetRandomString();
            var phoneBookId = GetRandomString();

            this.termiiBrokerMock.Setup(broker =>
                broker.DeletePhoneBookContactAsync(apiKey, phoneBookId))
                    .ReturnsAsync(randomExternalDeletePhoneContactResponse);

            // when
            DeletePhoneBookContact actualDeletePhoneContact =
               await this.switchService.DeletePhoneBookContactRequestAsync(apiKey, phoneBookId);

            // then
            actualDeletePhoneContact.Should().BeEquivalentTo(expectedDeletePhoneContact);

            this.termiiBrokerMock.Verify(broker =>
                broker.DeletePhoneBookContactAsync(apiKey, phoneBookId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
