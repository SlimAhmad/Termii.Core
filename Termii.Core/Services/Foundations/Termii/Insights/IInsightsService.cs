using Termii.Core.Models.Services.Foundations.Termii.Insights;

namespace Termii.Core.Services.Foundations.Termii.Insights.InsightsService
{
    internal interface IInsightsService
    {

        ValueTask<Balance> GetBalanceAsync(string apiKey);

        ValueTask<History> GetHistoryAsync(string apiKey);

        ValueTask<Search> GetSearchPhoneNumberStatusAsync(Search externalSearch);

        ValueTask<Status> GetPhoneNumberStatusAsync(Status externalStatus);
    }
}
