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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnPostBalanceIfBalanceRequestIsInvalidAsync(
            string invalidApiKey)
        {
            // given


            var invalidPaymentsException = new InvalidInsightsException();

            invalidPaymentsException.AddData(
                key: nameof(Balance),
                values: "Value is required");




            var expectedInsightsValidationException =
                new InsightsValidationException(invalidPaymentsException);

            // when
            ValueTask<Balance> BalanceTask =
                this.insightsService.GetBalanceAsync(invalidApiKey);

            InsightsValidationException actualInsightsValidationException =
                await Assert.ThrowsAsync<InsightsValidationException>(BalanceTask.AsTask);

            // then
            actualInsightsValidationException.Should().BeEquivalentTo(
                expectedInsightsValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


    }
}