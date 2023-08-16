using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;

namespace Termii.Core.Brokers.Termii
{
    internal partial class TermiiBroker
    {



        public async ValueTask<ExternalBalanceResponse> GetBalanceAsync(string apiKey)
        {
            return await GetAsync<ExternalBalanceResponse>(
                relativeUrl: $"api/get-balance?api_key={apiKey}");
        }

        public async ValueTask<ExternalHistoryResponse> GetHistoryAsync(string apiKey)
        {
            return await GetAsync<ExternalHistoryResponse>(
                relativeUrl: $"api.ng.termii.com/api/sms/inbox?api_key={apiKey}");
        }

        public async ValueTask<ExternalSearchResponse> GetSearchPhoneNumberStatusAsync(ExternalSearchRequest externalSearchRequest)
        {
            return await GetAsync<ExternalSearchResponse>(
                relativeUrl: $"api/check/dnd?api_key={externalSearchRequest.ApiKey}&phone_number={externalSearchRequest.PhoneNumber}");
        }

        public async ValueTask<ExternalStatusResponse> GetPhoneNumberStatusAsync(ExternalStatusRequest externalStatusRequest)
        {
            return await GetAsync<ExternalStatusResponse>(
                relativeUrl: $"api/insight/number/query?phone_number={externalStatusRequest.PhoneNumber}&api_key={externalStatusRequest.ApiKey}&country_code={externalStatusRequest.CountryCode}");
        }


 
    }
}
