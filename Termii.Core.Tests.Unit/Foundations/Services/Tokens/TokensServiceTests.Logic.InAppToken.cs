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
        public async Task ShouldPostInAppTokenWithInAppTokenRequestAsync()
        {
            // given 



            dynamic createRandomInAppTokenRequestProperties =
              CreateRandomInAppTokenRequestProperties();

            dynamic createRandomInAppTokenResponseProperties =
                CreateRandomInAppTokenResponseProperties();


            var randomExternalInAppTokenRequest = new ExternalInAppTokenRequest
            {
                 ApiKey = createRandomInAppTokenRequestProperties.ApiKey,
                 PhoneNumber = createRandomInAppTokenRequestProperties.PhoneNumber,
                 PinAttempts = createRandomInAppTokenRequestProperties.PinAttempts,
                 PinLength = createRandomInAppTokenRequestProperties.PinLength,
                 PinTimeToLive = createRandomInAppTokenRequestProperties.PinTimeToLive,
                 PinType = createRandomInAppTokenRequestProperties.PinType

            };

            var randomExternalInAppTokenResponse = new ExternalInAppTokenResponse
            {

                Data = new ExternalInAppTokenResponse.ExternalData
                {
                   Otp = createRandomInAppTokenResponseProperties.Data.Otp,
                   PhoneNumber = createRandomInAppTokenResponseProperties.Data.PhoneNumber,
                   PhoneNumberOther = createRandomInAppTokenResponseProperties.Data.PhoneNumberOther,
                   PinId = createRandomInAppTokenResponseProperties.Data.PinId
                },
                Status = createRandomInAppTokenResponseProperties.Status,
            };


            var randomInAppTokenRequest = new InAppTokenRequest
            {
                ApiKey = createRandomInAppTokenRequestProperties.ApiKey,
                PhoneNumber = createRandomInAppTokenRequestProperties.PhoneNumber,
                PinAttempts = createRandomInAppTokenRequestProperties.PinAttempts,
                PinLength = createRandomInAppTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomInAppTokenRequestProperties.PinTimeToLive,
                PinType = createRandomInAppTokenRequestProperties.PinType

            };

            var randomInAppTokenResponse = new InAppTokenResponse
            {
                Data = new InAppTokenResponse.InAppData
                {
                    Otp = createRandomInAppTokenResponseProperties.Data.Otp,
                    PhoneNumber = createRandomInAppTokenResponseProperties.Data.PhoneNumber,
                    PhoneNumberOther = createRandomInAppTokenResponseProperties.Data.PhoneNumberOther,
                    PinId = createRandomInAppTokenResponseProperties.Data.PinId
                },
                Status = createRandomInAppTokenResponseProperties.Status,
            };


            var randomInAppToken = new InAppToken
            {
                Request = randomInAppTokenRequest,
            };

            InAppToken inputInAppToken = randomInAppToken;
            InAppToken expectedInAppToken = inputInAppToken.DeepClone();
            expectedInAppToken.Response = randomInAppTokenResponse;

            ExternalInAppTokenRequest mappedExternalInAppTokenRequest =
               randomExternalInAppTokenRequest;

            ExternalInAppTokenResponse returnedExternalInAppTokenResponse =
                randomExternalInAppTokenResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostInAppAsync(It.Is(
                      SameExternalInAppTokenRequestAs(mappedExternalInAppTokenRequest))))
                     .ReturnsAsync(returnedExternalInAppTokenResponse);

            // when
            InAppToken actualCreateInAppToken =
               await this.tokensService.PostInAppAsync(inputInAppToken);

            // then
            actualCreateInAppToken.Should().BeEquivalentTo(expectedInAppToken);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostInAppAsync(It.Is(
                   SameExternalInAppTokenRequestAs(mappedExternalInAppTokenRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
