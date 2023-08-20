using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Insights;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;

namespace Termii.Core.Services.Foundations.Termii.Tokens.TokensService
{
    internal partial class TokensService
    {
        private delegate ValueTask<VerifyToken> ReturningVerifyTokenFunction();

        private delegate ValueTask<InAppToken> ReturningInAppTokenFunction();

        private delegate ValueTask<SendToken> ReturningSendTokenFunction();

        private delegate ValueTask<EmailToken> ReturningEmailTokenFunction();

        private delegate ValueTask<VoiceCall> ReturningVoiceCallFunction();

        private delegate ValueTask<VoiceToken> ReturningVoiceTokenFunction();

        private async ValueTask<VoiceToken> TryCatch(ReturningVoiceTokenFunction returningVoiceTokenFunction)
        {
            try
            {
                return await returningVoiceTokenFunction();
            }
            catch (NullTokensException nullTokensException)
            {
                throw new TokensValidationException(nullTokensException);
            }
            catch (InvalidTokensException invalidTokensException)
            {
                throw new TokensValidationException(invalidTokensException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTokensException =
                    new InvalidConfigurationTokensException(httpResponseUrlNotFoundException);

                throw new TokensDependencyException(invalidConfigurationTokensException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTokensException =
                    new UnauthorizedTokensException(httpResponseUnauthorizedException);

                throw new TokensDependencyException(unauthorizedTokensException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTokensException =
                    new UnauthorizedTokensException(httpResponseForbiddenException);

                throw new TokensDependencyException(unauthorizedTokensException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTokensException =
                    new NotFoundTokensException(httpResponseNotFoundException);

                throw new TokensDependencyValidationException(notFoundTokensException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTokensException =
                    new InvalidTokensException(httpResponseBadRequestException);

                throw new TokensDependencyValidationException(invalidTokensException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTokensException =
                    new ExcessiveCallTokensException(httpResponseTooManyRequestsException);

                throw new TokensDependencyValidationException(excessiveCallTokensException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTokensException =
                    new FailedServerTokensException(httpResponseException);

                throw new TokensDependencyException(failedServerTokensException);
            }
            catch (Exception exception)
            {
                var failedTokensServiceException =
                    new FailedTokensServiceException(exception);

                throw new TokensServiceException(failedTokensServiceException);
            }
        }

        private async ValueTask<VoiceCall> TryCatch(ReturningVoiceCallFunction returningVoiceCallFunction)
        {
            try
            {
                return await returningVoiceCallFunction();
            }
            catch (NullTokensException nullTokensException)
            {
                throw new TokensValidationException(nullTokensException);
            }
            catch (InvalidTokensException invalidTokensException)
            {
                throw new TokensValidationException(invalidTokensException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTokensException =
                    new InvalidConfigurationTokensException(httpResponseUrlNotFoundException);

                throw new TokensDependencyException(invalidConfigurationTokensException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTokensException =
                    new UnauthorizedTokensException(httpResponseUnauthorizedException);

                throw new TokensDependencyException(unauthorizedTokensException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTokensException =
                    new UnauthorizedTokensException(httpResponseForbiddenException);

                throw new TokensDependencyException(unauthorizedTokensException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTokensException =
                    new NotFoundTokensException(httpResponseNotFoundException);

                throw new TokensDependencyValidationException(notFoundTokensException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTokensException =
                    new InvalidTokensException(httpResponseBadRequestException);

                throw new TokensDependencyValidationException(invalidTokensException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTokensException =
                    new ExcessiveCallTokensException(httpResponseTooManyRequestsException);

                throw new TokensDependencyValidationException(excessiveCallTokensException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTokensException =
                    new FailedServerTokensException(httpResponseException);

                throw new TokensDependencyException(failedServerTokensException);
            }
            catch (Exception exception)
            {
                var failedTokensServiceException =
                    new FailedTokensServiceException(exception);

                throw new TokensServiceException(failedTokensServiceException);
            }
        }
        private async ValueTask<SendToken> TryCatch(ReturningSendTokenFunction returningSendTokenFunction)
        {
            try
            {
                return await returningSendTokenFunction();
            }
            catch (NullTokensException nullTokensException)
            {
                throw new TokensValidationException(nullTokensException);
            }
            catch (InvalidTokensException invalidTokensException)
            {
                throw new TokensValidationException(invalidTokensException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTokensException =
                    new InvalidConfigurationTokensException(httpResponseUrlNotFoundException);

                throw new TokensDependencyException(invalidConfigurationTokensException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTokensException =
                    new UnauthorizedTokensException(httpResponseUnauthorizedException);

                throw new TokensDependencyException(unauthorizedTokensException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTokensException =
                    new UnauthorizedTokensException(httpResponseForbiddenException);

                throw new TokensDependencyException(unauthorizedTokensException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTokensException =
                    new NotFoundTokensException(httpResponseNotFoundException);

                throw new TokensDependencyValidationException(notFoundTokensException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTokensException =
                    new InvalidTokensException(httpResponseBadRequestException);

                throw new TokensDependencyValidationException(invalidTokensException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTokensException =
                    new ExcessiveCallTokensException(httpResponseTooManyRequestsException);

                throw new TokensDependencyValidationException(excessiveCallTokensException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTokensException =
                    new FailedServerTokensException(httpResponseException);

                throw new TokensDependencyException(failedServerTokensException);
            }
            catch (Exception exception)
            {
                var failedTokensServiceException =
                    new FailedTokensServiceException(exception);

                throw new TokensServiceException(failedTokensServiceException);
            }
        }

        private async ValueTask<EmailToken> TryCatch(ReturningEmailTokenFunction returningEmailTokenFunction)
        {
            try
            {
                return await returningEmailTokenFunction();
            }
            catch (NullTokensException nullTokensException)
            {
                throw new TokensValidationException(nullTokensException);
            }
            catch (InvalidTokensException invalidTokensException)
            {
                throw new TokensValidationException(invalidTokensException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTokensException =
                    new InvalidConfigurationTokensException(httpResponseUrlNotFoundException);

                throw new TokensDependencyException(invalidConfigurationTokensException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTokensException =
                    new UnauthorizedTokensException(httpResponseUnauthorizedException);

                throw new TokensDependencyException(unauthorizedTokensException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTokensException =
                    new UnauthorizedTokensException(httpResponseForbiddenException);

                throw new TokensDependencyException(unauthorizedTokensException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTokensException =
                    new NotFoundTokensException(httpResponseNotFoundException);

                throw new TokensDependencyValidationException(notFoundTokensException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTokensException =
                    new InvalidTokensException(httpResponseBadRequestException);

                throw new TokensDependencyValidationException(invalidTokensException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTokensException =
                    new ExcessiveCallTokensException(httpResponseTooManyRequestsException);

                throw new TokensDependencyValidationException(excessiveCallTokensException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTokensException =
                    new FailedServerTokensException(httpResponseException);

                throw new TokensDependencyException(failedServerTokensException);
            }
            catch (Exception exception)
            {
                var failedTokensServiceException =
                    new FailedTokensServiceException(exception);

                throw new TokensServiceException(failedTokensServiceException);
            }
        }

        private async ValueTask<VerifyToken> TryCatch(ReturningVerifyTokenFunction returningVerifyTokenFunction)
        {
            try
            {
                return await returningVerifyTokenFunction();
            }
            catch (NullTokensException nullTokensException)
            {
                throw new TokensValidationException(nullTokensException);
            }
            catch (InvalidTokensException invalidTokensException)
            {
                throw new TokensValidationException(invalidTokensException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTokensException =
                    new InvalidConfigurationTokensException(httpResponseUrlNotFoundException);

                throw new TokensDependencyException(invalidConfigurationTokensException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTokensException =
                    new UnauthorizedTokensException(httpResponseUnauthorizedException);

                throw new TokensDependencyException(unauthorizedTokensException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTokensException =
                    new UnauthorizedTokensException(httpResponseForbiddenException);

                throw new TokensDependencyException(unauthorizedTokensException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTokensException =
                    new NotFoundTokensException(httpResponseNotFoundException);

                throw new TokensDependencyValidationException(notFoundTokensException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTokensException =
                    new InvalidTokensException(httpResponseBadRequestException);

                throw new TokensDependencyValidationException(invalidTokensException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTokensException =
                    new ExcessiveCallTokensException(httpResponseTooManyRequestsException);

                throw new TokensDependencyValidationException(excessiveCallTokensException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTokensException =
                    new FailedServerTokensException(httpResponseException);

                throw new TokensDependencyException(failedServerTokensException);
            }
            catch (Exception exception)
            {
                var failedTokensServiceException =
                    new FailedTokensServiceException(exception);

                throw new TokensServiceException(failedTokensServiceException);
            }
        }

        private async ValueTask<InAppToken> TryCatch(
            ReturningInAppTokenFunction returningInAppTokenFunction)
        {
            try
            {
                return await returningInAppTokenFunction();
            }
            catch (NullTokensException nullTokensException)
            {
                throw new TokensValidationException(nullTokensException);
            }
            catch (InvalidTokensException invalidTokensException)
            {
                throw new TokensValidationException(invalidTokensException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTokensException =
                    new InvalidConfigurationTokensException(httpResponseUrlNotFoundException);

                throw new TokensDependencyException(invalidConfigurationTokensException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTokensException =
                    new UnauthorizedTokensException(httpResponseUnauthorizedException);

                throw new TokensDependencyException(unauthorizedTokensException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTokensException =
                    new UnauthorizedTokensException(httpResponseForbiddenException);

                throw new TokensDependencyException(unauthorizedTokensException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTokensException =
                    new NotFoundTokensException(httpResponseNotFoundException);

                throw new TokensDependencyValidationException(notFoundTokensException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTokensException =
                    new InvalidTokensException(httpResponseBadRequestException);

                throw new TokensDependencyValidationException(invalidTokensException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTokensException =
                    new ExcessiveCallTokensException(httpResponseTooManyRequestsException);

                throw new TokensDependencyValidationException(excessiveCallTokensException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTokensException =
                    new FailedServerTokensException(httpResponseException);

                throw new TokensDependencyException(failedServerTokensException);
            }
            catch (Exception exception)
            {
                var failedTokensServiceException =
                    new FailedTokensServiceException(exception);

                throw new TokensServiceException(failedTokensServiceException);
            }
        }

    }
}