using Termii.Core.Clients.Insights;
using Termii.Core.Clients.Switch;
using Termii.Core.Clients.Tokens;

namespace Termii.Core.Clients.Termii
{
    public interface ITermiiClient
    {
        ISwitchClient Switch { get; }

        IInsightsClient Insights { get; }

        ITokensClient Tokens { get; }

    }
}
