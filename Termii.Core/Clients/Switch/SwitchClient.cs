using FlutterWave.Core.Models.Clients.Switch.Exceptions;
using System.Text.Json;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Switch;
using Termii.Core.Services.Foundations.Termii.Switch.SwitchService;
using Xeptions;

namespace Termii.Core.Clients.Switch
{
    internal class SwitchClient : ISwitchClient
    {
        private readonly ISwitchService switchService;

        public SwitchClient(ISwitchService switchService) =>
            switchService = switchService;

        public async ValueTask<DeletePhoneBook> RemovePhoneBookAsync(string apiKey, string phoneBookId)
        {
            try
            {
                return await switchService.DeletePhoneBookRequestAsync(apiKey,phoneBookId);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<DeletePhoneBookContact> RemovePhoneBookContactAsync(string apiKey, string phoneBookId)
        {
            try
            {
                return await switchService.DeletePhoneBookContactRequestAsync(apiKey,phoneBookId);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchCampaigns> RetrieveCampaignsAsync(string apiKey)
        {
            try
            {
                return await switchService.GetCampaignsRequestAsync(apiKey);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchCampaignsHistory> RetrieveCampaignsHistoryAsync(string apiKey)
        {
            try
            {
                return await switchService.GetCampaignsHistoryRequestAsync(apiKey);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CampaignPhoneBook> RetrieveCampaignsPhoneBooksAsync(string apiKey)
        {
            try
            {
                return await switchService.GetCampaignsPhoneBooksRequestAsync(apiKey);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchContactsByPhoneBookId> RetrieveContactsByPhoneBookIdAsync(string apiKey, string contactId)
        {
            try
            {
                return await switchService.GetContactsByPhoneBookIdRequestAsync(apiKey,contactId);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchSenderIds> RetrieveSenderIdsAsync(string apiKey)
        {
            try
            {
                return await switchService.GetSenderIdsRequestAsync(apiKey);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<SendBulkMessage> SendBulkMessagesAsync(SendBulkMessage externalSendBulkMessage)
        {
            try
            {
                return await switchService.PostBulkMessagesRequestAsync(externalSendBulkMessage);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<AddMultipleContactsToPhoneBook> SendContactsToPhoneBookAsync(AddMultipleContactsToPhoneBook externalAddMultipleContactsToPhoneBook, string phoneBookId)
        {
            try
            {
                return await switchService.PostContactsToPhoneBookRequestAsync(externalAddMultipleContactsToPhoneBook,phoneBookId);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<AddContactToPhoneBook> SendContactToPhoneBookAsync(AddContactToPhoneBook externalAddContactToPhoneBook, string phoneBookId)
        {
            try
            {
                return await switchService.PostContactToPhoneBookRequestAsync(externalAddContactToPhoneBook, phoneBookId);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<SendCampaign> SendCreateCampaignAsync(SendCampaign externalSendCampaign)
        {
            try
            {
                return await switchService.PostCreateCampaignRequestAsync(externalSendCampaign);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CreateCampaignPhoneBook> SendCreatePhoneBookAsync(CreateCampaignPhoneBook externalCreateCampaignPhoneBook)
        {
            try
            {
                return await switchService.PostCreatePhoneBookRequestAsync(externalCreateCampaignPhoneBook);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<SendMessage> SendMessageAsync(SendMessage externalSendMessage)
        {
            try
            {
                return await switchService.PostMessageRequestAsync(externalSendMessage);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<NumberMessage> SendNumberMessageAsync(NumberMessage externalNumberMessage)
        {
            try
            {
                return await switchService.PostNumberMessageRequestAsync(externalNumberMessage);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CreateSenderId> SendSenderIdAsync(CreateSenderId externalCreateSenderId)
        {
            try
            {
                return await switchService.PostSenderIdRequestAsync(externalCreateSenderId);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<TemplatedMessage> SendTemplatedMessageAsync(TemplatedMessage externalTemplatedMessage)
        {
            try
            {
                return await switchService.PostTemplatedMessageRequestAsync(externalTemplatedMessage);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UpdateCampaignPhoneBook> UpdateCampaignPhoneBookAsync(string apiKey, UpdateCampaignPhoneBook externalUpdateCampaignPhoneBook)
        {
            try
            {
                return await switchService.UpdateCampaignPhoneBookRequestAsync(apiKey,externalUpdateCampaignPhoneBook);
            }
            catch (SwitchValidationException switchValidationException)
            {

                throw new SwitchClientValidationException(
                    switchValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyValidationException switchDependencyValidationException)
            {

                throw new SwitchClientValidationException(
                    switchDependencyValidationException.InnerException as Xeption);
            }
            catch (SwitchDependencyException switchDependencyException)
            {
                throw new SwitchClientDependencyException(
                    switchDependencyException.InnerException as Xeption);
            }
            catch (SwitchServiceException switchServiceException)
            {
                throw new SwitchClientServiceException(
                    switchServiceException.InnerException as Xeption);
            }
        }
    }
}
