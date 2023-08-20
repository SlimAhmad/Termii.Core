using System;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;

namespace Termii.Core.Services.Foundations.Termii.Tokens.TokensService
{
    internal partial class TokensService
    {
        private static void ValidateVoiceToken(VoiceToken voiceToken)
        {
            ValidateVoiceTokenNotNull(voiceToken);
            ValidateVoiceTokenRequest(voiceToken.Request);
            Validate(
                (Rule: IsInvalid(voiceToken.Request), Parameter: nameof(voiceToken.Request)));

            Validate(
                (Rule: IsInvalid(voiceToken.Request.ApiKey), Parameter: nameof(VoiceTokenRequest.ApiKey)),
                (Rule: IsInvalid(voiceToken.Request.PinTimeToLive), Parameter: nameof(VoiceTokenRequest.PinTimeToLive)),
                (Rule: IsInvalid(voiceToken.Request.PinLength), Parameter: nameof(VoiceTokenRequest.PinLength)),
                (Rule: IsInvalid(voiceToken.Request.PhoneNumber), Parameter: nameof(VoiceTokenRequest.PhoneNumber)),
                (Rule: IsInvalid(voiceToken.Request.PinAttempts), Parameter: nameof(VoiceTokenRequest.PinAttempts))
                );

        }

        private static void ValidateVoiceCall(VoiceCall voiceCall)
        {
            ValidateVoiceCallNotNull(voiceCall);
            ValidateVoiceCallRequest(voiceCall.Request);
            Validate(
                (Rule: IsInvalid(voiceCall.Request), Parameter: nameof(voiceCall.Request)));

            Validate(
                (Rule: IsInvalid(voiceCall.Request.PhoneNumber), Parameter: nameof(VoiceCallRequest.PhoneNumber)),
                (Rule: IsInvalid(voiceCall.Request.ApiKey), Parameter: nameof(VoiceCallRequest.ApiKey)),
                (Rule: IsInvalid(voiceCall.Request.Code), Parameter: nameof(VoiceCallRequest.Code))
        

                );

        }

        private static void ValidateSendToken(SendToken sendToken)
        {
            ValidateSendTokenNotNull(sendToken);
            ValidateSendTokenRequest(sendToken.Request);
            Validate(
                (Rule: IsInvalid(sendToken.Request), Parameter: nameof(sendToken.Request)));

            Validate(
                (Rule: IsInvalid(sendToken.Request.To), Parameter: nameof(SendTokenRequest.To)),
                (Rule: IsInvalid(sendToken.Request.ApiKey), Parameter: nameof(SendTokenRequest.ApiKey)),
                (Rule: IsInvalid(sendToken.Request.MessageText), Parameter: nameof(SendTokenRequest.MessageText)),
                (Rule: IsInvalid(sendToken.Request.MessageType), Parameter: nameof(SendTokenRequest.MessageType)),
                (Rule: IsInvalid(sendToken.Request.Channel), Parameter: nameof(SendTokenRequest.Channel)),
                (Rule: IsInvalid(sendToken.Request.From), Parameter: nameof(SendTokenRequest.From)),
                (Rule: IsInvalid(sendToken.Request.PinType), Parameter: nameof(SendTokenRequest.PinType)),
                (Rule: IsInvalid(sendToken.Request.PinLength), Parameter: nameof(SendTokenRequest.PinLength)),
                (Rule: IsInvalid(sendToken.Request.PinAttempts), Parameter: nameof(SendTokenRequest.PinAttempts)),
                (Rule: IsInvalid(sendToken.Request.PinPlaceholder), Parameter: nameof(SendTokenRequest.PinPlaceholder)),
                (Rule: IsInvalid(sendToken.Request.PinTimeToLive), Parameter: nameof(SendTokenRequest.PinTimeToLive))



                );

        }

        private static void ValidateEmailToken(EmailToken emailToken)
        {
            ValidateEmailTokenNotNull(emailToken);
            ValidateEmailTokenRequest(emailToken.Request);
            Validate(
                (Rule: IsInvalid(emailToken.Request), Parameter: nameof(emailToken.Request)));

            Validate(
                (Rule: IsInvalid(emailToken.Request.EmailConfigurationId), Parameter: nameof(EmailTokenRequest.EmailConfigurationId)),
                (Rule: IsInvalid(emailToken.Request.ApiKey), Parameter: nameof(EmailTokenRequest.ApiKey)),
                (Rule: IsInvalid(emailToken.Request.Code), Parameter: nameof(EmailTokenRequest.Code)),
                (Rule: IsInvalid(emailToken.Request.EmailAddress), Parameter: nameof(EmailTokenRequest.EmailAddress))

                );

        }

