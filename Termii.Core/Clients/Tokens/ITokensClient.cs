using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Tokens;

namespace Termii.Core.Clients.Tokens
{
    public interface ITokensClient
    {

        ValueTask<SendToken> SendTokenAsync(SendToken externalSendToken);
        ValueTask<VoiceToken> SendVoiceTokenAsync(VoiceToken externalVoiceToken);
        ValueTask<VoiceCall> SendVoiceCallAsync(VoiceCall externalVoiceCall);
        ValueTask<InAppToken> SendInAppAsync(InAppToken externalInAppToken);
        ValueTask<VerifyToken> SendVerifyTokenAsync(VerifyToken externalVerifyToken);
        ValueTask<EmailToken> SendSendEmailTokenAsync(EmailToken externalEmailToken);
    }
}
