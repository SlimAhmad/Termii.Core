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
        public async Task ShouldThrowValidationExceptionOnStatusIfStatusIsNullAsync()
        {
            // given
            Status nullInsights = null;
            var nullInsightsException = new NullInsightsException();

            var exceptedInsightsValidationException =
                new InsightsValidationException(nullInsightsException);

            // when
            ValueTask<Status> PaymentsTask =
                this.insightsService.GetPhoneNumberStatusAsync(nullInsights);

            InsightsValidationException actualInsightsValidationException =
                await Assert.ThrowsAsync<InsightsValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualInsightsValidationException.Should()
                .BeEquivalentTo(exceptedInsightsValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetPhoneNumberStatusAsync(
                    It.IsAny<ExternalStatusRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnStatusIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new Status();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidInsightsException();

            invalidPaymentsException.AddData(
                key: nameof(StatusRequest),
                values: "Value is required");

            var expectedInsightsValidationException =
                new InsightsValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<Status> StatusTask =
                this.insightsService.GetPhoneNumberStatusAsync(invalidPayments);

            InsightsValidationException actualInsightsValidationException =
                await Assert.ThrowsAsync<InsightsValidationException>(
                    StatusTask.AsTask);

            // then
            actualInsightsValidationException.Should()
                .BeEquivalentTo(expectedInsightsValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.GetPhoneNumberStatusAsync(
                    It.IsAny<ExternalStatusRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", "", "")]
        [InlineData("  ", "  ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostStatusIfStatusIsInvalidAsync(
           string invalidPhoneNumber, string invalidApiKey, string invalidCountryCode)
        {
            // given
            var Status = new Status
            {
                Request = new StatusRequest
                {
                    PhoneNumber = invalidPhoneNumber,
                    ApiKey = invalidApiKey,
                    CountryCode = invalidCountryCode



                }
            };

            var invalidPaymentsException = new InvalidInsightsException();

            invalidPaymentsException.AddData(
                key: nameof(StatusRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(StatusRequest.PhoneNumber),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(StatusRequest.CountryCode),
                values: "Value is required");






            var expectedInsightsValidationException =
                new InsightsValidationException(invalidPaymentsException);

            // when
            ValueTask<Status> StatusTask =
                this.insightsService.GetPhoneNumberStatusAsync(Status);

            InsightsValidationException actualInsightsValidationException =
                await Assert.ThrowsAsync<InsightsValidationException>(StatusTask.AsTask);

            // then
            actualInsightsValidationException.Should().BeEquivalentTo(
                expectedInsightsValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostStatusIfPostStatusIsEmptyAsync()
        {
            // given
            var Status = new Status
            {
                Request = new StatusRequest
                {

                    PhoneNumber = string.Empty,
                    ApiKey = string.Empty,
                    CountryCode = string.Empty



                }
            };

            var invalidPaymentsException = new InvalidInsightsException();


            invalidPaymentsException.AddData(
                key: nameof(StatusRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(StatusRequest.PhoneNumber),
                values: "Value is required");


            invalidPaymentsException.AddData(
                key: nameof(StatusRequest.CountryCode),
                values: "Value is required");




            var expectedInsightsValidationException =
                new InsightsValidationException(invalidPaymentsException);

            // when
            ValueTask<Status> StatusTask =
                this.insightsService.GetPhoneNumberStatusAsync(Status);

            InsightsValidationException actualInsightsValidationException =
                await Assert.ThrowsAsync<InsightsValidationException>(
                    StatusTask.AsTask);

            // then
            actualInsightsValidationException.Should().BeEquivalentTo(
                expectedInsightsValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}