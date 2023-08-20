using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;

namespace Termii.Core.Brokers.Termii
{
    internal partial interface ITermiiBroker
    {
     

        ValueTask<ExternalBalanceResponse> GetBalanceAsync(string apiKey);

        ValueTask<ExternalHistoryResponse> GetHistoryAsync(string apiKey);

        ValueTask<ExternalSearchResponse> GetSearchPhoneNumberStatusAsync(ExternalSearchRequest  externalSearchRequest);

        ValueTask<ExternalStatusResponse> GetPhoneNumberStatusAsync(ExternalStatusRequest  externalStatusRequest);

 

    }
}
