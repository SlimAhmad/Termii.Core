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
        public async Task ShouldThrowDependencyExceptionOnPostCreateNumberMessageRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCreateNumberMessageRequestProperties =
               CreateRandomCreateNumberMessageRequestProperties();

            
            var randomNumberMessageRequest = new NumberMessageRequest
            {
                ApiKey = createRandomCreateNumberMessageRequestProperties.ApiKey,
                Sms = createRandomCreateNumberMessageRequestProperties.Sms,
                To = createRandomCreateNumberMessageRequestProperties.To,
           



            };

            var randomNumberMessage = new NumberMessage
            {
                Request = randomNumberMessageRequest
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
                broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<NumberMessage> retrieveSwitchTask =
               this.switchService.PostNumberMessageRequestAsync(randomNumberMessage);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostCreateNumberMessageRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCreateNumberMessageRequestProperties =
             CreateRandomCreateNumberMessageRequestProperties();




            var randomNumberMessageRequest = new NumberMessageRequest
            {
                ApiKey = createRandomCreateNumberMessageRequestProperties.ApiKey,
                Sms = createRandomCreateNumberMessageRequestProperties.Sms,
                To = createRandomCreateNumberMessageRequestProperties.To,





            };

            var randomNumberMessage = new NumberMessage
            {
                Request = randomNumberMessageRequest
            };

            var unauthorizedSwitchException =
                new UnauthorizedSwitchException(unauthorizedException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(unauthorizedSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<NumberMessage> retrieveSwitchTask =
               this.switchService.PostNumberMessageRequestAsync(randomNumberMessage);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateNumberMessageRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCreateNumberMessageRequestProperties =
              CreateRandomCreateNumberMessageRequestProperties();




            var randomNumberMessageRequest = new NumberMessageRequest
            {
               ApiKey = createRandomCreateNumberMessageRequestProperties.ApiKey,
                Sms = createRandomCreateNumberMessageRequestProperties.Sms,
                To = createRandomCreateNumberMessageRequestProperties.To,





            };

            var randomNumberMessage = new NumberMessage
            {
                Request = randomNumberMessageRequest
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
                broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<NumberMessage> retrieveSwitchTask =
               this.switchService.PostNumberMessageRequestAsync(randomNumberMessage);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateNumberMessageRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCreateNumberMessageRequestProperties =
          CreateRandomCreateNumberMessageRequestProperties();


            var randomNumberMessageRequest = new NumberMessageRequest
            {
               ApiKey = createRandomCreateNumberMessageRequestProperties.ApiKey,
                Sms = createRandomCreateNumberMessageRequestProperties.Sms,
                To = createRandomCreateNumberMessageRequestProperties.To,





            };

            var randomNumberMessage = new NumberMessage
            {
                Request = randomNumberMessageRequest
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
                broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<NumberMessage> retrieveSwitchTask =
               this.switchService.PostNumberMessageRequestAsync(randomNumberMessage);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateNumberMessageRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCreateNumberMessageRequestProperties =
          CreateRandomCreateNumberMessageRequestProperties();


            var randomNumberMessageRequest = new NumberMessageRequest
            {
               ApiKey = createRandomCreateNumberMessageRequestProperties.ApiKey,
                Sms = createRandomCreateNumberMessageRequestProperties.Sms,
                To = createRandomCreateNumberMessageRequestProperties.To,





            };

            var randomNumberMessage = new NumberMessage
            {
                Request = randomNumberMessageRequest
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
                 broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<NumberMessage> retrieveSwitchTask =
               this.switchService.PostNumberMessageRequestAsync(randomNumberMessage);

            SwitchDependencyValidationException actualSwitchDependencyValidationException =
                await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCreateNumberMessageRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateNumberMessageRequestProperties =
          CreateRandomCreateNumberMessageRequestProperties();


            var randomNumberMessageRequest = new NumberMessageRequest
            {
               ApiKey = createRandomCreateNumberMessageRequestProperties.ApiKey,
                Sms = createRandomCreateNumberMessageRequestProperties.Sms,
                To = createRandomCreateNumberMessageRequestProperties.To,





            };

            var randomNumberMessage = new NumberMessage
            {
                Request = randomNumberMessageRequest
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
                 broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<NumberMessage> retrieveSwitchTask =
               this.switchService.PostNumberMessageRequestAsync(randomNumberMessage);

            SwitchDependencyException actualSwitchDependencyException =
                await Assert.ThrowsAsync<SwitchDependencyException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostCreateNumberMessageRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateNumberMessageRequestProperties =
            CreateRandomCreateNumberMessageRequestProperties();


            var randomNumberMessageRequest = new NumberMessageRequest
            {
               ApiKey = createRandomCreateNumberMessageRequestProperties.ApiKey,
                Sms = createRandomCreateNumberMessageRequestProperties.Sms,
                To = createRandomCreateNumberMessageRequestProperties.To,





            };

            var randomNumberMessage = new NumberMessage
            {
                Request = randomNumberMessageRequest
            };

            var serviceException = new Exception();

            var failedSwitchServiceException =
                new FailedSwitchServiceException(serviceException);

            var expectedSwitchServiceException =
                new SwitchServiceException(failedSwitchServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<NumberMessage> retrieveSwitchTask =
               this.switchService.PostNumberMessageRequestAsync(randomNumberMessage);

            SwitchServiceException actualSwitchServiceException =
                await Assert.ThrowsAsync<SwitchServiceException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchServiceException.Should().BeEquivalentTo(
                expectedSwitchServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostNumberMessageAsync(It.IsAny<ExternalNumberMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}