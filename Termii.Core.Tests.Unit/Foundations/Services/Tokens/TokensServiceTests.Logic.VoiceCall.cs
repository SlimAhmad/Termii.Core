using FluentAssertions;
using Force.DeepCloner;
using Moq;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;

namespace Termii.Core.Tests.Unit.Foundations.Services.Tokens
{
    public partial class TokensServiceTests
    {
        [Fact]
        public async Task ShouldPostVoiceCallWithVoiceCallRequestAsync()
        {
            // given 



            dynamic createRandomVoiceCallRequestProperties =
              CreateRandomVoiceCallRequestProperties();

            dynamic createRandomVoiceCallResponseProperties =
                CreateRandomVoiceCallResponseProperties();


            var randomExternalVoiceCallRequest = new ExternalVoiceCallRequest
            {
                 ApiKey = createRandomVoiceCallRequestProperties.ApiKey,
                 Code = createRandomVoiceCallRequestProperties.Code,
                 PhoneNumber = createRandomVoiceCallRequestProperties.PhoneNumber,

            };

            var randomExternalVoiceCallResponse = new ExternalVoiceCallResponse
            {

                PinId = createRandomVoiceCallResponseProperties.PinId,
                Code = createRandomVoiceCallResponseProperties.Code,
                Balance = createRandomVoiceCallResponseProperties.Balance,
                Message = createRandomVoiceCallResponseProperties.Message,
                MessageId = createRandomVoiceCallResponseProperties.MessageId,
                User = createRandomVoiceCallResponseProperties.User,
            };


            var randomVoiceCallRequest = new VoiceCallRequest
            {
                ApiKey = createRandomVoiceCallRequestProperties.ApiKey,
                Code = createRandomVoiceCallRequestProperties.Code,
                PhoneNumber = createRandomVoiceCallRequestProperties.PhoneNumber,

            };

            var randomVoiceCallResponse = new VoiceCallResponse
            {
                PinId = createRandomVoiceCallResponseProperties.PinId,
                Code = createRandomVoiceCallResponseProperties.Code,
                Balance = createRandomVoiceCallResponseProperties.Balance,
                Message = createRandomVoiceCallResponseProperties.Message,
                MessageId = createRandomVoiceCallResponseProperties.MessageId,
                User = createRandomVoiceCallResponseProperties.User,

            };


            var randomVoiceCall = new VoiceCall
            {
                Request = randomVoiceCallRequest,
            };

            VoiceCall inputVoiceCall = randomVoiceCall;
            VoiceCall expectedVoiceCall = inputVoiceCall.DeepClone();
            expectedVoiceCall.Response = randomVoiceCallResponse;

            ExternalVoiceCallRequest mappedExternalVoiceCallRequest =
               randomExternalVoiceCallRequest;

            ExternalVoiceCallResponse returnedExternalVoiceCallResponse =
                randomExternalVoiceCallResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostVoiceCallAsync(It.Is(
                      SameExternalVoiceCallRequestAs(mappedExternalVoiceCallRequest))))
                     .ReturnsAsync(returnedExternalVoiceCallResponse);

            // when
            VoiceCall actualCreateVoiceCall =
               await this.tokensService.PostVoiceCallAsync(inputVoiceCall);

            // then
            actualCreateVoiceCall.Should().BeEquivalentTo(expectedVoiceCall);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostVoiceCallAsync(It.Is(
                   SameExternalVoiceCallRequestAs(mappedExternalVoiceCallRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
