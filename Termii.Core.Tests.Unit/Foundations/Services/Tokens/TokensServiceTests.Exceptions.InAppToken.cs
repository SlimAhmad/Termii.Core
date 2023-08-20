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
        public async Task ShouldThrowDependencyExceptionOnPostInAppTokenRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomInAppTokenRequestProperties =
               CreateRandomInAppTokenRequestProperties();


            var randomInAppTokenRequest = new InAppTokenRequest
            {
                ApiKey = createRandomInAppTokenRequestProperties.ApiKey,
                PinAttempts = createRandomInAppTokenRequestProperties.PinAttempts,
                PinLength = createRandomInAppTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomInAppTokenRequestProperties.PinTimeToLive,
                PhoneNumber = createRandomInAppTokenRequestProperties.PhoneNumber,
                PinType = createRandomInAppTokenRequestProperties.PinType
             

            };

            var randomInAppToken = new InAppToken
            {
                Request = randomInAppTokenRequest
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
                broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<InAppToken> retrieveTokensTask =
               this.tokensService.PostInAppAsync(randomInAppToken);

            TokensDependencyException
                actualTokensDependencyException =
                    await Assert.ThrowsAsync<TokensDependencyException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostInAppTokenRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomInAppTokenRequestProperties =
             CreateRandomInAppTokenRequestProperties();




            var randomInAppTokenRequest = new InAppTokenRequest
            {
                ApiKey = createRandomInAppTokenRequestProperties.ApiKey,
                PinAttempts = createRandomInAppTokenRequestProperties.PinAttempts,
                PinLength = createRandomInAppTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomInAppTokenRequestProperties.PinTimeToLive,
                PhoneNumber = createRandomInAppTokenRequestProperties.PhoneNumber,
                PinType = createRandomInAppTokenRequestProperties.PinType




            };

            var randomInAppToken = new InAppToken
            {
                Request = randomInAppTokenRequest
            };

            var unauthorizedTokensException =
                new UnauthorizedTokensException(unauthorizedException);

            var expectedTokensDependencyException =
                new TokensDependencyException(unauthorizedTokensException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<InAppToken> retrieveTokensTask =
               this.tokensService.PostInAppAsync(randomInAppToken);

            TokensDependencyException
                actualTokensDependencyException =
                    await Assert.ThrowsAsync<TokensDependencyException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostInAppTokenRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomInAppTokenRequestProperties =
              CreateRandomInAppTokenRequestProperties();




            var randomInAppTokenRequest = new InAppTokenRequest
            {
                ApiKey = createRandomInAppTokenRequestProperties.ApiKey,
                PinAttempts = createRandomInAppTokenRequestProperties.PinAttempts,
                PinLength = createRandomInAppTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomInAppTokenRequestProperties.PinTimeToLive,
                PhoneNumber = createRandomInAppTokenRequestProperties.PhoneNumber,
                PinType = createRandomInAppTokenRequestProperties.PinType




            };

            var randomInAppToken = new InAppToken
            {
                Request = randomInAppTokenRequest
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
                broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<InAppToken> retrieveTokensTask =
               this.tokensService.PostInAppAsync(randomInAppToken);

            TokensDependencyValidationException
                actualTokensDependencyValidationException =
                    await Assert.ThrowsAsync<TokensDependencyValidationException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostInAppTokenRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomInAppTokenRequestProperties =
          CreateRandomInAppTokenRequestProperties();


            var randomInAppTokenRequest = new InAppTokenRequest
            {
                ApiKey = createRandomInAppTokenRequestProperties.ApiKey,
                PinAttempts = createRandomInAppTokenRequestProperties.PinAttempts,
                PinLength = createRandomInAppTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomInAppTokenRequestProperties.PinTimeToLive,
                PhoneNumber = createRandomInAppTokenRequestProperties.PhoneNumber,
                PinType = createRandomInAppTokenRequestProperties.PinType




            };

            var randomInAppToken = new InAppToken
            {
                Request = randomInAppTokenRequest
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
                broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<InAppToken> retrieveTokensTask =
               this.tokensService.PostInAppAsync(randomInAppToken);

            TokensDependencyValidationException
                actualTokensDependencyValidationException =
                    await Assert.ThrowsAsync<TokensDependencyValidationException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostInAppTokenRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomInAppTokenRequestProperties =
          CreateRandomInAppTokenRequestProperties();


            var randomInAppTokenRequest = new InAppTokenRequest
            {
                ApiKey = createRandomInAppTokenRequestProperties.ApiKey,
                PinAttempts = createRandomInAppTokenRequestProperties.PinAttempts,
                PinLength = createRandomInAppTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomInAppTokenRequestProperties.PinTimeToLive,
                PhoneNumber = createRandomInAppTokenRequestProperties.PhoneNumber,
                PinType = createRandomInAppTokenRequestProperties.PinType




            };

            var randomInAppToken = new InAppToken
            {
                Request = randomInAppTokenRequest
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
                 broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<InAppToken> retrieveTokensTask =
               this.tokensService.PostInAppAsync(randomInAppToken);

            TokensDependencyValidationException actualTokensDependencyValidationException =
                await Assert.ThrowsAsync<TokensDependencyValidationException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostInAppTokenRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomInAppTokenRequestProperties =
          CreateRandomInAppTokenRequestProperties();


            var randomInAppTokenRequest = new InAppTokenRequest
            {
                ApiKey = createRandomInAppTokenRequestProperties.ApiKey,
                PinAttempts = createRandomInAppTokenRequestProperties.PinAttempts,
                PinLength = createRandomInAppTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomInAppTokenRequestProperties.PinTimeToLive,
                PhoneNumber = createRandomInAppTokenRequestProperties.PhoneNumber,
                PinType = createRandomInAppTokenRequestProperties.PinType




            };

            var randomInAppToken = new InAppToken
            {
                Request = randomInAppTokenRequest
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
                 broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<InAppToken> retrieveTokensTask =
               this.tokensService.PostInAppAsync(randomInAppToken);

            TokensDependencyException actualTokensDependencyException =
                await Assert.ThrowsAsync<TokensDependencyException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostInAppTokenRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomInAppTokenRequestProperties =
            CreateRandomInAppTokenRequestProperties();


            var randomInAppTokenRequest = new InAppTokenRequest
            {
                ApiKey = createRandomInAppTokenRequestProperties.ApiKey,
                PinAttempts = createRandomInAppTokenRequestProperties.PinAttempts,
                PinLength = createRandomInAppTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomInAppTokenRequestProperties.PinTimeToLive,
                PhoneNumber = createRandomInAppTokenRequestProperties.PhoneNumber,
                PinType = createRandomInAppTokenRequestProperties.PinType




            };

            var randomInAppToken = new InAppToken
            {
                Request = randomInAppTokenRequest
            };

            var serviceException = new Exception();

            var failedTokensServiceException =
                new FailedTokensServiceException(serviceException);

            var expectedTokensServiceException =
                new TokensServiceException(failedTokensServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<InAppToken> retrieveTokensTask =
               this.tokensService.PostInAppAsync(randomInAppToken);

            TokensServiceException actualTokensServiceException =
                await Assert.ThrowsAsync<TokensServiceException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensServiceException.Should().BeEquivalentTo(
                expectedTokensServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostInAppAsync(It.IsAny<ExternalInAppTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}