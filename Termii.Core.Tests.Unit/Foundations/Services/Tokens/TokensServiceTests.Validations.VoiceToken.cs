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
        public async Task ShouldThrowValidationExceptionOnVoiceTokenIfVoiceTokenIsNullAsync()
        {
            // given
            VoiceToken nullTokens = null;
            var nullTokensException = new NullTokensException();

            var exceptedTokensValidationException =
                new TokensValidationException(nullTokensException);

            // when
            ValueTask<VoiceToken> PaymentsTask =
                this.tokensService.PostVoiceTokenAsync(nullTokens);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualTokensValidationException.Should()
                .BeEquivalentTo(exceptedTokensValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceTokenAsync(
                    It.IsAny<ExternalVoiceTokenRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnVoiceTokenIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new VoiceToken();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidTokensException();

            invalidPaymentsException.AddData(
                key: nameof(VoiceTokenRequest),
                values: "Value is required");

            var expectedTokensValidationException =
                new TokensValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<VoiceToken> VoiceTokenTask =
                this.tokensService.PostVoiceTokenAsync(invalidPayments);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    VoiceTokenTask.AsTask);

            // then
            actualTokensValidationException.Should()
                .BeEquivalentTo(expectedTokensValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceTokenAsync(
                    It.IsAny<ExternalVoiceTokenRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, 0,0,0)]
        [InlineData("", "", 0,0,0)]
        [InlineData("  ", "  ", 0,0,0)]
        public async Task ShouldThrowValidationExceptionOnPostVoiceTokenIfVoiceTokenIsInvalidAsync(
           string invalidPhoneNumber,string invalidApiKey, int invalidPinLength, int invalidPinTimeToLive, int invalidPinAttempts)
        {
            // given
            var VoiceToken = new VoiceToken
            {
                Request = new VoiceTokenRequest
                {
                    PhoneNumber = invalidPhoneNumber,
                    ApiKey = invalidApiKey,
                    PinTimeToLive = invalidPinTimeToLive,
                    PinAttempts = invalidPinAttempts,
                    PinLength = invalidPinLength,

                   


                }
            };

            var invalidPaymentsException = new InvalidTokensException();

            invalidPaymentsException.AddData(
                key: nameof(VoiceTokenRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(VoiceTokenRequest.PinAttempts),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(VoiceTokenRequest.PhoneNumber),
               values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(VoiceTokenRequest.PinTimeToLive),
               values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(VoiceTokenRequest.PinLength),
               values: "Value is required");





            var expectedTokensValidationException =
                new TokensValidationException(invalidPaymentsException);

            // when
            ValueTask<VoiceToken> VoiceTokenTask =
                this.tokensService.PostVoiceTokenAsync(VoiceToken);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(VoiceTokenTask.AsTask);

            // then
            actualTokensValidationException.Should().BeEquivalentTo(
                expectedTokensValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostVoiceTokenIfPostVoiceTokenIsEmptyAsync()
        {
            // given
            var VoiceToken = new VoiceToken
            {
                Request = new VoiceTokenRequest
                {

                    ApiKey = string.Empty,
                    PhoneNumber = string.Empty,
              
                 
                }
            };

            var invalidPaymentsException = new InvalidTokensException();

            invalidPaymentsException.AddData(
              key: nameof(VoiceTokenRequest.ApiKey),
              values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(VoiceTokenRequest.PinAttempts),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(VoiceTokenRequest.PhoneNumber),
               values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(VoiceTokenRequest.PinTimeToLive),
               values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(VoiceTokenRequest.PinLength),
               values: "Value is required");






            var expectedTokensValidationException =
                new TokensValidationException(invalidPaymentsException);

            // when
            ValueTask<VoiceToken> VoiceTokenTask =
                this.tokensService.PostVoiceTokenAsync(VoiceToken);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    VoiceTokenTask.AsTask);

            // then
            actualTokensValidationException.Should().BeEquivalentTo(
                expectedTokensValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}