using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Switch;

namespace Termii.Core.Services.Foundations.Termii.Switch.SwitchService
{
    internal interface ISwitchService
    {
        ValueTask<FetchSenderIds> GetSenderIdsRequestAsync(string apiKey);

        ValueTask<CreateSenderId> PostSenderIdRequestAsync(CreateSenderId externalCreateSenderId);

        ValueTask<SendMessage> PostMessageRequestAsync(SendMessage externalSendMessage);

        ValueTask<SendBulkMessage> PostBulkMessagesRequestAsync(SendBulkMessage externalSendBulkMessage);
        ValueTask<NumberMessage> PostNumberMessageRequestAsync(NumberMessage externalNumberMessage);

        ValueTask<TemplatedMessage> PostTemplatedMessageRequestAsync(TemplatedMessage externalTemplatedMessage);

        ValueTask<CampaignPhoneBook> GetCampaignsPhoneBooksRequestAsync(string apiKey);

        ValueTask<UpdateCampaignPhoneBook> UpdateCampaignPhoneBookRequestAsync(string apiKey, UpdateCampaignPhoneBook externalUpdateCampaignPhoneBook);

        ValueTask<DeletePhoneBook> DeletePhoneBookRequestAsync(string apiKey, string phoneBookId);

        ValueTask<CreateCampaignPhoneBook> PostCreatePhoneBookRequestAsync(CreateCampaignPhoneBook externalCreateCampaignPhoneBook);

        ValueTask<DeletePhoneBookContact> DeletePhoneBookContactRequestAsync(string apiKey, string phoneBookId);

        ValueTask<FetchContactsByPhoneBookId> GetContactsByPhoneBookIdRequestAsync(string apiKey, string contactId);

        ValueTask<AddContactToPhoneBook> PostContactToPhoneBookRequestAsync(AddContactToPhoneBook externalAddContactToPhoneBook, string phoneBookId);

        ValueTask<AddMultipleContactsToPhoneBook> PostContactsToPhoneBookRequestAsync(AddMultipleContactsToPhoneBook externalAddMultipleContactsToPhoneBook, string phoneBookId);

        ValueTask<SendCampaign> PostCreateCampaignRequestAsync(
            SendCampaign externalSendCampaign);
        ValueTask<FetchCampaignsHistory> GetCampaignsHistoryRequestAsync(string apiKey);

        ValueTask<FetchCampaigns> GetCampaignsRequestAsync(string apiKey);

    }
}
