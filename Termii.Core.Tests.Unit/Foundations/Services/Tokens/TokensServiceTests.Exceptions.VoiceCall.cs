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
        public async Task ShouldThrowDependencyExceptionOnPostVoiceTokenRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomVoiceTokenRequestProperties =
               CreateRandomVoiceTokenRequestProperties();


            var randomVoiceTokenRequest = new VoiceTokenRequest
            {
                ApiKey = createRandomVoiceTokenRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceTokenRequestProperties.PhoneNumber,
                PinAttempts = createRandomVoiceTokenRequestProperties.PinAttempts,
                PinLength = createRandomVoiceTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomVoiceTokenRequestProperties.PinTimeToLive
             

            };

            var randomVoiceToken = new VoiceToken
            {
                Request = randomVoiceTokenRequest
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
                broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<VoiceToken> retrieveTokensTask =
               this.tokensService.PostVoiceTokenAsync(randomVoiceToken);

            TokensDependencyException
                actualTokensDependencyException =
                    await Assert.ThrowsAsync<TokensDependencyException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostVoiceTokenRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomVoiceTokenRequestProperties =
             CreateRandomVoiceTokenRequestProperties();




            var randomVoiceTokenRequest = new VoiceTokenRequest
            {
                ApiKey = createRandomVoiceTokenRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceTokenRequestProperties.PhoneNumber,
                PinAttempts = createRandomVoiceTokenRequestProperties.PinAttempts,
                PinLength = createRandomVoiceTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomVoiceTokenRequestProperties.PinTimeToLive




            };

            var randomVoiceToken = new VoiceToken
            {
                Request = randomVoiceTokenRequest
            };

            var unauthorizedTokensException =
                new UnauthorizedTokensException(unauthorizedException);

            var expectedTokensDependencyException =
                new TokensDependencyException(unauthorizedTokensException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<VoiceToken> retrieveTokensTask =
               this.tokensService.PostVoiceTokenAsync(randomVoiceToken);

            TokensDependencyException
                actualTokensDependencyException =
                    await Assert.ThrowsAsync<TokensDependencyException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostVoiceTokenRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomVoiceTokenRequestProperties =
              CreateRandomVoiceTokenRequestProperties();




            var randomVoiceTokenRequest = new VoiceTokenRequest
            {
                ApiKey = createRandomVoiceTokenRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceTokenRequestProperties.PhoneNumber,
                PinAttempts = createRandomVoiceTokenRequestProperties.PinAttempts,
                PinLength = createRandomVoiceTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomVoiceTokenRequestProperties.PinTimeToLive




            };

            var randomVoiceToken = new VoiceToken
            {
                Request = randomVoiceTokenRequest
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
                broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<VoiceToken> retrieveTokensTask =
               this.tokensService.PostVoiceTokenAsync(randomVoiceToken);

            TokensDependencyValidationException
                actualTokensDependencyValidationException =
                    await Assert.ThrowsAsync<TokensDependencyValidationException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostVoiceTokenRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomVoiceTokenRequestProperties =
          CreateRandomVoiceTokenRequestProperties();


            var randomVoiceTokenRequest = new VoiceTokenRequest
            {
                ApiKey = createRandomVoiceTokenRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceTokenRequestProperties.PhoneNumber,
                PinAttempts = createRandomVoiceTokenRequestProperties.PinAttempts,
                PinLength = createRandomVoiceTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomVoiceTokenRequestProperties.PinTimeToLive




            };

            var randomVoiceToken = new VoiceToken
            {
                Request = randomVoiceTokenRequest
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
                broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<VoiceToken> retrieveTokensTask =
               this.tokensService.PostVoiceTokenAsync(randomVoiceToken);

            TokensDependencyValidationException
                actualTokensDependencyValidationException =
                    await Assert.ThrowsAsync<TokensDependencyValidationException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostVoiceTokenRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomVoiceTokenRequestProperties =
          CreateRandomVoiceTokenRequestProperties();


            var randomVoiceTokenRequest = new VoiceTokenRequest
            {
                ApiKey = createRandomVoiceTokenRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceTokenRequestProperties.PhoneNumber,
                PinAttempts = createRandomVoiceTokenRequestProperties.PinAttempts,
                PinLength = createRandomVoiceTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomVoiceTokenRequestProperties.PinTimeToLive




            };

            var randomVoiceToken = new VoiceToken
            {
                Request = randomVoiceTokenRequest
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
                 broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<VoiceToken> retrieveTokensTask =
               this.tokensService.PostVoiceTokenAsync(randomVoiceToken);

            TokensDependencyValidationException actualTokensDependencyValidationException =
                await Assert.ThrowsAsync<TokensDependencyValidationException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostVoiceTokenRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomVoiceTokenRequestProperties =
          CreateRandomVoiceTokenRequestProperties();


            var randomVoiceTokenRequest = new VoiceTokenRequest
            {
                ApiKey = createRandomVoiceTokenRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceTokenRequestProperties.PhoneNumber,
                PinAttempts = createRandomVoiceTokenRequestProperties.PinAttempts,
                PinLength = createRandomVoiceTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomVoiceTokenRequestProperties.PinTimeToLive




            };

            var randomVoiceToken = new VoiceToken
            {
                Request = randomVoiceTokenRequest
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
                 broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<VoiceToken> retrieveTokensTask =
               this.tokensService.PostVoiceTokenAsync(randomVoiceToken);

            TokensDependencyException actualTokensDependencyException =
                await Assert.ThrowsAsync<TokensDependencyException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostVoiceTokenRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomVoiceTokenRequestProperties =
            CreateRandomVoiceTokenRequestProperties();


            var randomVoiceTokenRequest = new VoiceTokenRequest
            {
                ApiKey = createRandomVoiceTokenRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceTokenRequestProperties.PhoneNumber,
                PinAttempts = createRandomVoiceTokenRequestProperties.PinAttempts,
                PinLength = createRandomVoiceTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomVoiceTokenRequestProperties.PinTimeToLive




            };

            var randomVoiceToken = new VoiceToken
            {
                Request = randomVoiceTokenRequest
            };

            var serviceException = new Exception();

            var failedTokensServiceException =
                new FailedTokensServiceException(serviceException);

            var expectedTokensServiceException =
                new TokensServiceException(failedTokensServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<VoiceToken> retrieveTokensTask =
               this.tokensService.PostVoiceTokenAsync(randomVoiceToken);

            TokensServiceException actualTokensServiceException =
                await Assert.ThrowsAsync<TokensServiceException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensServiceException.Should().BeEquivalentTo(
                expectedTokensServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceTokenAsync(It.IsAny<ExternalVoiceTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}