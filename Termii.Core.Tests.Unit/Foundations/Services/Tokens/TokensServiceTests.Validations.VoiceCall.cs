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
        public async Task ShouldThrowValidationExceptionOnVoiceCallIfVoiceCallIsNullAsync()
        {
            // given
            VoiceCall nullTokens = null;
            var nullTokensException = new NullTokensException();

            var exceptedTokensValidationException =
                new TokensValidationException(nullTokensException);

            // when
            ValueTask<VoiceCall> PaymentsTask =
                this.tokensService.PostVoiceCallAsync(nullTokens);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualTokensValidationException.Should()
                .BeEquivalentTo(exceptedTokensValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceCallAsync(
                    It.IsAny<ExternalVoiceCallRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnVoiceCallIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new VoiceCall();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidTokensException();

            invalidPaymentsException.AddData(
                key: nameof(VoiceCallRequest),
                values: "Value is required");

            var expectedTokensValidationException =
                new TokensValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<VoiceCall> VoiceCallTask =
                this.tokensService.PostVoiceCallAsync(invalidPayments);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    VoiceCallTask.AsTask);

            // then
            actualTokensValidationException.Should()
                .BeEquivalentTo(expectedTokensValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVoiceCallAsync(
                    It.IsAny<ExternalVoiceCallRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, 0)]
        [InlineData("", "", 0)]
        [InlineData("  ", "  ", 0)]
        public async Task ShouldThrowValidationExceptionOnPostVoiceCallIfVoiceCallIsInvalidAsync(
           string invalidPhoneNumber,string invalidApiKey, int invalidCode)
        {
            // given
            var VoiceCall = new VoiceCall
            {
                Request = new VoiceCallRequest
                {
                    PhoneNumber = invalidPhoneNumber,
                    Code = invalidCode,
                    ApiKey = invalidApiKey,
                   


                }
            };

            var invalidPaymentsException = new InvalidTokensException();

            invalidPaymentsException.AddData(
                key: nameof(VoiceCallRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(VoiceCallRequest.Code),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(VoiceCallRequest.PhoneNumber),
               values: "Value is required");

        

  

            var expectedTokensValidationException =
                new TokensValidationException(invalidPaymentsException);

            // when
            ValueTask<VoiceCall> VoiceCallTask =
                this.tokensService.PostVoiceCallAsync(VoiceCall);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(VoiceCallTask.AsTask);

            // then
            actualTokensValidationException.Should().BeEquivalentTo(
                expectedTokensValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostVoiceCallIfPostVoiceCallIsEmptyAsync()
        {
            // given
            var VoiceCall = new VoiceCall
            {
                Request = new VoiceCallRequest
                {

                    ApiKey = string.Empty,
                    PhoneNumber = string.Empty,
              
                 
                }
            };

            var invalidPaymentsException = new InvalidTokensException();

            invalidPaymentsException.AddData(
                  key: nameof(VoiceCallRequest.ApiKey),
                  values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(VoiceCallRequest.PhoneNumber),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(VoiceCallRequest.Code),
               values: "Value is required");



       

            var expectedTokensValidationException =
                new TokensValidationException(invalidPaymentsException);

            // when
            ValueTask<VoiceCall> VoiceCallTask =
                this.tokensService.PostVoiceCallAsync(VoiceCall);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    VoiceCallTask.AsTask);

            // then
            actualTokensValidationException.Should().BeEquivalentTo(
                expectedTokensValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}