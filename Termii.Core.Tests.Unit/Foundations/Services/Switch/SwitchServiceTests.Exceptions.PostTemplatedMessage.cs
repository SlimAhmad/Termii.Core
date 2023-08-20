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
        public async Task ShouldThrowDependencyExceptionOnPostCreateTemplatedMessageRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCreateTemplatedMessageRequestProperties =
               CreateRandomCreateTemplatedMessageRequestProperties();

            
            var randomTemplatedMessageRequest = new TemplatedMessageRequest
            {
                ApiKey = createRandomCreateTemplatedMessageRequestProperties.ApiKey,
                DeviceId = createRandomCreateTemplatedMessageRequestProperties.DeviceId,
                PhoneNumber = createRandomCreateTemplatedMessageRequestProperties.PhoneNumber,
                TemplateId = createRandomCreateTemplatedMessageRequestProperties.TemplateId,
                Data = new TemplatedMessageRequest.ExternalData
                {
                    ExpiryTime = createRandomCreateTemplatedMessageRequestProperties.Data.ExpiryTime,
                    Otp = createRandomCreateTemplatedMessageRequestProperties.Data.Otp,
                    ProductName = createRandomCreateTemplatedMessageRequestProperties.Data.ProductName

                }




            };

            var randomTemplatedMessage = new TemplatedMessage
            {
                Request = randomTemplatedMessageRequest
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
                broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<TemplatedMessage> retrieveSwitchTask =
               this.switchService.PostTemplatedMessageRequestAsync(randomTemplatedMessage);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostCreateTemplatedMessageRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCreateTemplatedMessageRequestProperties =
             CreateRandomCreateTemplatedMessageRequestProperties();




            var randomTemplatedMessageRequest = new TemplatedMessageRequest
            {
                ApiKey = createRandomCreateTemplatedMessageRequestProperties.ApiKey,
                DeviceId = createRandomCreateTemplatedMessageRequestProperties.DeviceId,
                PhoneNumber = createRandomCreateTemplatedMessageRequestProperties.PhoneNumber,
                TemplateId = createRandomCreateTemplatedMessageRequestProperties.TemplateId,
                Data = new TemplatedMessageRequest.ExternalData
                {
                   ExpiryTime = createRandomCreateTemplatedMessageRequestProperties.Data.ExpiryTime,
                   Otp = createRandomCreateTemplatedMessageRequestProperties.Data.Otp,
                   ProductName = createRandomCreateTemplatedMessageRequestProperties.Data.ProductName

                }





            };

            var randomTemplatedMessage = new TemplatedMessage
            {
                Request = randomTemplatedMessageRequest
            };

            var unauthorizedSwitchException =
                new UnauthorizedSwitchException(unauthorizedException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(unauthorizedSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<TemplatedMessage> retrieveSwitchTask =
               this.switchService.PostTemplatedMessageRequestAsync(randomTemplatedMessage);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateTemplatedMessageRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCreateTemplatedMessageRequestProperties =
              CreateRandomCreateTemplatedMessageRequestProperties();




            var randomTemplatedMessageRequest = new TemplatedMessageRequest
            {
               ApiKey = createRandomCreateTemplatedMessageRequestProperties.ApiKey,
                DeviceId = createRandomCreateTemplatedMessageRequestProperties.DeviceId,
                PhoneNumber = createRandomCreateTemplatedMessageRequestProperties.PhoneNumber,
                TemplateId = createRandomCreateTemplatedMessageRequestProperties.TemplateId,
                Data = new TemplatedMessageRequest.ExternalData
                {
                   ExpiryTime = createRandomCreateTemplatedMessageRequestProperties.Data.ExpiryTime,
                   Otp = createRandomCreateTemplatedMessageRequestProperties.Data.Otp,
                   ProductName = createRandomCreateTemplatedMessageRequestProperties.Data.ProductName

                }





            };

            var randomTemplatedMessage = new TemplatedMessage
            {
                Request = randomTemplatedMessageRequest
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
                broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<TemplatedMessage> retrieveSwitchTask =
               this.switchService.PostTemplatedMessageRequestAsync(randomTemplatedMessage);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateTemplatedMessageRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCreateTemplatedMessageRequestProperties =
          CreateRandomCreateTemplatedMessageRequestProperties();


            var randomTemplatedMessageRequest = new TemplatedMessageRequest
            {
               ApiKey = createRandomCreateTemplatedMessageRequestProperties.ApiKey,
                DeviceId = createRandomCreateTemplatedMessageRequestProperties.DeviceId,
                PhoneNumber = createRandomCreateTemplatedMessageRequestProperties.PhoneNumber,
                TemplateId = createRandomCreateTemplatedMessageRequestProperties.TemplateId,
                Data = new TemplatedMessageRequest.ExternalData
                {
                   ExpiryTime = createRandomCreateTemplatedMessageRequestProperties.Data.ExpiryTime,
                   Otp = createRandomCreateTemplatedMessageRequestProperties.Data.Otp,
                   ProductName = createRandomCreateTemplatedMessageRequestProperties.Data.ProductName

                }





            };

            var randomTemplatedMessage = new TemplatedMessage
            {
                Request = randomTemplatedMessageRequest
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
                broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<TemplatedMessage> retrieveSwitchTask =
               this.switchService.PostTemplatedMessageRequestAsync(randomTemplatedMessage);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateTemplatedMessageRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCreateTemplatedMessageRequestProperties =
          CreateRandomCreateTemplatedMessageRequestProperties();


            var randomTemplatedMessageRequest = new TemplatedMessageRequest
            {
               ApiKey = createRandomCreateTemplatedMessageRequestProperties.ApiKey,
                DeviceId = createRandomCreateTemplatedMessageRequestProperties.DeviceId,
                PhoneNumber = createRandomCreateTemplatedMessageRequestProperties.PhoneNumber,
                TemplateId = createRandomCreateTemplatedMessageRequestProperties.TemplateId,
                Data = new TemplatedMessageRequest.ExternalData
                {
                   ExpiryTime = createRandomCreateTemplatedMessageRequestProperties.Data.ExpiryTime,
                   Otp = createRandomCreateTemplatedMessageRequestProperties.Data.Otp,
                   ProductName = createRandomCreateTemplatedMessageRequestProperties.Data.ProductName

                }





            };

            var randomTemplatedMessage = new TemplatedMessage
            {
                Request = randomTemplatedMessageRequest
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
                 broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<TemplatedMessage> retrieveSwitchTask =
               this.switchService.PostTemplatedMessageRequestAsync(randomTemplatedMessage);

            SwitchDependencyValidationException actualSwitchDependencyValidationException =
                await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCreateTemplatedMessageRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateTemplatedMessageRequestProperties =
          CreateRandomCreateTemplatedMessageRequestProperties();


            var randomTemplatedMessageRequest = new TemplatedMessageRequest
            {
               ApiKey = createRandomCreateTemplatedMessageRequestProperties.ApiKey,
                DeviceId = createRandomCreateTemplatedMessageRequestProperties.DeviceId,
                PhoneNumber = createRandomCreateTemplatedMessageRequestProperties.PhoneNumber,
                TemplateId = createRandomCreateTemplatedMessageRequestProperties.TemplateId,
                Data = new TemplatedMessageRequest.ExternalData
                {
                   ExpiryTime = createRandomCreateTemplatedMessageRequestProperties.Data.ExpiryTime,
                   Otp = createRandomCreateTemplatedMessageRequestProperties.Data.Otp,
                   ProductName = createRandomCreateTemplatedMessageRequestProperties.Data.ProductName

                }





            };

            var randomTemplatedMessage = new TemplatedMessage
            {
                Request = randomTemplatedMessageRequest
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
                 broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<TemplatedMessage> retrieveSwitchTask =
               this.switchService.PostTemplatedMessageRequestAsync(randomTemplatedMessage);

            SwitchDependencyException actualSwitchDependencyException =
                await Assert.ThrowsAsync<SwitchDependencyException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostCreateTemplatedMessageRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateTemplatedMessageRequestProperties =
            CreateRandomCreateTemplatedMessageRequestProperties();


            var randomTemplatedMessageRequest = new TemplatedMessageRequest
            {
               ApiKey = createRandomCreateTemplatedMessageRequestProperties.ApiKey,
                DeviceId = createRandomCreateTemplatedMessageRequestProperties.DeviceId,
                PhoneNumber = createRandomCreateTemplatedMessageRequestProperties.PhoneNumber,
                TemplateId = createRandomCreateTemplatedMessageRequestProperties.TemplateId,
                Data = new TemplatedMessageRequest.ExternalData
                {
                   ExpiryTime = createRandomCreateTemplatedMessageRequestProperties.Data.ExpiryTime,
                   Otp = createRandomCreateTemplatedMessageRequestProperties.Data.Otp,
                   ProductName = createRandomCreateTemplatedMessageRequestProperties.Data.ProductName

                }





            };

            var randomTemplatedMessage = new TemplatedMessage
            {
                Request = randomTemplatedMessageRequest
            };

            var serviceException = new Exception();

            var failedSwitchServiceException =
                new FailedSwitchServiceException(serviceException);

            var expectedSwitchServiceException =
                new SwitchServiceException(failedSwitchServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<TemplatedMessage> retrieveSwitchTask =
               this.switchService.PostTemplatedMessageRequestAsync(randomTemplatedMessage);

            SwitchServiceException actualSwitchServiceException =
                await Assert.ThrowsAsync<SwitchServiceException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchServiceException.Should().BeEquivalentTo(
                expectedSwitchServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTemplatedMessageAsync(It.IsAny<ExternalTemplatedMessageRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}