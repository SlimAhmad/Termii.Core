using System;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;

namespace Termii.Core.Brokers.Termii
{
    internal partial class TermiiBroker
    {


        public async ValueTask<ExternalFetchSenderIdsResponse> GetSenderIdsAsync(string apiKey)
        {
            return await GetAsync<ExternalFetchSenderIdsResponse>(
                          relativeUrl: $"api/sender-id?api_key={apiKey}");
        }

        public async ValueTask<ExternalCreateSenderIdResponse> PostSenderIdAsync(
            ExternalCreateSenderIdRequest externalCreateSenderIdRequest)
        {
            return await PostAsync<ExternalCreateSenderIdRequest, ExternalCreateSenderIdResponse>(
            relativeUrl: $"api/sender-id/request",
            content: externalCreateSenderIdRequest);


        }

        public async ValueTask<ExternalSendMessageResponse> PostMessageAsync(
            ExternalSendMessageRequest externalSendMessageRequest)
        {
            return await PostAsync<ExternalSendMessageRequest, ExternalSendMessageResponse>(
            relativeUrl: $"api/sms/send",
            content: externalSendMessageRequest);


        }

        public async ValueTask<ExternalSendBulkMessageResponse> PostBulkMessagesAsync(
            ExternalSendBulkMessageRequest externalSendBulkMessageRequest)
        {
            return await PostAsync<ExternalSendBulkMessageRequest, ExternalSendBulkMessageResponse>(
            relativeUrl: $"api/sms/send/bulk",
            content: externalSendBulkMessageRequest);


        }
        public async ValueTask<ExternalNumberMessageResponse> PostNumberMessageAsync(
            ExternalNumberMessageRequest externalNumberMessageRequest)
        {
            return await PostAsync<ExternalNumberMessageRequest, ExternalNumberMessageResponse>(
            relativeUrl: $"api/sms/number/send",
            content: externalNumberMessageRequest);


        }

        public async ValueTask<ExternalTemplatedMessageResponse> PostTemplatedMessageAsync(
            ExternalTemplatedMessageRequest externalTemplatedMessageRequest)
        {
            return await PostAsync<ExternalTemplatedMessageRequest, ExternalTemplatedMessageResponse>(
            relativeUrl: $"api/send/template",
            content: externalTemplatedMessageRequest);


        }

        public async ValueTask<ExternalCampaignPhoneBookResponse> GetCampaignsPhoneBooksAsync(string apiKey)
        {
            return await GetAsync<ExternalCampaignPhoneBookResponse>(
            relativeUrl: $"api/phonebooks?api_key={apiKey}");


        }

        public async ValueTask<ExternalUpdateCampaignPhoneBookResponse> UpdateCampaignPhoneBookAsync(
            string phoneBookId,ExternalUpdateCampaignPhoneBookRequest externalUpdateCampaignPhoneBookRequest)
        {
            return await PutAsync<ExternalUpdateCampaignPhoneBookRequest, ExternalUpdateCampaignPhoneBookResponse>(
            relativeUrl: $"api/phonebooks/{phoneBookId}",
            content: externalUpdateCampaignPhoneBookRequest);


        }


        public async ValueTask<ExternalCreateCampaignPhoneBookResponse> PostCreatePhoneBookAsync(
            ExternalCreateCampaignPhoneBookRequest externalCreateCampaignPhoneBookRequest)
        {
            return await PostAsync<ExternalCreateCampaignPhoneBookRequest, ExternalCreateCampaignPhoneBookResponse>(
            relativeUrl: $"api/phonebooks",
            content: externalCreateCampaignPhoneBookRequest);


        }

        public async ValueTask<ExternalDeletePhoneBookContactResponse> DeletePhoneBookContactAsync(string apiKey, string contactId)
        {
           
            return await DeleteAsync<ExternalDeletePhoneBookContactResponse>(
            relativeUrl: $"api/phonebook/contact/{contactId}?api_key={apiKey}");


        }

        public async ValueTask<ExternalDeletePhoneBookResponse> DeletePhoneBookAsync(string apiKey,string phoneBookId)
        {
            return await DeleteAsync<ExternalDeletePhoneBookResponse>(
            relativeUrl: $"api/phonebooks/{phoneBookId}?api_key={apiKey}");


        }


        public async ValueTask<ExternalFetchContactsByPhoneBookResponse> GetContactsByPhoneBookIdAsync(string apiKey, string phoneBookId)
        {
            return await GetAsync<ExternalFetchContactsByPhoneBookResponse>(
            relativeUrl: $"api/phonebooks/{phoneBookId}/contacts?api_key={apiKey}");


        }

        public async ValueTask<ExternalAddContactToPhoneBookResponse> PostContactToPhoneBookAsync(
            ExternalAddContactToPhoneBookRequest externalAddContactToPhoneBookRequest, string phoneBookId)
        {
            return await PostAsync<ExternalAddContactToPhoneBookRequest, ExternalAddContactToPhoneBookResponse>(
            relativeUrl: $"api/phonebooks/{phoneBookId}/contacts",
            content: externalAddContactToPhoneBookRequest);


        }

        public async ValueTask<ExternalAddMultipleContactsToPhoneBookResponse> PostContactsToPhoneBookAsync(
            ExternalAddMultipleContactsToPhoneBookRequest externalAddMultipleContactsToPhoneBookRequest, string phoneBookId)
        {
            return await PostAsync<ExternalAddMultipleContactsToPhoneBookRequest, ExternalAddMultipleContactsToPhoneBookResponse>(
            relativeUrl: $"api/phonebooks/{phoneBookId}/contacts",
            content: externalAddMultipleContactsToPhoneBookRequest);


        }


        public async ValueTask<ExternalSendCampaignResponse> PostCreateCampaignAsync(
            ExternalSendCampaignRequest externalSendCampaignRequest)
        {
            return await PostAsync<ExternalSendCampaignRequest, ExternalSendCampaignResponse>(
            relativeUrl: $"api/sms/campaigns/send",
            content: externalSendCampaignRequest);


        }
        public async ValueTask<ExternalFetchCampaignsHistoryResponse> GetCampaignsHistoryAsync(string apiKey, string campaignId)
        {
            return await GetAsync<ExternalFetchCampaignsHistoryResponse>(
            relativeUrl: $"api/sms/campaigns/{campaignId}?api_key={apiKey}");


        }

        public async ValueTask<ExternalFetchCampaignsResponse> GetCampaignsAsync(string apiKey)
        {
            return await GetAsync<ExternalFetchCampaignsResponse>(
            relativeUrl: $"api/sms/campaigns?api_key={apiKey}");


        }





    }
}

