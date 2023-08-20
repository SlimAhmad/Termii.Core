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
        public async Task ShouldThrowDependencyExceptionOnPostAddContactToPhoneBookRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomAddContactToPhoneBookRequestProperties =
               CreateRandomAddContactToPhoneBookRequestProperties();


            var randomAddContactToPhoneBookRequest = new AddContactToPhoneBookRequest
            {
                ApiKey = createRandomAddContactToPhoneBookRequestProperties.ApiKey,
                Company = createRandomAddContactToPhoneBookRequestProperties.Company,
                CountryCode = createRandomAddContactToPhoneBookRequestProperties.CountryCode,
                EmailAddress = createRandomAddContactToPhoneBookRequestProperties.EmailAddress,
                FirstName = createRandomAddContactToPhoneBookRequestProperties.FirstName,
                LastName = createRandomAddContactToPhoneBookRequestProperties.LastName,
                PhoneNumber = createRandomAddContactToPhoneBookRequestProperties.PhoneNumber
               




            };

            var randomAddContactToPhoneBook = new AddContactToPhoneBook
            {
                Request = randomAddContactToPhoneBookRequest
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
                broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AddContactToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactToPhoneBookRequestAsync(randomAddContactToPhoneBook,apiKey);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostAddContactToPhoneBookRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomAddContactToPhoneBookRequestProperties =
            CreateRandomAddContactToPhoneBookRequestProperties();


            var randomAddContactToPhoneBookRequest = new AddContactToPhoneBookRequest
            {
                ApiKey = createRandomAddContactToPhoneBookRequestProperties.ApiKey,
                Company = createRandomAddContactToPhoneBookRequestProperties.Company,
                CountryCode = createRandomAddContactToPhoneBookRequestProperties.CountryCode,
                EmailAddress = createRandomAddContactToPhoneBookRequestProperties.EmailAddress,
                FirstName = createRandomAddContactToPhoneBookRequestProperties.FirstName,
                LastName = createRandomAddContactToPhoneBookRequestProperties.LastName,
                PhoneNumber = createRandomAddContactToPhoneBookRequestProperties.PhoneNumber





            };

            var randomAddContactToPhoneBook = new AddContactToPhoneBook
            {
                Request = randomAddContactToPhoneBookRequest
            };

            var apiKey = GetRandomString();

            var unauthorizedSwitchException =
                new UnauthorizedSwitchException(unauthorizedException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(unauthorizedSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AddContactToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactToPhoneBookRequestAsync(randomAddContactToPhoneBook, apiKey);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostAddContactToPhoneBookRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomAddContactToPhoneBookRequestProperties =
              CreateRandomAddContactToPhoneBookRequestProperties();


            var randomAddContactToPhoneBookRequest = new AddContactToPhoneBookRequest
            {
                ApiKey = createRandomAddContactToPhoneBookRequestProperties.ApiKey,
                Company = createRandomAddContactToPhoneBookRequestProperties.Company,
                CountryCode = createRandomAddContactToPhoneBookRequestProperties.CountryCode,
                EmailAddress = createRandomAddContactToPhoneBookRequestProperties.EmailAddress,
                FirstName = createRandomAddContactToPhoneBookRequestProperties.FirstName,
                LastName = createRandomAddContactToPhoneBookRequestProperties.LastName,
                PhoneNumber = createRandomAddContactToPhoneBookRequestProperties.PhoneNumber





            };

            var randomAddContactToPhoneBook = new AddContactToPhoneBook
            {
                Request = randomAddContactToPhoneBookRequest
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
                broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AddContactToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactToPhoneBookRequestAsync(randomAddContactToPhoneBook, apiKey);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostAddContactToPhoneBookRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomAddContactToPhoneBookRequestProperties =
             CreateRandomAddContactToPhoneBookRequestProperties();


            var randomAddContactToPhoneBookRequest = new AddContactToPhoneBookRequest
            {
                ApiKey = createRandomAddContactToPhoneBookRequestProperties.ApiKey,
                Company = createRandomAddContactToPhoneBookRequestProperties.Company,
                CountryCode = createRandomAddContactToPhoneBookRequestProperties.CountryCode,
                EmailAddress = createRandomAddContactToPhoneBookRequestProperties.EmailAddress,
                FirstName = createRandomAddContactToPhoneBookRequestProperties.FirstName,
                LastName = createRandomAddContactToPhoneBookRequestProperties.LastName,
                PhoneNumber = createRandomAddContactToPhoneBookRequestProperties.PhoneNumber





            };

            var randomAddContactToPhoneBook = new AddContactToPhoneBook
            {
                Request = randomAddContactToPhoneBookRequest
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
                broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AddContactToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactToPhoneBookRequestAsync(randomAddContactToPhoneBook, apiKey);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostAddContactToPhoneBookRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomAddContactToPhoneBookRequestProperties =
             CreateRandomAddContactToPhoneBookRequestProperties();


            var randomAddContactToPhoneBookRequest = new AddContactToPhoneBookRequest
            {
                ApiKey = createRandomAddContactToPhoneBookRequestProperties.ApiKey,
                Company = createRandomAddContactToPhoneBookRequestProperties.Company,
                CountryCode = createRandomAddContactToPhoneBookRequestProperties.CountryCode,
                EmailAddress = createRandomAddContactToPhoneBookRequestProperties.EmailAddress,
                FirstName = createRandomAddContactToPhoneBookRequestProperties.FirstName,
                LastName = createRandomAddContactToPhoneBookRequestProperties.LastName,
                PhoneNumber = createRandomAddContactToPhoneBookRequestProperties.PhoneNumber





            };

            var randomAddContactToPhoneBook = new AddContactToPhoneBook
            {
                Request = randomAddContactToPhoneBookRequest
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
                 broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AddContactToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactToPhoneBookRequestAsync(randomAddContactToPhoneBook, apiKey);

            SwitchDependencyValidationException actualSwitchDependencyValidationException =
                await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostAddContactToPhoneBookRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomAddContactToPhoneBookRequestProperties =
            CreateRandomAddContactToPhoneBookRequestProperties();


            var randomAddContactToPhoneBookRequest = new AddContactToPhoneBookRequest
            {
                ApiKey = createRandomAddContactToPhoneBookRequestProperties.ApiKey,
                Company = createRandomAddContactToPhoneBookRequestProperties.Company,
                CountryCode = createRandomAddContactToPhoneBookRequestProperties.CountryCode,
                EmailAddress = createRandomAddContactToPhoneBookRequestProperties.EmailAddress,
                FirstName = createRandomAddContactToPhoneBookRequestProperties.FirstName,
                LastName = createRandomAddContactToPhoneBookRequestProperties.LastName,
                PhoneNumber = createRandomAddContactToPhoneBookRequestProperties.PhoneNumber





            };

            var randomAddContactToPhoneBook = new AddContactToPhoneBook
            {
                Request = randomAddContactToPhoneBookRequest
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
                 broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AddContactToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactToPhoneBookRequestAsync(randomAddContactToPhoneBook, apiKey);

            SwitchDependencyException actualSwitchDependencyException =
                await Assert.ThrowsAsync<SwitchDependencyException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostAddContactToPhoneBookRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomAddContactToPhoneBookRequestProperties =
             CreateRandomAddContactToPhoneBookRequestProperties();


            var randomAddContactToPhoneBookRequest = new AddContactToPhoneBookRequest
            {
                ApiKey = createRandomAddContactToPhoneBookRequestProperties.ApiKey,
                Company = createRandomAddContactToPhoneBookRequestProperties.Company,
                CountryCode = createRandomAddContactToPhoneBookRequestProperties.CountryCode,
                EmailAddress = createRandomAddContactToPhoneBookRequestProperties.EmailAddress,
                FirstName = createRandomAddContactToPhoneBookRequestProperties.FirstName,
                LastName = createRandomAddContactToPhoneBookRequestProperties.LastName,
                PhoneNumber = createRandomAddContactToPhoneBookRequestProperties.PhoneNumber





            };

            var randomAddContactToPhoneBook = new AddContactToPhoneBook
            {
                Request = randomAddContactToPhoneBookRequest
            };

             var apiKey = GetRandomString();

            var serviceException = new Exception();

            var failedSwitchServiceException =
                new FailedSwitchServiceException(serviceException);

            var expectedSwitchServiceException =
                new SwitchServiceException(failedSwitchServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AddContactToPhoneBook> retrieveSwitchTask =
               this.switchService.PostContactToPhoneBookRequestAsync(randomAddContactToPhoneBook, apiKey);

            SwitchServiceException actualSwitchServiceException =
                await Assert.ThrowsAsync<SwitchServiceException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchServiceException.Should().BeEquivalentTo(
                expectedSwitchServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactToPhoneBookAsync(It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}