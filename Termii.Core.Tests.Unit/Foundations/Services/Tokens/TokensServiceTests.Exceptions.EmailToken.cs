using FluentAssertions;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;
using Moq;
using RESTFulSense.Exceptions;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using System;

namespace Termii.Core.Tests.Unit.Foundations.Services.Tokens
{
    public partial class TokensServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostEmailTokenRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomEmailTokenRequestProperties =
               CreateRandomEmailTokenRequestProperties();


            var randomEmailTokenRequest = new EmailTokenRequest
            {
                ApiKey = createRandomEmailTokenRequestProperties.ApiKey,
                Code = createRandomEmailTokenRequestProperties.Code,
                EmailAddress = createRandomEmailTokenRequestProperties.EmailAddress,
                EmailConfigurationId = createRandomEmailTokenRequestProperties.EmailConfigurationId,
             

            };

            var randomEmailToken = new EmailToken
            {
                Request = randomEmailTokenRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTokensException =
                new InvalidConfigurationTokensException(
                    httpResponseUrlNotFoundException);

            var expectedTokensDependencyException =
                new TokensDependencyException(
                    invalidConfigurationTokensException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<EmailToken> retrieveTokensTask =
               this.tokensService.PostSendEmailTokenAsync(randomEmailToken);

            TokensDependencyException
                actualTokensDependencyException =
                    await Assert.ThrowsAsync<TokensDependencyException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostEmailTokenRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomEmailTokenRequestProperties =
             CreateRandomEmailTokenRequestProperties();




            var randomEmailTokenRequest = new EmailTokenRequest
            {
                ApiKey = createRandomEmailTokenRequestProperties.ApiKey,
                Code = createRandomEmailTokenRequestProperties.Code,
                EmailAddress = createRandomEmailTokenRequestProperties.EmailAddress,
                EmailConfigurationId = createRandomEmailTokenRequestProperties.EmailConfigurationId,




            };

            var randomEmailToken = new EmailToken
            {
                Request = randomEmailTokenRequest
            };

            var unauthorizedTokensException =
                new UnauthorizedTokensException(unauthorizedException);

            var expectedTokensDependencyException =
                new TokensDependencyException(unauthorizedTokensException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<EmailToken> retrieveTokensTask =
               this.tokensService.PostSendEmailTokenAsync(randomEmailToken);

            TokensDependencyException
                actualTokensDependencyException =
                    await Assert.ThrowsAsync<TokensDependencyException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostEmailTokenRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomEmailTokenRequestProperties =
              CreateRandomEmailTokenRequestProperties();




            var randomEmailTokenRequest = new EmailTokenRequest
            {
                 ApiKey = createRandomEmailTokenRequestProperties.ApiKey,
                Code = createRandomEmailTokenRequestProperties.Code,
                EmailAddress = createRandomEmailTokenRequestProperties.EmailAddress,
                EmailConfigurationId = createRandomEmailTokenRequestProperties.EmailConfigurationId,




            };

            var randomEmailToken = new EmailToken
            {
                Request = randomEmailTokenRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTokensException =
                new NotFoundTokensException(
                    httpResponseNotFoundException);

            var expectedTokensDependencyValidationException =
                new TokensDependencyValidationException(
                    notFoundTokensException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<EmailToken> retrieveTokensTask =
               this.tokensService.PostSendEmailTokenAsync(randomEmailToken);

            TokensDependencyValidationException
                actualTokensDependencyValidationException =
                    await Assert.ThrowsAsync<TokensDependencyValidationException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostEmailTokenRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomEmailTokenRequestProperties =
          CreateRandomEmailTokenRequestProperties();


            var randomEmailTokenRequest = new EmailTokenRequest
            {
                 ApiKey = createRandomEmailTokenRequestProperties.ApiKey,
                Code = createRandomEmailTokenRequestProperties.Code,
                EmailAddress = createRandomEmailTokenRequestProperties.EmailAddress,
                EmailConfigurationId = createRandomEmailTokenRequestProperties.EmailConfigurationId,




            };

            var randomEmailToken = new EmailToken
            {
                Request = randomEmailTokenRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTokensException =
                new InvalidTokensException(
                    httpResponseBadRequestException);

            var expectedTokensDependencyValidationException =
                new TokensDependencyValidationException(
                    invalidTokensException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<EmailToken> retrieveTokensTask =
               this.tokensService.PostSendEmailTokenAsync(randomEmailToken);

            TokensDependencyValidationException
                actualTokensDependencyValidationException =
                    await Assert.ThrowsAsync<TokensDependencyValidationException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostEmailTokenRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomEmailTokenRequestProperties =
          CreateRandomEmailTokenRequestProperties();


            var randomEmailTokenRequest = new EmailTokenRequest
            {
                 ApiKey = createRandomEmailTokenRequestProperties.ApiKey,
                Code = createRandomEmailTokenRequestProperties.Code,
                EmailAddress = createRandomEmailTokenRequestProperties.EmailAddress,
                EmailConfigurationId = createRandomEmailTokenRequestProperties.EmailConfigurationId,




            };

            var randomEmailToken = new EmailToken
            {
                Request = randomEmailTokenRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTokensException =
                new ExcessiveCallTokensException(
                    httpResponseTooManyRequestsException);

            var expectedTokensDependencyValidationException =
                new TokensDependencyValidationException(
                    excessiveCallTokensException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<EmailToken> retrieveTokensTask =
               this.tokensService.PostSendEmailTokenAsync(randomEmailToken);

            TokensDependencyValidationException actualTokensDependencyValidationException =
                await Assert.ThrowsAsync<TokensDependencyValidationException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostEmailTokenRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomEmailTokenRequestProperties =
          CreateRandomEmailTokenRequestProperties();


            var randomEmailTokenRequest = new EmailTokenRequest
            {
                 ApiKey = createRandomEmailTokenRequestProperties.ApiKey,
                Code = createRandomEmailTokenRequestProperties.Code,
                EmailAddress = createRandomEmailTokenRequestProperties.EmailAddress,
                EmailConfigurationId = createRandomEmailTokenRequestProperties.EmailConfigurationId,




            };

            var randomEmailToken = new EmailToken
            {
                Request = randomEmailTokenRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerTokensException =
                new FailedServerTokensException(
                    httpResponseException);

            var expectedTokensDependencyException =
                new TokensDependencyException(
                    failedServerTokensException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<EmailToken> retrieveTokensTask =
               this.tokensService.PostSendEmailTokenAsync(randomEmailToken);

            TokensDependencyException actualTokensDependencyException =
                await Assert.ThrowsAsync<TokensDependencyException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostEmailTokenRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomEmailTokenRequestProperties =
            CreateRandomEmailTokenRequestProperties();


            var randomEmailTokenRequest = new EmailTokenRequest
            {
                 ApiKey = createRandomEmailTokenRequestProperties.ApiKey,
                Code = createRandomEmailTokenRequestProperties.Code,
                EmailAddress = createRandomEmailTokenRequestProperties.EmailAddress,
                EmailConfigurationId = createRandomEmailTokenRequestProperties.EmailConfigurationId,




            };

            var randomEmailToken = new EmailToken
            {
                Request = randomEmailTokenRequest
            };

            var serviceException = new Exception();

            var failedTokensServiceException =
                new FailedTokensServiceException(serviceException);

            var expectedTokensServiceException =
                new TokensServiceException(failedTokensServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<EmailToken> retrieveTokensTask =
               this.tokensService.PostSendEmailTokenAsync(randomEmailToken);

            TokensServiceException actualTokensServiceException =
                await Assert.ThrowsAsync<TokensServiceException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensServiceException.Should().BeEquivalentTo(
                expectedTokensServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostEmailTokenAsync(It.IsAny<ExternalEmailTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}