using System;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Switch;

namespace Termii.Core.Services.Foundations.Termii.Switch.SwitchService
{
    internal partial class SwitchService
    {
        private static void ValidateCreateCampaign(SendCampaign  sendCampaign)
        {
            ValidateCreateCampaignNotNull(sendCampaign);
            ValidateCreateCampaignRequest(sendCampaign.Request);
            Validate(
                (Rule: IsInvalid(sendCampaign.Request), Parameter: nameof(sendCampaign.Request)));

            Validate(
                (Rule: IsInvalid(sendCampaign.Request.CampaignType), Parameter: nameof(SendCampaignRequest.CampaignType)),
                (Rule: IsInvalid(sendCampaign.Request.ApiKey), Parameter: nameof(SendCampaignRequest.ApiKey)),
                (Rule: IsInvalid(sendCampaign.Request.Channel), Parameter: nameof(SendCampaignRequest.Channel)),
                (Rule: IsInvalid(sendCampaign.Request.ScheduleTime), Parameter: nameof(SendCampaignRequest.ScheduleTime)),
                (Rule: IsInvalid(sendCampaign.Request.Message), Parameter: nameof(SendCampaignRequest.Message)),
                (Rule: IsInvalid(sendCampaign.Request.RemoveDuplicate), Parameter: nameof(SendCampaignRequest.RemoveDuplicate)),
                (Rule: IsInvalid(sendCampaign.Request.ScheduleSmsStatus), Parameter: nameof(SendCampaignRequest.ScheduleSmsStatus)),
                (Rule: IsInvalid(sendCampaign.Request.PhonebookId), Parameter: nameof(SendCampaignRequest.PhonebookId)),
                (Rule: IsInvalid(sendCampaign.Request.Delimiter), Parameter: nameof(SendCampaignRequest.Delimiter)),
                (Rule: IsInvalid(sendCampaign.Request.SenderId), Parameter: nameof(SendCampaignRequest.SenderId))
                );

        }


        private static void ValidateContactToPhoneBook(AddContactToPhoneBook   addContactsToPhoneBook, string phoneBookId)
        {
            ValidateContactsToPhoneBookNotNull(addContactsToPhoneBook);
            ValidateContactsToPhoneBookRequest(addContactsToPhoneBook.Request);
            Validate(
                (Rule: IsInvalid(addContactsToPhoneBook.Request), Parameter: nameof(addContactsToPhoneBook.Request)));

            Validate(
                (Rule: IsInvalid(addContactsToPhoneBook.Request.CountryCode), Parameter: nameof(AddContactToPhoneBookRequest.CountryCode)),
                (Rule: IsInvalid(addContactsToPhoneBook.Request.ApiKey), Parameter: nameof(AddContactToPhoneBookRequest.ApiKey)),
                (Rule: IsInvalid(addContactsToPhoneBook.Request.PhoneNumber), Parameter: nameof(AddContactToPhoneBookRequest.PhoneNumber)),
                (Rule: IsInvalid(addContactsToPhoneBook.Request.FirstName), Parameter: nameof(AddContactToPhoneBookRequest.FirstName)),
                (Rule: IsInvalid(addContactsToPhoneBook.Request.LastName), Parameter: nameof(AddContactToPhoneBookRequest.LastName)),
                (Rule: IsInvalid(addContactsToPhoneBook.Request.Company), Parameter: nameof(AddContactToPhoneBookRequest.Company)),
                (Rule: IsInvalid(addContactsToPhoneBook.Request.EmailAddress), Parameter: nameof(AddContactToPhoneBookRequest.EmailAddress)),
                (Rule: IsInvalid(phoneBookId), Parameter: nameof(AddContactToPhoneBook))
                );

        }

        private static void ValidateContactsToPhoneBook(AddMultipleContactsToPhoneBook addMultipleContactsToPhoneBook, string phoneBook)
        {
            ValidateMultipleContactsToPhoneBookNotNull(addMultipleContactsToPhoneBook);
            ValidateMultipleContactsToPhoneBookRequest(addMultipleContactsToPhoneBook.Request);
            Validate(
                (Rule: IsInvalid(addMultipleContactsToPhoneBook.Request), Parameter: nameof(addMultipleContactsToPhoneBook.Request)));

            Validate(
                (Rule: IsInvalid(addMultipleContactsToPhoneBook.Request.CountryCode), Parameter: nameof(AddMultipleContactsToPhoneBookRequest.CountryCode)),
                (Rule: IsInvalid(addMultipleContactsToPhoneBook.Request.ApiKey), Parameter: nameof(AddMultipleContactsToPhoneBookRequest.ApiKey)),
                (Rule: IsInvalid(addMultipleContactsToPhoneBook.Request.ContactFile), Parameter: nameof(AddMultipleContactsToPhoneBookRequest.ContactFile)),
                 (Rule: IsInvalid(phoneBook), Parameter: nameof(AddMultipleContactsToPhoneBook))
                );

        }

