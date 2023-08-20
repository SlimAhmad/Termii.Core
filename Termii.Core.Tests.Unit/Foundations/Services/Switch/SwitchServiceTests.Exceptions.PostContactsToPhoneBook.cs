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
        public async Task ShouldThrowDependencyExceptionOnPostAddMultipleContactsToPhoneBookRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomAddMultipleContactsToPhoneBookRequestProperties =
               CreateRandomAddMultipleContactsToPhoneBookRequestProperties();


            var randomAddMultipleContactsToPhoneBookRequest = new AddMultipleContactsToPhoneBookRequest
            {
                ApiKey = createRandomAddMultipleContactsToPhoneBookRequestProperties.ApiKey,
                CountryCode = createRandomAddMultipleContactsToPhoneBookRequestProperties.CountryCode,
                ContactFile = createRandomAddMultipleContactsToPhoneBookRequestProperties.ContactFile
              
            };

            var randomAddMultipleContactsToPhoneBook = new AddMultipleContactsToPhoneBook
            {
                Request = randomAddMultipleContactsToPhoneBookRequest
            };

             var apiKey = GetRandomString();


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationSwitchException =
                new InvalidConfigurationSwitchException(
                    httpResponseUrlNotFoundException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(
                    invalidConfigurationSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AddMultipleContactsToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactsToPhoneBookRequestAsync(randomAddMultipleContactsToPhoneBook,apiKey);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostAddMultipleContactsToPhoneBookRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomAddMultipleContactsToPhoneBookRequestProperties =
            CreateRandomAddMultipleContactsToPhoneBookRequestProperties();


            var randomAddMultipleContactsToPhoneBookRequest = new AddMultipleContactsToPhoneBookRequest
            {
                ApiKey = createRandomAddMultipleContactsToPhoneBookRequestProperties.ApiKey,
                CountryCode = createRandomAddMultipleContactsToPhoneBookRequestProperties.CountryCode,
                ContactFile = createRandomAddMultipleContactsToPhoneBookRequestProperties.ContactFile

            };

            var randomAddMultipleContactsToPhoneBook = new AddMultipleContactsToPhoneBook
            {
                Request = randomAddMultipleContactsToPhoneBookRequest
            };

            var apiKey = GetRandomString();

            var unauthorizedSwitchException =
                new UnauthorizedSwitchException(unauthorizedException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(unauthorizedSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AddMultipleContactsToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactsToPhoneBookRequestAsync(randomAddMultipleContactsToPhoneBook, apiKey);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostAddMultipleContactsToPhoneBookRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomAddMultipleContactsToPhoneBookRequestProperties =
              CreateRandomAddMultipleContactsToPhoneBookRequestProperties();


            var randomAddMultipleContactsToPhoneBookRequest = new AddMultipleContactsToPhoneBookRequest
            {
               ApiKey = createRandomAddMultipleContactsToPhoneBookRequestProperties.ApiKey,
                CountryCode = createRandomAddMultipleContactsToPhoneBookRequestProperties.CountryCode,
                ContactFile = createRandomAddMultipleContactsToPhoneBookRequestProperties.ContactFile





            };

            var randomAddMultipleContactsToPhoneBook = new AddMultipleContactsToPhoneBook
            {
                Request = randomAddMultipleContactsToPhoneBookRequest
            };

             var apiKey = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundSwitchException =
                new NotFoundSwitchException(
                    httpResponseNotFoundException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    notFoundSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AddMultipleContactsToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactsToPhoneBookRequestAsync(randomAddMultipleContactsToPhoneBook, apiKey);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostAddMultipleContactsToPhoneBookRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomAddMultipleContactsToPhoneBookRequestProperties =
             CreateRandomAddMultipleContactsToPhoneBookRequestProperties();


            var randomAddMultipleContactsToPhoneBookRequest = new AddMultipleContactsToPhoneBookRequest
            {
               ApiKey = createRandomAddMultipleContactsToPhoneBookRequestProperties.ApiKey,
                CountryCode = createRandomAddMultipleContactsToPhoneBookRequestProperties.CountryCode,
                ContactFile = createRandomAddMultipleContactsToPhoneBookRequestProperties.ContactFile





            };

            var randomAddMultipleContactsToPhoneBook = new AddMultipleContactsToPhoneBook
            {
                Request = randomAddMultipleContactsToPhoneBookRequest
            };

             var apiKey = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidSwitchException =
                new InvalidSwitchException(
                    httpResponseBadRequestException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    invalidSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AddMultipleContactsToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactsToPhoneBookRequestAsync(randomAddMultipleContactsToPhoneBook, apiKey);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostAddMultipleContactsToPhoneBookRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomAddMultipleContactsToPhoneBookRequestProperties =
             CreateRandomAddMultipleContactsToPhoneBookRequestProperties();


            var randomAddMultipleContactsToPhoneBookRequest = new AddMultipleContactsToPhoneBookRequest
            {
               ApiKey = createRandomAddMultipleContactsToPhoneBookRequestProperties.ApiKey,
                CountryCode = createRandomAddMultipleContactsToPhoneBookRequestProperties.CountryCode,
                ContactFile = createRandomAddMultipleContactsToPhoneBookRequestProperties.ContactFile





            };

            var randomAddMultipleContactsToPhoneBook = new AddMultipleContactsToPhoneBook
            {
                Request = randomAddMultipleContactsToPhoneBookRequest
            };

             var apiKey = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallSwitchException =
                new ExcessiveCallSwitchException(
                    httpResponseTooManyRequestsException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    excessiveCallSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AddMultipleContactsToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactsToPhoneBookRequestAsync(randomAddMultipleContactsToPhoneBook, apiKey);

            SwitchDependencyValidationException actualSwitchDependencyValidationException =
                await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostAddMultipleContactsToPhoneBookRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomAddMultipleContactsToPhoneBookRequestProperties =
            CreateRandomAddMultipleContactsToPhoneBookRequestProperties();


            var randomAddMultipleContactsToPhoneBookRequest = new AddMultipleContactsToPhoneBookRequest
            {
               ApiKey = createRandomAddMultipleContactsToPhoneBookRequestProperties.ApiKey,
                CountryCode = createRandomAddMultipleContactsToPhoneBookRequestProperties.CountryCode,
                ContactFile = createRandomAddMultipleContactsToPhoneBookRequestProperties.ContactFile





            };

            var randomAddMultipleContactsToPhoneBook = new AddMultipleContactsToPhoneBook
            {
                Request = randomAddMultipleContactsToPhoneBookRequest
            };

             var apiKey = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerSwitchException =
                new FailedServerSwitchException(
                    httpResponseException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(
                    failedServerSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AddMultipleContactsToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactsToPhoneBookRequestAsync(randomAddMultipleContactsToPhoneBook, apiKey);

            SwitchDependencyException actualSwitchDependencyException =
                await Assert.ThrowsAsync<SwitchDependencyException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostAddMultipleContactsToPhoneBookRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomAddMultipleContactsToPhoneBookRequestProperties =
             CreateRandomAddMultipleContactsToPhoneBookRequestProperties();


            var randomAddMultipleContactsToPhoneBookRequest = new AddMultipleContactsToPhoneBookRequest
            {
               ApiKey = createRandomAddMultipleContactsToPhoneBookRequestProperties.ApiKey,
                CountryCode = createRandomAddMultipleContactsToPhoneBookRequestProperties.CountryCode,
                ContactFile = createRandomAddMultipleContactsToPhoneBookRequestProperties.ContactFile





            };

            var randomAddMultipleContactsToPhoneBook = new AddMultipleContactsToPhoneBook
            {
                Request = randomAddMultipleContactsToPhoneBookRequest
            };

             var apiKey = GetRandomString();

            var serviceException = new Exception();

            var failedSwitchServiceException =
                new FailedSwitchServiceException(serviceException);

            var expectedSwitchServiceException =
                new SwitchServiceException(failedSwitchServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AddMultipleContactsToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactsToPhoneBookRequestAsync(randomAddMultipleContactsToPhoneBook, apiKey);

            SwitchServiceException actualSwitchServiceException =
                await Assert.ThrowsAsync<SwitchServiceException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchServiceException.Should().BeEquivalentTo(
                expectedSwitchServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactsToPhoneBookAsync(It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}