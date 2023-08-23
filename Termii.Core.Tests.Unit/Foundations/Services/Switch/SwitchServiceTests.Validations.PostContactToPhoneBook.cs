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
        public async Task ShouldThrowValidationExceptionOnAddContactToPhoneBookIfAddContactToPhoneBookIsNullAsync()
        {
            // given
            AddContactToPhoneBook nullSwitch = null;
            var nullSwitchException = new NullSwitchException();

            string phoneBookId = null;

            var exceptedSwitchValidationException =
                new SwitchValidationException(nullSwitchException);

            // when
            ValueTask<AddContactToPhoneBook> PaymentsTask =
                this.switchService.PostContactToPhoneBookRequestAsync(nullSwitch,phoneBookId);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(exceptedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactToPhoneBookAsync(
                    It.IsAny<ExternalAddContactToPhoneBookRequest>(), It.IsAny<string>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddContactToPhoneBookIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new AddContactToPhoneBook();
            invalidPayments.Request = null;

            string phoneBookId = null;

            var invalidPaymentsException =
                new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(AddContactToPhoneBookRequest),
                values: "Value is required");

            var expectedSwitchValidationException =
                new SwitchValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<AddContactToPhoneBook> AddContactToPhoneBookTask =
                this.switchService.PostContactToPhoneBookRequestAsync(invalidPayments,phoneBookId);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    AddContactToPhoneBookTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(expectedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostContactToPhoneBookAsync(
                    It.IsAny<ExternalAddContactToPhoneBookRequest>(),It.IsAny<string>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null, null, null, null, null, null)]
        [InlineData("", "","","","","","","")]
        [InlineData("  ", "  "," "," "," "," ", " ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostAddContactToPhoneBookIfAddContactToPhoneBookIsInvalidAsync(
           string invalidApiKey,
           string invalidCompany,
           string invalidCountryCode, string invalidEmailAddress,
           string invalidFirstName, string invalidLastName, string invalidPhoneNumber,string invalidPhoneBookId)
        {
            // given
            var addContactToPhoneBook = new AddContactToPhoneBook
            {
                Request = new AddContactToPhoneBookRequest
                {
                    ApiKey = invalidApiKey,
                    Company = invalidCompany,
                    CountryCode = invalidCountryCode,
                    EmailAddress = invalidEmailAddress,
                    FirstName = invalidFirstName,
                    LastName = invalidLastName,
                    PhoneNumber = invalidPhoneNumber
                  
                  



                }
            };

      

            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(AddContactToPhoneBookRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(AddContactToPhoneBookRequest.CountryCode),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(AddContactToPhoneBookRequest.Company),
                values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(AddContactToPhoneBookRequest.PhoneNumber),
              values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(AddContactToPhoneBookRequest.LastName),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(AddContactToPhoneBookRequest.FirstName),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(AddContactToPhoneBookRequest.EmailAddress),
               values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(AddContactToPhoneBook),
              values: "Value is required");


            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<AddContactToPhoneBook> AddContactToPhoneBookTask =
                this.switchService.PostContactToPhoneBookRequestAsync(addContactToPhoneBook,invalidPhoneBookId);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(AddContactToPhoneBookTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostAddContactToPhoneBookIfPostAddContactToPhoneBookIsEmptyAsync()
        {
            // given
            var addContactToPhoneBook = new AddContactToPhoneBook
            {
                Request = new AddContactToPhoneBookRequest
                {

                    ApiKey = string.Empty,
                    EmailAddress = string.Empty,
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    PhoneNumber = string.Empty,
                    Company = string.Empty,
                    CountryCode = string.Empty,
              
                    




                }
            };

            var phoneBookId = string.Empty;

            var invalidPaymentsException = new InvalidSwitchException();


            invalidPaymentsException.AddData(
                key: nameof(AddContactToPhoneBookRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(AddContactToPhoneBookRequest.CountryCode),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(AddContactToPhoneBookRequest.Company),
                values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(AddContactToPhoneBookRequest.PhoneNumber),
              values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(AddContactToPhoneBookRequest.LastName),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(AddContactToPhoneBookRequest.FirstName),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(AddContactToPhoneBookRequest.EmailAddress),
               values: "Value is required");



            invalidPaymentsException.AddData(
              key: nameof(AddContactToPhoneBook),
              values: "Value is required");




            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<AddContactToPhoneBook> AddContactToPhoneBookTask =
                this.switchService.PostContactToPhoneBookRequestAsync(addContactToPhoneBook, phoneBookId);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    AddContactToPhoneBookTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
