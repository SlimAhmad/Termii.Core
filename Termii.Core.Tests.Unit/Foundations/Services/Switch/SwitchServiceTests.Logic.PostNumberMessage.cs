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
        public async Task ShouldPostNumberMessageWithNumberMessageRequestAsync()
        {
            // given 



            dynamic createRandomCreateNumberMessageRequestProperties =
              CreateRandomCreateNumberMessageRequestProperties();

            dynamic createRandomCreateNumberMessageResponseProperties =
                CreateRandomCreateNumberMessageResponseProperties();


            var randomExternalNumberMessageRequest = new ExternalNumberMessageRequest
            {
                ApiKey = createRandomCreateNumberMessageRequestProperties.ApiKey,
                Sms = createRandomCreateNumberMessageRequestProperties.Sms,
                To = createRandomCreateNumberMessageRequestProperties.To,


            };

            var randomExternalCreateNumberMessageResponse = new ExternalNumberMessageResponse
            {

                Code = createRandomCreateNumberMessageResponseProperties.Code,
                Message= createRandomCreateNumberMessageResponseProperties.Message,
                Balance = createRandomCreateNumberMessageResponseProperties.Balance,
                MessageId = createRandomCreateNumberMessageResponseProperties.MessageId,
                User = createRandomCreateNumberMessageResponseProperties.User,
                   
            };


            var randomNumberMessageRequest = new NumberMessageRequest
            {
                ApiKey = createRandomCreateNumberMessageRequestProperties.ApiKey,
                Sms = createRandomCreateNumberMessageRequestProperties.Sms,
                To = createRandomCreateNumberMessageRequestProperties.To,

            };

            var randomNumberMessageResponse = new NumberMessageResponse
            {
                Code = createRandomCreateNumberMessageResponseProperties.Code,
                Message = createRandomCreateNumberMessageResponseProperties.Message,
                Balance = createRandomCreateNumberMessageResponseProperties.Balance,
                MessageId = createRandomCreateNumberMessageResponseProperties.MessageId,
                User = createRandomCreateNumberMessageResponseProperties.User,
            };


            var randomNumberMessage = new NumberMessage
            {
                Request = randomNumberMessageRequest,
            };

            NumberMessage inputNumberMessage = randomNumberMessage;
            NumberMessage expectedNumberMessage = inputNumberMessage.DeepClone();
            expectedNumberMessage.Response = randomNumberMessageResponse;

            ExternalNumberMessageRequest mappedExternalCreateNumberMessageRequest =
               randomExternalNumberMessageRequest;

            ExternalNumberMessageResponse returnedExternalCreateNumberMessageResponse =
                randomExternalCreateNumberMessageResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostNumberMessageAsync(It.Is(
                      SameExternalNumberMessageRequestAs(mappedExternalCreateNumberMessageRequest))))
                     .ReturnsAsync(returnedExternalCreateNumberMessageResponse);

            // when
            NumberMessage actualCreateNumberMessage =
               await this.switchService.PostNumberMessageRequestAsync(inputNumberMessage);

            // then
            actualCreateNumberMessage.Should().BeEquivalentTo(expectedNumberMessage);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostNumberMessageAsync(It.Is(
                   SameExternalNumberMessageRequestAs(mappedExternalCreateNumberMessageRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
