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
        public async Task ShouldThrowValidationExceptionOnAddMultipleContactsToPhoneBookIfAddMultipleContactsToPhoneBookIsNullAsync()
        {
            // given
            AddMultipleContactsToPhoneBook nullSwitch = null;
            var nullSwitchException = new NullSwitchException();

            string phoneBookId = null;

            var exceptedSwitchValidationException =
                new SwitchValidationException(nullSwitchException);

            // when
            ValueTask<AddMultipleContactsToPhoneBook> PaymentsTask =
                this.switchService.PostContactsToPhoneBookRequestAsync(nullSwitch,phoneBookId);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(exceptedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactsToPhoneBookAsync(
                    It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(), It.IsAny<string>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddMultipleContactsToPhoneBookIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new AddMultipleContactsToPhoneBook();
            invalidPayments.Request = null;

            string phoneBookId = null;

            var invalidPaymentsException =
                new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(AddMultipleContactsToPhoneBookRequest),
                values: "Value is required");

            var expectedSwitchValidationException =
                new SwitchValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<AddMultipleContactsToPhoneBook> AddMultipleContactsToPhoneBookTask =
                this.switchService.PostContactsToPhoneBookRequestAsync(invalidPayments,phoneBookId);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    AddMultipleContactsToPhoneBookTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(expectedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactsToPhoneBookAsync(
                    It.IsAny<ExternalAddMultipleContactsToPhoneBookRequest>(),It.IsAny<string>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null,null)]
        [InlineData("", "","","")]
        [InlineData("  ", "  "," "," ")]
        public async Task ShouldThrowValidationExceptionOnPostAddMultipleContactsToPhoneBookIfAddMultipleContactsToPhoneBookIsInvalidAsync(
           string invalidApiKey,
           string invalidContactFile,
           string invalidCountryCode, string invalidPhoneBookId)
        {
            // given
            var addContactToPhoneBook = new AddMultipleContactsToPhoneBook
            {
                Request = new AddMultipleContactsToPhoneBookRequest
                {
                    ApiKey = invalidApiKey,
                    ContactFile = invalidContactFile,
                    CountryCode = invalidCountryCode,
                  
                  



                }
            };

            var phoneBookId = invalidPhoneBookId;

            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(AddMultipleContactsToPhoneBookRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(AddMultipleContactsToPhoneBookRequest.CountryCode),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(AddMultipleContactsToPhoneBookRequest.ContactFile),
                values: "Value is required");


            invalidPaymentsException.AddData(
              key: nameof(AddMultipleContactsToPhoneBook),
              values: "Value is required");


            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<AddMultipleContactsToPhoneBook> AddMultipleContactsToPhoneBookTask =
                this.switchService.PostContactsToPhoneBookRequestAsync(addContactToPhoneBook,phoneBookId);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(AddMultipleContactsToPhoneBookTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostAddMultipleContactsToPhoneBookIfPostAddMultipleContactsToPhoneBookIsEmptyAsync()
        {
            // given
            var addContactToPhoneBook = new AddMultipleContactsToPhoneBook
            {
                Request = new AddMultipleContactsToPhoneBookRequest
                {

                    ApiKey = string.Empty,
                    ContactFile = string.Empty,
                    CountryCode = string.Empty,
              
                    




                }
            };

            var phoneBookId = string.Empty;

            var invalidPaymentsException = new InvalidSwitchException();


            invalidPaymentsException.AddData(
                key: nameof(AddMultipleContactsToPhoneBookRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(AddMultipleContactsToPhoneBookRequest.CountryCode),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(AddMultipleContactsToPhoneBookRequest.ContactFile),
                values: "Value is required");



            invalidPaymentsException.AddData(
              key: nameof(AddMultipleContactsToPhoneBook),
              values: "Value is required");




            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<AddMultipleContactsToPhoneBook> AddMultipleContactsToPhoneBookTask =
                this.switchService.PostContactsToPhoneBookRequestAsync(addContactToPhoneBook, phoneBookId);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    AddMultipleContactsToPhoneBookTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
