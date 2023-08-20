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
        public async Task ShouldThrowValidationExceptionOnTemplatedMessageIfTemplatedMessageIsNullAsync()
        {
            // given
            TemplatedMessage nullSwitch = null;
            var nullSwitchException = new NullSwitchException();

            var exceptedSwitchValidationException =
                new SwitchValidationException(nullSwitchException);

            // when
            ValueTask<TemplatedMessage> PaymentsTask =
                this.switchService.PostTemplatedMessageRequestAsync(nullSwitch);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(exceptedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTemplatedMessageAsync(
                    It.IsAny<ExternalTemplatedMessageRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnTemplatedMessageIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new TemplatedMessage();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(TemplatedMessageRequest),
                values: "Value is required");

            var expectedSwitchValidationException =
                new SwitchValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<TemplatedMessage> TemplatedMessageTask =
                this.switchService.PostTemplatedMessageRequestAsync(invalidPayments);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    TemplatedMessageTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(expectedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTemplatedMessageAsync(
                    It.IsAny<ExternalTemplatedMessageRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null,null,null)]
        [InlineData("", "","","")]
        [InlineData("  ", "  "," "," ")]
        public async Task ShouldThrowValidationExceptionOnPostTemplatedMessageIfTemplatedMessageIsInvalidAsync(
           string invalidApiKey, string invalidDeviceId,
           string invalidPhoneNumber, string invalidTemplateId)
        {
            // given
            var TemplatedMessage = new TemplatedMessage
            {
                Request = new TemplatedMessageRequest
                {
                    ApiKey = invalidApiKey,
                    DeviceId = invalidDeviceId,
                    PhoneNumber = invalidPhoneNumber,
                    TemplateId = invalidTemplateId
                  
                  



                }
            };

            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(TemplatedMessageRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(TemplatedMessageRequest.DeviceId),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(TemplatedMessageRequest.PhoneNumber),
                values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(TemplatedMessageRequest.TemplateId),
              values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(TemplatedMessageRequest.Data),
               values: "Value is required");






            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<TemplatedMessage> TemplatedMessageTask =
                this.switchService.PostTemplatedMessageRequestAsync(TemplatedMessage);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(TemplatedMessageTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostTemplatedMessageIfPostTemplatedMessageIsEmptyAsync()
        {
            // given
            var TemplatedMessage = new TemplatedMessage
            {
                Request = new TemplatedMessageRequest
                {

                    ApiKey = string.Empty,
                    TemplateId = string.Empty,
                    PhoneNumber = string.Empty,
                    DeviceId = string.Empty
                    




                }
            };

            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                         key: nameof(TemplatedMessageRequest.ApiKey),
                         values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(TemplatedMessageRequest.DeviceId),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(TemplatedMessageRequest.PhoneNumber),
                values: "Value is required");

            invalidPaymentsException.AddData(
              key: nameof(TemplatedMessageRequest.TemplateId),
              values: "Value is required");


            invalidPaymentsException.AddData(
              key: nameof(TemplatedMessageRequest.Data),
              values: "Value is required");






            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<TemplatedMessage> TemplatedMessageTask =
                this.switchService.PostTemplatedMessageRequestAsync(TemplatedMessage);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    TemplatedMessageTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
