using FluentAssertions;
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
        public async Task ShouldThrowDependencyExceptionOnFetchCampaignsHistoryRequestIfUrlNotFoundAsync()
        {
            // given
            

            var apiKey = GetRandomString();
            var campaignId = GetRandomString();

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
                broker.GetCampaignsHistoryAsync(apiKey, campaignId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FetchCampaignsHistory> retrieveFetchCampaignsHistoryTask =
               this.switchService.GetCampaignsHistoryRequestAsync(apiKey,campaignId);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveFetchCampaignsHistoryTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetCampaignsHistoryAsync(apiKey, campaignId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnFetchCampaignsHistoryRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
              

            var apiKey = GetRandomString();
            var campaignId = GetRandomString();

            var unauthorizedSwitchException =
                new UnauthorizedSwitchException(unauthorizedException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(unauthorizedSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.GetCampaignsHistoryAsync(apiKey, campaignId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FetchCampaignsHistory> retrieveFetchCampaignsHistoryTask =
               this.switchService.GetCampaignsHistoryRequestAsync(apiKey,campaignId);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveFetchCampaignsHistoryTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetCampaignsHistoryAsync(apiKey, campaignId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFetchCampaignsHistoryRequestIfNotFoundOccurredAsync()
        {
            // given
              

            var apiKey = GetRandomString();
            var campaignId = GetRandomString();


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
                broker.GetCampaignsHistoryAsync(apiKey, campaignId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FetchCampaignsHistory> retrieveFetchCampaignsHistoryTask =
               this.switchService.GetCampaignsHistoryRequestAsync(apiKey,campaignId);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveFetchCampaignsHistoryTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetCampaignsHistoryAsync(apiKey, campaignId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFetchCampaignsHistoryRequestIfBadRequestOccurredAsync()
        {
            // given
              

            var apiKey = GetRandomString();
            var campaignId = GetRandomString();

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
                broker.GetCampaignsHistoryAsync(apiKey, campaignId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FetchCampaignsHistory> retrieveFetchCampaignsHistoryTask =
               this.switchService.GetCampaignsHistoryRequestAsync(apiKey,campaignId);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveFetchCampaignsHistoryTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetCampaignsHistoryAsync(apiKey, campaignId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFetchCampaignsHistoryRequestIfTooManyRequestsOccurredAsync()
        {
            // given
              

            var apiKey = GetRandomString();
            var campaignId = GetRandomString();

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
                 broker.GetCampaignsHistoryAsync(apiKey, campaignId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FetchCampaignsHistory> retrieveFetchCampaignsHistoryTask =
               this.switchService.GetCampaignsHistoryRequestAsync(apiKey,campaignId);

            SwitchDependencyValidationException actualSwitchDependencyValidationException =
                await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                    retrieveFetchCampaignsHistoryTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetCampaignsHistoryAsync(apiKey, campaignId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnFetchCampaignsHistoryRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
              

            var apiKey = GetRandomString();
            var campaignId = GetRandomString();

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
                 broker.GetCampaignsHistoryAsync(apiKey, campaignId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FetchCampaignsHistory> retrieveFetchCampaignsHistoryTask =
               this.switchService.GetCampaignsHistoryRequestAsync(apiKey,campaignId);

            SwitchDependencyException actualSwitchDependencyException =
                await Assert.ThrowsAsync<SwitchDependencyException>(
                    retrieveFetchCampaignsHistoryTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetCampaignsHistoryAsync(apiKey, campaignId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnFetchCampaignsHistoryRequestIfServiceErrorOccurredAsync()
        {
            // given
              

            var apiKey = GetRandomString();
            var campaignId = GetRandomString();
            var serviceException = new Exception();

            var failedSwitchServiceException =
                new FailedSwitchServiceException(serviceException);

            var expectedSwitchServiceException =
                new SwitchServiceException(failedSwitchServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetCampaignsHistoryAsync(apiKey, campaignId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FetchCampaignsHistory> retrieveFetchCampaignsHistoryTask =
               this.switchService.GetCampaignsHistoryRequestAsync(apiKey,campaignId);

            SwitchServiceException actualSwitchServiceException =
                await Assert.ThrowsAsync<SwitchServiceException>(
                    retrieveFetchCampaignsHistoryTask.AsTask);

            // then
            actualSwitchServiceException.Should().BeEquivalentTo(
                expectedSwitchServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetCampaignsHistoryAsync(apiKey, campaignId),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}