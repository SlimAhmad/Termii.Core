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
        [InlineData(null,null)]
        [InlineData("","")]
        [InlineData("  "," ")]
        public async Task ShouldThrowValidationExceptionOnFetchContactsByPhoneBookIdIfFetchContactsByPhoneBookIdRequestIsInvalidAsync(
            string invalidApiKey, string invalidContactId)
        {
            // given


            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(FetchContactsByPhoneBookId),
                values: "Value is required");




            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<FetchContactsByPhoneBookId> FetchContactsByPhoneBookIdTask =
                this.switchService.GetContactsByPhoneBookIdRequestAsync(invalidApiKey,invalidContactId);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(FetchContactsByPhoneBookIdTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


    }
}