        private static void ValidateCreateCampaignPhoneBook(CreateCampaignPhoneBook  createCampaignPhoneBook)
        {
            ValidateCreateCampaignPhoneBookNotNull(createCampaignPhoneBook);
            ValidateCreateCampaignPhoneBookRequest(createCampaignPhoneBook.Request);
            Validate(
                (Rule: IsInvalid(createCampaignPhoneBook.Request), Parameter: nameof(createCampaignPhoneBook.Request)));

            Validate(
                (Rule: IsInvalid(createCampaignPhoneBook.Request.ApiKey), Parameter: nameof(CreateCampaignPhoneBookRequest.ApiKey)),
                (Rule: IsInvalid(createCampaignPhoneBook.Request.PhonebookName), Parameter: nameof(CreateCampaignPhoneBookRequest.PhonebookName)),
                (Rule: IsInvalid(createCampaignPhoneBook.Request.Description), Parameter: nameof(CreateCampaignPhoneBookRequest.Description))

                );

        }

        private static void ValidateUpdateCampaignPhoneBook(UpdateCampaignPhoneBook updateCampaignPhoneBook, string phoneBookId)
        {
            ValidateUpdateCampaignPhoneBookNotNull(updateCampaignPhoneBook);
            ValidateUpdateCampaignPhoneBookRequest(updateCampaignPhoneBook.Request);
            Validate(
                (Rule: IsInvalid(updateCampaignPhoneBook.Request), Parameter: nameof(updateCampaignPhoneBook.Request)));

            Validate(
                (Rule: IsInvalid(updateCampaignPhoneBook.Request.ApiKey), Parameter: nameof(UpdateCampaignPhoneBookRequest.ApiKey)),
                (Rule: IsInvalid(updateCampaignPhoneBook.Request.PhonebookName), Parameter: nameof(UpdateCampaignPhoneBookRequest.PhonebookName)),
                (Rule: IsInvalid(updateCampaignPhoneBook.Request.Description), Parameter: nameof(UpdateCampaignPhoneBookRequest.Description)),
                (Rule: IsInvalid(phoneBookId), Parameter: nameof(UpdateCampaignPhoneBook))

                );

        }

        private static void ValidateTemplatedMessage(TemplatedMessage updateCampaignPhoneBook)
        {
            ValidateTemplatedMessageNotNull(updateCampaignPhoneBook);
            ValidateTemplatedMessageRequest(updateCampaignPhoneBook.Request);
            Validate(
                (Rule: IsInvalid(updateCampaignPhoneBook.Request), Parameter: nameof(updateCampaignPhoneBook.Request)));

            Validate(
                (Rule: IsInvalid(updateCampaignPhoneBook.Request.ApiKey), Parameter: nameof(TemplatedMessageRequest.ApiKey)),
                (Rule: IsInvalid(updateCampaignPhoneBook.Request.TemplateId), Parameter: nameof(TemplatedMessageRequest.TemplateId)),
                (Rule: IsInvalid(updateCampaignPhoneBook.Request.PhoneNumber), Parameter: nameof(TemplatedMessageRequest.PhoneNumber)),
                (Rule: IsInvalid(updateCampaignPhoneBook.Request.DeviceId), Parameter: nameof(TemplatedMessageRequest.DeviceId)),
                (Rule: IsInvalid(updateCampaignPhoneBook.Request.Data), Parameter: nameof(TemplatedMessageRequest.Data))


                );

        }

        private static void ValidateNumberMessage(NumberMessage numberMessage)
        {
            ValidateNumberMessageNotNull(numberMessage);
            ValidateNumberMessageRequest(numberMessage.Request);
            Validate(
                (Rule: IsInvalid(numberMessage.Request), Parameter: nameof(numberMessage.Request)));

            Validate(
                (Rule: IsInvalid(numberMessage.Request.ApiKey), Parameter: nameof(NumberMessageRequest.ApiKey)),
                (Rule: IsInvalid(numberMessage.Request.Sms), Parameter: nameof(NumberMessageRequest.Sms)),
                (Rule: IsInvalid(numberMessage.Request.To), Parameter: nameof(NumberMessageRequest.To))
 


                );

        }

