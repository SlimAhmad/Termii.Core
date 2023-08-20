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
        public async Task ShouldThrowValidationExceptionOnVerifyTokenIfVerifyTokensIsNullAsync()
        {
            // given
            VerifyToken nullTokens = null;
            var nullTokensException = new NullTokensException();

            var exceptedTokensValidationException =
                new TokensValidationException(nullTokensException);

            // when
            ValueTask<VerifyToken> PaymentsTask =
                this.tokensService.PostVerifyTokenAsync(nullTokens);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualTokensValidationException.Should()
                .BeEquivalentTo(exceptedTokensValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVerifyTokenAsync(
                    It.IsAny<ExternalVerifyTokenRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnVerifyTokenIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new VerifyToken();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidTokensException();

            invalidPaymentsException.AddData(
                key: nameof(VerifyTokenRequest),
                values: "Value is required");

            var expectedTokensValidationException =
                new TokensValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<VerifyToken> VerifyTokenTask =
                this.tokensService.PostVerifyTokenAsync(invalidPayments);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    VerifyTokenTask.AsTask);

            // then
            actualTokensValidationException.Should()
                .BeEquivalentTo(expectedTokensValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostVerifyTokenAsync(
                    It.IsAny<ExternalVerifyTokenRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", "", "")]
        [InlineData("  ", "  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostVerifyTokenIfVerifyTokenIsInvalidAsync(
           string invalidPinId,string invalidApiKey, string invalidPin)
        {
            // given
            var VerifyToken = new VerifyToken
            {
                Request = new VerifyTokenRequest
                {
                    PinId = invalidPinId,
                    Pin = invalidPin,
                    ApiKey = invalidApiKey,
                   


                }
            };

            var invalidPaymentsException = new InvalidTokensException();

            invalidPaymentsException.AddData(
                key: nameof(VerifyTokenRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(VerifyTokenRequest.Pin),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(VerifyTokenRequest.PinId),
               values: "Value is required");

        

  

            var expectedTokensValidationException =
                new TokensValidationException(invalidPaymentsException);

            // when
            ValueTask<VerifyToken> VerifyTokenTask =
                this.tokensService.PostVerifyTokenAsync(VerifyToken);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(VerifyTokenTask.AsTask);

            // then
            actualTokensValidationException.Should().BeEquivalentTo(
                expectedTokensValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostVerifyTokenIfPostVerifyTokenIsEmptyAsync()
        {
            // given
            var VerifyToken = new VerifyToken
            {
                Request = new VerifyTokenRequest
                {

                    ApiKey = string.Empty,
                    PinId = string.Empty,
                    Pin = string.Empty,
                 
                }
            };

            var invalidPaymentsException = new InvalidTokensException();

            invalidPaymentsException.AddData(
                  key: nameof(VerifyTokenRequest.ApiKey),
                  values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(VerifyTokenRequest.Pin),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(VerifyTokenRequest.PinId),
               values: "Value is required");



       

            var expectedTokensValidationException =
                new TokensValidationException(invalidPaymentsException);

            // when
            ValueTask<VerifyToken> VerifyTokenTask =
                this.tokensService.PostVerifyTokenAsync(VerifyToken);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    VerifyTokenTask.AsTask);

            // then
            actualTokensValidationException.Should().BeEquivalentTo(
                expectedTokensValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}