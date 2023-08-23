using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Switch;

namespace Termii.Core.Clients.Switch
{
    public interface ISwitchClient
    {

        ValueTask<FetchSenderIds> RetrieveSenderIdsAsync(string apiKey);

        ValueTask<CreateSenderId> CreateSenderIdAsync(CreateSenderId externalCreateSenderId);

        ValueTask<SendMessage> SendMessageAsync(SendMessage externalSendMessage);

        ValueTask<SendBulkMessage> SendBulkMessagesAsync(SendBulkMessage externalSendBulkMessage);
        ValueTask<NumberMessage> SendNumberMessageAsync(NumberMessage externalNumberMessage);

        ValueTask<TemplatedMessage> SendTemplatedMessageAsync(TemplatedMessage externalTemplatedMessage);

        ValueTask<CampaignPhoneBook> RetrievePhoneBooksAsync(string apiKey);

        ValueTask<UpdateCampaignPhoneBook> UpdatePhoneBookAsync(string apiKey, UpdateCampaignPhoneBook externalUpdateCampaignPhoneBook);

        ValueTask<DeletePhoneBook> RemovePhoneBookAsync(string apiKey, string phoneBookId);

        ValueTask<CreateCampaignPhoneBook> CreatePhoneBookAsync(CreateCampaignPhoneBook externalCreateCampaignPhoneBook);

        ValueTask<DeletePhoneBookContact> RemovePhoneBookContactAsync(string apiKey, string phoneBookId);

        ValueTask<FetchContactsByPhoneBookId> RetrieveContactsByPhoneBookIdAsync(string apiKey, string contactId);

        ValueTask<AddContactToPhoneBook> SendContactToPhoneBookAsync(AddContactToPhoneBook externalAddContactToPhoneBook, string phoneBookId);

        ValueTask<AddMultipleContactsToPhoneBook> SendContactsToPhoneBookAsync(AddMultipleContactsToPhoneBook externalAddMultipleContactsToPhoneBook, string phoneBookId);

        ValueTask<SendCampaign> CreateCampaignAsync(
            SendCampaign externalSendCampaign);
        ValueTask<FetchCampaignsHistory> RetrieveCampaignsHistoryAsync(string apiKey, string campaignId);

        ValueTask<FetchCampaigns> RetrieveCampaignsAsync(string apiKey);
    }
}
