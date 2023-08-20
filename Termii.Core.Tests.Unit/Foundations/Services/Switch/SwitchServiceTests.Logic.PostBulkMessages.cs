using FluentAssertions;
using Force.DeepCloner;
using Moq;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;
using Termii.Core.Models.Services.Foundations.Termii.Switch;

namespace Termii.Core.Tests.Unit.Foundations.Services.Switch
{
    public partial class SwitchServiceTests
    {
        [Fact]
        public async Task ShouldPostSendBulkMessageWithSendBulkMessageRequestAsync()
        {
            // given 



            dynamic createRandomCreateSendBulkMessageRequestProperties =
               CreateRandomCreateSendBulkMessageRequestProperties();

            dynamic createRandomCreateSendBulkMessageResponseProperties =
                CreateRandomCreateSendBulkMessageResponseProperties();


            var randomExternalSendBulkMessageRequest = new ExternalSendBulkMessageRequest
            {
                ApiKey = createRandomCreateSendBulkMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendBulkMessageRequestProperties.Channel,
                From = createRandomCreateSendBulkMessageRequestProperties.From,
                Sms = createRandomCreateSendBulkMessageRequestProperties.Sms,
                To = createRandomCreateSendBulkMessageRequestProperties.To,
                Type = createRandomCreateSendBulkMessageRequestProperties.Type



            };

            var randomExternalSendBulkMessageResponse = new ExternalSendBulkMessageResponse
            {

                Code = createRandomCreateSendBulkMessageResponseProperties.Code,
                Message= createRandomCreateSendBulkMessageResponseProperties.Message,
                
            };


            var randomSendBulkMessageRequest = new SendBulkMessageRequest
            {
                ApiKey = createRandomCreateSendBulkMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendBulkMessageRequestProperties.Channel,
                From = createRandomCreateSendBulkMessageRequestProperties.From,
                Sms = createRandomCreateSendBulkMessageRequestProperties.Sms,
                To = createRandomCreateSendBulkMessageRequestProperties.To,
                Type = createRandomCreateSendBulkMessageRequestProperties.Type

            };

            var randomCreateSendBulkMessageResponse = new SendBulkMessageResponse
            {
                Code = createRandomCreateSendBulkMessageResponseProperties.Code,
                Message = createRandomCreateSendBulkMessageResponseProperties.Message,
               
            };


            var randomCreateSendBulkMessage = new SendBulkMessage
            {
                Request = randomSendBulkMessageRequest,
            };

            SendBulkMessage inputSendBulkMessage = randomCreateSendBulkMessage;
            SendBulkMessage expectedSendBulkMessage = inputSendBulkMessage.DeepClone();
            expectedSendBulkMessage.Response = randomCreateSendBulkMessageResponse;

            ExternalSendBulkMessageRequest mappedExternalSendBulkMessageRequest =
               randomExternalSendBulkMessageRequest;

            ExternalSendBulkMessageResponse returnedExternalSendBulkMessageResponse =
                randomExternalSendBulkMessageResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostBulkMessagesAsync(It.Is(
                      SameExternalSendBulkMessageRequestAs(mappedExternalSendBulkMessageRequest))))
                     .ReturnsAsync(returnedExternalSendBulkMessageResponse);

            // when
            SendBulkMessage actualCreateSendBulkMessage =
               await this.switchService.PostBulkMessagesRequestAsync(inputSendBulkMessage);

            // then
            actualCreateSendBulkMessage.Should().BeEquivalentTo(expectedSendBulkMessage);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostBulkMessagesAsync(It.Is(
                   SameExternalSendBulkMessageRequestAs(mappedExternalSendBulkMessageRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