        private static void ValidateSendBulkMessage(SendBulkMessage numberMessage)
        {
            ValidateSendBulkMessageNotNull(numberMessage);
            ValidateSendBulkMessageRequest(numberMessage.Request);
            Validate(
                (Rule: IsInvalid(numberMessage.Request), Parameter: nameof(numberMessage.Request)));

            Validate(
                (Rule: IsInvalid(numberMessage.Request.ApiKey), Parameter: nameof(SendBulkMessageRequest.ApiKey)),
                (Rule: IsInvalid(numberMessage.Request.Sms), Parameter: nameof(SendBulkMessageRequest.Sms)),
                (Rule: IsInvalid(numberMessage.Request.To), Parameter: nameof(SendBulkMessageRequest.To)),
                (Rule: IsInvalid(numberMessage.Request.From), Parameter: nameof(SendBulkMessageRequest.From)),
                (Rule: IsInvalid(numberMessage.Request.Type), Parameter: nameof(SendBulkMessageRequest.Type)),
                (Rule: IsInvalid(numberMessage.Request.Channel), Parameter: nameof(SendBulkMessageRequest.Channel))





                );

        }

        private static void ValidateSendMessage(SendMessage sendMessage)
        {
            ValidateSendMessageNotNull(sendMessage);
            ValidateSendMessageRequest(sendMessage.Request);
            Validate(
                (Rule: IsInvalid(sendMessage.Request), Parameter: nameof(sendMessage.Request)));

            Validate(
                (Rule: IsInvalid(sendMessage.Request.To), Parameter: nameof(SendMessageRequest.To)),
                (Rule: IsInvalid(sendMessage.Request.Sms), Parameter: nameof(SendMessageRequest.Sms)),
                (Rule: IsInvalid(sendMessage.Request.ApiKey), Parameter: nameof(SendMessageRequest.ApiKey)),
                (Rule: IsInvalid(sendMessage.Request.Channel), Parameter: nameof(SendMessageRequest.Channel)),
                (Rule: IsInvalid(sendMessage.Request.Type), Parameter: nameof(SendMessageRequest.Type)),
                (Rule: IsInvalid(sendMessage.Request.From), Parameter: nameof(SendMessageRequest.From))





                );

        }

        private static void ValidateSenderIdMessage(CreateSenderId  createSenderId)
        {
            ValidateCreateSenderIdRequestNotNull(createSenderId);
            ValidateCreateSenderIdRequestRequest(createSenderId.Request);
            Validate(
                (Rule: IsInvalid(createSenderId.Request), Parameter: nameof(createSenderId.Request)));

            Validate(
                (Rule: IsInvalid(createSenderId.Request.SenderId), Parameter: nameof(CreateSenderIdRequest.SenderId)),
                (Rule: IsInvalid(createSenderId.Request.Usecase), Parameter: nameof(CreateSenderIdRequest.Usecase)),
                (Rule: IsInvalid(createSenderId.Request.ApiKey), Parameter: nameof(CreateSenderIdRequest.ApiKey)),
                (Rule: IsInvalid(createSenderId.Request.Company), Parameter: nameof(CreateSenderIdRequest.Company))
           


                );

        }


        private static void ValidateCreateSenderIdRequestNotNull(CreateSenderId  createSenderId)
        {
            if (createSenderId is null)
            {
                throw new NullSwitchException();
            }
        }

        private static void ValidateCreateSenderIdRequestRequest(CreateSenderIdRequest  createSenderIdRequest)
        {
            Validate((Rule: IsInvalid(createSenderIdRequest), Parameter: nameof(CreateSenderIdRequest)));
        }

        private static void ValidateSendMessageNotNull(SendMessage sendMessage)
        {
            if (sendMessage is null)
            {
                throw new NullSwitchException();
            }
        }

        private static void ValidateSendMessageRequest(SendMessageRequest sendMessage)
        {
            Validate((Rule: IsInvalid(sendMessage), Parameter: nameof(SendMessageRequest)));
        }

        private static void ValidateSendBulkMessageNotNull(SendBulkMessage sendBulkMessage)
        {
            if (sendBulkMessage is null)
            {
                throw new NullSwitchException();
            }
        }

        private static void ValidateSendBulkMessageRequest(SendBulkMessageRequest sendBulkMessage)
        {
            Validate((Rule: IsInvalid(sendBulkMessage), Parameter: nameof(SendBulkMessageRequest)));
        }

        private static void ValidateNumberMessageNotNull(NumberMessage numberMessage)
        {
            if (numberMessage is null)
            {
                throw new NullSwitchException();
            }
        }

        private static void ValidateNumberMessageRequest(NumberMessageRequest numberMessage)
        {
            Validate((Rule: IsInvalid(numberMessage), Parameter: nameof(NumberMessageRequest)));
        }

