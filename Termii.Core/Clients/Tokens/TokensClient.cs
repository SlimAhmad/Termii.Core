using FlutterWave.Core.Models.Clients.Tokens.Exceptions;
using FlutterWave.Core.Models.Clients.Tokenss.Exceptions;
using System.Text.Json;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;
using Termii.Core.Services.Foundations.Termii.Tokens.TokensService;
using Xeptions;

namespace Termii.Core.Clients.Tokens
{
    internal class TokensClient : ITokensClient
    {
        private readonly ITokensService tokensService;

        public TokensClient(ITokensService tokenService) =>
            tokensService = tokenService;

        public async ValueTask<InAppToken> SendInAppAsync(InAppToken externalInAppToken)
        {
            try
            {
                return await tokensService.PostInAppAsync(externalInAppToken);
            }
            catch (TokensValidationException tokensValidationException)
            {

                throw new TokensClientValidationException(
                    tokensValidationException.InnerException as Xeption);
            }
            catch (TokensDependencyValidationException tokensDependencyValidationException)
            {
                throw new TokensClientValidationException(
                    tokensDependencyValidationException.InnerException as Xeption);
            }
            catch (TokensDependencyException tokensDependencyException)
            {
                throw new TokensClientDependencyException(
                    tokensDependencyException.InnerException as Xeption);
            }
            catch (TokensServiceException tokensServiceException)
            {
                throw new TokensClientServiceException(
                    tokensServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<EmailToken> SendSendEmailTokenAsync(EmailToken externalEmailToken)
        {
            try
            {
                return await tokensService.PostSendEmailTokenAsync(externalEmailToken);
            }
            catch (TokensValidationException tokensValidationException)
            {

                throw new TokensClientValidationException(
                    tokensValidationException.InnerException as Xeption);
            }
            catch (TokensDependencyValidationException tokensDependencyValidationException)
            {
                throw new TokensClientValidationException(
                    tokensDependencyValidationException.InnerException as Xeption);
            }
            catch (TokensDependencyException tokensDependencyException)
            {
                throw new TokensClientDependencyException(
                    tokensDependencyException.InnerException as Xeption);
            }
            catch (TokensServiceException tokensServiceException)
            {
                throw new TokensClientServiceException(
                    tokensServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<SendToken> SendTokenAsync(SendToken externalSendToken)
        {
            try
            {
                return await tokensService.PostTokenAsync(externalSendToken);
            }
            catch (TokensValidationException tokensValidationException)
            {

                throw new TokensClientValidationException(
                    tokensValidationException.InnerException as Xeption);
            }
            catch (TokensDependencyValidationException tokensDependencyValidationException)
            {
                throw new TokensClientValidationException(
                    tokensDependencyValidationException.InnerException as Xeption);
            }
            catch (TokensDependencyException tokensDependencyException)
            {
                throw new TokensClientDependencyException(
                    tokensDependencyException.InnerException as Xeption);
            }
            catch (TokensServiceException tokensServiceException)
            {
                throw new TokensClientServiceException(
                    tokensServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<VerifyToken> SendVerifyTokenAsync(VerifyToken externalVerifyToken)
        {
            try
            {
                return await tokensService.PostVerifyTokenAsync(externalVerifyToken);
            }
            catch (TokensValidationException tokensValidationException)
            {

                throw new TokensClientValidationException(
                    tokensValidationException.InnerException as Xeption);
            }
            catch (TokensDependencyValidationException tokensDependencyValidationException)
            {
                throw new TokensClientValidationException(
                    tokensDependencyValidationException.InnerException as Xeption);
            }
            catch (TokensDependencyException tokensDependencyException)
            {
                throw new TokensClientDependencyException(
                    tokensDependencyException.InnerException as Xeption);
            }
            catch (TokensServiceException tokensServiceException)
            {
                throw new TokensClientServiceException(
                    tokensServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<VoiceCall> SendVoiceCallAsync(VoiceCall externalVoiceCall)
        {
            try
            {
                return await tokensService.PostVoiceCallAsync(externalVoiceCall);
            }
            catch (TokensValidationException tokensValidationException)
            {

                throw new TokensClientValidationException(
                    tokensValidationException.InnerException as Xeption);
            }
            catch (TokensDependencyValidationException tokensDependencyValidationException)
            {
                throw new TokensClientValidationException(
                    tokensDependencyValidationException.InnerException as Xeption);
            }
            catch (TokensDependencyException tokensDependencyException)
            {
                throw new TokensClientDependencyException(
                    tokensDependencyException.InnerException as Xeption);
            }
            catch (TokensServiceException tokensServiceException)
            {
                throw new TokensClientServiceException(
                    tokensServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<VoiceToken> SendVoiceTokenAsync(VoiceToken externalVoiceToken)
        {
            try
            {
                return await tokensService.PostVoiceTokenAsync(externalVoiceToken);
            }
            catch (TokensValidationException tokensValidationException)
            {

                throw new TokensClientValidationException(
                    tokensValidationException.InnerException as Xeption);
            }
            catch (TokensDependencyValidationException tokensDependencyValidationException)
            {
                throw new TokensClientValidationException(
                    tokensDependencyValidationException.InnerException as Xeption);
            }
            catch (TokensDependencyException tokensDependencyException)
            {
                throw new TokensClientDependencyException(
                    tokensDependencyException.InnerException as Xeption);
            }
            catch (TokensServiceException tokensServiceException)
            {
                throw new TokensClientServiceException(
                    tokensServiceException.InnerException as Xeption);
            }
        }
    }
}
