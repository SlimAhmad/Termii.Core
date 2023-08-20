using FluentAssertions;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;
using Termii.Core.Models.Services.Foundations.Termii.Insights;
using Moq;
using RESTFulSense.Exceptions;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using System;

namespace Termii.Core.Tests.Unit.Foundations.Services.Insights
{
    public partial class InsightsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostStatusRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomStatusRequestProperties =
               CreateRandomStatusRequestProperties();


            var randomStatusRequest = new StatusRequest
            {
                ApiKey = createRandomStatusRequestProperties.ApiKey,
                PhoneNumber = createRandomStatusRequestProperties.PhoneNumber,
                CountryCode = createRandomStatusRequestProperties.CountryCode,
               

            };

            var randomStatus = new Status
            {
                Request = randomStatusRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationInsightsException =
                new InvalidConfigurationInsightsException(
                    httpResponseUrlNotFoundException);

            var expectedInsightsDependencyException =
                new InsightsDependencyException(
                    invalidConfigurationInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Status> retrieveInsightsTask =
               this.insightsService.GetPhoneNumberStatusAsync(randomStatus);

            InsightsDependencyException
                actualInsightsDependencyException =
                    await Assert.ThrowsAsync<InsightsDependencyException>(
                        retrieveInsightsTask.AsTask);

            // then
            actualInsightsDependencyException.Should().BeEquivalentTo(
                expectedInsightsDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostStatusRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomStatusRequestProperties =
             CreateRandomStatusRequestProperties();




            var randomStatusRequest = new StatusRequest
            {
                ApiKey = createRandomStatusRequestProperties.ApiKey,
                PhoneNumber = createRandomStatusRequestProperties.PhoneNumber,
                CountryCode = createRandomStatusRequestProperties.CountryCode,




            };

            var randomStatus = new Status
            {
                Request = randomStatusRequest
            };

            var unauthorizedInsightsException =
                new UnauthorizedInsightsException(unauthorizedException);

            var expectedInsightsDependencyException =
                new InsightsDependencyException(unauthorizedInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Status> retrieveInsightsTask =
               this.insightsService.GetPhoneNumberStatusAsync(randomStatus);

            InsightsDependencyException
                actualInsightsDependencyException =
                    await Assert.ThrowsAsync<InsightsDependencyException>(
                        retrieveInsightsTask.AsTask);

            // then
            actualInsightsDependencyException.Should().BeEquivalentTo(
                expectedInsightsDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostStatusRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomStatusRequestProperties =
              CreateRandomStatusRequestProperties();




            var randomStatusRequest = new StatusRequest
            {
                 ApiKey = createRandomStatusRequestProperties.ApiKey,
                PhoneNumber = createRandomStatusRequestProperties.PhoneNumber,
                CountryCode = createRandomStatusRequestProperties.CountryCode,




            };

            var randomStatus = new Status
            {
                Request = randomStatusRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundInsightsException =
                new NotFoundInsightsException(
                    httpResponseNotFoundException);

            var expectedInsightsDependencyValidationException =
                new InsightsDependencyValidationException(
                    notFoundInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Status> retrieveInsightsTask =
               this.insightsService.GetPhoneNumberStatusAsync(randomStatus);

            InsightsDependencyValidationException
                actualInsightsDependencyValidationException =
                    await Assert.ThrowsAsync<InsightsDependencyValidationException>(
                        retrieveInsightsTask.AsTask);

            // then
            actualInsightsDependencyValidationException.Should().BeEquivalentTo(
                expectedInsightsDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostStatusRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomStatusRequestProperties =
          CreateRandomStatusRequestProperties();


            var randomStatusRequest = new StatusRequest
            {
                 ApiKey = createRandomStatusRequestProperties.ApiKey,
                PhoneNumber = createRandomStatusRequestProperties.PhoneNumber,
                CountryCode = createRandomStatusRequestProperties.CountryCode,




            };

            var randomStatus = new Status
            {
                Request = randomStatusRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidInsightsException =
                new InvalidInsightsException(
                    httpResponseBadRequestException);

            var expectedInsightsDependencyValidationException =
                new InsightsDependencyValidationException(
                    invalidInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Status> retrieveInsightsTask =
               this.insightsService.GetPhoneNumberStatusAsync(randomStatus);

            InsightsDependencyValidationException
                actualInsightsDependencyValidationException =
                    await Assert.ThrowsAsync<InsightsDependencyValidationException>(
                        retrieveInsightsTask.AsTask);

            // then
            actualInsightsDependencyValidationException.Should().BeEquivalentTo(
                expectedInsightsDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostStatusRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomStatusRequestProperties =
          CreateRandomStatusRequestProperties();


            var randomStatusRequest = new StatusRequest
            {
                 ApiKey = createRandomStatusRequestProperties.ApiKey,
                PhoneNumber = createRandomStatusRequestProperties.PhoneNumber,
                CountryCode = createRandomStatusRequestProperties.CountryCode,




            };

            var randomStatus = new Status
            {
                Request = randomStatusRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallInsightsException =
                new ExcessiveCallInsightsException(
                    httpResponseTooManyRequestsException);

            var expectedInsightsDependencyValidationException =
                new InsightsDependencyValidationException(
                    excessiveCallInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Status> retrieveInsightsTask =
               this.insightsService.GetPhoneNumberStatusAsync(randomStatus);

            InsightsDependencyValidationException actualInsightsDependencyValidationException =
                await Assert.ThrowsAsync<InsightsDependencyValidationException>(
                    retrieveInsightsTask.AsTask);

            // then
            actualInsightsDependencyValidationException.Should().BeEquivalentTo(
                expectedInsightsDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostStatusRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomStatusRequestProperties =
          CreateRandomStatusRequestProperties();


            var randomStatusRequest = new StatusRequest
            {
                 ApiKey = createRandomStatusRequestProperties.ApiKey,
                PhoneNumber = createRandomStatusRequestProperties.PhoneNumber,
                CountryCode = createRandomStatusRequestProperties.CountryCode,




            };

            var randomStatus = new Status
            {
                Request = randomStatusRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerInsightsException =
                new FailedServerInsightsException(
                    httpResponseException);

            var expectedInsightsDependencyException =
                new InsightsDependencyException(
                    failedServerInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Status> retrieveInsightsTask =
               this.insightsService.GetPhoneNumberStatusAsync(randomStatus);

            InsightsDependencyException actualInsightsDependencyException =
                await Assert.ThrowsAsync<InsightsDependencyException>(
                    retrieveInsightsTask.AsTask);

            // then
            actualInsightsDependencyException.Should().BeEquivalentTo(
                expectedInsightsDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostStatusRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomStatusRequestProperties =
            CreateRandomStatusRequestProperties();


            var randomStatusRequest = new StatusRequest
            {
                 ApiKey = createRandomStatusRequestProperties.ApiKey,
                PhoneNumber = createRandomStatusRequestProperties.PhoneNumber,
                CountryCode = createRandomStatusRequestProperties.CountryCode,




            };

            var randomStatus = new Status
            {
                Request = randomStatusRequest
            };

            var serviceException = new Exception();

            var failedInsightsServiceException =
                new FailedInsightsServiceException(serviceException);

            var expectedInsightsServiceException =
                new InsightsServiceException(failedInsightsServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Status> retrieveInsightsTask =
               this.insightsService.GetPhoneNumberStatusAsync(randomStatus);

            InsightsServiceException actualInsightsServiceException =
                await Assert.ThrowsAsync<InsightsServiceException>(
                    retrieveInsightsTask.AsTask);

            // then
            actualInsightsServiceException.Should().BeEquivalentTo(
                expectedInsightsServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetPhoneNumberStatusAsync(It.IsAny<ExternalStatusRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}