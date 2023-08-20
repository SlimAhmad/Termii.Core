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
        public async Task ShouldPostEmailTokenWithEmailTokenRequestAsync()
        {
            // given 



            dynamic createRandomEmailTokenRequestProperties =
              CreateRandomEmailTokenRequestProperties();

            dynamic createRandomEmailTokenResponseProperties =
                CreateRandomEmailTokenResponseProperties();


            var randomExternalEmailTokenRequest = new ExternalEmailTokenRequest
            {
                 ApiKey = createRandomEmailTokenRequestProperties.ApiKey,
                 Code = createRandomEmailTokenRequestProperties.Code,
                 EmailAddress = createRandomEmailTokenRequestProperties.EmailAddress,
                 EmailConfigurationId = createRandomEmailTokenRequestProperties.EmailConfigurationId

            };

            var randomExternalEmailTokenResponse = new ExternalEmailTokenResponse
            {

                Code = createRandomEmailTokenResponseProperties.Code,
                Balance = createRandomEmailTokenResponseProperties.Balance,
                Message = createRandomEmailTokenResponseProperties.Message,
                MessageId = createRandomEmailTokenResponseProperties.MessageId,
                User = createRandomEmailTokenResponseProperties.User
            };  


            var randomEmailTokenRequest = new EmailTokenRequest
            {
                ApiKey = createRandomEmailTokenRequestProperties.ApiKey,
                Code = createRandomEmailTokenRequestProperties.Code,
                EmailAddress = createRandomEmailTokenRequestProperties.EmailAddress,
                EmailConfigurationId = createRandomEmailTokenRequestProperties.EmailConfigurationId

            };

            var randomEmailTokenResponse = new EmailTokenResponse
            {
                Code = createRandomEmailTokenResponseProperties.Code,
                Balance = createRandomEmailTokenResponseProperties.Balance,
                Message = createRandomEmailTokenResponseProperties.Message,
                MessageId = createRandomEmailTokenResponseProperties.MessageId,
                User = createRandomEmailTokenResponseProperties.User

            };


            var randomEmailToken = new EmailToken
            {
                Request = randomEmailTokenRequest,
            };

            EmailToken inputEmailToken = randomEmailToken;
            EmailToken expectedEmailToken = inputEmailToken.DeepClone();
            expectedEmailToken.Response = randomEmailTokenResponse;

            ExternalEmailTokenRequest mappedExternalEmailTokenRequest =
               randomExternalEmailTokenRequest;

            ExternalEmailTokenResponse returnedExternalEmailTokenResponse =
                randomExternalEmailTokenResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostEmailTokenAsync(It.Is(
                      SameExternalEmailTokenRequestAs(mappedExternalEmailTokenRequest))))
                     .ReturnsAsync(returnedExternalEmailTokenResponse);

            // when
            EmailToken actualCreateEmailToken =
               await this.tokensService.PostSendEmailTokenAsync(inputEmailToken);

            // then
            actualCreateEmailToken.Should().BeEquivalentTo(expectedEmailToken);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostEmailTokenAsync(It.Is(
                   SameExternalEmailTokenRequestAs(mappedExternalEmailTokenRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
