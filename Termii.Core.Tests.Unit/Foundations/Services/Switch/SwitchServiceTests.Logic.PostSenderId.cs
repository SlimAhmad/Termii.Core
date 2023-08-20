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
        public async Task ShouldPostSenderIdWithSenderIdRequestAsync()
        {
            // given 



            dynamic createRandomCreateSenderIdRequestProperties =
              CreateRandomCreateSenderIdRequestProperties();

            dynamic createRandomCreateSenderIdResponseProperties =
                CreateRandomCreateSenderIdResponseProperties();


            var randomExternalCreateSenderIdRequest = new ExternalCreateSenderIdRequest
            {
                ApiKey = createRandomCreateSenderIdRequestProperties.ApiKey,
                Company = createRandomCreateSenderIdRequestProperties.Company,
                SenderId = createRandomCreateSenderIdRequestProperties.SenderId,
                Usecase = createRandomCreateSenderIdRequestProperties.Usecase

            };

            var randomExternalCreateSenderIdResponse = new ExternalCreateSenderIdResponse
            {

                Code = createRandomCreateSenderIdResponseProperties.Code,
                Message= createRandomCreateSenderIdResponseProperties.Message,
                
            };


            var randomCreateSenderIdRequest = new CreateSenderIdRequest
            {
                ApiKey = createRandomCreateSenderIdRequestProperties.ApiKey,
                Company = createRandomCreateSenderIdRequestProperties.Company,
                SenderId = createRandomCreateSenderIdRequestProperties.SenderId,
                Usecase = createRandomCreateSenderIdRequestProperties.Usecase

            };

            var randomCreateSenderIdResponse = new CreateSenderIdResponse
            {
                Code = createRandomCreateSenderIdResponseProperties.Code,
                Message = createRandomCreateSenderIdResponseProperties.Message,
            };


            var randomCreateSenderId = new CreateSenderId
            {
                Request = randomCreateSenderIdRequest,
            };

            CreateSenderId inputSenderId = randomCreateSenderId;
            CreateSenderId expectedSenderId = inputSenderId.DeepClone();
            expectedSenderId.Response = randomCreateSenderIdResponse;

            ExternalCreateSenderIdRequest mappedExternalCreateSenderIdRequest =
               randomExternalCreateSenderIdRequest;

            ExternalCreateSenderIdResponse returnedExternalCreateSenderIdResponse =
                randomExternalCreateSenderIdResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostSenderIdAsync(It.Is(
                      SameExternalCreateSenderIdRequestAs(mappedExternalCreateSenderIdRequest))))
                     .ReturnsAsync(returnedExternalCreateSenderIdResponse);

            // when
            CreateSenderId actualCreateSenderId =
               await this.switchService.PostSenderIdRequestAsync(inputSenderId);

            // then
            actualCreateSenderId.Should().BeEquivalentTo(expectedSenderId);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostSenderIdAsync(It.Is(
                   SameExternalCreateSenderIdRequestAs(mappedExternalCreateSenderIdRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
