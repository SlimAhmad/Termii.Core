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
        public async Task ShouldThrowValidationExceptionOnNumberMessageIfNumberMessageIsNullAsync()
        {
            // given
            NumberMessage nullSwitch = null;
            var nullSwitchException = new NullSwitchException();

            var exceptedSwitchValidationException =
                new SwitchValidationException(nullSwitchException);

            // when
            ValueTask<NumberMessage> PaymentsTask =
                this.switchService.PostNumberMessageRequestAsync(nullSwitch);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(exceptedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostNumberMessageAsync(
                    It.IsAny<ExternalNumberMessageRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnNumberMessageIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new NumberMessage();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(NumberMessageRequest),
                values: "Value is required");

            var expectedSwitchValidationException =
                new SwitchValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<NumberMessage> NumberMessageTask =
                this.switchService.PostNumberMessageRequestAsync(invalidPayments);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    NumberMessageTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(expectedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostNumberMessageAsync(
                    It.IsAny<ExternalNumberMessageRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null,null)]
        [InlineData("", "","")]
        [InlineData("  ", "  "," ")]
        public async Task ShouldThrowValidationExceptionOnPostNumberMessageIfNumberMessageIsInvalidAsync(
           string invalidApiKey, string invalidSms,
           string invalidTo)
        {
            // given
            var NumberMessage = new NumberMessage
            {
                Request = new NumberMessageRequest
                {
                    ApiKey = invalidApiKey,
                    Sms = invalidSms,
                    To = invalidTo,
                  
                  



                }
            };

            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(NumberMessageRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(NumberMessageRequest.Sms),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(NumberMessageRequest.To),
                values: "Value is required");








            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<NumberMessage> NumberMessageTask =
                this.switchService.PostNumberMessageRequestAsync(NumberMessage);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(NumberMessageTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostNumberMessageIfPostNumberMessageIsEmptyAsync()
        {
            // given
            var NumberMessage = new NumberMessage
            {
                Request = new NumberMessageRequest
                {

                    ApiKey = string.Empty,
                    Sms = string.Empty,
                    To = string.Empty,
                    




                }
            };

            var invalidPaymentsException = new InvalidSwitchException();


            invalidPaymentsException.AddData(
            key: nameof(NumberMessageRequest.ApiKey),
            values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(NumberMessageRequest.Sms),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(NumberMessageRequest.To),
                values: "Value is required");






            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<NumberMessage> NumberMessageTask =
                this.switchService.PostNumberMessageRequestAsync(NumberMessage);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    NumberMessageTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
