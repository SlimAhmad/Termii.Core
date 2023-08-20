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
        public async Task ShouldPostVerifyTokenWithVerifyTokenRequestAsync()
        {
            // given 



            dynamic createRandomVerifyTokenRequestProperties =
              CreateRandomVerifyTokenRequestProperties();

            dynamic createRandomVerifyTokenResponseProperties =
                CreateRandomVerifyTokenResponseProperties();


            var randomExternalVerifyTokenRequest = new ExternalVerifyTokenRequest
            {
                 ApiKey = createRandomVerifyTokenRequestProperties.ApiKey,
                 Pin = createRandomVerifyTokenRequestProperties.Pin,
                 PinId = createRandomVerifyTokenRequestProperties.PinId,

            };

            var randomExternalVerifyTokenResponse = new ExternalVerifyTokenResponse
            {

                PinId = createRandomVerifyTokenResponseProperties.PinId,
                Msisdn = createRandomVerifyTokenResponseProperties.Msisdn,
                Verified = createRandomVerifyTokenResponseProperties.Verified,
            };


            var randomVerifyTokenRequest = new VerifyTokenRequest
            {
                ApiKey = createRandomVerifyTokenRequestProperties.ApiKey,
                Pin = createRandomVerifyTokenRequestProperties.Pin,
                PinId = createRandomVerifyTokenRequestProperties.PinId,

            };

            var randomVerifyTokenResponse = new VerifyTokenResponse
            {
                PinId = createRandomVerifyTokenResponseProperties.PinId,
                Msisdn = createRandomVerifyTokenResponseProperties.Msisdn,
                Verified = createRandomVerifyTokenResponseProperties.Verified,

            };


            var randomVerifyToken = new VerifyToken
            {
                Request = randomVerifyTokenRequest,
            };

            VerifyToken inputVerifyToken = randomVerifyToken;
            VerifyToken expectedVerifyToken = inputVerifyToken.DeepClone();
            expectedVerifyToken.Response = randomVerifyTokenResponse;

            ExternalVerifyTokenRequest mappedExternalVerifyTokenRequest =
               randomExternalVerifyTokenRequest;

            ExternalVerifyTokenResponse returnedExternalVerifyTokenResponse =
                randomExternalVerifyTokenResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostVerifyTokenAsync(It.Is(
                      SameExternalVerifyTokenRequestAs(mappedExternalVerifyTokenRequest))))
                     .ReturnsAsync(returnedExternalVerifyTokenResponse);

            // when
            VerifyToken actualCreateVerifyToken =
               await this.tokensService.PostVerifyTokenAsync(inputVerifyToken);

            // then
            actualCreateVerifyToken.Should().BeEquivalentTo(expectedVerifyToken);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostVerifyTokenAsync(It.Is(
                   SameExternalVerifyTokenRequestAs(mappedExternalVerifyTokenRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