        private static void ValidateTemplatedMessageNotNull(TemplatedMessage updateCampaignPhoneBook)
        {
            if (updateCampaignPhoneBook is null)
            {
                throw new NullSwitchException();
            }
        }

        private static void ValidateTemplatedMessageRequest(TemplatedMessageRequest updateCampaignPhoneBook)
        {
            Validate((Rule: IsInvalid(updateCampaignPhoneBook), Parameter: nameof(TemplatedMessageRequest)));
        }

        private static void ValidateUpdateCampaignPhoneBookNotNull(UpdateCampaignPhoneBook updateCampaignPhoneBook)
        {
            if (updateCampaignPhoneBook is null)
            {
                throw new NullSwitchException();
            }
        }

        private static void ValidateUpdateCampaignPhoneBookRequest(UpdateCampaignPhoneBookRequest updateCampaignPhoneBook)
        {
            Validate((Rule: IsInvalid(updateCampaignPhoneBook), Parameter: nameof(UpdateCampaignPhoneBookRequest)));
        }

        private static void ValidateCreateCampaignPhoneBookNotNull(CreateCampaignPhoneBook createCampaignPhoneBook)
        {
            if (createCampaignPhoneBook is null)
            {
                throw new NullSwitchException();
            }
        }

        private static void ValidateCreateCampaignPhoneBookRequest(CreateCampaignPhoneBookRequest createCampaignPhoneBook)
        {
            Validate((Rule: IsInvalid(createCampaignPhoneBook), Parameter: nameof(CreateCampaignPhoneBookRequest)));
        }

        private static void ValidateMultipleContactsToPhoneBookNotNull(AddMultipleContactsToPhoneBook addMultipleContactsToPhoneBook)
        {
            if (addMultipleContactsToPhoneBook is null)
            {
                throw new NullSwitchException();
            }
        }

        private static void ValidateMultipleContactsToPhoneBookRequest(AddMultipleContactsToPhoneBookRequest addMultipleContactsToPhoneBook)
        {
            Validate((Rule: IsInvalid(addMultipleContactsToPhoneBook), Parameter: nameof(AddMultipleContactsToPhoneBookRequest)));
        }

        private static void ValidateContactsToPhoneBookNotNull(AddContactToPhoneBook  addContactsToPhoneBook)
        {
            if (addContactsToPhoneBook is null)
            {
                throw new NullSwitchException();
            }
        }

        private static void ValidateContactsToPhoneBookRequest(AddContactToPhoneBookRequest  addContactsToPhoneBookRequest)
        {
            Validate((Rule: IsInvalid(addContactsToPhoneBookRequest), Parameter: nameof(AddContactToPhoneBookRequest)));
        }
        private static void ValidateCreateCampaignNotNull(SendCampaign  sendCampaign)
        {
            if (sendCampaign is null)
            {
                throw new NullSwitchException();
            }
        }

        private static void ValidateCreateCampaignRequest(SendCampaignRequest sendCampaignRequest)
        {
            Validate((Rule: IsInvalid(sendCampaignRequest), Parameter: nameof(SendCampaignRequest)));
        }





        private static void ValidateHistoryParameters(string text) =>
          Validate((Rule: IsInvalid(text), Parameter: nameof(FetchCampaignsHistory)));

        private static void ValidateFetchCampaignsParameters(string text) =>
         Validate((Rule: IsInvalid(text), Parameter: nameof(FetchCampaigns)));

        private static void ValidateFetchContactsByPhoneBookIdParameters(string text) =>
         Validate((Rule: IsInvalid(text), Parameter: nameof(FetchContactsByPhoneBookId)));

        private static void ValidateDeletePhoneBookContactParameters(string text) =>
          Validate((Rule: IsInvalid(text), Parameter: nameof(DeletePhoneBookContact)));

        private static void ValidateDeletePhoneBookParameters(string text) =>
        Validate((Rule: IsInvalid(text), Parameter: nameof(DeletePhoneBook)));

        private static void ValidateCampaignPhoneBooksParameters(string text) =>
          Validate((Rule: IsInvalid(text), Parameter: nameof(CampaignPhoneBook)));

        private static void ValidateFetchSenderIdsParameters(string text) =>
          Validate((Rule: IsInvalid(text), Parameter: nameof(FetchSenderIds)));

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };


        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };

        private static dynamic IsInvalid(double number) => new
        {
            Condition = number >= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidstatusException = new InvalidSwitchException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidstatusException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidstatusException.ThrowIfContainsErrors();
        }
    }
}