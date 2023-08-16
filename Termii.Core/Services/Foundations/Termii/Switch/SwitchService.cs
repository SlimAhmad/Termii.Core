using Termii.Core.Brokers.DateTimes;
using Termii.Core.Brokers.Termii;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;
using Termii.Core.Models.Services.Foundations.Termii.Switch;

namespace Termii.Core.Services.Foundations.Termii.Switch.SwitchService
{
    internal partial class SwitchService : ISwitchService
    {
        private readonly ITermiiBroker termiiBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public SwitchService(
            ITermiiBroker termiiBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.termiiBroker = termiiBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<DeletePhoneBookContact> DeletePhoneBookContactRequestAsync(string apiKey, string phoneBookId) =>
        TryCatch(async () =>
        {
            ValidateDeletePhoneBookContactParameters(apiKey);
            ValidateDeletePhoneBookContactParameters(phoneBookId);
            ExternalDeletePhoneBookContactResponse externalDeletePhoneBookContactResponse = await termiiBroker.DeletePhoneBookContactAsync(apiKey,phoneBookId);
            return ConvertToSwitchResponse(externalDeletePhoneBookContactResponse);
        });

        public ValueTask<DeletePhoneBook> DeletePhoneBookRequestAsync(string apiKey, string phoneBookId) =>
        TryCatch(async () =>
        {
            ValidateDeletePhoneBookParameters(apiKey);
            ValidateDeletePhoneBookParameters(phoneBookId);
            ExternalDeletePhoneBookResponse externalDeletePhoneBookResponse = await termiiBroker.DeletePhoneBookAsync(apiKey, phoneBookId);
            return ConvertToSwitchResponse(externalDeletePhoneBookResponse);
        });

        public ValueTask<FetchCampaignsHistory> GetCampaignsHistoryRequestAsync(string apiKey) =>
        TryCatch(async () =>
        {
            ValidateHistoryParameters(apiKey);
            ExternalFetchCampaignsHistoryResponse externalFetchCampaignsHistoryResponse = await termiiBroker.GetCampaignsHistoryAsync(apiKey);
            return ConvertToSwitchResponse(externalFetchCampaignsHistoryResponse);
        });

        public ValueTask<CampaignPhoneBook> GetCampaignsPhoneBooksRequestAsync(string apiKey) =>
        TryCatch(async () =>
        {
            ValidateCampaignPhoneBooksParameters(apiKey);
            ExternalCampaignPhoneBookResponse externalCampaignPhoneBookResponse = await termiiBroker.GetCampaignsPhoneBooksAsync(apiKey);
            return ConvertToSwitchResponse(externalCampaignPhoneBookResponse);
        });

        public ValueTask<FetchCampaigns> GetCampaignsRequestAsync(string apiKey) =>
        TryCatch(async () =>
        {
            ValidateFetchCampaignsParameters(apiKey);
            ExternalFetchCampaignsResponse externalFetchCampaignsResponse = await termiiBroker.GetCampaignsAsync(apiKey);
            return ConvertToSwitchResponse(externalFetchCampaignsResponse);
        });

        public ValueTask<FetchContactsByPhoneBookId> GetContactsByPhoneBookIdRequestAsync(string apiKey, string contactId) =>
        TryCatch(async () =>
        {
            ValidateFetchContactsByPhoneBookIdParameters(apiKey);
            ValidateFetchContactsByPhoneBookIdParameters(contactId);
            ExternalFetchContactsByPhoneBookResponse externalDeletePhoneBookResponse = await termiiBroker.GetContactsByPhoneBookIdAsync(apiKey, contactId);
            return ConvertToSwitchResponse(externalDeletePhoneBookResponse);
        });

        public ValueTask<FetchSenderIds> GetSenderIdsRequestAsync(string apiKey) =>
        TryCatch(async () =>
        {
            ValidateFetchSenderIdsParameters(apiKey);
            ExternalFetchSenderIdsResponse externalFetchSenderIdsResponse = await termiiBroker.GetSenderIdsAsync(apiKey);
            return ConvertToSwitchResponse(externalFetchSenderIdsResponse);
        });

        public ValueTask<SendBulkMessage> PostBulkMessagesRequestAsync(SendBulkMessage externalSendBulkMessage) =>
        TryCatch(async () =>
        {
            ValidateSendBulkMessage(externalSendBulkMessage);
            ExternalSendBulkMessageRequest externalSendBulkMessageRequest = 
            ConvertToSwitchRequest(externalSendBulkMessage);
            ExternalSendBulkMessageResponse externalSendBulkMessageResponse = 
            await termiiBroker.PostBulkMessagesAsync(externalSendBulkMessageRequest);
            return ConvertToSwitchResponse(externalSendBulkMessage, externalSendBulkMessageResponse);
        });

        public ValueTask<AddMultipleContactsToPhoneBook> PostContactsToPhoneBookRequestAsync(
            AddMultipleContactsToPhoneBook externalAddMultipleContactsToPhoneBook, string phoneBookId) =>
        TryCatch(async () =>
        {
            ValidateContactsToPhoneBook(externalAddMultipleContactsToPhoneBook, phoneBookId);
            ExternalAddMultipleContactsToPhoneBookRequest externalAddMultipleContactsToPhoneBookRequest = 
            ConvertToSwitchRequest(externalAddMultipleContactsToPhoneBook);
            ExternalAddMultipleContactsToPhoneBookResponse externalAddMultipleContactsToPhoneBookResponse = 
            await termiiBroker.PostContactsToPhoneBookAsync(externalAddMultipleContactsToPhoneBookRequest, phoneBookId);
            return ConvertToSwitchResponse(externalAddMultipleContactsToPhoneBook, externalAddMultipleContactsToPhoneBookResponse);
        });

        public ValueTask<AddContactToPhoneBook> PostContactToPhoneBookRequestAsync(
            AddContactToPhoneBook externalAddContactToPhoneBook, string phoneBookId) =>
        TryCatch(async () =>
        {
            ValidateContactToPhoneBook(externalAddContactToPhoneBook, phoneBookId);
            ExternalAddContactToPhoneBookRequest externalAddContactToPhoneBookRequest = ConvertToSwitchRequest(externalAddContactToPhoneBook);
            ExternalAddContactToPhoneBookResponse externalAddContactToPhoneBookResponse = await termiiBroker.PostContactToPhoneBookAsync(externalAddContactToPhoneBookRequest, phoneBookId);
            return ConvertToSwitchResponse(externalAddContactToPhoneBook, externalAddContactToPhoneBookResponse);
        });

        public ValueTask<SendCampaign> PostCreateCampaignRequestAsync(SendCampaign externalSendCampaign) =>
        TryCatch(async () =>
        {
            ValidateCreateCampaign(externalSendCampaign);
            ExternalSendCampaignRequest externalSendCampaignRequest = ConvertToSwitchRequest(externalSendCampaign);
            ExternalSendCampaignResponse externalSendCampaignResponse = await termiiBroker.PostCreateCampaignAsync(externalSendCampaignRequest);
            return ConvertToSwitchResponse(externalSendCampaign, externalSendCampaignResponse);
        });

        public ValueTask<CreateCampaignPhoneBook> PostCreatePhoneBookRequestAsync(
            CreateCampaignPhoneBook externalCreateCampaignPhoneBook) =>
        TryCatch(async () =>
        {
            ValidateCreateCampaignPhoneBook(externalCreateCampaignPhoneBook);
            ExternalCreateCampaignPhoneBookRequest externalCreateCampaignPhoneBookRequest = ConvertToSwitchRequest(externalCreateCampaignPhoneBook);
            ExternalCreateCampaignPhoneBookResponse externalCreateCampaignPhoneBookResponse = await termiiBroker.PostCreatePhoneBookAsync(externalCreateCampaignPhoneBookRequest);
            return ConvertToSwitchResponse(externalCreateCampaignPhoneBook, externalCreateCampaignPhoneBookResponse);
        });

        public ValueTask<SendMessage> PostMessageRequestAsync(SendMessage externalSendMessage) =>
        TryCatch(async () =>
        {
            ValidateSendMessage(externalSendMessage);
            ExternalSendMessageRequest externalSendMessageRequest = ConvertToSwitchRequest(externalSendMessage);
            ExternalSendMessageResponse externalSendMessageResponse = await termiiBroker.PostMessageAsync(externalSendMessageRequest);
            return ConvertToSwitchResponse(externalSendMessage, externalSendMessageResponse);
        });

        public ValueTask<NumberMessage> PostNumberMessageRequestAsync(NumberMessage externalNumberMessage) =>
        TryCatch(async () =>
        {
            ValidateNumberMessage(externalNumberMessage);
            ExternalNumberMessageRequest externalNumberMessageRequest = ConvertToSwitchRequest(externalNumberMessage);
            ExternalNumberMessageResponse externalNumberMessageResponse = await termiiBroker.PostNumberMessageAsync(externalNumberMessageRequest);
            return ConvertToSwitchResponse(externalNumberMessage, externalNumberMessageResponse);
        });

        public ValueTask<CreateSenderId> PostSenderIdRequestAsync(CreateSenderId externalCreateSenderId) =>
        TryCatch(async () =>
        {
            ValidateSenderIdMessage(externalCreateSenderId);
            ExternalCreateSenderIdRequest externalCreateSenderIdRequest = ConvertToSwitchRequest(externalCreateSenderId);
            ExternalCreateSenderIdResponse externalCreateSenderIdResponse = await termiiBroker.PostSenderIdAsync(externalCreateSenderIdRequest);
            return ConvertToSwitchResponse(externalCreateSenderId, externalCreateSenderIdResponse);
        });

        public ValueTask<TemplatedMessage> PostTemplatedMessageRequestAsync(TemplatedMessage externalTemplatedMessage) =>
        TryCatch(async () =>
        {
            ValidateTemplatedMessage(externalTemplatedMessage);
            ExternalTemplatedMessageRequest externalTemplatedMessageRequest = ConvertToSwitchRequest(externalTemplatedMessage);
            ExternalTemplatedMessageResponse externalTemplatedMessageResponse = await termiiBroker.PostTemplatedMessageAsync(externalTemplatedMessageRequest);
            return ConvertToSwitchResponse(externalTemplatedMessage, externalTemplatedMessageResponse);
        });

        public ValueTask<UpdateCampaignPhoneBook> UpdateCampaignPhoneBookRequestAsync(
            string phoneBookId, UpdateCampaignPhoneBook externalUpdateCampaignPhoneBook) =>
        TryCatch(async () =>
        {
            ValidateUpdateCampaignPhoneBook(externalUpdateCampaignPhoneBook, phoneBookId);
            ExternalUpdateCampaignPhoneBookRequest externalUpdateCampaignPhoneBookRequest = 
            ConvertToSwitchRequest(externalUpdateCampaignPhoneBook);
            ExternalUpdateCampaignPhoneBookResponse externalUpdateCampaignPhoneBookResponse =
            await termiiBroker.UpdateCampaignPhoneBookAsync(phoneBookId, externalUpdateCampaignPhoneBookRequest);
            return ConvertToSwitchResponse(externalUpdateCampaignPhoneBook, externalUpdateCampaignPhoneBookResponse);
        });


        private static ExternalSendBulkMessageRequest ConvertToSwitchRequest(SendBulkMessage sendBulkMessage)
        {
            return new ExternalSendBulkMessageRequest
            {
                ApiKey = sendBulkMessage.Request.ApiKey,
                Channel = sendBulkMessage.Request.Channel,
                From = sendBulkMessage.Request.From,
                Sms = sendBulkMessage.Request.Sms,
                To = sendBulkMessage.Request.To,
                Type = sendBulkMessage.Request.Type,
            };



        }
        private static ExternalAddMultipleContactsToPhoneBookRequest ConvertToSwitchRequest(AddMultipleContactsToPhoneBook  addMultipleContactsToPhoneBook)
        {
            return new ExternalAddMultipleContactsToPhoneBookRequest
            {
                CountryCode = addMultipleContactsToPhoneBook.Request.CountryCode,
                ApiKey = addMultipleContactsToPhoneBook.Request.ApiKey,
                ContactFile = addMultipleContactsToPhoneBook.Request.ContactFile,
                
            };



        }
        private static ExternalAddContactToPhoneBookRequest ConvertToSwitchRequest(AddContactToPhoneBook  addContactToPhoneBook)
        {
            return new ExternalAddContactToPhoneBookRequest
            {
                CountryCode = addContactToPhoneBook.Request.CountryCode,
                ApiKey = addContactToPhoneBook.Request.ApiKey,
                Company = addContactToPhoneBook.Request.Company,
                EmailAddress =  addContactToPhoneBook.Request.EmailAddress,
                FirstName = addContactToPhoneBook.Request.FirstName,
                LastName = addContactToPhoneBook.Request.LastName,
                PhoneNumber = addContactToPhoneBook.Request.PhoneNumber,
            };



        }
        private static ExternalSendCampaignRequest ConvertToSwitchRequest(SendCampaign  sendCampaign)
        {
            return new ExternalSendCampaignRequest
            {
               SenderId = sendCampaign.Request.SenderId,
               ApiKey = sendCampaign.Request.ApiKey,
               CampaignType = sendCampaign.Request.CampaignType,
               Channel = sendCampaign.Request.Channel,
               CountryCode = sendCampaign.Request.CountryCode,
               Delimiter = sendCampaign.Request.Delimiter,
               Message = sendCampaign.Request.Message,
               MessageType = sendCampaign.Request.MessageType,
               PhonebookId = sendCampaign.Request.PhonebookId,
               RemoveDuplicate = sendCampaign.Request.RemoveDuplicate,
               ScheduleSmsStatus = sendCampaign.Request.ScheduleSmsStatus,
               ScheduleTime =   sendCampaign.Request.ScheduleTime,
            };



        }
        private static ExternalCreateSenderIdRequest ConvertToSwitchRequest(CreateSenderId  createSenderId)
        {
            return new ExternalCreateSenderIdRequest
            {
               ApiKey = createSenderId.Request.ApiKey,
               Company = createSenderId.Request.Company,
               SenderId = createSenderId.Request.SenderId,
               Usecase = createSenderId.Request.Usecase,
            };



        }
        private static ExternalNumberMessageRequest ConvertToSwitchRequest(NumberMessage  numberMessage)
        {
            return new ExternalNumberMessageRequest
            {
              ApiKey = numberMessage.Request.ApiKey,
              Sms = numberMessage.Request.Sms,
              To = numberMessage.Request.To,
            };



        }
        private static ExternalSendMessageRequest ConvertToSwitchRequest(SendMessage sendMessage)
        {
            return new ExternalSendMessageRequest
            {
               To = sendMessage.Request.To,
               Sms = sendMessage.Request.Sms,
               ApiKey = sendMessage.Request.ApiKey,
               Channel = sendMessage.Request.Channel,
               From =   sendMessage.Request.From,
               Media = new ExternalSendMessageRequest.ExternalMedia
               {
                  Caption = sendMessage.Request.Media.Caption,
                  Url = sendMessage.Request.Media.Url,
               },
               Type = sendMessage.Request.Type,
            };



        }
        private static ExternalCreateCampaignPhoneBookRequest ConvertToSwitchRequest(CreateCampaignPhoneBook createCampaignPhoneBook)
        {
            return new ExternalCreateCampaignPhoneBookRequest
            {
                ApiKey = createCampaignPhoneBook.Request.ApiKey,
                PhonebookName = createCampaignPhoneBook.Request.PhonebookName,
                Description = createCampaignPhoneBook.Request.Description
            };



        }
        private static ExternalTemplatedMessageRequest ConvertToSwitchRequest(TemplatedMessage templatedMessage)
        {
            return new ExternalTemplatedMessageRequest
            {
                ApiKey = templatedMessage.Request.ApiKey,
                DeviceId = templatedMessage.Request.DeviceId,
                PhoneNumber = templatedMessage.Request.PhoneNumber,
                Data = new ExternalTemplatedMessageRequest.ExternalData
                {
                    ExpiryTime = templatedMessage.Request.Data.ExpiryTime,
                    Otp = templatedMessage.Request.Data.Otp,
                    ProductName = templatedMessage.Request.Data.ProductName,

                },
                TemplateId = templatedMessage.Request.TemplateId,
            };



        }
        private static ExternalUpdateCampaignPhoneBookRequest ConvertToSwitchRequest(UpdateCampaignPhoneBook updateCampaignPhoneBook)
        {
            return new ExternalUpdateCampaignPhoneBookRequest
            {
                ApiKey = updateCampaignPhoneBook.Request.ApiKey,
                Description = updateCampaignPhoneBook.Request.Description,
                PhonebookName = updateCampaignPhoneBook.Request.PhonebookName
            };



        }


        private static CampaignPhoneBook ConvertToSwitchResponse(ExternalCampaignPhoneBookResponse  externalCampaignPhoneBookResponse)
        {

            return new CampaignPhoneBook
            {
                Response = new  CampaignPhoneBookResponse
                {
                     Links = new CampaignPhoneBookResponse.PhoneBookLinks
                     {
                         First = externalCampaignPhoneBookResponse.Links.First,
                         Last = externalCampaignPhoneBookResponse.Links.Last,
                         Next = externalCampaignPhoneBookResponse.Links.Next,
                         Prev = externalCampaignPhoneBookResponse.Links.Prev,
                         
                     },
                     Data = externalCampaignPhoneBookResponse.Data.Select(data =>
                     {
                         return new CampaignPhoneBookResponse.Datum
                         {
                             DateCreated = data.DateCreated,
                             Id = data.Id,
                             LastUpdated = data.LastUpdated,
                             Name = data.Name,
                             TotalNumberOfContacts = data.TotalNumberOfContacts,

                         };

                     }).ToList(),
                     Meta = new CampaignPhoneBookResponse.PhoneBookMeta
                     {
                         CurrentPage = externalCampaignPhoneBookResponse.Meta.CurrentPage,
                         From = externalCampaignPhoneBookResponse.Meta.From,
                         LastPage = externalCampaignPhoneBookResponse.Meta.LastPage,
                         Path = externalCampaignPhoneBookResponse.Meta.Path,
                         PerPage = externalCampaignPhoneBookResponse.Meta.PerPage,
                         To = externalCampaignPhoneBookResponse.Meta.To,
                         Total = externalCampaignPhoneBookResponse.Meta.Total,
                         
                     }
                }
            };



        }

        private static DeletePhoneBook ConvertToSwitchResponse(ExternalDeletePhoneBookResponse externalDeletePhoneBookResponse)
        {

            return new DeletePhoneBook
            {
                Response = new DeletePhoneBookResponse
                {
                    Message = externalDeletePhoneBookResponse.Message,
                }
            };



        }

        private static DeletePhoneBookContact ConvertToSwitchResponse(
            ExternalDeletePhoneBookContactResponse externalDeletePhoneBookContactResponse)
        {

            return new DeletePhoneBookContact 
            { 
                Response = new DeletePhoneBookContactResponse
                {
                    Message = externalDeletePhoneBookContactResponse.Message,
                } 
            };

        



        }

        private static FetchCampaignsHistory ConvertToSwitchResponse(ExternalFetchCampaignsHistoryResponse  externalFetchCampaignsHistoryResponse)
        {

            return new FetchCampaignsHistory
            {
                Response = new FetchCampaignsHistoryResponse
                {
                    Meta = new FetchCampaignsHistoryResponse.HistoryMeta
                    {
                       CurrentPage = externalFetchCampaignsHistoryResponse.Meta.CurrentPage,
                       From = externalFetchCampaignsHistoryResponse.Meta.From,
                       LastPage = externalFetchCampaignsHistoryResponse.Meta.LastPage,
                       Path = externalFetchCampaignsHistoryResponse.Meta.Path,
                       PerPage = externalFetchCampaignsHistoryResponse.Meta.PerPage,
                       To = externalFetchCampaignsHistoryResponse.Meta.To,
                       Total = externalFetchCampaignsHistoryResponse.Meta.Total
                    } ,
                    Links = new FetchCampaignsHistoryResponse.HistoryLinks
                    {
                       First = externalFetchCampaignsHistoryResponse.Links.First,
                       Last = externalFetchCampaignsHistoryResponse.Links.Last,
                       Next = externalFetchCampaignsHistoryResponse.Links.Next,
                       Prev = externalFetchCampaignsHistoryResponse.Links.Prev,
                      
                    },
                    Data = externalFetchCampaignsHistoryResponse.Data.Select(data =>
                    {
                        return new FetchCampaignsHistoryResponse.Datum
                        {
                            Amount = data.Amount,
                            Channel = data.Channel,
                            DateCreated = data.DateCreated,
                            Id = data.Id,
                            LastUpdated = data.LastUpdated,
                            Message = data.Message,
                            MessageAbbreviation = data.MessageAbbreviation,
                            MessageId = data.MessageId,
                            Receiver = data.Receiver,
                            Sender = data.Sender,
                            SmsType = data.SmsType,
                            Status = data.Status,
                        };
                    }).ToList()
                }
            };



        }

        private static FetchCampaigns ConvertToSwitchResponse(ExternalFetchCampaignsResponse externalFetchCampaignsResponse)
        {

            return new FetchCampaigns
            {
               Response = new FetchCampaignsResponse
               {
                   Data = externalFetchCampaignsResponse.Data.Select(data =>
                   {
                       return new FetchCampaignsResponse.Datum
                       {
                           Status = data.Status,
                           CampaignId = data.CampaignId,
                           CampType = data.CampType,
                           Channel = data.Channel,
                           CreatedAt = data.CreatedAt,
                           PhoneBook = data.PhoneBook,
                           RunAt = data.RunAt,
                           Sender = data.Sender,
                           TotalRecipients = data.TotalRecipients,

                       };
                   }).ToList(),
                   Links = new FetchCampaignsResponse.CampaignsLinks
                   {
                      Prev = externalFetchCampaignsResponse.Links.Prev,
                      First = externalFetchCampaignsResponse.Links.First,
                      Last = externalFetchCampaignsResponse.Links.Last,
                      Next = externalFetchCampaignsResponse.Links.Next,
                      
                   },
                   Meta = new FetchCampaignsResponse.CampaignsMeta
                   {
                      CurrentPage = externalFetchCampaignsResponse.CampaignsMeta.CurrentPage,
                      From = externalFetchCampaignsResponse.CampaignsMeta.From,
                      LastPage = externalFetchCampaignsResponse.CampaignsMeta.LastPage,
                      Path = externalFetchCampaignsResponse.CampaignsMeta.Path,
                      PerPage = externalFetchCampaignsResponse.CampaignsMeta.PerPage,
                      To = externalFetchCampaignsResponse.CampaignsMeta.To,
                      Total = externalFetchCampaignsResponse.CampaignsMeta.Total
                   }
               }
            };



        }

        private static FetchContactsByPhoneBookId ConvertToSwitchResponse(ExternalFetchContactsByPhoneBookResponse externalFetchContactsByPhoneBookResponse)
        {

            return new FetchContactsByPhoneBookId
            {
                
               Response = new FetchContactsByPhoneBookIdResponse
               {
                   Links = new FetchContactsByPhoneBookIdResponse.ContactsLinks
                   {
                       First = externalFetchContactsByPhoneBookResponse.Links.First,
                       Last = externalFetchContactsByPhoneBookResponse.Links.Last,
                       Next = externalFetchContactsByPhoneBookResponse.Links.Next,
                       Prev = externalFetchContactsByPhoneBookResponse.Links.Prev
                   },
                   Meta = new FetchContactsByPhoneBookIdResponse.ContactsMeta
                   {
                       CurrentPage = externalFetchContactsByPhoneBookResponse.Meta.CurrentPage,
                       From = externalFetchContactsByPhoneBookResponse.Meta.From,
                       LastPage = externalFetchContactsByPhoneBookResponse.Meta.LastPage,
                       Path = externalFetchContactsByPhoneBookResponse.Meta.Path,
                       PerPage = externalFetchContactsByPhoneBookResponse.Meta.PerPage,
                       To = externalFetchContactsByPhoneBookResponse.Meta.To,
                       Total = externalFetchContactsByPhoneBookResponse.Meta.Total
                   },
                   Data = externalFetchContactsByPhoneBookResponse.Data.Select(data =>
                   {

                       return new FetchContactsByPhoneBookIdResponse.Datum
                       {
                           Company = data.Company,
                           CreateAt = data.CreateAt,
                           EmailAddress = data.EmailAddress,
                           FirstName = data.FirstName,
                           Id = data.Id,
                           LastName = data.LastName,
                           Message = data.Message,
                           PhoneNumber = data.PhoneNumber,
                           Pid = data.Pid,
                           UpdatedAt = data.UpdatedAt,

                       };

                   }).ToList(),
               }

            };

        }

        private static FetchSenderIds ConvertToSwitchResponse(ExternalFetchSenderIdsResponse externalFetchSenderIdsResponse)
        {

            return new FetchSenderIds
            {
                Response = new FetchSenderIdsResponse
                {
                    CurrentPage = externalFetchSenderIdsResponse.CurrentPage,
                    FirstPageUrl = externalFetchSenderIdsResponse.FirstPageUrl,
                    From = externalFetchSenderIdsResponse.From,
                    LastPage = externalFetchSenderIdsResponse.LastPage,
                    LastPageUrl = externalFetchSenderIdsResponse.LastPageUrl,
                    NextPageUrl = externalFetchSenderIdsResponse.NextPageUrl,
                    Path = externalFetchSenderIdsResponse.Path,
                    PerPage = externalFetchSenderIdsResponse.PerPage,
                    PrevPageUrl = externalFetchSenderIdsResponse.PrevPageUrl,
                    To = externalFetchSenderIdsResponse.To,
                    Total = externalFetchSenderIdsResponse.Total,
                    Data = externalFetchSenderIdsResponse.Data.Select(data =>
                    {

                        return new FetchSenderIdsResponse.Datum
                        {
                            Company = data.Company,
                            Country = data.Country,
                            CreatedAt = data.CreatedAt,
                            SenderId = data.SenderId,
                            Status = data.Status,
                            Usecase = data.Usecase,


                        };

                    }).ToList(),
                }
            };

        }

        private static SendMessage ConvertToSwitchResponse(SendMessage sendMessage,ExternalSendMessageResponse externalSendMessageResponse)
        {
            sendMessage.Response = new SendMessageResponse
            {
                   Balance = externalSendMessageResponse.Balance,
                   Message = externalSendMessageResponse.Message,
                   MessageId = externalSendMessageResponse.MessageId,
                   User = externalSendMessageResponse.User
            };

            return sendMessage;

           

        }

        private static SendBulkMessage ConvertToSwitchResponse(SendBulkMessage sendBulkMessage, ExternalSendBulkMessageResponse externalSendBulkMessageResponse)
        {
            sendBulkMessage.Response = new SendBulkMessageResponse
            {
                Balance = externalSendBulkMessageResponse.Balance,
                Message = externalSendBulkMessageResponse.Message,
                MessageId = externalSendBulkMessageResponse.MessageId,
                User = externalSendBulkMessageResponse.User
            };

            return sendBulkMessage;



        }

        private static AddMultipleContactsToPhoneBook ConvertToSwitchResponse(AddMultipleContactsToPhoneBook sendMessage, ExternalAddMultipleContactsToPhoneBookResponse externalAddMultipleContactsToPhoneBookResponse)
        {
            sendMessage.Response = new AddMultipleContactsToPhoneBookResponse
            {
             
                Message = externalAddMultipleContactsToPhoneBookResponse.Message,
              
            };

            return sendMessage;



        }

        private static AddContactToPhoneBook ConvertToSwitchResponse(AddContactToPhoneBook sendMessage, ExternalAddContactToPhoneBookResponse externalAddContactToPhoneBookResponse)
        {
            sendMessage.Response = new AddContactToPhoneBookResponse
            {

                 Data = new AddContactToPhoneBookResponse.ExternalContactData
                 {
                     Message = externalAddContactToPhoneBookResponse.Data.Message,
                     Company = externalAddContactToPhoneBookResponse.Data.Company,
                     CreateAt = externalAddContactToPhoneBookResponse.Data.CreateAt,
                     EmailAddress = externalAddContactToPhoneBookResponse.Data.EmailAddress,
                     FirstName = externalAddContactToPhoneBookResponse.Data.FirstName,
                     Id = externalAddContactToPhoneBookResponse.Data.Id,
                     LastName = externalAddContactToPhoneBookResponse.Data.LastName,
                     PhoneNumber = externalAddContactToPhoneBookResponse.Data.PhoneNumber,
                     UpdatedAt = externalAddContactToPhoneBookResponse.Data.UpdatedAt
                 }

            };

            return sendMessage;



        }

        private static SendCampaign ConvertToSwitchResponse(SendCampaign sendMessage, ExternalSendCampaignResponse externalSendCampaignResponse)
        {
            sendMessage.Response = new SendCampaignResponse
            {
                
                Message = externalSendCampaignResponse.Message,

            };

            return sendMessage;



        }

        private static CreateCampaignPhoneBook ConvertToSwitchResponse(CreateCampaignPhoneBook sendMessage, ExternalCreateCampaignPhoneBookResponse externalCreateCampaignPhoneBookResponse)
        {
            sendMessage.Response = new CreateCampaignPhoneBookResponse
            {

                Message = externalCreateCampaignPhoneBookResponse.Message,

            };

            return sendMessage;



        }

        private static NumberMessage ConvertToSwitchResponse(NumberMessage sendMessage, ExternalNumberMessageResponse externalNumberMessageResponse)
        {
            sendMessage.Response = new NumberMessageResponse
            {

                 Balance = externalNumberMessageResponse.Balance,
                 Code = externalNumberMessageResponse.Code,
                 Message = externalNumberMessageResponse.Message,
                 MessageId = externalNumberMessageResponse.MessageId,
                 User = externalNumberMessageResponse.User

            };

            return sendMessage;



        }

        private static CreateSenderId ConvertToSwitchResponse(CreateSenderId createSenderId, ExternalCreateSenderIdResponse externalCreateSenderIdResponse)
        {
            createSenderId.Response = new CreateSenderIdResponse
            {

                Message = externalCreateSenderIdResponse.Message,
                Code = externalCreateSenderIdResponse.Code,

            };

            return createSenderId;



        }

        private static TemplatedMessage ConvertToSwitchResponse(TemplatedMessage templatedMessage, ExternalTemplatedMessageResponse externalTemplatedMessageResponse)
        {
            templatedMessage.Response = new TemplatedMessageResponse
            {

                Balance = externalTemplatedMessageResponse.Balance,
                Code = externalTemplatedMessageResponse.Code,
                Message = externalTemplatedMessageResponse.Message,
                MessageId = externalTemplatedMessageResponse.MessageId,
                User = externalTemplatedMessageResponse.User,
               

            };

            return templatedMessage;



        }

        private static UpdateCampaignPhoneBook ConvertToSwitchResponse(UpdateCampaignPhoneBook sendMessage, ExternalUpdateCampaignPhoneBookResponse externalUpdateCampaignPhoneBookResponse)
        {
            sendMessage.Response = new UpdateCampaignPhoneBookResponse
            {

                 Message = externalUpdateCampaignPhoneBookResponse.Message

            };

            return sendMessage;



        }





    }
}
