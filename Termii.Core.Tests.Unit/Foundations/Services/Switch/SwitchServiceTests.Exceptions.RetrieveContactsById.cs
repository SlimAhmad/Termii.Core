﻿using FluentAssertions;
using Moq;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Switch;

namespace Termii.Core.Tests.Unit.Foundations.Services.Switch
{
    public partial class SwitchServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnFetchContactsByPhoneBookIdRequestIfUrlNotFoundAsync()
        {
            // given
            var contactId = GetRandomString();

            var apiKey = GetRandomString();
          
            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationSwitchException =
                new InvalidConfigurationSwitchException(
                    message: "Invalid switch configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(
                    message: "Switch dependency error occurred, contact support.",
                    invalidConfigurationSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetContactsByPhoneBookIdAsync(apiKey, contactId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FetchContactsByPhoneBookId> retrieveFetchContactsByPhoneBookIdTask =
               this.switchService.GetContactsByPhoneBookIdRequestAsync(apiKey, contactId);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveFetchContactsByPhoneBookIdTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetContactsByPhoneBookIdAsync(apiKey, contactId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnFetchContactsByPhoneBookIdRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
              var contactId = GetRandomString();

            var apiKey = GetRandomString();
            var unauthorizedSwitchException =
                new UnauthorizedSwitchException(unauthorizedException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(unauthorizedSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.GetContactsByPhoneBookIdAsync(apiKey,contactId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FetchContactsByPhoneBookId> retrieveFetchContactsByPhoneBookIdTask =
               this.switchService.GetContactsByPhoneBookIdRequestAsync(apiKey, contactId);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveFetchContactsByPhoneBookIdTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetContactsByPhoneBookIdAsync(apiKey, contactId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFetchContactsByPhoneBookIdRequestIfNotFoundOccurredAsync()
        {
            // given
              var contactId = GetRandomString();

            var apiKey = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundSwitchException =
                new NotFoundSwitchException(
                    message: "Not found switch error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    message: "Switch dependency validation error occurred, contact support.",
                    notFoundSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetContactsByPhoneBookIdAsync(apiKey, contactId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FetchContactsByPhoneBookId> retrieveFetchContactsByPhoneBookIdTask =
               this.switchService.GetContactsByPhoneBookIdRequestAsync(apiKey, contactId);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveFetchContactsByPhoneBookIdTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetContactsByPhoneBookIdAsync(apiKey,contactId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFetchContactsByPhoneBookIdRequestIfBadRequestOccurredAsync()
        {
            // given
              var contactId = GetRandomString();

            var apiKey = GetRandomString();
            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidSwitchException =
                new InvalidSwitchException(
                    message: "Invalid switch error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    message: "Switch dependency validation error occurred, contact support.",
                    invalidSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetContactsByPhoneBookIdAsync(apiKey, contactId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FetchContactsByPhoneBookId> retrieveFetchContactsByPhoneBookIdTask =
               this.switchService.GetContactsByPhoneBookIdRequestAsync(apiKey,contactId);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveFetchContactsByPhoneBookIdTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetContactsByPhoneBookIdAsync(apiKey, contactId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFetchContactsByPhoneBookIdRequestIfTooManyRequestsOccurredAsync()
        {
            // given
              var contactId = GetRandomString();

            var apiKey = GetRandomString();
            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallSwitchException =
                new ExcessiveCallSwitchException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    message: "Switch dependency validation error occurred, contact support.",
                    excessiveCallSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.GetContactsByPhoneBookIdAsync(apiKey,contactId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FetchContactsByPhoneBookId> retrieveFetchContactsByPhoneBookIdTask =
               this.switchService.GetContactsByPhoneBookIdRequestAsync(apiKey, contactId);

            SwitchDependencyValidationException actualSwitchDependencyValidationException =
                await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                    retrieveFetchContactsByPhoneBookIdTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetContactsByPhoneBookIdAsync(apiKey,contactId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnFetchContactsByPhoneBookIdRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
              var contactId = GetRandomString();

            var apiKey = GetRandomString();
            var httpResponseException =
                new HttpResponseException();

            var failedServerSwitchException =
                new FailedServerSwitchException(
                    message: "Failed switch server error occurred, contact support.",
                    httpResponseException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(
                    message: "Switch dependency error occurred, contact support.",
                    failedServerSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.GetContactsByPhoneBookIdAsync(apiKey, contactId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FetchContactsByPhoneBookId> retrieveFetchContactsByPhoneBookIdTask =
               this.switchService.GetContactsByPhoneBookIdRequestAsync(apiKey,contactId);

            SwitchDependencyException actualSwitchDependencyException =
                await Assert.ThrowsAsync<SwitchDependencyException>(
                    retrieveFetchContactsByPhoneBookIdTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetContactsByPhoneBookIdAsync(apiKey, contactId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnFetchContactsByPhoneBookIdRequestIfServiceErrorOccurredAsync()
        {
            // given
              var contactId = GetRandomString();

            var apiKey = GetRandomString();var serviceException = new Exception();

            var failedSwitchServiceException =
                new FailedSwitchServiceException(serviceException);

            var expectedSwitchServiceException =
                new SwitchServiceException(failedSwitchServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetContactsByPhoneBookIdAsync(apiKey,contactId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FetchContactsByPhoneBookId> retrieveFetchContactsByPhoneBookIdTask =
               this.switchService.GetContactsByPhoneBookIdRequestAsync(apiKey, contactId);

            SwitchServiceException actualSwitchServiceException =
                await Assert.ThrowsAsync<SwitchServiceException>(
                    retrieveFetchContactsByPhoneBookIdTask.AsTask);

            // then
            actualSwitchServiceException.Should().BeEquivalentTo(
                expectedSwitchServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetContactsByPhoneBookIdAsync(apiKey, contactId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}