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
        public async Task ShouldThrowDependencyExceptionOnPostVerifyTokenRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomVerifyTokenRequestProperties =
               CreateRandomVerifyTokenRequestProperties();


            var randomVerifyTokenRequest = new VerifyTokenRequest
            {
                ApiKey = createRandomVerifyTokenRequestProperties.ApiKey,
                Pin = createRandomVerifyTokenRequestProperties.Pin,
                PinId = createRandomVerifyTokenRequestProperties.PinId,
             

            };

            var randomVerifyToken = new VerifyToken
            {
                Request = randomVerifyTokenRequest
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
                broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<VerifyToken> retrieveTokensTask =
               this.tokensService.PostVerifyTokenAsync(randomVerifyToken);

            TokensDependencyException
                actualTokensDependencyException =
                    await Assert.ThrowsAsync<TokensDependencyException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostVerifyTokenRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomVerifyTokenRequestProperties =
             CreateRandomVerifyTokenRequestProperties();




            var randomVerifyTokenRequest = new VerifyTokenRequest
            {
                ApiKey = createRandomVerifyTokenRequestProperties.ApiKey,
                Pin = createRandomVerifyTokenRequestProperties.Pin,
                PinId = createRandomVerifyTokenRequestProperties.PinId,




            };

            var randomVerifyToken = new VerifyToken
            {
                Request = randomVerifyTokenRequest
            };

            var unauthorizedTokensException =
                new UnauthorizedTokensException(unauthorizedException);

            var expectedTokensDependencyException =
                new TokensDependencyException(unauthorizedTokensException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<VerifyToken> retrieveTokensTask =
               this.tokensService.PostVerifyTokenAsync(randomVerifyToken);

            TokensDependencyException
                actualTokensDependencyException =
                    await Assert.ThrowsAsync<TokensDependencyException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostVerifyTokenRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomVerifyTokenRequestProperties =
              CreateRandomVerifyTokenRequestProperties();




            var randomVerifyTokenRequest = new VerifyTokenRequest
            {
                ApiKey = createRandomVerifyTokenRequestProperties.ApiKey,
                Pin = createRandomVerifyTokenRequestProperties.Pin,
                PinId = createRandomVerifyTokenRequestProperties.PinId,




            };

            var randomVerifyToken = new VerifyToken
            {
                Request = randomVerifyTokenRequest
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
                broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<VerifyToken> retrieveTokensTask =
               this.tokensService.PostVerifyTokenAsync(randomVerifyToken);

            TokensDependencyValidationException
                actualTokensDependencyValidationException =
                    await Assert.ThrowsAsync<TokensDependencyValidationException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostVerifyTokenRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomVerifyTokenRequestProperties =
          CreateRandomVerifyTokenRequestProperties();


            var randomVerifyTokenRequest = new VerifyTokenRequest
            {
                ApiKey = createRandomVerifyTokenRequestProperties.ApiKey,
                Pin = createRandomVerifyTokenRequestProperties.Pin,
                PinId = createRandomVerifyTokenRequestProperties.PinId,




            };

            var randomVerifyToken = new VerifyToken
            {
                Request = randomVerifyTokenRequest
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
                broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<VerifyToken> retrieveTokensTask =
               this.tokensService.PostVerifyTokenAsync(randomVerifyToken);

            TokensDependencyValidationException
                actualTokensDependencyValidationException =
                    await Assert.ThrowsAsync<TokensDependencyValidationException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostVerifyTokenRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomVerifyTokenRequestProperties =
          CreateRandomVerifyTokenRequestProperties();


            var randomVerifyTokenRequest = new VerifyTokenRequest
            {
                ApiKey = createRandomVerifyTokenRequestProperties.ApiKey,
                Pin = createRandomVerifyTokenRequestProperties.Pin,
                PinId = createRandomVerifyTokenRequestProperties.PinId,




            };

            var randomVerifyToken = new VerifyToken
            {
                Request = randomVerifyTokenRequest
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
                 broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<VerifyToken> retrieveTokensTask =
               this.tokensService.PostVerifyTokenAsync(randomVerifyToken);

            TokensDependencyValidationException actualTokensDependencyValidationException =
                await Assert.ThrowsAsync<TokensDependencyValidationException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostVerifyTokenRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomVerifyTokenRequestProperties =
          CreateRandomVerifyTokenRequestProperties();


            var randomVerifyTokenRequest = new VerifyTokenRequest
            {
                ApiKey = createRandomVerifyTokenRequestProperties.ApiKey,
                Pin = createRandomVerifyTokenRequestProperties.Pin,
                PinId = createRandomVerifyTokenRequestProperties.PinId,




            };

            var randomVerifyToken = new VerifyToken
            {
                Request = randomVerifyTokenRequest
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
                 broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<VerifyToken> retrieveTokensTask =
               this.tokensService.PostVerifyTokenAsync(randomVerifyToken);

            TokensDependencyException actualTokensDependencyException =
                await Assert.ThrowsAsync<TokensDependencyException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostVerifyTokenRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomVerifyTokenRequestProperties =
            CreateRandomVerifyTokenRequestProperties();


            var randomVerifyTokenRequest = new VerifyTokenRequest
            {
                ApiKey = createRandomVerifyTokenRequestProperties.ApiKey,
                Pin = createRandomVerifyTokenRequestProperties.Pin,
                PinId = createRandomVerifyTokenRequestProperties.PinId,




            };

            var randomVerifyToken = new VerifyToken
            {
                Request = randomVerifyTokenRequest
            };

            var serviceException = new Exception();

            var failedTokensServiceException =
                new FailedTokensServiceException(serviceException);

            var expectedTokensServiceException =
                new TokensServiceException(failedTokensServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<VerifyToken> retrieveTokensTask =
               this.tokensService.PostVerifyTokenAsync(randomVerifyToken);

            TokensServiceException actualTokensServiceException =
                await Assert.ThrowsAsync<TokensServiceException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensServiceException.Should().BeEquivalentTo(
                expectedTokensServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVerifyTokenAsync(It.IsAny<ExternalVerifyTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}