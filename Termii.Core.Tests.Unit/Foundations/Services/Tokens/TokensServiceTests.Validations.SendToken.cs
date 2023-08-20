using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;

namespace Termii.Core.Tests.Unit.Foundations.Services.Tokens
{
    public partial class TokensServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnSendTokenIfSendTokensIsNullAsync()
        {
            // given
            SendToken nullTokens = null;
            var nullTokensException = new NullTokensException();

            var exceptedTokensValidationException =
                new TokensValidationException(nullTokensException);

            // when
            ValueTask<SendToken> PaymentsTask =
                this.tokensService.PostTokenAsync(nullTokens);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualTokensValidationException.Should()
                .BeEquivalentTo(exceptedTokensValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTokenAsync(
                    It.IsAny<ExternalSendTokenRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnSendTokenIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new SendToken();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidTokensException();

            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest),
                values: "Value is required");

            var expectedTokensValidationException =
                new TokensValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<SendToken> SendTokenTask =
                this.tokensService.PostTokenAsync(invalidPayments);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    SendTokenTask.AsTask);

            // then
            actualTokensValidationException.Should()
                .BeEquivalentTo(expectedTokensValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostTokenAsync(
                    It.IsAny<ExternalSendTokenRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null,null,null,0,0,null,0,null,null)]
        [InlineData("", "", "","","",0,0,"",0,"","")]
        [InlineData("  ", "  ", "  "," "," ",0,0," ",0," "," ")]
        public async Task ShouldThrowValidationExceptionOnPostSendTokenIfSendTokenIsInvalidAsync(
           string invalidChannel,string invalidApiKey, string invalidFrom, string invalidMessageText,
            string invalidMessageType, int invalidPinAttempts,int invalidPinLength,string invalidPlaceholder,
            int invalidPinTimeToLive, string invalidPinType,string invalidTo)
        {
            // given
            var SendToken = new SendToken
            {
                Request = new SendTokenRequest
                {
                    Channel = invalidChannel,
                    From = invalidFrom,
                    ApiKey = invalidApiKey,
                    MessageText = invalidMessageText,
                    MessageType = invalidMessageType,
                    PinAttempts = invalidPinAttempts,
                    PinLength = invalidPinLength,
                    PinPlaceholder = invalidPlaceholder,
                    PinTimeToLive  = invalidPinTimeToLive,
                    PinType = invalidPinType,
                    To = invalidTo
                   


                }
            };

            var invalidPaymentsException = new InvalidTokensException();

            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest.Channel),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendTokenRequest.From),
               values: "Value is required");


            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest.MessageType),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest.MessageText),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendTokenRequest.PinAttempts),
               values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest.PinLength),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest.PinPlaceholder),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendTokenRequest.PinTimeToLive),
               values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest.PinType),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendTokenRequest.To),
               values: "Value is required");


            var expectedTokensValidationException =
                new TokensValidationException(invalidPaymentsException);

            // when
            ValueTask<SendToken> SendTokenTask =
                this.tokensService.PostTokenAsync(SendToken);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(SendTokenTask.AsTask);

            // then
            actualTokensValidationException.Should().BeEquivalentTo(
                expectedTokensValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostSendTokenIfPostSendTokenIsEmptyAsync()
        {
            // given
            var SendToken = new SendToken
            {
                Request = new SendTokenRequest
                {

                    Channel = string.Empty,
                    From = string.Empty,
                    ApiKey = string.Empty,
                    MessageText = string.Empty,
                    MessageType = string.Empty,
                    PinPlaceholder = string.Empty,
                    PinType = string.Empty,
                    To = string.Empty

                }
            };

            var invalidPaymentsException = new InvalidTokensException();

            invalidPaymentsException.AddData(
                    key: nameof(SendTokenRequest.ApiKey),
                    values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest.Channel),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendTokenRequest.From),
               values: "Value is required");


            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest.MessageType),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest.MessageText),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendTokenRequest.PinAttempts),
               values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest.PinLength),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest.PinPlaceholder),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendTokenRequest.PinTimeToLive),
               values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(SendTokenRequest.PinType),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(SendTokenRequest.To),
               values: "Value is required");





            var expectedTokensValidationException =
                new TokensValidationException(invalidPaymentsException);

            // when
            ValueTask<SendToken> SendTokenTask =
                this.tokensService.PostTokenAsync(SendToken);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    SendTokenTask.AsTask);

            // then
            actualTokensValidationException.Should().BeEquivalentTo(
                expectedTokensValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}