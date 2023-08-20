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
        public async Task ShouldThrowValidationExceptionOnCreateCampaignPhoneBookIfCreateCampaignPhoneBookIsNullAsync()
        {
            // given
            CreateCampaignPhoneBook nullSwitch = null;
            var nullSwitchException = new NullSwitchException();

            var exceptedSwitchValidationException =
                new SwitchValidationException(nullSwitchException);

            // when
            ValueTask<CreateCampaignPhoneBook> PaymentsTask =
                this.switchService.PostCreatePhoneBookRequestAsync(nullSwitch);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(exceptedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostCreatePhoneBookAsync(
                    It.IsAny<ExternalCreateCampaignPhoneBookRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateCampaignPhoneBookIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new CreateCampaignPhoneBook();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(CreateCampaignPhoneBookRequest),
                values: "Value is required");

            var expectedSwitchValidationException =
                new SwitchValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<CreateCampaignPhoneBook> CreateCampaignPhoneBookTask =
                this.switchService.PostCreatePhoneBookRequestAsync(invalidPayments);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    CreateCampaignPhoneBookTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(expectedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostCreatePhoneBookAsync(
                    It.IsAny<ExternalCreateCampaignPhoneBookRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null,null)]
        [InlineData("", "","")]
        [InlineData("  ", "  "," ")]
        public async Task ShouldThrowValidationExceptionOnPostCreateCampaignPhoneBookIfCreateCampaignPhoneBookIsInvalidAsync(
           string invalidApiKey, string invalidDescription,
           string invalidPhoneBookName)
        {
            // given
            var CreateCampaignPhoneBook = new CreateCampaignPhoneBook
            {
                Request = new CreateCampaignPhoneBookRequest
                {
                    ApiKey = invalidApiKey,
                    Description = invalidDescription,
                    PhonebookName = invalidPhoneBookName
                  
                  



                }
            };

            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(CreateCampaignPhoneBookRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateCampaignPhoneBookRequest.Description),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateCampaignPhoneBookRequest.PhonebookName),
                values: "Value is required");







            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<CreateCampaignPhoneBook> CreateCampaignPhoneBookTask =
                this.switchService.PostCreatePhoneBookRequestAsync(CreateCampaignPhoneBook);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(CreateCampaignPhoneBookTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCreateCampaignPhoneBookIfPostCreateCampaignPhoneBookIsEmptyAsync()
        {
            // given
            var CreateCampaignPhoneBook = new CreateCampaignPhoneBook
            {
                Request = new CreateCampaignPhoneBookRequest
                {

                    ApiKey = string.Empty,
                    PhonebookName = string.Empty,
                    Description = string.Empty,
              
                    




                }
            };

            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                         key: nameof(CreateCampaignPhoneBookRequest.ApiKey),
                         values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateCampaignPhoneBookRequest.Description),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateCampaignPhoneBookRequest.PhonebookName),
                values: "Value is required");







            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<CreateCampaignPhoneBook> CreateCampaignPhoneBookTask =
                this.switchService.PostCreatePhoneBookRequestAsync(CreateCampaignPhoneBook);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    CreateCampaignPhoneBookTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
