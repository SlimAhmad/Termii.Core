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
        public async Task ShouldThrowDependencyExceptionOnPostSendTokenRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomSendTokenRequestProperties =
               CreateRandomSendTokenRequestProperties();


            var randomSendTokenRequest = new SendTokenRequest
            {
                ApiKey = createRandomSendTokenRequestProperties.ApiKey,
                PinAttempts = createRandomSendTokenRequestProperties.PinAttempts,
                PinLength = createRandomSendTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomSendTokenRequestProperties.PinTimeToLive,
                Channel = createRandomSendTokenRequestProperties.Channel,
                PinType = createRandomSendTokenRequestProperties.PinType,
                From = createRandomSendTokenRequestProperties.From,
                MessageText = createRandomSendTokenRequestProperties.MessageText,
                MessageType = createRandomSendTokenRequestProperties.MessageType,
                PinPlaceholder = createRandomSendTokenRequestProperties.PinPlaceholder,
                To = createRandomSendTokenRequestProperties.To,
             

            };

            var randomSendToken = new SendToken
            {
                Request = randomSendTokenRequest
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
                broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<SendToken> retrieveTokensTask =
               this.tokensService.PostTokenAsync(randomSendToken);

            TokensDependencyException
                actualTokensDependencyException =
                    await Assert.ThrowsAsync<TokensDependencyException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostSendTokenRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomSendTokenRequestProperties =
             CreateRandomSendTokenRequestProperties();




            var randomSendTokenRequest = new SendTokenRequest
            {
                ApiKey = createRandomSendTokenRequestProperties.ApiKey,
                PinAttempts = createRandomSendTokenRequestProperties.PinAttempts,
                PinLength = createRandomSendTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomSendTokenRequestProperties.PinTimeToLive,
                Channel = createRandomSendTokenRequestProperties.Channel,
                PinType = createRandomSendTokenRequestProperties.PinType,
                From = createRandomSendTokenRequestProperties.From,
                MessageText = createRandomSendTokenRequestProperties.MessageText,
                MessageType = createRandomSendTokenRequestProperties.MessageType,
                PinPlaceholder = createRandomSendTokenRequestProperties.PinPlaceholder,
                To = createRandomSendTokenRequestProperties.To,




            };

            var randomSendToken = new SendToken
            {
                Request = randomSendTokenRequest
            };

            var unauthorizedTokensException =
                new UnauthorizedTokensException(unauthorizedException);

            var expectedTokensDependencyException =
                new TokensDependencyException(unauthorizedTokensException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<SendToken> retrieveTokensTask =
               this.tokensService.PostTokenAsync(randomSendToken);

            TokensDependencyException
                actualTokensDependencyException =
                    await Assert.ThrowsAsync<TokensDependencyException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostSendTokenRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomSendTokenRequestProperties =
              CreateRandomSendTokenRequestProperties();




            var randomSendTokenRequest = new SendTokenRequest
            {
                ApiKey = createRandomSendTokenRequestProperties.ApiKey,
                PinAttempts = createRandomSendTokenRequestProperties.PinAttempts,
                PinLength = createRandomSendTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomSendTokenRequestProperties.PinTimeToLive,
                Channel = createRandomSendTokenRequestProperties.Channel,
                PinType = createRandomSendTokenRequestProperties.PinType,
                From = createRandomSendTokenRequestProperties.From,
                MessageText = createRandomSendTokenRequestProperties.MessageText,
                MessageType = createRandomSendTokenRequestProperties.MessageType,
                PinPlaceholder = createRandomSendTokenRequestProperties.PinPlaceholder,
                To = createRandomSendTokenRequestProperties.To,




            };

            var randomSendToken = new SendToken
            {
                Request = randomSendTokenRequest
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
                broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<SendToken> retrieveTokensTask =
               this.tokensService.PostTokenAsync(randomSendToken);

            TokensDependencyValidationException
                actualTokensDependencyValidationException =
                    await Assert.ThrowsAsync<TokensDependencyValidationException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostSendTokenRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomSendTokenRequestProperties =
          CreateRandomSendTokenRequestProperties();


            var randomSendTokenRequest = new SendTokenRequest
            {
                ApiKey = createRandomSendTokenRequestProperties.ApiKey,
                PinAttempts = createRandomSendTokenRequestProperties.PinAttempts,
                PinLength = createRandomSendTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomSendTokenRequestProperties.PinTimeToLive,
                Channel = createRandomSendTokenRequestProperties.Channel,
                PinType = createRandomSendTokenRequestProperties.PinType,
                From = createRandomSendTokenRequestProperties.From,
                MessageText = createRandomSendTokenRequestProperties.MessageText,
                MessageType = createRandomSendTokenRequestProperties.MessageType,
                PinPlaceholder = createRandomSendTokenRequestProperties.PinPlaceholder,
                To = createRandomSendTokenRequestProperties.To,




            };

            var randomSendToken = new SendToken
            {
                Request = randomSendTokenRequest
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
                broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<SendToken> retrieveTokensTask =
               this.tokensService.PostTokenAsync(randomSendToken);

            TokensDependencyValidationException
                actualTokensDependencyValidationException =
                    await Assert.ThrowsAsync<TokensDependencyValidationException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostSendTokenRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomSendTokenRequestProperties =
          CreateRandomSendTokenRequestProperties();


            var randomSendTokenRequest = new SendTokenRequest
            {
                ApiKey = createRandomSendTokenRequestProperties.ApiKey,
                PinAttempts = createRandomSendTokenRequestProperties.PinAttempts,
                PinLength = createRandomSendTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomSendTokenRequestProperties.PinTimeToLive,
                Channel = createRandomSendTokenRequestProperties.Channel,
                PinType = createRandomSendTokenRequestProperties.PinType,
                From = createRandomSendTokenRequestProperties.From,
                MessageText = createRandomSendTokenRequestProperties.MessageText,
                MessageType = createRandomSendTokenRequestProperties.MessageType,
                PinPlaceholder = createRandomSendTokenRequestProperties.PinPlaceholder,
                To = createRandomSendTokenRequestProperties.To,




            };

            var randomSendToken = new SendToken
            {
                Request = randomSendTokenRequest
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
                 broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<SendToken> retrieveTokensTask =
               this.tokensService.PostTokenAsync(randomSendToken);

            TokensDependencyValidationException actualTokensDependencyValidationException =
                await Assert.ThrowsAsync<TokensDependencyValidationException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostSendTokenRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomSendTokenRequestProperties =
          CreateRandomSendTokenRequestProperties();


            var randomSendTokenRequest = new SendTokenRequest
            {
                ApiKey = createRandomSendTokenRequestProperties.ApiKey,
                PinAttempts = createRandomSendTokenRequestProperties.PinAttempts,
                PinLength = createRandomSendTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomSendTokenRequestProperties.PinTimeToLive,
                Channel = createRandomSendTokenRequestProperties.Channel,
                PinType = createRandomSendTokenRequestProperties.PinType,
                From = createRandomSendTokenRequestProperties.From,
                MessageText = createRandomSendTokenRequestProperties.MessageText,
                MessageType = createRandomSendTokenRequestProperties.MessageType,
                PinPlaceholder = createRandomSendTokenRequestProperties.PinPlaceholder,
                To = createRandomSendTokenRequestProperties.To,




            };

            var randomSendToken = new SendToken
            {
                Request = randomSendTokenRequest
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
                 broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<SendToken> retrieveTokensTask =
               this.tokensService.PostTokenAsync(randomSendToken);

            TokensDependencyException actualTokensDependencyException =
                await Assert.ThrowsAsync<TokensDependencyException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostSendTokenRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomSendTokenRequestProperties =
            CreateRandomSendTokenRequestProperties();


            var randomSendTokenRequest = new SendTokenRequest
            {
                ApiKey = createRandomSendTokenRequestProperties.ApiKey,
                PinAttempts = createRandomSendTokenRequestProperties.PinAttempts,
                PinLength = createRandomSendTokenRequestProperties.PinLength,
                PinTimeToLive = createRandomSendTokenRequestProperties.PinTimeToLive,
                Channel = createRandomSendTokenRequestProperties.Channel,
                PinType = createRandomSendTokenRequestProperties.PinType,
                From = createRandomSendTokenRequestProperties.From,
                MessageText = createRandomSendTokenRequestProperties.MessageText,
                MessageType = createRandomSendTokenRequestProperties.MessageType,
                PinPlaceholder = createRandomSendTokenRequestProperties.PinPlaceholder,
                To = createRandomSendTokenRequestProperties.To,




            };

            var randomSendToken = new SendToken
            {
                Request = randomSendTokenRequest
            };

            var serviceException = new Exception();

            var failedTokensServiceException =
                new FailedTokensServiceException(serviceException);

            var expectedTokensServiceException =
                new TokensServiceException(failedTokensServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<SendToken> retrieveTokensTask =
               this.tokensService.PostTokenAsync(randomSendToken);

            TokensServiceException actualTokensServiceException =
                await Assert.ThrowsAsync<TokensServiceException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensServiceException.Should().BeEquivalentTo(
                expectedTokensServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTokenAsync(It.IsAny<ExternalSendTokenRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}