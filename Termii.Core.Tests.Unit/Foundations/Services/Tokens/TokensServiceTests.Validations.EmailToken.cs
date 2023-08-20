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
        public async Task ShouldThrowValidationExceptionOnEmailTokenIfEmailTokensIsNullAsync()
        {
            // given
            EmailToken nullTokens = null;
            var nullTokensException = new NullTokensException();

            var exceptedTokensValidationException =
                new TokensValidationException(nullTokensException);

            // when
            ValueTask<EmailToken> PaymentsTask =
                this.tokensService.PostSendEmailTokenAsync(nullTokens);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualTokensValidationException.Should()
                .BeEquivalentTo(exceptedTokensValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostEmailTokenAsync(
                    It.IsAny<ExternalEmailTokenRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnEmailTokenIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new EmailToken();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidTokensException();

            invalidPaymentsException.AddData(
                key: nameof(EmailTokenRequest),
                values: "Value is required");

            var expectedTokensValidationException =
                new TokensValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<EmailToken> EmailTokenTask =
                this.tokensService.PostSendEmailTokenAsync(invalidPayments);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    EmailTokenTask.AsTask);

            // then
            actualTokensValidationException.Should()
                .BeEquivalentTo(expectedTokensValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostEmailTokenAsync(
                    It.IsAny<ExternalEmailTokenRequest>()),
                        Times.Never);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null, null, null)]
        [InlineData("", "", "", "")]
        [InlineData("  ", "  ", "  ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostEmailTokenIfEmailTokenIsInvalidAsync(
           string invalidEmail, string invalidCode,
            string invalidApiKey, string invalidEmailConfiguration)
        {
            // given
            var EmailToken = new EmailToken
            {
                Request = new EmailTokenRequest
                {
                    EmailAddress = invalidEmail,
                    EmailConfigurationId = invalidEmailConfiguration,
                    Code = invalidCode,
                    ApiKey = invalidApiKey,
                   


                }
            };

            var invalidPaymentsException = new InvalidTokensException();

            invalidPaymentsException.AddData(
                key: nameof(EmailTokenRequest.ApiKey),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(EmailTokenRequest.Code),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(EmailTokenRequest.EmailConfigurationId),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(EmailTokenRequest.EmailAddress),
             values: "Value is required");

  

            var expectedTokensValidationException =
                new TokensValidationException(invalidPaymentsException);

            // when
            ValueTask<EmailToken> EmailTokenTask =
                this.tokensService.PostSendEmailTokenAsync(EmailToken);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(EmailTokenTask.AsTask);

            // then
            actualTokensValidationException.Should().BeEquivalentTo(
                expectedTokensValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostEmailTokenIfPostEmailTokenIsEmptyAsync()
        {
            // given
            var EmailToken = new EmailToken
            {
                Request = new EmailTokenRequest
                {

                    ApiKey = string.Empty,
                    Code = string.Empty,
                    EmailConfigurationId = string.Empty,
                    EmailAddress = string.Empty
                }
            };

            var invalidPaymentsException = new InvalidTokensException();

            invalidPaymentsException.AddData(
                  key: nameof(EmailTokenRequest.ApiKey),
                  values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(EmailTokenRequest.Code),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(EmailTokenRequest.EmailConfigurationId),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(EmailTokenRequest.EmailAddress),
             values: "Value is required");


       

            var expectedTokensValidationException =
                new TokensValidationException(invalidPaymentsException);

            // when
            ValueTask<EmailToken> EmailTokenTask =
                this.tokensService.PostSendEmailTokenAsync(EmailToken);

            TokensValidationException actualTokensValidationException =
                await Assert.ThrowsAsync<TokensValidationException>(
                    EmailTokenTask.AsTask);

            // then
            actualTokensValidationException.Should().BeEquivalentTo(
                expectedTokensValidationException);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}