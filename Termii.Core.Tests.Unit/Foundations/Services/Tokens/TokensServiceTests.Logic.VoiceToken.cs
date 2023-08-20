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
        public async Task ShouldPostVoiceTokenWithVoiceTokenRequestAsync()
        {
            // given 



            dynamic createRandomVoiceTokenRequestProperties =
              CreateRandomVoiceTokenRequestProperties();

            dynamic createRandomVoiceTokenResponseProperties =
                CreateRandomVoiceTokenResponseProperties();


            var randomExternalVoiceTokenRequest = new ExternalVoiceTokenRequest
            {
                 ApiKey = createRandomVoiceTokenRequestProperties.ApiKey,
                 PinTimeToLive  = createRandomVoiceTokenRequestProperties.PinTimeToLive,
                 PhoneNumber = createRandomVoiceTokenRequestProperties.PhoneNumber,
                 PinAttempts = createRandomVoiceTokenRequestProperties.PinAttempts,
                 PinLength = createRandomVoiceTokenRequestProperties.PinLength,
            };

            var randomExternalVoiceTokenResponse = new ExternalVoiceTokenResponse
            {

                PinId = createRandomVoiceTokenResponseProperties.PinId,
                Balance = createRandomVoiceTokenResponseProperties.Balance,
                Code = createRandomVoiceTokenResponseProperties.Code,
                Message = createRandomVoiceTokenResponseProperties.Message,
                MessageId = createRandomVoiceTokenResponseProperties.MessageId,
                User = createRandomVoiceTokenResponseProperties.User,
            };


            var randomVoiceTokenRequest = new VoiceTokenRequest
            {
                ApiKey = createRandomVoiceTokenRequestProperties.ApiKey,
                PinTimeToLive = createRandomVoiceTokenRequestProperties.PinTimeToLive,
                PhoneNumber = createRandomVoiceTokenRequestProperties.PhoneNumber,
                PinAttempts = createRandomVoiceTokenRequestProperties.PinAttempts,
                PinLength = createRandomVoiceTokenRequestProperties.PinLength,

            };

            var randomVoiceTokenResponse = new VoiceTokenResponse
            {
                PinId = createRandomVoiceTokenResponseProperties.PinId,
                Balance = createRandomVoiceTokenResponseProperties.Balance,
                Code = createRandomVoiceTokenResponseProperties.Code,
                Message = createRandomVoiceTokenResponseProperties.Message,
                MessageId = createRandomVoiceTokenResponseProperties.MessageId,
                User = createRandomVoiceTokenResponseProperties.User,

            };


            var randomVoiceToken = new VoiceToken
            {
                Request = randomVoiceTokenRequest,
            };

            VoiceToken inputVoiceToken = randomVoiceToken;
            VoiceToken expectedVoiceToken = inputVoiceToken.DeepClone();
            expectedVoiceToken.Response = randomVoiceTokenResponse;

            ExternalVoiceTokenRequest mappedExternalVoiceTokenRequest =
               randomExternalVoiceTokenRequest;

            ExternalVoiceTokenResponse returnedExternalVoiceTokenResponse =
                randomExternalVoiceTokenResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostVoiceTokenAsync(It.Is(
                      SameExternalVoiceTokenRequestAs(mappedExternalVoiceTokenRequest))))
                     .ReturnsAsync(returnedExternalVoiceTokenResponse);

            // when
            VoiceToken actualCreateVoiceToken =
               await this.tokensService.PostVoiceTokenAsync(inputVoiceToken);

            // then
            actualCreateVoiceToken.Should().BeEquivalentTo(expectedVoiceToken);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostVoiceTokenAsync(It.Is(
                   SameExternalVoiceTokenRequestAs(mappedExternalVoiceTokenRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
