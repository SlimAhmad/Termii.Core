using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;

namespace Termii.Core.Brokers.Termii
{
    internal partial interface ITermiiBroker
    {
        ValueTask<ExternalFetchSenderIdsResponse> GetSenderIdsAsync(string apiKey);

        ValueTask<ExternalCreateSenderIdResponse> PostSenderIdAsync(ExternalCreateSenderIdRequest  externalCreateSenderIdRequest);

        ValueTask<ExternalSendMessageResponse> PostMessageAsync(ExternalSendMessageRequest  externalSendMessageRequest);

        ValueTask<ExternalSendBulkMessageResponse> PostBulkMessagesAsync(ExternalSendBulkMessageRequest  externalSendBulkMessageRequest);
        ValueTask<ExternalNumberMessageResponse> PostNumberMessageAsync(ExternalNumberMessageRequest  externalNumberMessageRequest);

        ValueTask<ExternalTemplatedMessageResponse> PostTemplatedMessageAsync(ExternalTemplatedMessageRequest  externalTemplatedMessageRequest);

        ValueTask<ExternalCreateCampaignPhoneBookResponse> PostCreatePhoneBookAsync(ExternalCreateCampaignPhoneBookRequest externalCreateCampaignPhoneBookRequest);

        ValueTask<ExternalCampaignPhoneBookResponse> GetCampaignsPhoneBooksAsync(string apiKey);

      
        ValueTask<ExternalDeletePhoneBookResponse> DeletePhoneBookAsync(string apiKey, string phoneBookId);

     
        ValueTask<ExternalDeletePhoneBookContactResponse> DeletePhoneBookContactAsync(string apiKey, string phoneBookId);

        ValueTask<ExternalFetchContactsByPhoneBookResponse> GetContactsByPhoneBookIdAsync(string apiKey, string contactId);

        ValueTask<ExternalUpdateCampaignPhoneBookResponse> UpdateCampaignPhoneBookAsync(
            string apiKey, ExternalUpdateCampaignPhoneBookRequest externalUpdateCampaignPhoneBookRequest);


        ValueTask<ExternalAddContactToPhoneBookResponse> PostContactToPhoneBookAsync(
            ExternalAddContactToPhoneBookRequest  externalAddContactToPhoneBookRequest, string phoneBookId);

        ValueTask<ExternalAddMultipleContactsToPhoneBookResponse> PostContactsToPhoneBookAsync(
            ExternalAddMultipleContactsToPhoneBookRequest  externalAddMultipleContactsToPhoneBookRequest, string phoneBookId);


        ValueTask<ExternalSendCampaignResponse> PostCreateCampaignAsync(
            ExternalSendCampaignRequest externalSendCampaignRequest);
        ValueTask<ExternalFetchCampaignsHistoryResponse> GetCampaignsHistoryAsync(string apiKey, string campaignId);

        ValueTask<ExternalFetchCampaignsResponse> GetCampaignsAsync(string apiKey);

    }
}
