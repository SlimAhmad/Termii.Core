using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Insights;

namespace Termii.Core.Tests.Unit.Foundations.Services.Insights
{
    public partial class InsightsServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnSearchIfSearchIsNullAsync()
        {
            // given
            Search nullInsights = null;
            var nullInsightsException = new NullInsightsException();

            var exceptedInsightsValidationException =
                new InsightsValidationException(nullInsightsException);

            // when
            ValueTask<Search> PaymentsTask =
                this.insightsService.GetSearchPhoneNumberStatusAsync(nullInsights);

            InsightsValidationException actualInsightsValidationException =
                await Assert.ThrowsAsync<InsightsValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualInsightsValidationException.Should()
                .BeEquivalentTo(exceptedInsightsValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetSearchPhoneNumberStatusAsync(
                    It.IsAny<ExternalSearchRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnSearchIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new Search();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidInsightsException();

            invalidPaymentsException.AddData(
                key: nameof(SearchRequest),
                values: "Value is required");

            var expectedInsightsValidationException =
                new InsightsValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<Search> SearchTask =
                this.insightsService.GetSearchPhoneNumberStatusAsync(invalidPayments);

            InsightsValidationException actualInsightsValidationException =
                await Assert.ThrowsAsync<InsightsValidationException>(
                    SearchTask.AsTask);

            // then
            actualInsightsValidationException.Should()
                .BeEquivalentTo(expectedInsightsValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetSearchPhoneNumberStatusAsync(
                    It.IsAny<ExternalSearchRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostSearchIfSearchIsInvalidAsync(
           string invalidPhoneNumber, string invalidApiKey)
        {
            // given
            var Search = new Search
            {
                Request = new SearchRequest
                {
                    PhoneNumber = invalidPhoneNumber,
                    ApiKey = invalidApiKey



                }
            };

            var invalidPaymentsException = new InvalidInsightsException();

            invalidPaymentsException.AddData(
                key: nameof(SearchRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SearchRequest.PhoneNumber),
                values: "Value is required");







            var expectedInsightsValidationException =
                new InsightsValidationException(invalidPaymentsException);

            // when
            ValueTask<Search> SearchTask =
                this.insightsService.GetSearchPhoneNumberStatusAsync(Search);

            InsightsValidationException actualInsightsValidationException =
                await Assert.ThrowsAsync<InsightsValidationException>(SearchTask.AsTask);

            // then
            actualInsightsValidationException.Should().BeEquivalentTo(
                expectedInsightsValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostSearchIfPostSearchIsEmptyAsync()
        {
            // given
            var Search = new Search
            {
                Request = new SearchRequest
                {

                    PhoneNumber = string.Empty,
                    ApiKey = string.Empty,



                }
            };

            var invalidPaymentsException = new InvalidInsightsException();


            invalidPaymentsException.AddData(
                key: nameof(SearchRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SearchRequest.PhoneNumber),
                values: "Value is required");







            var expectedInsightsValidationException =
                new InsightsValidationException(invalidPaymentsException);

            // when
            ValueTask<Search> SearchTask =
                this.insightsService.GetSearchPhoneNumberStatusAsync(Search);

            InsightsValidationException actualInsightsValidationException =
                await Assert.ThrowsAsync<InsightsValidationException>(
                    SearchTask.AsTask);

            // then
            actualInsightsValidationException.Should().BeEquivalentTo(
                expectedInsightsValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


    }
}