        private static void ValidateVerifyToken(VerifyToken verifyToken)
        {
            ValidateVerifyTokenNotNull(verifyToken);
            ValidateVerifyTokenRequest(verifyToken.Request);
            Validate(
                (Rule: IsInvalid(verifyToken.Request), Parameter: nameof(verifyToken.Request)));

            Validate(
                (Rule: IsInvalid(verifyToken.Request.PinId), Parameter: nameof(VerifyTokenRequest.PinId)),
                (Rule: IsInvalid(verifyToken.Request.ApiKey), Parameter: nameof(VerifyTokenRequest.ApiKey)),
                (Rule: IsInvalid(verifyToken.Request.Pin), Parameter: nameof(VerifyTokenRequest.Pin))
      

                );

        }

        private static void ValidateInAppToken(InAppToken inAppToken)
        {
            ValidateInAppTokenNotNull(inAppToken);
            ValidateInAppTokenRequest(inAppToken.Request);
            Validate(
                (Rule: IsInvalid(inAppToken.Request), Parameter: nameof(inAppToken.Request)));

            Validate(
                (Rule: IsInvalid(inAppToken.Request.PinType), Parameter: nameof(InAppTokenRequest.PinType)),
                (Rule: IsInvalid(inAppToken.Request.ApiKey), Parameter: nameof(InAppTokenRequest.ApiKey)),
                (Rule: IsInvalid(inAppToken.Request.PhoneNumber), Parameter: nameof(InAppTokenRequest.PhoneNumber)),
                (Rule: IsInvalid(inAppToken.Request.PinTimeToLive), Parameter: nameof(InAppTokenRequest.PinTimeToLive)),
                (Rule: IsInvalid(inAppToken.Request.PinLength), Parameter: nameof(InAppTokenRequest.PinLength)),
                (Rule: IsInvalid(inAppToken.Request.PinAttempts), Parameter: nameof(InAppTokenRequest.PinAttempts))


                );

        }


        private static void ValidateInAppTokenNotNull(InAppToken inAppToken)
        {
            if (inAppToken is null)
            {
                throw new NullTokensException();
            }
        }

        private static void ValidateInAppTokenRequest(InAppTokenRequest inAppToken)
        {
            Validate((Rule: IsInvalid(inAppToken), Parameter: nameof(InAppTokenRequest)));
        }
        private static void ValidateVerifyTokenNotNull(VerifyToken verifyToken)
        {
            if (verifyToken is null)
            {
                throw new NullTokensException();
            }
        }

        private static void ValidateVerifyTokenRequest(VerifyTokenRequest verifyToken)
        {
            Validate((Rule: IsInvalid(verifyToken), Parameter: nameof(VerifyTokenRequest)));
        }
        private static void ValidateEmailTokenNotNull(EmailToken emailToken)
        {
            if (emailToken is null)
            {
                throw new NullTokensException();
            }
        }

        private static void ValidateEmailTokenRequest(EmailTokenRequest emailToken)
        {
            Validate((Rule: IsInvalid(emailToken), Parameter: nameof(EmailTokenRequest)));
        }

        private static void ValidateSendTokenNotNull(SendToken sendToken)
        {
            if (sendToken is null)
            {
                throw new NullTokensException();
            }
        }

        private static void ValidateSendTokenRequest(SendTokenRequest sendToken)
        {
            Validate((Rule: IsInvalid(sendToken), Parameter: nameof(SendTokenRequest)));
        }

        private static void ValidateVoiceCallNotNull(VoiceCall voiceCall)
        {
            if (voiceCall is null)
            {
                throw new NullTokensException();
            }
        }

        private static void ValidateVoiceCallRequest(VoiceCallRequest voiceCall)
        {
            Validate((Rule: IsInvalid(voiceCall), Parameter: nameof(VoiceCallRequest)));
        }
        private static void ValidateVoiceTokenNotNull(VoiceToken voiceCall)
        {
            if (voiceCall is null)
            {
                throw new NullTokensException();
            }
        }

        private static void ValidateVoiceTokenRequest(VoiceTokenRequest voiceCallRequest)
        {
            Validate((Rule: IsInvalid(voiceCallRequest), Parameter: nameof(VoiceTokenRequest)));
        }

   
        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };


        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };

        private static dynamic IsInvalid(double number) => new
        {
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidvoiceCallException = new InvalidTokensException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidvoiceCallException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidvoiceCallException.ThrowIfContainsErrors();
        }
    }
}