using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Switch;

namespace Termii.Core.Tests.Unit.Foundations.Services.Switch
{
    public partial class SwitchServiceTests
    {

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnFetchCampaignsIfFetchCampaignsRequestIsInvalidAsync(
            string invalidApiKey)
        {
            // given


            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(FetchCampaigns),
                values: "Value is required");




            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<FetchCampaigns> FetchCampaignsTask =
                this.switchService.GetCampaignsRequestAsync(invalidApiKey);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(FetchCampaignsTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


    }
}