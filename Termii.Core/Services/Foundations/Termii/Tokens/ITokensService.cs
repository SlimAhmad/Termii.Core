using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;

namespace Termii.Core.Services.Foundations.Termii.Tokens.TokensService
{
    internal interface ITokensService
    {
        ValueTask<SendToken> PostTokenAsync(SendToken externalSendToken);
        ValueTask<VoiceToken> PostVoiceTokenAsync(VoiceToken externalVoiceToken);
        ValueTask<VoiceCall> PostVoiceCallAsync(VoiceCall externalVoiceCall);
        ValueTask<InAppToken> PostInAppAsync(InAppToken externalInAppToken);
        ValueTask<VerifyToken> PostVerifyTokenAsync(VerifyToken externalVerifyToken);
        ValueTask<EmailToken> PostSendEmailTokenAsync(EmailToken externalEmailToken);
    }
}
