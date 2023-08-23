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
        public async Task ShouldThrowValidationExceptionOnSendBulkMessageIfSendBulkMessageIsNullAsync()
        {
            // given
            SendBulkMessage nullSwitch = null;
            var nullSwitchException = new NullSwitchException();

            var exceptedSwitchValidationException =
                new SwitchValidationException(nullSwitchException);

            // when
            ValueTask<SendBulkMessage> PaymentsTask =
                this.switchService.PostBulkMessagesRequestAsync(nullSwitch);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(exceptedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostBulkMessagesAsync(
                    It.IsAny<ExternalSendBulkMessageRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnSendBulkMessageIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new SendBulkMessage();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(SendBulkMessageRequest),
                values: "Value is required");

            var expectedSwitchValidationException =
                new SwitchValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<SendBulkMessage> SendBulkMessageTask =
                this.switchService.PostBulkMessagesRequestAsync(invalidPayments);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    SendBulkMessageTask.AsTask);

            // then
            actualSwitchValidationException.Should()
                .BeEquivalentTo(expectedSwitchValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostBulkMessagesAsync(
                    It.IsAny<ExternalSendBulkMessageRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null,null,null,null)]
        [InlineData("", "","","","")]
        [InlineData("  ", "  "," "," "," ")]
        public async Task ShouldThrowValidationExceptionOnPostSendBulkMessageIfSendBulkMessageIsInvalidAsync(
           string invalidChannel, string invalidApiKey, string invalidFrom,string invalidSms,
           string invalidType)
        {
            // given
            var SendBulkMessage = new SendBulkMessage
            {
                Request = new SendBulkMessageRequest
                {
                    Channel = invalidChannel,
                    ApiKey = invalidApiKey,
                    From = invalidFrom,
                    Sms = invalidSms,
                    Type = invalidType,
                   
                    
                  



                }
            };

            var invalidPaymentsException = new InvalidSwitchException();

            invalidPaymentsException.AddData(
                key: nameof(SendBulkMessageRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendBulkMessageRequest.Channel),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendBulkMessageRequest.From),
                values: "Value is required");
             
            invalidPaymentsException.AddData(
               key: nameof(SendBulkMessageRequest.To),
               values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendBulkMessageRequest.Sms),
               values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendBulkMessageRequest.Type),
               values: "Value is required");






            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<SendBulkMessage> SendBulkMessageTask =
                this.switchService.PostBulkMessagesRequestAsync(SendBulkMessage);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(SendBulkMessageTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostSendBulkMessageIfPostSendBulkMessageIsEmptyAsync()
        {
            // given
            var SendBulkMessage = new SendBulkMessage
            {
                Request = new SendBulkMessageRequest
                {

                    Channel = string.Empty,
                    ApiKey = string.Empty,
                    From = string.Empty,
                    Sms = string.Empty,
                    Type = string.Empty,
                    




                }
            };

            var invalidPaymentsException = new InvalidSwitchException();


            invalidPaymentsException.AddData(
                 key: nameof(SendBulkMessageRequest.ApiKey),
                 values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendBulkMessageRequest.Channel),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendBulkMessageRequest.From),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendBulkMessageRequest.To),
               values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendBulkMessageRequest.Sms),
               values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendBulkMessageRequest.Type),
               values: "Value is required");







            var expectedSwitchValidationException =
                new SwitchValidationException(invalidPaymentsException);

            // when
            ValueTask<SendBulkMessage> SendBulkMessageTask =
                this.switchService.PostBulkMessagesRequestAsync(SendBulkMessage);

            SwitchValidationException actualSwitchValidationException =
                await Assert.ThrowsAsync<SwitchValidationException>(
                    SendBulkMessageTask.AsTask);

            // then
            actualSwitchValidationException.Should().BeEquivalentTo(
                expectedSwitchValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
