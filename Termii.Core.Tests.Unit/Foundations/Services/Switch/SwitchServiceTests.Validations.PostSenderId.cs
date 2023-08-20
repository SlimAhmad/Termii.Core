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
        public async Task ShouldThrowValidationExceptionOnCreateSenderIdIfCreateSenderIdIsNullAsync()
        {
            // given
            CreateSenderId nullSwitch = null;
            var nullSwitchException = new NullSwitchException();

            var exceptedSwitchValidationException =
                new SwitchValidationException(nullSwitchException);

            // when
            ValueTask<CreateSenderId> PaymentsTask =
                this.switchService.PostSenderIdRequestAsync(nullSwitch);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(exceptedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostSenderIdAsync(
                    It.IsAny<ExternalCreateSenderIdRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateSenderIdIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new CreateSenderId();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(CreateSenderIdRequest),
                values: "Value is required");

            var expectedSwitchValidationException =
                new SwitchValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<CreateSenderId> CreateSenderIdTask =
                this.switchService.PostSenderIdRequestAsync(invalidPayments);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    CreateSenderIdTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(expectedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostSenderIdAsync(
                    It.IsAny<ExternalCreateSenderIdRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null,null,null)]
        [InlineData("", "","","")]
        [InlineData("  ", "  "," "," ")]
        public async Task ShouldThrowValidationExceptionOnPostCreateSenderIdIfCreateSenderIdIsInvalidAsync(
           string invalidCompany, string invalidApiKey, string invalidSenderId,string invalidUsecase)
        {
            // given
            var CreateSenderId = new CreateSenderId
            {
                Request = new CreateSenderIdRequest
                {
                    Company = invalidCompany,
                    ApiKey = invalidApiKey,
                    SenderId = invalidSenderId,
                    Usecase = invalidUsecase



                }
            };

            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(CreateSenderIdRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateSenderIdRequest.Company),
                values: "Value is required");


            invalidPaymentsException.AddData(
                key: nameof(CreateSenderIdRequest.SenderId),
                values: "Value is required");


            invalidPaymentsException.AddData(
                key: nameof(CreateSenderIdRequest.Usecase),
                values: "Value is required");







            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<CreateSenderId> CreateSenderIdTask =
                this.switchService.PostSenderIdRequestAsync(CreateSenderId);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(CreateSenderIdTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCreateSenderIdIfPostCreateSenderIdIsEmptyAsync()
        {
            // given
            var CreateSenderId = new CreateSenderId
            {
                Request = new CreateSenderIdRequest
                {

                    Usecase = string.Empty,
                    ApiKey = string.Empty,
                    SenderId = string.Empty,
                    Company = string.Empty,
                


                }
            };

            var invalidPaymentsException = new InvalidSwitchException();


            invalidPaymentsException.AddData(
                    key: nameof(CreateSenderIdRequest.ApiKey),
                    values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(CreateSenderIdRequest.Company),
                values: "Value is required");


            invalidPaymentsException.AddData(
                key: nameof(CreateSenderIdRequest.SenderId),
                values: "Value is required");


            invalidPaymentsException.AddData(
                key: nameof(CreateSenderIdRequest.Usecase),
                values: "Value is required");







            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<CreateSenderId> CreateSenderIdTask =
                this.switchService.PostSenderIdRequestAsync(CreateSenderId);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    CreateSenderIdTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
