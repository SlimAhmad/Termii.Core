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
        public async Task ShouldThrowDependencyExceptionOnPostSendMessageRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCreateSendMessageRequestProperties =
               CreateRandomCreateSendMessageRequestProperties();

            
            var randomSendMessageRequest = new SendMessageRequest
            {
                ApiKey = createRandomCreateSendMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendMessageRequestProperties.Channel,
                From = createRandomCreateSendMessageRequestProperties.From,
                To = createRandomCreateSendMessageRequestProperties.To,
                Media = new SendMessageRequest.MessageMedia
                {
                    Caption = createRandomCreateSendMessageRequestProperties.Media.Caption,
                    Url = createRandomCreateSendMessageRequestProperties.Media.Url,
                },
                Sms = createRandomCreateSendMessageRequestProperties.Sms,
                Type = createRandomCreateSendMessageRequestProperties.Type,


            };

            var randomSendMessage = new SendMessage
            {
                Request = randomSendMessageRequest
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
                broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<SendMessage> retrieveSwitchTask =
               this.switchService.PostMessageRequestAsync(randomSendMessage);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostSendMessageRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCreateSendMessageRequestProperties =
             CreateRandomCreateSendMessageRequestProperties();




            var randomSendMessageRequest = new SendMessageRequest
            {
                ApiKey = createRandomCreateSendMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendMessageRequestProperties.Channel,
                From = createRandomCreateSendMessageRequestProperties.From,
                To = createRandomCreateSendMessageRequestProperties.To,
                Media = new SendMessageRequest.MessageMedia
                {
                    Caption = createRandomCreateSendMessageRequestProperties.Media.Caption,
                    Url = createRandomCreateSendMessageRequestProperties.Media.Url,
                },
                Sms = createRandomCreateSendMessageRequestProperties.Sms,
                Type = createRandomCreateSendMessageRequestProperties.Type,




            };

            var randomSendMessage = new SendMessage
            {
                Request = randomSendMessageRequest
            };

            var unauthorizedSwitchException =
                new UnauthorizedSwitchException(unauthorizedException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(unauthorizedSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<SendMessage> retrieveSwitchTask =
               this.switchService.PostMessageRequestAsync(randomSendMessage);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostSendMessageRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCreateSendMessageRequestProperties =
              CreateRandomCreateSendMessageRequestProperties();




            var randomSendMessageRequest = new SendMessageRequest
            {
                ApiKey = createRandomCreateSendMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendMessageRequestProperties.Channel,
                From = createRandomCreateSendMessageRequestProperties.From,
                To = createRandomCreateSendMessageRequestProperties.To,
                Media = new SendMessageRequest.MessageMedia
                {
                    Caption = createRandomCreateSendMessageRequestProperties.Media.Caption,
                    Url = createRandomCreateSendMessageRequestProperties.Media.Url,
                },
                Sms = createRandomCreateSendMessageRequestProperties.Sms,
                Type = createRandomCreateSendMessageRequestProperties.Type,




            };

            var randomSendMessage = new SendMessage
            {
                Request = randomSendMessageRequest
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
                broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<SendMessage> retrieveSwitchTask =
               this.switchService.PostMessageRequestAsync(randomSendMessage);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostSendMessageRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCreateSendMessageRequestProperties =
          CreateRandomCreateSendMessageRequestProperties();


            var randomSendMessageRequest = new SendMessageRequest
            {
                ApiKey = createRandomCreateSendMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendMessageRequestProperties.Channel,
                From = createRandomCreateSendMessageRequestProperties.From,
                To = createRandomCreateSendMessageRequestProperties.To,
                Media = new SendMessageRequest.MessageMedia
                {
                    Caption = createRandomCreateSendMessageRequestProperties.Media.Caption,
                    Url = createRandomCreateSendMessageRequestProperties.Media.Url,
                },
                Sms = createRandomCreateSendMessageRequestProperties.Sms,
                Type = createRandomCreateSendMessageRequestProperties.Type,




            };

            var randomSendMessage = new SendMessage
            {
                Request = randomSendMessageRequest
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
                broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<SendMessage> retrieveSwitchTask =
               this.switchService.PostMessageRequestAsync(randomSendMessage);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostSendMessageRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCreateSendMessageRequestProperties =
          CreateRandomCreateSendMessageRequestProperties();


            var randomSendMessageRequest = new SendMessageRequest
            {
                ApiKey = createRandomCreateSendMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendMessageRequestProperties.Channel,
                From = createRandomCreateSendMessageRequestProperties.From,
                To = createRandomCreateSendMessageRequestProperties.To,
                Media = new SendMessageRequest.MessageMedia
                {
                    Caption = createRandomCreateSendMessageRequestProperties.Media.Caption,
                    Url = createRandomCreateSendMessageRequestProperties.Media.Url,
                },
                Sms = createRandomCreateSendMessageRequestProperties.Sms,
                Type = createRandomCreateSendMessageRequestProperties.Type,




            };

            var randomSendMessage = new SendMessage
            {
                Request = randomSendMessageRequest
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
                 broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<SendMessage> retrieveSwitchTask =
               this.switchService.PostMessageRequestAsync(randomSendMessage);

            SwitchDependencyValidationException actualSwitchDependencyValidationException =
                await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostSendMessageRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateSendMessageRequestProperties =
          CreateRandomCreateSendMessageRequestProperties();


            var randomSendMessageRequest = new SendMessageRequest
            {
                ApiKey = createRandomCreateSendMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendMessageRequestProperties.Channel,
                From = createRandomCreateSendMessageRequestProperties.From,
                To = createRandomCreateSendMessageRequestProperties.To,
                Media = new SendMessageRequest.MessageMedia
                {
                    Caption = createRandomCreateSendMessageRequestProperties.Media.Caption,
                    Url = createRandomCreateSendMessageRequestProperties.Media.Url,
                },
                Sms = createRandomCreateSendMessageRequestProperties.Sms,
                Type = createRandomCreateSendMessageRequestProperties.Type,




            };

            var randomSendMessage = new SendMessage
            {
                Request = randomSendMessageRequest
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
                 broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<SendMessage> retrieveSwitchTask =
               this.switchService.PostMessageRequestAsync(randomSendMessage);

            SwitchDependencyException actualSwitchDependencyException =
                await Assert.ThrowsAsync<SwitchDependencyException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostSendMessageRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateSendMessageRequestProperties =
            CreateRandomCreateSendMessageRequestProperties();


            var randomSendMessageRequest = new SendMessageRequest
            {
                ApiKey = createRandomCreateSendMessageRequestProperties.ApiKey,
                Channel = createRandomCreateSendMessageRequestProperties.Channel,
                From = createRandomCreateSendMessageRequestProperties.From,
                To = createRandomCreateSendMessageRequestProperties.To,
                Media = new SendMessageRequest.MessageMedia
                {
                    Caption = createRandomCreateSendMessageRequestProperties.Media.Caption,
                    Url = createRandomCreateSendMessageRequestProperties.Media.Url,
                },
                Sms = createRandomCreateSendMessageRequestProperties.Sms,
                Type = createRandomCreateSendMessageRequestProperties.Type,




            };

            var randomSendMessage = new SendMessage
            {
                Request = randomSendMessageRequest
            };

            var serviceException = new Exception();

            var failedSwitchServiceException =
                new FailedSwitchServiceException(serviceException);

            var expectedSwitchServiceException =
                new SwitchServiceException(failedSwitchServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<SendMessage> retrieveSwitchTask =
               this.switchService.PostMessageRequestAsync(randomSendMessage);

            SwitchServiceException actualSwitchServiceException =
                await Assert.ThrowsAsync<SwitchServiceException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchServiceException.Should().BeEquivalentTo(
                expectedSwitchServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostMessageAsync(It.IsAny<ExternalSendMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}