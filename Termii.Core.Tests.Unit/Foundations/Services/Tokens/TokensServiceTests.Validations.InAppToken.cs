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
        public async Task ShouldThrowValidationExceptionOnInAppTokenIfInAppTokenIsNullAsync()
        {
            // given
            InAppToken nullTokens = null;
            var nullTokensException = new NullTokensException();

            var exceptedTokensValidationException =
                new TokensValidationException(nullTokensException);

            // when
            ValueTask<InAppToken> PaymentsTask =
                this.tokensService.PostInAppAsync(nullTokens);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualTokensValidationException.Should()
                .BeEquivalentTo(exceptedTokensValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostInAppAsync(
                    It.IsAny<ExternalInAppTokenRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnInAppTokenIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new InAppToken();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidTokensException();

            invalidPaymentsException.AddData(
                key: nameof(InAppTokenRequest),
                values: "Value is required");

            var expectedTokensValidationException =
                new TokensValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<InAppToken> InAppTokenTask =
                this.tokensService.PostInAppAsync(invalidPayments);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    InAppTokenTask.AsTask);

            // then
            actualTokensValidationException.Should()
                .BeEquivalentTo(expectedTokensValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostInAppAsync(
                    It.IsAny<ExternalInAppTokenRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, 0,null,0,0)]
        [InlineData("", "", 0,"",0,0)]
        [InlineData("  ", "  ", 0," ", 0,0)]
        public async Task ShouldThrowValidationExceptionOnPostInAppTokenIfInAppTokenIsInvalidAsync(
           string invalidPhoneNumber,string invalidApiKey, int invalidPinTimeToLive, string invalidPinType,
           int invalidLength, int invalidPinAttempts)
        {
            // given
            var InAppToken = new InAppToken
            {
                Request = new InAppTokenRequest
                {
                    PhoneNumber = invalidPhoneNumber,
                    PinTimeToLive = invalidPinTimeToLive,
                    ApiKey = invalidApiKey,
                    PinType = invalidPinType,
                    PinLength = invalidLength,
                    PinAttempts = invalidPinAttempts
                   


                }
            };

            var invalidPaymentsException = new InvalidTokensException();

            invalidPaymentsException.AddData(
                key: nameof(InAppTokenRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(InAppTokenRequest.PinAttempts),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(InAppTokenRequest.PhoneNumber),
               values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(InAppTokenRequest.PinType),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(InAppTokenRequest.PinTimeToLive),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(InAppTokenRequest.PinLength),
               values: "Value is required");





            var expectedTokensValidationException =
                new TokensValidationException(invalidPaymentsException);

            // when
            ValueTask<InAppToken> InAppTokenTask =
                this.tokensService.PostInAppAsync(InAppToken);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(InAppTokenTask.AsTask);

            // then
            actualTokensValidationException.Should().BeEquivalentTo(
                expectedTokensValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostInAppTokenIfPostInAppTokenIsEmptyAsync()
        {
            // given
            var InAppToken = new InAppToken
            {
                Request = new InAppTokenRequest
                {

                    PhoneNumber = string.Empty,
                    ApiKey = string.Empty,
                    PinType = string.Empty,


                }
            };

            var invalidPaymentsException = new InvalidTokensException();


            invalidPaymentsException.AddData(
                key: nameof(InAppTokenRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(InAppTokenRequest.PinAttempts),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(InAppTokenRequest.PhoneNumber),
               values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(InAppTokenRequest.PinType),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(InAppTokenRequest.PinTimeToLive),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(InAppTokenRequest.PinLength),
               values: "Value is required");





            var expectedTokensValidationException =
                new TokensValidationException(invalidPaymentsException);

            // when
            ValueTask<InAppToken> InAppTokenTask =
                this.tokensService.PostInAppAsync(InAppToken);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    InAppTokenTask.AsTask);

            // then
            actualTokensValidationException.Should().BeEquivalentTo(
                expectedTokensValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}