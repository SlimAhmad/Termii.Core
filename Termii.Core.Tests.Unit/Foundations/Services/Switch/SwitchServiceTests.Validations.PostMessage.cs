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
        public async Task ShouldThrowValidationExceptionOnSendMessageIfSendMessageIsNullAsync()
        {
            // given
            SendMessage nullSwitch = null;
            var nullSwitchException = new NullSwitchException();

            var exceptedSwitchValidationException =
                new SwitchValidationException(nullSwitchException);

            // when
            ValueTask<SendMessage> PaymentsTask =
                this.switchService.PostMessageRequestAsync(nullSwitch);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(exceptedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostMessageAsync(
                    It.IsAny<ExternalSendMessageRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnSendMessageIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new SendMessage();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(SendMessageRequest),
                values: "Value is required");

            var expectedSwitchValidationException =
                new SwitchValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<SendMessage> SendMessageTask =
                this.switchService.PostMessageRequestAsync(invalidPayments);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    SendMessageTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(expectedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostMessageAsync(
                    It.IsAny<ExternalSendMessageRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null,null,null,null,null)]
        [InlineData("", "","","","","")]
        [InlineData("  ", "  "," "," "," "," ")]
        public async Task ShouldThrowValidationExceptionOnPostSendMessageIfSendMessageIsInvalidAsync(
           string invalidChannel, string invalidApiKey, string invalidFrom,string invalidSms,
           string invalidTo, string invalidType)
        {
            // given
            var SendMessage = new SendMessage
            {
                Request = new SendMessageRequest
                {
                    Channel = invalidChannel,
                    ApiKey = invalidApiKey,
                    From = invalidFrom,
                    Sms = invalidSms,
                    To = invalidTo,
                    Type = invalidType,
                  



                }
            };

            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(SendMessageRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendMessageRequest.Channel),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendMessageRequest.From),
                values: "Value is required");

             
            invalidPaymentsException.AddData(
               key: nameof(SendMessageRequest.To),
               values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendMessageRequest.Sms),
               values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendMessageRequest.Type),
               values: "Value is required");






            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<SendMessage> SendMessageTask =
                this.switchService.PostMessageRequestAsync(SendMessage);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(SendMessageTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostSendMessageIfPostSendMessageIsEmptyAsync()
        {
            // given
            var SendMessage = new SendMessage
            {
                Request = new SendMessageRequest
                {

                    Channel = string.Empty,
                    ApiKey = string.Empty,
                    From = string.Empty,
                    Sms = string.Empty,
                    To = string.Empty,
                    Type = string.Empty,
                    




                }
            };

            var invalidPaymentsException = new InvalidSwitchException();


            invalidPaymentsException.AddData(
                 key: nameof(SendMessageRequest.ApiKey),
                 values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendMessageRequest.Channel),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendMessageRequest.From),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendMessageRequest.To),
               values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendMessageRequest.Sms),
               values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendMessageRequest.Type),
               values: "Value is required");







            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<SendMessage> SendMessageTask =
                this.switchService.PostMessageRequestAsync(SendMessage);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    SendMessageTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
