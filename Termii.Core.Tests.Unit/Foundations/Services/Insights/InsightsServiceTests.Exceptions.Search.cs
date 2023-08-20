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
        public async Task ShouldThrowDependencyExceptionOnPostSearchRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomSearchRequestProperties =
               CreateRandomSearchRequestProperties();


            var randomSearchRequest = new SearchRequest
            {
                ApiKey = createRandomSearchRequestProperties.ApiKey,
                PhoneNumber = createRandomSearchRequestProperties.PhoneNumber,
             

            };

            var randomSearch = new Search
            {
                Request = randomSearchRequest
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
                broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Search> retrieveInsightsTask =
               this.insightsService.GetSearchPhoneNumberStatusAsync(randomSearch);

            InsightsDependencyException
                actualInsightsDependencyException =
                    await Assert.ThrowsAsync<InsightsDependencyException>(
                        retrieveInsightsTask.AsTask);

            // then
            actualInsightsDependencyException.Should().BeEquivalentTo(
                expectedInsightsDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostSearchRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomSearchRequestProperties =
             CreateRandomSearchRequestProperties();




            var randomSearchRequest = new SearchRequest
            {
                ApiKey = createRandomSearchRequestProperties.ApiKey,
                PhoneNumber = createRandomSearchRequestProperties.PhoneNumber,




            };

            var randomSearch = new Search
            {
                Request = randomSearchRequest
            };

            var unauthorizedInsightsException =
                new UnauthorizedInsightsException(unauthorizedException);

            var expectedInsightsDependencyException =
                new InsightsDependencyException(unauthorizedInsightsException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Search> retrieveInsightsTask =
               this.insightsService.GetSearchPhoneNumberStatusAsync(randomSearch);

            InsightsDependencyException
                actualInsightsDependencyException =
                    await Assert.ThrowsAsync<InsightsDependencyException>(
                        retrieveInsightsTask.AsTask);

            // then
            actualInsightsDependencyException.Should().BeEquivalentTo(
                expectedInsightsDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostSearchRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomSearchRequestProperties =
              CreateRandomSearchRequestProperties();




            var randomSearchRequest = new SearchRequest
            {
                ApiKey = createRandomSearchRequestProperties.ApiKey,
                PhoneNumber = createRandomSearchRequestProperties.PhoneNumber,




            };

            var randomSearch = new Search
            {
                Request = randomSearchRequest
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
                broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Search> retrieveInsightsTask =
               this.insightsService.GetSearchPhoneNumberStatusAsync(randomSearch);

            InsightsDependencyValidationException
                actualInsightsDependencyValidationException =
                    await Assert.ThrowsAsync<InsightsDependencyValidationException>(
                        retrieveInsightsTask.AsTask);

            // then
            actualInsightsDependencyValidationException.Should().BeEquivalentTo(
                expectedInsightsDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostSearchRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomSearchRequestProperties =
          CreateRandomSearchRequestProperties();


            var randomSearchRequest = new SearchRequest
            {
                ApiKey = createRandomSearchRequestProperties.ApiKey,
                PhoneNumber = createRandomSearchRequestProperties.PhoneNumber,




            };

            var randomSearch = new Search
            {
                Request = randomSearchRequest
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
                broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Search> retrieveInsightsTask =
               this.insightsService.GetSearchPhoneNumberStatusAsync(randomSearch);

            InsightsDependencyValidationException
                actualInsightsDependencyValidationException =
                    await Assert.ThrowsAsync<InsightsDependencyValidationException>(
                        retrieveInsightsTask.AsTask);

            // then
            actualInsightsDependencyValidationException.Should().BeEquivalentTo(
                expectedInsightsDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostSearchRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomSearchRequestProperties =
          CreateRandomSearchRequestProperties();


            var randomSearchRequest = new SearchRequest
            {
                ApiKey = createRandomSearchRequestProperties.ApiKey,
                PhoneNumber = createRandomSearchRequestProperties.PhoneNumber,




            };

            var randomSearch = new Search
            {
                Request = randomSearchRequest
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
                 broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Search> retrieveInsightsTask =
               this.insightsService.GetSearchPhoneNumberStatusAsync(randomSearch);

            InsightsDependencyValidationException actualInsightsDependencyValidationException =
                await Assert.ThrowsAsync<InsightsDependencyValidationException>(
                    retrieveInsightsTask.AsTask);

            // then
            actualInsightsDependencyValidationException.Should().BeEquivalentTo(
                expectedInsightsDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostSearchRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomSearchRequestProperties =
          CreateRandomSearchRequestProperties();


            var randomSearchRequest = new SearchRequest
            {
                ApiKey = createRandomSearchRequestProperties.ApiKey,
                PhoneNumber = createRandomSearchRequestProperties.PhoneNumber,




            };

            var randomSearch = new Search
            {
                Request = randomSearchRequest
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
                 broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Search> retrieveInsightsTask =
               this.insightsService.GetSearchPhoneNumberStatusAsync(randomSearch);

            InsightsDependencyException actualInsightsDependencyException =
                await Assert.ThrowsAsync<InsightsDependencyException>(
                    retrieveInsightsTask.AsTask);

            // then
            actualInsightsDependencyException.Should().BeEquivalentTo(
                expectedInsightsDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostSearchRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomSearchRequestProperties =
            CreateRandomSearchRequestProperties();


            var randomSearchRequest = new SearchRequest
            {
                ApiKey = createRandomSearchRequestProperties.ApiKey,
                PhoneNumber = createRandomSearchRequestProperties.PhoneNumber,




            };

            var randomSearch = new Search
            {
                Request = randomSearchRequest
            };

            var serviceException = new Exception();

            var failedInsightsServiceException =
                new FailedInsightsServiceException(serviceException);

            var expectedInsightsServiceException =
                new InsightsServiceException(failedInsightsServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Search> retrieveInsightsTask =
               this.insightsService.GetSearchPhoneNumberStatusAsync(randomSearch);

            InsightsServiceException actualInsightsServiceException =
                await Assert.ThrowsAsync<InsightsServiceException>(
                    retrieveInsightsTask.AsTask);

            // then
            actualInsightsServiceException.Should().BeEquivalentTo(
                expectedInsightsServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetSearchPhoneNumberStatusAsync(It.IsAny<ExternalSearchRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}