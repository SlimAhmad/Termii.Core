using Termii.Core.Clients.Termii;
using Termii.Core.Models.Configurations;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace Termii.Core.Tests.Acceptance.Clients.Tokens
{
    public partial class TokensClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly ITermiiClient termiiClient;

        public TokensClientTests()
        {
            apiKey = GetRandomString();
            wireMockServer = WireMockServer.Start();

            var apiConfigurations = new ApiConfigurations
            {
                ApiUrl = wireMockServer.Url,
                ApiKey = apiKey,

            };

            termiiClient = new TermiiClient(apiConfigurations);
        }

        private static DateTimeOffset GetRandomDate() =>
             new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

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
                User = externalVoiceTokenResponse.User,
            };
            return voiceToken;

        }


        private static ExternalSendTokenResponse CreateExternalSendTokenResponseResult() =>
                CreateExternalSendTokenResponseFiller().Create();

        private static ExternalVoiceCallResponse CreateExternalVoiceCallResponseResult() =>
           CreateExternalVoiceCallResponseFiller().Create();
        private static ExternalEmailTokenResponse CreateExternalEmailTokenResponseResult() =>
           CreateExternalEmailTokenResponseFiller().Create();

        private static ExternalInAppTokenResponse CreateExternalInAppTokenResponseResult() =>
           CreateExternalInAppTokenResponseFiller().Create();

        private static ExternalVerifyTokenResponse CreateExternalVerifyTokenResponseResult() =>
           CreateExternalExternalVerifyTokenResponseFiller().Create();

        private static ExternalVoiceTokenResponse CreateExternalVoiceTokenResponseResult() =>
          CreateExternalVoiceTokenResponseFiller().Create();



        private static VoiceCall CreateVoiceCallResponseResult() =>
          CreateVoiceCallFiller().Create();

        private static VoiceToken CreateVoiceTokenResponseResult() =>
          CreateVoiceTokenFiller().Create();

        private static EmailToken CreateEmailTokenResponseResult() =>
          CreateEmailTokenFiller().Create();

        private static SendToken CreateSendTokenResponseResult() =>
            CreateSendTokenFiller().Create();

        private static InAppToken CreateRandomInAppTokenResponseResult() =>
            CreateRandomInAppTokenFiller().Create();

        private static VerifyToken CreateRandomVerifyTokenResponseResult() =>
          CreateRandomVerifyTokenFiller().Create();

        private static Filler<ExternalEmailTokenResponse> CreateExternalEmailTokenResponseFiller()
        {
            var filler = new Filler<ExternalEmailTokenResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalVoiceCallResponse> CreateExternalVoiceCallResponseFiller()
        {
            var filler = new Filler<ExternalVoiceCallResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalSendTokenResponse> CreateExternalSendTokenResponseFiller()
        {
            var filler = new Filler<ExternalSendTokenResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalInAppTokenResponse> CreateExternalInAppTokenResponseFiller()
        {
            var filler = new Filler<ExternalInAppTokenResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalVerifyTokenResponse> CreateExternalExternalVerifyTokenResponseFiller()
        {
            var filler = new Filler<ExternalVerifyTokenResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalVoiceTokenResponse> CreateExternalVoiceTokenResponseFiller()
        {
            var filler = new Filler<ExternalVoiceTokenResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }

        private static Filler<EmailToken> CreateEmailTokenFiller()
        {
            var filler = new Filler<EmailToken>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<VoiceCall> CreateVoiceCallFiller()
        {
            var filler = new Filler<VoiceCall>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<VoiceToken> CreateVoiceTokenFiller()
        {
            var filler = new Filler<VoiceToken>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<SendToken> CreateSendTokenFiller()
        {
            var filler = new Filler<SendToken>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<InAppToken> CreateRandomInAppTokenFiller()
        {
            var filler = new Filler<InAppToken>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        private static Filler<VerifyToken> CreateRandomVerifyTokenFiller()
        {
            var filler = new Filler<VerifyToken>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => wireMockServer.Stop();
    }
}
