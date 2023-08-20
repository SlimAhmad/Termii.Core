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
        public async Task ShouldPostTemplatedMessageWithTemplatedMessageRequestAsync()
        {
            // given 



            dynamic createRandomCreateTemplatedMessageRequestProperties =
              CreateRandomCreateTemplatedMessageRequestProperties();

            dynamic createRandomCreateTemplatedMessageResponseProperties =
                CreateRandomCreateTemplatedMessageResponseProperties();


            var randomExternalTemplatedMessageRequest = new ExternalTemplatedMessageRequest
            {
                ApiKey = createRandomCreateTemplatedMessageRequestProperties.ApiKey,
                DeviceId = createRandomCreateTemplatedMessageRequestProperties.DeviceId,
                PhoneNumber = createRandomCreateTemplatedMessageRequestProperties.PhoneNumber,
                TemplateId = createRandomCreateTemplatedMessageRequestProperties.TemplateId,
                Data = new ExternalTemplatedMessageRequest.ExternalData
                {
                   ExpiryTime = createRandomCreateTemplatedMessageRequestProperties.Data.ExpiryTime,
                   Otp = createRandomCreateTemplatedMessageRequestProperties.Data.Otp,
                   ProductName = createRandomCreateTemplatedMessageRequestProperties.Data.ProductName

                }
                


            };

            var randomExternalCreateTemplatedMessageResponse = new ExternalTemplatedMessageResponse
            {

                Code = createRandomCreateTemplatedMessageResponseProperties.Code,
                Message= createRandomCreateTemplatedMessageResponseProperties.Message,
                Balance = createRandomCreateTemplatedMessageResponseProperties.Balance,
                MessageId = createRandomCreateTemplatedMessageResponseProperties.MessageId,
                User = createRandomCreateTemplatedMessageResponseProperties.User,
                
                   
            };


            var randomTemplatedMessageRequest = new TemplatedMessageRequest
            {
                ApiKey = createRandomCreateTemplatedMessageRequestProperties.ApiKey,
                DeviceId = createRandomCreateTemplatedMessageRequestProperties.DeviceId,
                PhoneNumber = createRandomCreateTemplatedMessageRequestProperties.PhoneNumber,
                TemplateId = createRandomCreateTemplatedMessageRequestProperties.TemplateId,
                Data = new TemplatedMessageRequest.ExternalData
                {
                    ExpiryTime = createRandomCreateTemplatedMessageRequestProperties.Data.ExpiryTime,
                    Otp = createRandomCreateTemplatedMessageRequestProperties.Data.Otp,
                    ProductName = createRandomCreateTemplatedMessageRequestProperties.Data.ProductName

                }

            };

            var randomTemplatedMessageResponse = new TemplatedMessageResponse
            {
                Code = createRandomCreateTemplatedMessageResponseProperties.Code,
                Message = createRandomCreateTemplatedMessageResponseProperties.Message,
                Balance = createRandomCreateTemplatedMessageResponseProperties.Balance,
                MessageId = createRandomCreateTemplatedMessageResponseProperties.MessageId,
                User = createRandomCreateTemplatedMessageResponseProperties.User,
            };


            var randomTemplatedMessage = new TemplatedMessage
            {
                Request = randomTemplatedMessageRequest,
            };

            TemplatedMessage inputTemplatedMessage = randomTemplatedMessage;
            TemplatedMessage expectedTemplatedMessage = inputTemplatedMessage.DeepClone();
            expectedTemplatedMessage.Response = randomTemplatedMessageResponse;

            ExternalTemplatedMessageRequest mappedExternalCreateTemplatedMessageRequest =
               randomExternalTemplatedMessageRequest;

            ExternalTemplatedMessageResponse returnedExternalCreateTemplatedMessageResponse =
                randomExternalCreateTemplatedMessageResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostTemplatedMessageAsync(It.Is(
                      SameExternalTemplatedMessageRequestAs(mappedExternalCreateTemplatedMessageRequest))))
                     .ReturnsAsync(returnedExternalCreateTemplatedMessageResponse);

            // when
            TemplatedMessage actualCreateTemplatedMessage =
               await this.switchService.PostTemplatedMessageRequestAsync(inputTemplatedMessage);

            // then
            actualCreateTemplatedMessage.Should().BeEquivalentTo(expectedTemplatedMessage);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostTemplatedMessageAsync(It.Is(
                   SameExternalTemplatedMessageRequestAs(mappedExternalCreateTemplatedMessageRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
