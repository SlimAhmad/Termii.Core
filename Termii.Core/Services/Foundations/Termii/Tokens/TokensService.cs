using System.Threading.Tasks;
using Termii.Core.Brokers.DateTimes;
using Termii.Core.Brokers.Termii;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;

namespace Termii.Core.Services.Foundations.Termii.Tokens.TokensService
{
    internal partial class TokensService : ITokensService
    {
        private readonly ITermiiBroker termiiBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public TokensService(
            ITermiiBroker termiiBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.termiiBroker = termiiBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<InAppToken> PostInAppAsync(InAppToken externalInAppToken) =>
        TryCatch(async () =>
        {
            ValidateInAppToken(externalInAppToken);
            ExternalInAppTokenRequest externalInAppTokenRequest = ConvertToTokensRequest(externalInAppToken);
            ExternalInAppTokenResponse externalInAppTokenResponse = await termiiBroker.PostInAppAsync(externalInAppTokenRequest);
            return ConvertToTokensResponse(externalInAppToken, externalInAppTokenResponse);
        });

        public ValueTask<EmailToken> PostSendEmailTokenAsync(EmailToken externalEmailToken) =>
        TryCatch(async () =>
        {
            ValidateEmailToken(externalEmailToken);
            ExternalEmailTokenRequest externalEmailTokenRequest = ConvertToTokensRequest(externalEmailToken);
            ExternalEmailTokenResponse externalEmailTokenResponse = await termiiBroker.PostEmailTokenAsync(externalEmailTokenRequest);
            return ConvertToTokensResponse(externalEmailToken, externalEmailTokenResponse);
        });

        public ValueTask<SendToken> PostTokenAsync(SendToken externalSendToken) =>
        TryCatch(async () =>
        {
            ValidateSendToken(externalSendToken);
            ExternalSendTokenRequest externalSendTokenRequest = ConvertToTokensRequest(externalSendToken);
            ExternalSendTokenResponse externalSendTokenResponse = await termiiBroker.PostTokenAsync(externalSendTokenRequest);
            return ConvertToTokensResponse(externalSendToken, externalSendTokenResponse);
        });

        public ValueTask<VerifyToken> PostVerifyTokenAsync(VerifyToken externalVerifyToken) =>
        TryCatch(async () =>
        {
            ValidateVerifyToken(externalVerifyToken);
            ExternalVerifyTokenRequest externalVerifyTokenRequest = ConvertToTokensRequest(externalVerifyToken);
            ExternalVerifyTokenResponse externalVerifyTokenResponse = await termiiBroker.PostVerifyTokenAsync(externalVerifyTokenRequest);
            return ConvertToTokensResponse(externalVerifyToken, externalVerifyTokenResponse);
        });

        public ValueTask<VoiceCall> PostVoiceCallAsync(VoiceCall externalVoiceCall) =>
        TryCatch(async () =>
        {
            ValidateVoiceCall(externalVoiceCall);
            ExternalVoiceCallRequest externalVoiceCallRequest = ConvertToTokensRequest(externalVoiceCall);
            ExternalVoiceCallResponse externalVoiceCallResponse = await termiiBroker.PostVoiceCallAsync(externalVoiceCallRequest);
            return ConvertToTokensResponse(externalVoiceCall, externalVoiceCallResponse);
        });

        public ValueTask<VoiceToken> PostVoiceTokenAsync(VoiceToken externalVoiceToken) =>
        TryCatch(async () =>
        {
            ValidateVoiceToken(externalVoiceToken);
            ExternalVoiceTokenRequest externalVoiceTokenRequest = ConvertToTokensRequest(externalVoiceToken);
            ExternalVoiceTokenResponse externalVoiceTokenResponse = await termiiBroker.PostVoiceTokenAsync(externalVoiceTokenRequest);
            return ConvertToTokensResponse(externalVoiceToken, externalVoiceTokenResponse);
        });


        private static ExternalVoiceCallRequest ConvertToTokensRequest(VoiceCall voiceCall)
        {

            return new ExternalVoiceCallRequest
            {
                ApiKey = voiceCall.Request.ApiKey,
                PhoneNumber = voiceCall.Request.PhoneNumber,
                Code = voiceCall.Request.Code,
            };



        }

        private static ExternalInAppTokenRequest ConvertToTokensRequest(InAppToken voiceCall)
        {

            return new ExternalInAppTokenRequest
            {
                ApiKey = voiceCall.Request.ApiKey,
                PhoneNumber = voiceCall.Request.PhoneNumber,
                PinAttempts = voiceCall.Request.PinAttempts,
                PinLength = voiceCall.Request.PinLength,
                PinTimeToLive = voiceCall.Request.PinTimeToLive,
                PinType = voiceCall.Request.PinType,
              
            };



        }

        private static ExternalSendTokenRequest ConvertToTokensRequest(SendToken voiceCall)
        {

            return new ExternalSendTokenRequest
            {
                ApiKey = voiceCall.Request.ApiKey,
                PinType = voiceCall.Request.PinType,
                PinTimeToLive = voiceCall.Request.PinTimeToLive,
                PinLength = voiceCall.Request.PinLength,
                PinAttempts = voiceCall.Request.PinAttempts,
                Channel = voiceCall.Request.Channel,
                From = voiceCall.Request.From,
                MessageText = voiceCall.Request.MessageText,
                MessageType = voiceCall.Request.MessageType,
                PinPlaceholder = voiceCall.Request.PinPlaceholder,
                To = voiceCall.Request.To,
            };



        }

        private static ExternalVoiceTokenRequest ConvertToTokensRequest(VoiceToken voiceCall)
        {

            return new ExternalVoiceTokenRequest
            {
                ApiKey = voiceCall.Request.ApiKey,
                PhoneNumber = voiceCall.Request.PhoneNumber,
                PinAttempts = voiceCall.Request.PinAttempts,
                PinLength = voiceCall.Request.PinLength,
                PinTimeToLive = voiceCall.Request.PinTimeToLive,
              
            };



        }

        private static ExternalVerifyTokenRequest ConvertToTokensRequest(VerifyToken voiceCall)
        {

            return new ExternalVerifyTokenRequest
            {
                ApiKey = voiceCall.Request.ApiKey,
                Pin = voiceCall.Request.Pin,
                PinId = voiceCall.Request.PinId,
            };



        }

        private static ExternalEmailTokenRequest ConvertToTokensRequest(EmailToken voiceCall)
        {

            return new ExternalEmailTokenRequest
            {
                ApiKey = voiceCall.Request.ApiKey,
                EmailAddress = voiceCall.Request.EmailAddress,
                EmailConfigurationId = voiceCall.Request.EmailConfigurationId,
                Code = voiceCall.Request.Code,
            };



        }



        private static VoiceCall ConvertToTokensResponse(VoiceCall voicecall, ExternalVoiceCallResponse externalVoiceCallResponse)
        {
            voicecall.Response = new VoiceCallResponse
            {
                PinId = externalVoiceCallResponse.PinId,
                User = externalVoiceCallResponse.User,
                MessageId = externalVoiceCallResponse.MessageId,
                Message = externalVoiceCallResponse.Message,
                Code = externalVoiceCallResponse.Code,
                Balance = externalVoiceCallResponse.Balance,
            };
            return voicecall;

        }

        private static InAppToken ConvertToTokensResponse(InAppToken inAppToken, ExternalInAppTokenResponse externalInAppTokenResponse)
        {
            inAppToken.Response = new InAppTokenResponse
            {
                   Data = new InAppTokenResponse.InAppData
                   {
                     Otp = externalInAppTokenResponse.Data.Otp,
                     PhoneNumber = externalInAppTokenResponse.Data.PhoneNumber,
                     PhoneNumberOther = externalInAppTokenResponse.Data.PhoneNumberOther,
                     PinId = externalInAppTokenResponse.Data.PinId
                   },
                   Status = externalInAppTokenResponse.Status
            };
            return inAppToken;

        }

        private static EmailToken ConvertToTokensResponse(EmailToken emailToken, ExternalEmailTokenResponse externalEmailTokenResponse)
        {
            emailToken.Response = new EmailTokenResponse
            {
                Balance = externalEmailTokenResponse.Balance,
                Code = externalEmailTokenResponse.Code,
                Message = externalEmailTokenResponse.Message,
                MessageId = externalEmailTokenResponse.MessageId,
                User = externalEmailTokenResponse.User,
            };
            return emailToken;

        }

        private static VerifyToken ConvertToTokensResponse(VerifyToken verifyToken, ExternalVerifyTokenResponse externalVerifyTokenResponse)
        {
            verifyToken.Response = new VerifyTokenResponse
            {
                 PinId = externalVerifyTokenResponse.PinId,
                 Msisdn = externalVerifyTokenResponse.Msisdn,
                 Verified = externalVerifyTokenResponse.Verified,
            };
            return verifyToken;

        }

        private static SendToken ConvertToTokensResponse(SendToken sendToken, ExternalSendTokenResponse externalSendTokenResponse)
        {
            sendToken.Response = new SendTokenResponse
            {
                PinId = externalSendTokenResponse.PinId,
                SmsStatus = externalSendTokenResponse.SmsStatus,
                To = externalSendTokenResponse.To,
            };
            return sendToken;

        }

        private static VoiceToken ConvertToTokensResponse(VoiceToken voiceToken, ExternalVoiceTokenResponse externalVoiceTokenResponse)
        {
            voiceToken.Response = new VoiceTokenResponse
            {
                PinId = externalVoiceTokenResponse.PinId,
                Balance = externalVoiceTokenResponse.Balance,
                Code = externalVoiceTokenResponse.Code,
                Message = externalVoiceTokenResponse.Message,
                MessageId = externalVoiceTokenResponse.MessageId,
                User =  externalVoiceTokenResponse.User,
            };
            return voiceToken;

        }
    }
}
