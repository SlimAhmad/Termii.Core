using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens;

namespace Termii.Core.Brokers.Termii
{
    internal partial class TermiiBroker
    {


        public async ValueTask<ExternalSendTokenResponse> PostTokenAsync(ExternalSendTokenRequest externalSendTokenRequest)
        {
            return await PostAsync<ExternalSendTokenRequest, ExternalSendTokenResponse>(
            relativeUrl: $"api/sms/otp/send",
            content: externalSendTokenRequest);


        }
        public async ValueTask<ExternalVoiceTokenResponse> PostVoiceTokenAsync(
            ExternalVoiceTokenRequest externalVoiceTokenRequest)
        {
            return await PostAsync<ExternalVoiceTokenRequest, ExternalVoiceTokenResponse>(
            relativeUrl: $"api/sms/otp/send/voice",
            content: externalVoiceTokenRequest);


        }
        public async ValueTask<ExternalVoiceCallResponse> PostVoiceCallAsync(ExternalVoiceCallRequest externalVoiceCallRequest)
        {
            return await PostAsync<ExternalVoiceCallRequest, ExternalVoiceCallResponse>(
            relativeUrl: $"api/sms/otp/call",
            content: externalVoiceCallRequest);


        }
        public async ValueTask<ExternalInAppTokenResponse> PostInAppAsync(ExternalInAppTokenRequest externalInAppTokenRequest)
        {
            return await PostAsync<ExternalInAppTokenRequest, ExternalInAppTokenResponse>(
            relativeUrl: $"api/sms/otp/generate",
            content: externalInAppTokenRequest);


        }
        public async ValueTask<ExternalVerifyTokenResponse> PostVerifyTokenAsync(ExternalVerifyTokenRequest externalVerifyTokenRequest)
        {
            return await PostAsync<ExternalVerifyTokenRequest, ExternalVerifyTokenResponse>(
            relativeUrl: $"api/sms/otp/verify",
            content: externalVerifyTokenRequest);


        }
        public async ValueTask<ExternalEmailTokenResponse> PostEmailTokenAsync(ExternalEmailTokenRequest externalEmailTokenRequest)
        {
            return await PostAsync<ExternalEmailTokenRequest, ExternalEmailTokenResponse>(
            relativeUrl: $"api/email/otp/send",
            content: externalEmailTokenRequest);


        }

    }
}
