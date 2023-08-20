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
        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateCampaignPhoneBookIfUpdateCampaignPhoneBookIsNullAsync()
        {
            // given
            UpdateCampaignPhoneBook nullSwitch = null;
            var nullSwitchException = new NullSwitchException();

            string phoneBookId = null;

            var exceptedSwitchValidationException =
                new SwitchValidationException(nullSwitchException);

            // when
            ValueTask<UpdateCampaignPhoneBook> PaymentsTask =
                this.switchService.UpdateCampaignPhoneBookRequestAsync(phoneBookId,nullSwitch);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(exceptedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),
                    It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateCampaignPhoneBookIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new UpdateCampaignPhoneBook();
            invalidPayments.Request = null;

            string phoneBookId = null;

            var invalidPaymentsException =
                new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(UpdateCampaignPhoneBookRequest),
                values: "Value is required");

            var expectedSwitchValidationException =
                new SwitchValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<UpdateCampaignPhoneBook> UpdateCampaignPhoneBookTask =
                this.switchService.UpdateCampaignPhoneBookRequestAsync(phoneBookId, invalidPayments);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    UpdateCampaignPhoneBookTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(expectedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),
                    It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null,null)]
        [InlineData("", "","","")]
        [InlineData("  ", "  "," "," ")]
        public async Task ShouldThrowValidationExceptionOnPostUpdateCampaignPhoneBookIfUpdateCampaignPhoneBookIsInvalidAsync(
           string invalidApiKey,
           string invalidDescription,
           string invalidPhoneNumber, string invalidPhoneBookId)
        {
            // given
            var addContactToPhoneBook = new UpdateCampaignPhoneBook
            {
                Request = new UpdateCampaignPhoneBookRequest
                {
                    ApiKey = invalidApiKey,
                    Description = invalidDescription,
                    PhonebookName = invalidPhoneNumber,
                  
                  



                }
            };

            var phoneBookId = invalidPhoneBookId;

            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(UpdateCampaignPhoneBookRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(UpdateCampaignPhoneBookRequest.Description),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(UpdateCampaignPhoneBookRequest.PhonebookName),
                values: "Value is required");


            invalidPaymentsException.AddData(
              key: nameof(UpdateCampaignPhoneBook),
              values: "Value is required");


            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<UpdateCampaignPhoneBook> UpdateCampaignPhoneBookTask =
                this.switchService.UpdateCampaignPhoneBookRequestAsync(phoneBookId, addContactToPhoneBook);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(UpdateCampaignPhoneBookTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostUpdateCampaignPhoneBookIfPostUpdateCampaignPhoneBookIsEmptyAsync()
        {
            // given
            var addContactToPhoneBook = new UpdateCampaignPhoneBook
            {
                Request = new UpdateCampaignPhoneBookRequest
                {

                    ApiKey = string.Empty,
                    Description = string.Empty,
                    PhonebookName = string.Empty,
              
                    




                }
            };

            var phoneBookId = string.Empty;

            var invalidPaymentsException = new InvalidSwitchException();


            invalidPaymentsException.AddData(
                key: nameof(UpdateCampaignPhoneBookRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(UpdateCampaignPhoneBookRequest.Description),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(UpdateCampaignPhoneBookRequest.PhonebookName),
                values: "Value is required");



            invalidPaymentsException.AddData(
              key: nameof(UpdateCampaignPhoneBook),
              values: "Value is required");




            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<UpdateCampaignPhoneBook> UpdateCampaignPhoneBookTask =
                this.switchService.UpdateCampaignPhoneBookRequestAsync(phoneBookId, addContactToPhoneBook);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    UpdateCampaignPhoneBookTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
