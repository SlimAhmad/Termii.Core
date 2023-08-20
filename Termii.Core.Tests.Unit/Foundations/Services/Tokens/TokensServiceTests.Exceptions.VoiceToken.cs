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
        public async Task ShouldThrowDependencyExceptionOnPostVoiceCallRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomVoiceCallRequestProperties =
               CreateRandomVoiceCallRequestProperties();


            var randomVoiceCallRequest = new VoiceCallRequest
            {
                ApiKey = createRandomVoiceCallRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceCallRequestProperties.PhoneNumber,
                Code = createRandomVoiceCallRequestProperties.Code,
             

            };

            var randomVoiceCall = new VoiceCall
            {
                Request = randomVoiceCallRequest
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
                broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<VoiceCall> retrieveTokensTask =
               this.tokensService.PostVoiceCallAsync(randomVoiceCall);

            TokensDependencyException
                actualTokensDependencyException =
                    await Assert.ThrowsAsync<TokensDependencyException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostVoiceCallRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomVoiceCallRequestProperties =
             CreateRandomVoiceCallRequestProperties();




            var randomVoiceCallRequest = new VoiceCallRequest
            {
                ApiKey = createRandomVoiceCallRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceCallRequestProperties.PhoneNumber,
                Code = createRandomVoiceCallRequestProperties.Code,




            };

            var randomVoiceCall = new VoiceCall
            {
                Request = randomVoiceCallRequest
            };

            var unauthorizedTokensException =
                new UnauthorizedTokensException(unauthorizedException);

            var expectedTokensDependencyException =
                new TokensDependencyException(unauthorizedTokensException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<VoiceCall> retrieveTokensTask =
               this.tokensService.PostVoiceCallAsync(randomVoiceCall);

            TokensDependencyException
                actualTokensDependencyException =
                    await Assert.ThrowsAsync<TokensDependencyException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostVoiceCallRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomVoiceCallRequestProperties =
              CreateRandomVoiceCallRequestProperties();




            var randomVoiceCallRequest = new VoiceCallRequest
            {
                ApiKey = createRandomVoiceCallRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceCallRequestProperties.PhoneNumber,
                Code = createRandomVoiceCallRequestProperties.Code,




            };

            var randomVoiceCall = new VoiceCall
            {
                Request = randomVoiceCallRequest
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
                broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<VoiceCall> retrieveTokensTask =
               this.tokensService.PostVoiceCallAsync(randomVoiceCall);

            TokensDependencyValidationException
                actualTokensDependencyValidationException =
                    await Assert.ThrowsAsync<TokensDependencyValidationException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostVoiceCallRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomVoiceCallRequestProperties =
          CreateRandomVoiceCallRequestProperties();


            var randomVoiceCallRequest = new VoiceCallRequest
            {
                ApiKey = createRandomVoiceCallRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceCallRequestProperties.PhoneNumber,
                Code = createRandomVoiceCallRequestProperties.Code,




            };

            var randomVoiceCall = new VoiceCall
            {
                Request = randomVoiceCallRequest
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
                broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<VoiceCall> retrieveTokensTask =
               this.tokensService.PostVoiceCallAsync(randomVoiceCall);

            TokensDependencyValidationException
                actualTokensDependencyValidationException =
                    await Assert.ThrowsAsync<TokensDependencyValidationException>(
                        retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostVoiceCallRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomVoiceCallRequestProperties =
          CreateRandomVoiceCallRequestProperties();


            var randomVoiceCallRequest = new VoiceCallRequest
            {
                ApiKey = createRandomVoiceCallRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceCallRequestProperties.PhoneNumber,
                Code = createRandomVoiceCallRequestProperties.Code,




            };

            var randomVoiceCall = new VoiceCall
            {
                Request = randomVoiceCallRequest
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
                 broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<VoiceCall> retrieveTokensTask =
               this.tokensService.PostVoiceCallAsync(randomVoiceCall);

            TokensDependencyValidationException actualTokensDependencyValidationException =
                await Assert.ThrowsAsync<TokensDependencyValidationException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyValidationException.Should().BeEquivalentTo(
                expectedTokensDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostVoiceCallRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomVoiceCallRequestProperties =
          CreateRandomVoiceCallRequestProperties();


            var randomVoiceCallRequest = new VoiceCallRequest
            {
                ApiKey = createRandomVoiceCallRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceCallRequestProperties.PhoneNumber,
                Code = createRandomVoiceCallRequestProperties.Code,




            };

            var randomVoiceCall = new VoiceCall
            {
                Request = randomVoiceCallRequest
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
                 broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<VoiceCall> retrieveTokensTask =
               this.tokensService.PostVoiceCallAsync(randomVoiceCall);

            TokensDependencyException actualTokensDependencyException =
                await Assert.ThrowsAsync<TokensDependencyException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensDependencyException.Should().BeEquivalentTo(
                expectedTokensDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostVoiceCallRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomVoiceCallRequestProperties =
            CreateRandomVoiceCallRequestProperties();


            var randomVoiceCallRequest = new VoiceCallRequest
            {
                ApiKey = createRandomVoiceCallRequestProperties.ApiKey,
                PhoneNumber = createRandomVoiceCallRequestProperties.PhoneNumber,
                Code = createRandomVoiceCallRequestProperties.Code,




            };

            var randomVoiceCall = new VoiceCall
            {
                Request = randomVoiceCallRequest
            };

            var serviceException = new Exception();

            var failedTokensServiceException =
                new FailedTokensServiceException(serviceException);

            var expectedTokensServiceException =
                new TokensServiceException(failedTokensServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<VoiceCall> retrieveTokensTask =
               this.tokensService.PostVoiceCallAsync(randomVoiceCall);

            TokensServiceException actualTokensServiceException =
                await Assert.ThrowsAsync<TokensServiceException>(
                    retrieveTokensTask.AsTask);

            // then
            actualTokensServiceException.Should().BeEquivalentTo(
                expectedTokensServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceCallAsync(It.IsAny<ExternalVoiceCallRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}