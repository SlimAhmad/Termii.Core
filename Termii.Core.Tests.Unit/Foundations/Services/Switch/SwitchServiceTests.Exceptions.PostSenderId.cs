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
        public async Task ShouldThrowDependencyExceptionOnPostCreateSenderIdRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCreateSenderIdRequestProperties =
               CreateRandomCreateSenderIdRequestProperties();

            
            var randomCreateSenderIdRequest = new CreateSenderIdRequest
            {
                ApiKey = createRandomCreateSenderIdRequestProperties.ApiKey,
                Company = createRandomCreateSenderIdRequestProperties.Company,
                SenderId = createRandomCreateSenderIdRequestProperties.SenderId,
                Usecase = createRandomCreateSenderIdRequestProperties.Usecase



            };

            var randomCreateSenderId = new CreateSenderId
            {
                Request = randomCreateSenderIdRequest
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
                broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreateSenderId> retrieveSwitchTask =
               this.switchService.PostSenderIdRequestAsync(randomCreateSenderId);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostCreateSenderIdRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCreateSenderIdRequestProperties =
             CreateRandomCreateSenderIdRequestProperties();




            var randomCreateSenderIdRequest = new CreateSenderIdRequest
            {
               ApiKey = createRandomCreateSenderIdRequestProperties.ApiKey,
                Company = createRandomCreateSenderIdRequestProperties.Company,
                SenderId = createRandomCreateSenderIdRequestProperties.SenderId,
                Usecase = createRandomCreateSenderIdRequestProperties.Usecase





            };

            var randomCreateSenderId = new CreateSenderId
            {
                Request = randomCreateSenderIdRequest
            };

            var unauthorizedSwitchException =
                new UnauthorizedSwitchException(unauthorizedException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(unauthorizedSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreateSenderId> retrieveSwitchTask =
               this.switchService.PostSenderIdRequestAsync(randomCreateSenderId);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateSenderIdRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCreateSenderIdRequestProperties =
              CreateRandomCreateSenderIdRequestProperties();




            var randomCreateSenderIdRequest = new CreateSenderIdRequest
            {
               ApiKey = createRandomCreateSenderIdRequestProperties.ApiKey,
                Company = createRandomCreateSenderIdRequestProperties.Company,
                SenderId = createRandomCreateSenderIdRequestProperties.SenderId,
                Usecase = createRandomCreateSenderIdRequestProperties.Usecase





            };

            var randomCreateSenderId = new CreateSenderId
            {
                Request = randomCreateSenderIdRequest
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
                broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreateSenderId> retrieveSwitchTask =
               this.switchService.PostSenderIdRequestAsync(randomCreateSenderId);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateSenderIdRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCreateSenderIdRequestProperties =
          CreateRandomCreateSenderIdRequestProperties();


            var randomCreateSenderIdRequest = new CreateSenderIdRequest
            {
               ApiKey = createRandomCreateSenderIdRequestProperties.ApiKey,
                Company = createRandomCreateSenderIdRequestProperties.Company,
                SenderId = createRandomCreateSenderIdRequestProperties.SenderId,
                Usecase = createRandomCreateSenderIdRequestProperties.Usecase





            };

            var randomCreateSenderId = new CreateSenderId
            {
                Request = randomCreateSenderIdRequest
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
                broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreateSenderId> retrieveSwitchTask =
               this.switchService.PostSenderIdRequestAsync(randomCreateSenderId);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateSenderIdRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCreateSenderIdRequestProperties =
          CreateRandomCreateSenderIdRequestProperties();


            var randomCreateSenderIdRequest = new CreateSenderIdRequest
            {
               ApiKey = createRandomCreateSenderIdRequestProperties.ApiKey,
                Company = createRandomCreateSenderIdRequestProperties.Company,
                SenderId = createRandomCreateSenderIdRequestProperties.SenderId,
                Usecase = createRandomCreateSenderIdRequestProperties.Usecase





            };

            var randomCreateSenderId = new CreateSenderId
            {
                Request = randomCreateSenderIdRequest
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
                 broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreateSenderId> retrieveSwitchTask =
               this.switchService.PostSenderIdRequestAsync(randomCreateSenderId);

            SwitchDependencyValidationException actualSwitchDependencyValidationException =
                await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCreateSenderIdRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateSenderIdRequestProperties =
          CreateRandomCreateSenderIdRequestProperties();


            var randomCreateSenderIdRequest = new CreateSenderIdRequest
            {
               ApiKey = createRandomCreateSenderIdRequestProperties.ApiKey,
                Company = createRandomCreateSenderIdRequestProperties.Company,
                SenderId = createRandomCreateSenderIdRequestProperties.SenderId,
                Usecase = createRandomCreateSenderIdRequestProperties.Usecase





            };

            var randomCreateSenderId = new CreateSenderId
            {
                Request = randomCreateSenderIdRequest
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
                 broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreateSenderId> retrieveSwitchTask =
               this.switchService.PostSenderIdRequestAsync(randomCreateSenderId);

            SwitchDependencyException actualSwitchDependencyException =
                await Assert.ThrowsAsync<SwitchDependencyException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostCreateSenderIdRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateSenderIdRequestProperties =
            CreateRandomCreateSenderIdRequestProperties();


            var randomCreateSenderIdRequest = new CreateSenderIdRequest
            {
               ApiKey = createRandomCreateSenderIdRequestProperties.ApiKey,
                Company = createRandomCreateSenderIdRequestProperties.Company,
                SenderId = createRandomCreateSenderIdRequestProperties.SenderId,
                Usecase = createRandomCreateSenderIdRequestProperties.Usecase





            };

            var randomCreateSenderId = new CreateSenderId
            {
                Request = randomCreateSenderIdRequest
            };

            var serviceException = new Exception();

            var failedSwitchServiceException =
                new FailedSwitchServiceException(serviceException);

            var expectedSwitchServiceException =
                new SwitchServiceException(failedSwitchServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreateSenderId> retrieveSwitchTask =
               this.switchService.PostSenderIdRequestAsync(randomCreateSenderId);

            SwitchServiceException actualSwitchServiceException =
                await Assert.ThrowsAsync<SwitchServiceException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchServiceException.Should().BeEquivalentTo(
                expectedSwitchServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostSenderIdAsync(It.IsAny<ExternalCreateSenderIdRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}