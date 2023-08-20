using FluentAssertions;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;
using Termii.Core.Models.Services.Foundations.Termii.Switch;
using Moq;
using RESTFulSense.Exceptions;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using System;

namespace Termii.Core.Tests.Unit.Foundations.Services.Switch
{
    public partial class SwitchServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostSendBulkMessageRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCreateSendBulkMessageRequestProperties =
               CreateRandomCreateSendBulkMessageRequestProperties();

            

            var randomSendBulkMessageRequest = new SendBulkMessageRequest
            {
                ApiKey = createRandomCreateSendBulkMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendBulkMessageRequestProperties.Channel,
                From = createRandomCreateSendBulkMessageRequestProperties.From,
                Sms = createRandomCreateSendBulkMessageRequestProperties.Sms,
                To = createRandomCreateSendBulkMessageRequestProperties.To,
                Type = createRandomCreateSendBulkMessageRequestProperties.Type



            };

            var randomSendBulkMessage = new SendBulkMessage
            {
                Request = randomSendBulkMessageRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationSwitchException =
                new InvalidConfigurationSwitchException(
                    httpResponseUrlNotFoundException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(
                    invalidConfigurationSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<SendBulkMessage> retrieveSwitchTask =
               this.switchService.PostBulkMessagesRequestAsync(randomSendBulkMessage);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostSendBulkMessageRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCreateSendBulkMessageRequestProperties =
             CreateRandomCreateSendBulkMessageRequestProperties();




            var randomSendBulkMessageRequest = new SendBulkMessageRequest
            {
                ApiKey = createRandomCreateSendBulkMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendBulkMessageRequestProperties.Channel,
                From = createRandomCreateSendBulkMessageRequestProperties.From,
                Sms = createRandomCreateSendBulkMessageRequestProperties.Sms,
                To = createRandomCreateSendBulkMessageRequestProperties.To,
                Type = createRandomCreateSendBulkMessageRequestProperties.Type





            };

            var randomSendBulkMessage = new SendBulkMessage
            {
                Request = randomSendBulkMessageRequest
            };

            var unauthorizedSwitchException =
                new UnauthorizedSwitchException(unauthorizedException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(unauthorizedSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<SendBulkMessage> retrieveSwitchTask =
               this.switchService.PostBulkMessagesRequestAsync(randomSendBulkMessage);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostSendBulkMessageRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCreateSendBulkMessageRequestProperties =
              CreateRandomCreateSendBulkMessageRequestProperties();




            var randomSendBulkMessageRequest = new SendBulkMessageRequest
            {
                ApiKey = createRandomCreateSendBulkMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendBulkMessageRequestProperties.Channel,
                From = createRandomCreateSendBulkMessageRequestProperties.From,
                Sms = createRandomCreateSendBulkMessageRequestProperties.Sms,
                To = createRandomCreateSendBulkMessageRequestProperties.To,
                Type = createRandomCreateSendBulkMessageRequestProperties.Type





            };

            var randomSendBulkMessage = new SendBulkMessage
            {
                Request = randomSendBulkMessageRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundSwitchException =
                new NotFoundSwitchException(
                    httpResponseNotFoundException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    notFoundSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<SendBulkMessage> retrieveSwitchTask =
               this.switchService.PostBulkMessagesRequestAsync(randomSendBulkMessage);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostSendBulkMessageRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCreateSendBulkMessageRequestProperties =
          CreateRandomCreateSendBulkMessageRequestProperties();


            var randomSendBulkMessageRequest = new SendBulkMessageRequest
            {
               ApiKey = createRandomCreateSendBulkMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendBulkMessageRequestProperties.Channel,
                From = createRandomCreateSendBulkMessageRequestProperties.From,
                Sms = createRandomCreateSendBulkMessageRequestProperties.Sms,
                To = createRandomCreateSendBulkMessageRequestProperties.To,
                Type = createRandomCreateSendBulkMessageRequestProperties.Type





            };

            var randomSendBulkMessage = new SendBulkMessage
            {
                Request = randomSendBulkMessageRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidSwitchException =
                new InvalidSwitchException(
                    httpResponseBadRequestException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    invalidSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<SendBulkMessage> retrieveSwitchTask =
               this.switchService.PostBulkMessagesRequestAsync(randomSendBulkMessage);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostSendBulkMessageRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCreateSendBulkMessageRequestProperties =
          CreateRandomCreateSendBulkMessageRequestProperties();


            var randomSendBulkMessageRequest = new SendBulkMessageRequest
            {
               ApiKey = createRandomCreateSendBulkMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendBulkMessageRequestProperties.Channel,
                From = createRandomCreateSendBulkMessageRequestProperties.From,
                Sms = createRandomCreateSendBulkMessageRequestProperties.Sms,
                To = createRandomCreateSendBulkMessageRequestProperties.To,
                Type = createRandomCreateSendBulkMessageRequestProperties.Type





            };

            var randomSendBulkMessage = new SendBulkMessage
            {
                Request = randomSendBulkMessageRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallSwitchException =
                new ExcessiveCallSwitchException(
                    httpResponseTooManyRequestsException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    excessiveCallSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<SendBulkMessage> retrieveSwitchTask =
               this.switchService.PostBulkMessagesRequestAsync(randomSendBulkMessage);

            SwitchDependencyValidationException actualSwitchDependencyValidationException =
                await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostSendBulkMessageRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateSendBulkMessageRequestProperties =
          CreateRandomCreateSendBulkMessageRequestProperties();


            var randomSendBulkMessageRequest = new SendBulkMessageRequest
            {
               ApiKey = createRandomCreateSendBulkMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendBulkMessageRequestProperties.Channel,
                From = createRandomCreateSendBulkMessageRequestProperties.From,
                Sms = createRandomCreateSendBulkMessageRequestProperties.Sms,
                To = createRandomCreateSendBulkMessageRequestProperties.To,
                Type = createRandomCreateSendBulkMessageRequestProperties.Type





            };

            var randomSendBulkMessage = new SendBulkMessage
            {
                Request = randomSendBulkMessageRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerSwitchException =
                new FailedServerSwitchException(
                    httpResponseException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(
                    failedServerSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<SendBulkMessage> retrieveSwitchTask =
               this.switchService.PostBulkMessagesRequestAsync(randomSendBulkMessage);

            SwitchDependencyException actualSwitchDependencyException =
                await Assert.ThrowsAsync<SwitchDependencyException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostSendBulkMessageRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateSendBulkMessageRequestProperties =
            CreateRandomCreateSendBulkMessageRequestProperties();


            var randomSendBulkMessageRequest = new SendBulkMessageRequest
            {
               ApiKey = createRandomCreateSendBulkMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendBulkMessageRequestProperties.Channel,
                From = createRandomCreateSendBulkMessageRequestProperties.From,
                Sms = createRandomCreateSendBulkMessageRequestProperties.Sms,
                To = createRandomCreateSendBulkMessageRequestProperties.To,
                Type = createRandomCreateSendBulkMessageRequestProperties.Type





            };

            var randomSendBulkMessage = new SendBulkMessage
            {
                Request = randomSendBulkMessageRequest
            };

            var serviceException = new Exception();

            var failedSwitchServiceException =
                new FailedSwitchServiceException(serviceException);

            var expectedSwitchServiceException =
                new SwitchServiceException(failedSwitchServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<SendBulkMessage> retrieveSwitchTask =
               this.switchService.PostBulkMessagesRequestAsync(randomSendBulkMessage);

            SwitchServiceException actualSwitchServiceException =
                await Assert.ThrowsAsync<SwitchServiceException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchServiceException.Should().BeEquivalentTo(
                expectedSwitchServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostBulkMessagesAsync(It.IsAny<ExternalSendBulkMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}