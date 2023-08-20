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
        public async Task ShouldPostSendTokenWithSendTokenRequestAsync()
        {
            // given 



            dynamic createRandomSendTokenRequestProperties =
              CreateRandomSendTokenRequestProperties();

            dynamic createRandomSendTokenResponseProperties =
                CreateRandomSendTokenResponseProperties();


            var randomExternalSendTokenRequest = new ExternalSendTokenRequest
            {
                 ApiKey = createRandomSendTokenRequestProperties.ApiKey,
                 Channel = createRandomSendTokenRequestProperties.Channel,
                 From = createRandomSendTokenRequestProperties.From,
                 MessageText = createRandomSendTokenRequestProperties.MessageText,
                 MessageType = createRandomSendTokenRequestProperties.MessageType,
                 PinAttempts = createRandomSendTokenRequestProperties.PinAttempts,
                 PinLength = createRandomSendTokenRequestProperties.PinLength,
                 PinPlaceholder = createRandomSendTokenRequestProperties.PinPlaceholder,
                 PinTimeToLive = createRandomSendTokenRequestProperties.PinTimeToLive,
                 PinType = createRandomSendTokenRequestProperties.PinType,
                 To = createRandomSendTokenRequestProperties.To,

            };

            var randomExternalSendTokenResponse = new ExternalSendTokenResponse
            {

                PinId = createRandomSendTokenResponseProperties.PinId,
                SmsStatus = createRandomSendTokenResponseProperties.SmsStatus,
                To = createRandomSendTokenResponseProperties.To,
            };


            var randomSendTokenRequest = new SendTokenRequest
            {
                ApiKey = createRandomSendTokenRequestProperties.ApiKey,
                Channel = createRandomSendTokenRequestProperties.Channel,
                From = createRandomSendTokenRequestProperties.From,
                MessageText = createRandomSendTokenRequestProperties.MessageText,
                MessageType = createRandomSendTokenRequestProperties.MessageType,
                PinAttempts = createRandomSendTokenRequestProperties.PinAttempts,
                PinLength = createRandomSendTokenRequestProperties.PinLength,
                PinPlaceholder = createRandomSendTokenRequestProperties.PinPlaceholder,
                PinTimeToLive = createRandomSendTokenRequestProperties.PinTimeToLive,
                PinType = createRandomSendTokenRequestProperties.PinType,
                To = createRandomSendTokenRequestProperties.To

            };

            var randomSendTokenResponse = new SendTokenResponse
            {
                PinId = createRandomSendTokenResponseProperties.PinId,
                SmsStatus = createRandomSendTokenResponseProperties.SmsStatus,
                To = createRandomSendTokenResponseProperties.To,

            };


            var randomSendToken = new SendToken
            {
                Request = randomSendTokenRequest,
            };

            SendToken inputSendToken = randomSendToken;
            SendToken expectedSendToken = inputSendToken.DeepClone();
            expectedSendToken.Response = randomSendTokenResponse;

            ExternalSendTokenRequest mappedExternalSendTokenRequest =
               randomExternalSendTokenRequest;

            ExternalSendTokenResponse returnedExternalSendTokenResponse =
                randomExternalSendTokenResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostTokenAsync(It.Is(
                      SameExternalSendTokenRequestAs(mappedExternalSendTokenRequest))))
                     .ReturnsAsync(returnedExternalSendTokenResponse);

            // when
            SendToken actualCreateSendToken =
               await this.tokensService.PostTokenAsync(inputSendToken);

            // then
            actualCreateSendToken.Should().BeEquivalentTo(expectedSendToken);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostTokenAsync(It.Is(
                   SameExternalSendTokenRequestAs(mappedExternalSendTokenRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
