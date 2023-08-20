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
        public async Task ShouldThrowValidationExceptionOnRetrieveCampaignPhoneBookIfCampaignPhoneBookRequestIsInvalidAsync(
            string invalidApiKey)
        {
            // given


            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(CampaignPhoneBook),
                values: "Value is required");




            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<CampaignPhoneBook> CampaignPhoneBookTask =
                this.switchService.GetCampaignsPhoneBooksRequestAsync(invalidApiKey);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(CampaignPhoneBookTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


    }
}