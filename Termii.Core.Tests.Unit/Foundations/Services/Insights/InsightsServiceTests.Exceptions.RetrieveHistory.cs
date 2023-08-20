using FluentAssertions;
using Moq;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Insights;

namespace Termii.Core.Tests.Unit.Foundations.Services.Insights
{
    public partial class InsightsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnHistoryRequestIfUrlNotFoundAsync()
        {
            // given
            var apiKey = GetRandomString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationInsightsException =
                new InvalidConfigurationInsightsException(
                    message: "Invalid insights configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedInsightsDependencyException =
                new InsightsDependencyException(
                    message: "Insights dependency error occurred, contact support.",
                    invalidConfigurationInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetHistoryAsync(apiKey))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<History> retrieveHistoryTask =
               this.insightsService.GetHistoryAsync(apiKey);

            InsightsDependencyException
                actualInsightsDependencyException =
                    await Assert.ThrowsAsync<InsightsDependencyException>(
                        retrieveHistoryTask.AsTask);

            // then
            actualInsightsDependencyException.Should().BeEquivalentTo(
                expectedInsightsDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetHistoryAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnHistoryRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var apiKey = GetRandomString();

            var unauthorizedInsightsException =
                new UnauthorizedInsightsException(unauthorizedException);

            var expectedInsightsDependencyException =
                new InsightsDependencyException(unauthorizedInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.GetHistoryAsync(apiKey))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<History> retrieveHistoryTask =
               this.insightsService.GetHistoryAsync(apiKey);

            InsightsDependencyException
                actualInsightsDependencyException =
                    await Assert.ThrowsAsync<InsightsDependencyException>(
                        retrieveHistoryTask.AsTask);

            // then
            actualInsightsDependencyException.Should().BeEquivalentTo(
                expectedInsightsDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetHistoryAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnHistoryRequestIfNotFoundOccurredAsync()
        {
            // given
            var apiKey = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundInsightsException =
                new NotFoundInsightsException(
                    message: "Not found insights error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedInsightsDependencyValidationException =
                new InsightsDependencyValidationException(
                    message: "Insights dependency validation error occurred, contact support.",
                    notFoundInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetHistoryAsync(apiKey))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<History> retrieveHistoryTask =
               this.insightsService.GetHistoryAsync(apiKey);

            InsightsDependencyValidationException
                actualInsightsDependencyValidationException =
                    await Assert.ThrowsAsync<InsightsDependencyValidationException>(
                        retrieveHistoryTask.AsTask);

            // then
            actualInsightsDependencyValidationException.Should().BeEquivalentTo(
                expectedInsightsDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetHistoryAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnHistoryRequestIfBadRequestOccurredAsync()
        {
            // given
            var apiKey = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidInsightsException =
                new InvalidInsightsException(
                    message: "Invalid insights error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedInsightsDependencyValidationException =
                new InsightsDependencyValidationException(
                    message: "Insights dependency validation error occurred, contact support.",
                    invalidInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetHistoryAsync(apiKey))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<History> retrieveHistoryTask =
               this.insightsService.GetHistoryAsync(apiKey);

            InsightsDependencyValidationException
                actualInsightsDependencyValidationException =
                    await Assert.ThrowsAsync<InsightsDependencyValidationException>(
                        retrieveHistoryTask.AsTask);

            // then
            actualInsightsDependencyValidationException.Should().BeEquivalentTo(
                expectedInsightsDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetHistoryAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnHistoryRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var apiKey = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallInsightsException =
                new ExcessiveCallInsightsException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedInsightsDependencyValidationException =
                new InsightsDependencyValidationException(
                    message: "Insights dependency validation error occurred, contact support.",
                    excessiveCallInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.GetHistoryAsync(apiKey))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<History> retrieveHistoryTask =
               this.insightsService.GetHistoryAsync(apiKey);

            InsightsDependencyValidationException actualInsightsDependencyValidationException =
                await Assert.ThrowsAsync<InsightsDependencyValidationException>(
                    retrieveHistoryTask.AsTask);

            // then
            actualInsightsDependencyValidationException.Should().BeEquivalentTo(
                expectedInsightsDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetHistoryAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnHistoryRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var apiKey = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerInsightsException =
                new FailedServerInsightsException(
                    message: "Failed Insights server error occurred, contact support.",
                    httpResponseException);

            var expectedInsightsDependencyException =
                new InsightsDependencyException(
                    message: "Insights dependency error occurred, contact support.",
                    failedServerInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.GetHistoryAsync(apiKey))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<History> retrieveHistoryTask =
               this.insightsService.GetHistoryAsync(apiKey);

            InsightsDependencyException actualInsightsDependencyException =
                await Assert.ThrowsAsync<InsightsDependencyException>(
                    retrieveHistoryTask.AsTask);

            // then
            actualInsightsDependencyException.Should().BeEquivalentTo(
                expectedInsightsDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetHistoryAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnHistoryRequestIfServiceErrorOccurredAsync()
        {
            // given
            var apiKey = GetRandomString();
            var serviceException = new Exception();

            var failedInsightsServiceException =
                new FailedInsightsServiceException(serviceException);

            var expectedInsightsServiceException =
                new InsightsServiceException(failedInsightsServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetHistoryAsync(apiKey))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<History> retrieveHistoryTask =
               this.insightsService.GetHistoryAsync(apiKey);

            InsightsServiceException actualInsightsServiceException =
                await Assert.ThrowsAsync<InsightsServiceException>(
                    retrieveHistoryTask.AsTask);

            // then
            actualInsightsServiceException.Should().BeEquivalentTo(
                expectedInsightsServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetHistoryAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}