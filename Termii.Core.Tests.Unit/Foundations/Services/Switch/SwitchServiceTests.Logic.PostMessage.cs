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
        public async Task ShouldPostSendMessageWithSendMessageRequestAsync()
        {
            // given 



            dynamic createRandomCreateSendMessageRequestProperties =
              CreateRandomCreateSendMessageRequestProperties();

            dynamic createRandomCreateSendMessageResponseProperties =
                CreateRandomCreateSendMessageResponseProperties();


            var randomExternalSendMessageRequest = new ExternalSendMessageRequest
            {
                ApiKey = createRandomCreateSendMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendMessageRequestProperties.Channel,
                From = createRandomCreateSendMessageRequestProperties.From,
                To  = createRandomCreateSendMessageRequestProperties.To,
                Media = new ExternalSendMessageRequest.ExternalMedia
                {
                   Caption = createRandomCreateSendMessageRequestProperties.Media.Caption,
                   Url = createRandomCreateSendMessageRequestProperties.Media.Url,
                },
                Sms = createRandomCreateSendMessageRequestProperties.Sms,
                Type = createRandomCreateSendMessageRequestProperties.Type,

            };

            var randomExternalSendMessageResponse = new ExternalSendMessageResponse
            {

                Balance = createRandomCreateSendMessageResponseProperties.Balance,
                Message= createRandomCreateSendMessageResponseProperties.Message,
                MessageId = createRandomCreateSendMessageResponseProperties.MessageId,
                User = createRandomCreateSendMessageResponseProperties.User
            };


            var randomSendMessageRequest = new SendMessageRequest
            {
                ApiKey = createRandomCreateSendMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendMessageRequestProperties.Channel,
                From = createRandomCreateSendMessageRequestProperties.From,
                To = createRandomCreateSendMessageRequestProperties.To,
                Media = new SendMessageRequest.MessageMedia
                {
                    Caption = createRandomCreateSendMessageRequestProperties.Media.Caption,
                    Url = createRandomCreateSendMessageRequestProperties.Media.Url,
                },
                Sms = createRandomCreateSendMessageRequestProperties.Sms,
                Type = createRandomCreateSendMessageRequestProperties.Type,

            };

            var randomSendMessageResponse = new SendMessageResponse
            {
                Balance = createRandomCreateSendMessageResponseProperties.Balance,
                Message = createRandomCreateSendMessageResponseProperties.Message,
                MessageId = createRandomCreateSendMessageResponseProperties.MessageId,
                User = createRandomCreateSendMessageResponseProperties.User
            };


            var randomSendMessage = new SendMessage
            {
                Request = randomSendMessageRequest,
            };

            SendMessage inputSendMessage = randomSendMessage;
            SendMessage expectedSendMessage = inputSendMessage.DeepClone();
            expectedSendMessage.Response = randomSendMessageResponse;

            ExternalSendMessageRequest mappedExternalSendMessageRequest =
               randomExternalSendMessageRequest;

            ExternalSendMessageResponse returnedExternalSendMessageResponse =
                randomExternalSendMessageResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostMessageAsync(It.Is(
                      SameExternalSendMessageRequestAs(mappedExternalSendMessageRequest))))
                     .ReturnsAsync(returnedExternalSendMessageResponse);

            // when
            SendMessage actualCreateSendMessage =
               await this.switchService.PostMessageRequestAsync(inputSendMessage);

            // then
            actualCreateSendMessage.Should().BeEquivalentTo(expectedSendMessage);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostMessageAsync(It.Is(
                   SameExternalSendMessageRequestAs(mappedExternalSendMessageRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
