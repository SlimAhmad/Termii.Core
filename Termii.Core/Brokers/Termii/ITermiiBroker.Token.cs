using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens;

namespace Termii.Core.Brokers.Termii
{
    internal partial interface ITermiiBroker
    {

        ValueTask<ExternalSendTokenResponse> PostTokenAsync(ExternalSendTokenRequest externalSendTokenRequest);
        ValueTask<ExternalVoiceTokenResponse> PostVoiceTokenAsync(ExternalVoiceTokenRequest externalVoiceTokenRequest);
        ValueTask<ExternalVoiceCallResponse> PostVoiceCallAsync(ExternalVoiceCallRequest externalVoiceCallRequest);
        ValueTask<ExternalInAppTokenResponse> PostInAppAsync(ExternalInAppTokenRequest  externalInAppTokenRequest);
        ValueTask<ExternalVerifyTokenResponse> PostVerifyTokenAsync(ExternalVerifyTokenRequest  externalVerifyTokenRequest);
        ValueTask<ExternalEmailTokenResponse> PostSendEmailTokenAsync(ExternalEmailTokenRequest externalEmailTokenRequest);

    }
}
