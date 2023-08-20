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
        public async Task ShouldThrowDependencyExceptionOnBalanceRequestIfUrlNotFoundAsync()
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
                broker.GetBalanceAsync(apiKey))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.insightsService.GetBalanceAsync(apiKey);

            InsightsDependencyException
                actualInsightsDependencyException =
                    await Assert.ThrowsAsync<InsightsDependencyException>(
                        retrieveBalanceTask.AsTask);

            // then
            actualInsightsDependencyException.Should().BeEquivalentTo(
                expectedInsightsDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnBalanceRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given

            var apiKey = GetRandomString();
            var unauthorizedInsightsException =
                new UnauthorizedInsightsException(unauthorizedException);

            var expectedInsightsDependencyException =
                new InsightsDependencyException(unauthorizedInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.GetBalanceAsync(apiKey))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.insightsService.GetBalanceAsync(apiKey);

            InsightsDependencyException
                actualInsightsDependencyException =
                    await Assert.ThrowsAsync<InsightsDependencyException>(
                        retrieveBalanceTask.AsTask);

            // then
            actualInsightsDependencyException.Should().BeEquivalentTo(
                expectedInsightsDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBalanceRequestIfNotFoundOccurredAsync()
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
                broker.GetBalanceAsync(apiKey))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.insightsService.GetBalanceAsync(apiKey);

            InsightsDependencyValidationException
                actualInsightsDependencyValidationException =
                    await Assert.ThrowsAsync<InsightsDependencyValidationException>(
                        retrieveBalanceTask.AsTask);

            // then
            actualInsightsDependencyValidationException.Should().BeEquivalentTo(
                expectedInsightsDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBalanceRequestIfBadRequestOccurredAsync()
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
                broker.GetBalanceAsync(apiKey))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.insightsService.GetBalanceAsync(apiKey);

            InsightsDependencyValidationException
                actualInsightsDependencyValidationException =
                    await Assert.ThrowsAsync<InsightsDependencyValidationException>(
                        retrieveBalanceTask.AsTask);

            // then
            actualInsightsDependencyValidationException.Should().BeEquivalentTo(
                expectedInsightsDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBalanceRequestIfTooManyRequestsOccurredAsync()
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
                 broker.GetBalanceAsync(apiKey))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.insightsService.GetBalanceAsync(apiKey);

            InsightsDependencyValidationException actualInsightsDependencyValidationException =
                await Assert.ThrowsAsync<InsightsDependencyValidationException>(
                    retrieveBalanceTask.AsTask);

            // then
            actualInsightsDependencyValidationException.Should().BeEquivalentTo(
                expectedInsightsDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBalanceRequestIfHttpResponseErrorOccurredAsync()
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
                 broker.GetBalanceAsync(apiKey))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.insightsService.GetBalanceAsync(apiKey);

            InsightsDependencyException actualInsightsDependencyException =
                await Assert.ThrowsAsync<InsightsDependencyException>(
                    retrieveBalanceTask.AsTask);

            // then
            actualInsightsDependencyException.Should().BeEquivalentTo(
                expectedInsightsDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnBalanceRequestIfServiceErrorOccurredAsync()
        {
            // given

            var apiKey = GetRandomString();var serviceException = new Exception();

            var failedInsightsServiceException =
                new FailedInsightsServiceException(serviceException);

            var expectedInsightsServiceException =
                new InsightsServiceException(failedInsightsServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetBalanceAsync(apiKey))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Balance> retrieveBalanceTask =
               this.insightsService.GetBalanceAsync(apiKey);

            InsightsServiceException actualInsightsServiceException =
                await Assert.ThrowsAsync<InsightsServiceException>(
                    retrieveBalanceTask.AsTask);

            // then
            actualInsightsServiceException.Should().BeEquivalentTo(
                expectedInsightsServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetBalanceAsync(apiKey),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}