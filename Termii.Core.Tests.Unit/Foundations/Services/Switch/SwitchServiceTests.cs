using KellermanSoftware.CompareNetObjects;
using Moq;
using RESTFulSense.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Termii.Core.Brokers.DateTimes;
using Termii.Core.Brokers.Termii;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens;
using Termii.Core.Services.Foundations.Termii.Switch.SwitchService;
using Tynamix.ObjectFiller;

namespace Termii.Core.Tests.Unit.Foundations.Services.Switch
{
    public partial class SwitchServiceTests
    {

        private readonly Mock<ITermiiBroker> termiiBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ISwitchService switchService;

        public SwitchServiceTests()
        {
            termiiBrokerMock = new Mock<ITermiiBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            switchService = new SwitchService(
                termiiBroker: termiiBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalSendMessageRequest, bool>> SameExternalSendMessageRequestAs(
         ExternalSendMessageRequest expectedExternalSendMessageRequest)
        {
            return actualExternalSendMessageRequest =>
                this.compareLogic.Compare(
                    expectedExternalSendMessageRequest,
                    actualExternalSendMessageRequest)
                        .AreEqual;
        }



        private Expression<Func<ExternalCreateSenderIdRequest, bool>> SameExternalCreateSenderIdRequestAs(
         ExternalCreateSenderIdRequest expectedExternalCreateSenderIdRequest)
        {
            return actualExternalCreateSenderIdRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreateSenderIdRequest,
                    actualExternalCreateSenderIdRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalSendBulkMessageRequest, bool>> SameExternalSendBulkMessageRequestAs(
       ExternalSendBulkMessageRequest expectedExternalSendBulkMessageRequest)
        {
            return actualExternalSendBulkMessageRequest =>
                this.compareLogic.Compare(
                    expectedExternalSendBulkMessageRequest,
                    actualExternalSendBulkMessageRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalNumberMessageRequest, bool>> SameExternalNumberMessageRequestAs(
             ExternalNumberMessageRequest expectedExternalNumberMessageRequest)
        {
            return actualExternalNumberMessageRequest =>
                this.compareLogic.Compare(
                    expectedExternalNumberMessageRequest,
                    actualExternalNumberMessageRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalTemplatedMessageRequest, bool>> SameExternalTemplatedMessageRequestAs(
         ExternalTemplatedMessageRequest expectedExternalTemplatedMessageRequest)
        {
            return actualExternalTemplatedMessageRequest =>
                this.compareLogic.Compare(
                    expectedExternalTemplatedMessageRequest,
                    actualExternalTemplatedMessageRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCreateCampaignPhoneBookRequest, bool>> SameExternalCreateCampaignPhoneBookRequestAs(
        ExternalCreateCampaignPhoneBookRequest expectedExternalCreateCampaignPhoneBookRequest)
        {
            return actualExternalCreateCampaignPhoneBookRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreateCampaignPhoneBookRequest,
                    actualExternalCreateCampaignPhoneBookRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalUpdateCampaignPhoneBookRequest, bool>> SameExternalUpdateCampaignPhoneBookRequestAs(
       ExternalUpdateCampaignPhoneBookRequest expectedExternalUpdateCampaignPhoneBookRequest)
        {
            return actualExternalUpdateCampaignPhoneBookRequest =>
                this.compareLogic.Compare(
                    expectedExternalUpdateCampaignPhoneBookRequest,
                    actualExternalUpdateCampaignPhoneBookRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalAddContactToPhoneBookRequest, bool>> SameExternalAddContactToPhoneBookRequestAs(
       ExternalAddContactToPhoneBookRequest expectedExternalAddContactToPhoneBookRequest)
        {
            return actualExternalAddContactToPhoneBookRequest =>
                this.compareLogic.Compare(
                    expectedExternalAddContactToPhoneBookRequest,
                    actualExternalAddContactToPhoneBookRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalAddMultipleContactsToPhoneBookRequest, bool>> SameExternalAddMultipleContactsToPhoneBookRequestAs(
       ExternalAddMultipleContactsToPhoneBookRequest expectedExternalAddMultipleContactsToPhoneBookRequest)
        {
            return actualExternalAddMultipleContactsToPhoneBookRequest =>
                this.compareLogic.Compare(
                    expectedExternalAddMultipleContactsToPhoneBookRequest,
                    actualExternalAddMultipleContactsToPhoneBookRequest)
                        .AreEqual;
        }

        private static DateTime GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
           new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string[] CreateRandomStringArray() =>
            new Filler<string[]>().Create();

        private static List<string> CreateRandomStringList() =>
          new Filler<List<string>>().Create();

        private static bool GetRandomBoolean() =>
            Randomizer<bool>.Create();

        private static Dictionary<string, int> CreateRandomDictionary() =>
            new Filler<Dictionary<string, int>>().Create();


        #region AddContactToPhoneBookRequest
        private static dynamic CreateRandomAddContactToPhoneBookRequestProperties()
        {
            return new
            {
                ApiKey = GetRandomString(),
                PhoneNumber = GetRandomString(),
                EmailAddress = GetRandomString(),
                FirstName = GetRandomString(),
                LastName = GetRandomString(),
                Company = GetRandomString(),
                CountryCode = GetRandomString(),


            };
        }


        #endregion

        #region AddContactToPhoneBookResponse 

        private static dynamic CreateRandomAddContactToPhoneBookResponseProperties()
        {
            return new
            {
                Data = GetRandomAddContactToPhoneBookData(),

            };
        }

        private static dynamic GetRandomAddContactToPhoneBookData()
        {
            return new
            {

                Id = GetRandomNumber(),
                PhoneNumber = GetRandomString(),
                EmailAddress = GetRandomString(),
                Message = GetRandomString(),
                Company = GetRandomString(),
                FirstName = GetRandomString(),
                LastName = GetRandomString(),
                CreateAt = GetRandomString(),
                UpdatedAt = GetRandomString(),

            };
        }

        #endregion

        #region AddMultipleContactsToPhoneBookRequest
        private static dynamic CreateRandomAddMultipleContactsToPhoneBookRequestProperties()
        {
            return new
            {
                ApiKey = GetRandomString(),
                ContactFile = GetRandomString(),
                CountryCode = GetRandomString(),



            };
        }


        #endregion

        #region AddMultipleContactsToPhoneBookResponse 

        private static dynamic CreateRandomAddMultipleContactsToPhoneBookResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),

            };
        }


        #endregion

        #region CampaignPhoneBookResponse

        private static dynamic CreateCampaignPhoneBookProperties()
        {

            return new
            {

                Data = GetCampaignPhoneBookData(),
                Links = GetCampaignPhoneBookLinks(),
                Meta = GetCampaignPhoneBookMeta()


            };

        }

        private static List<dynamic> GetCampaignPhoneBookData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Id = GetRandomString(),
                Name = GetRandomString(),
                TotalNumberOfContacts = GetRandomNumber(),
                DateCreated = GetRandomString(),
                LastUpdated = GetRandomString(),


            }).ToList<dynamic>();

        }

        private static dynamic GetCampaignPhoneBookMeta()
        {

            return new
            {

                CurrentPage = GetRandomNumber(),
                From = GetRandomNumber(),
                LastPage = GetRandomNumber(),
                Path = GetRandomString(),
                PerPage = GetRandomNumber(),
                To = GetRandomNumber(),
                Total = GetRandomNumber(),



            };

        }

        private static dynamic GetCampaignPhoneBookLinks()
        {

            return new
            {

                First = GetRandomString(),
                Last = GetRandomString(),
                Prev = new object(),
                Next = GetRandomString(),


            };

        }

        #endregion

        #region CreateCampaignPhoneBookRequest
        private static dynamic CreateRandomCreateCampaignPhoneBookRequestProperties()
        {
            return new
            {
                ApiKey = GetRandomString(),
                PhonebookName = GetRandomString(),
                Description = GetRandomString(),

            };
        }


        #endregion

        #region CreateCampaignPhoneBookResponse 

        private static dynamic CreateRandomCreateCampaignPhoneBookResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),

            };
        }


        #endregion

        #region CreateSenderIdRequest
        private static dynamic CreateRandomCreateSenderIdRequestProperties()
        {
            return new
            {
                ApiKey = GetRandomString(),
                SenderId = GetRandomString(),
                Usecase = GetRandomString(),
                Company = GetRandomString(),


            };
        }


        #endregion

        #region CreateSenderIdResponse 

        private static dynamic CreateRandomCreateSenderIdResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Code = GetRandomString(),

            };
        }


        #endregion

        #region DeletePhoneBookResponse 

        private static dynamic CreateRandomDeletePhoneBookResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),


            };
        }


        #endregion

        #region DeletePhoneContactResponse 

        private static dynamic CreateRandomDeletePhoneContactResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),


            };
        }


        #endregion

        #region FetchCampaignsResponse 

        private static dynamic CreateRandomFetchCampaignsResponseProperties()
        {
            return new
            {
                Data = GetRandomFetchCampaignsResponseData(),
                Links = GetRandomFetchCampaignsResponseLinks(),
                Meta = GetRandomFetchCampaignsResponseMeta(),

            };
        }

      

        private static List<dynamic> GetRandomFetchCampaignsResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                CampaignId = GetRandomString(),
                PhoneBook = GetRandomString(),
                Sender = GetRandomString(),
                CampType = GetRandomString(),
                Channel = GetRandomString(),
                TotalRecipients = GetRandomNumber(),
                RunAt = GetRandomString(),
                Status = GetRandomString(),
                CreatedAt = GetRandomDate(),


            }).ToList<dynamic>();

        }

        private static dynamic GetRandomFetchCampaignsResponseLinks()
        {
            return new
            {
                First = GetRandomString(),
                Last = GetRandomString(),
                Prev = new object(),
                Next = new object(),



            };
        }

        private static dynamic GetRandomFetchCampaignsResponseMeta()
        {
            return new
            {
                CurrentPage = GetRandomNumber(),
                From = GetRandomNumber(),
                LastPage = GetRandomNumber(),
                Path = GetRandomString(),
                PerPage = GetRandomNumber(),
                To = GetRandomNumber(),
                Total = GetRandomNumber(),

            };
        }

        #endregion

        #region FetchCampaignsHistoryResponse 

        private static dynamic CreateRandomFetchCampaignsHistoryResponseProperties()
        {
            return new
            {
                Data = GetRandomFetchCampaignsHistoryResponseData(),
                Links = GetRandomFetchCampaignsHistoryResponseLinks(),
                Meta = GetRandomFetchCampaignsHistoryResponseMeta(),

            };
        }



        private static List<dynamic> GetRandomFetchCampaignsHistoryResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Id = GetRandomNumber(),
                Sender = GetRandomString(),
                Receiver = GetRandomString(),
                Message = GetRandomString(),
                MessageAbbreviation = GetRandomString(),
                Amount = GetRandomNumber(),
                Channel = GetRandomString(),
                SmsType = GetRandomString(),
                MessageId = GetRandomString(),
                Status = GetRandomString(),
                DateCreated = GetRandomString(),
                LastUpdated = GetRandomString(),


            }).ToList<dynamic>();

        }

        private static dynamic GetRandomFetchCampaignsHistoryResponseLinks()
        {
            return new
            {
                First = GetRandomString(),
                Last = GetRandomString(),
                Prev = new object(),
                Next = new object(),



            };
        }

        private static dynamic GetRandomFetchCampaignsHistoryResponseMeta()
        {
            return new
            {
                CurrentPage = GetRandomNumber(),
                From = GetRandomNumber(),
                LastPage = GetRandomNumber(),
                Path = GetRandomString(),
                PerPage = GetRandomNumber(),
                To = GetRandomNumber(),
                Total = GetRandomNumber(),


            };
        }

        #endregion

        #region FetchContactsByPhoneBookIdResponse 

        private static dynamic CreateRandomFetchContactsByPhoneBookIdResponseProperties()
        {
            return new
            {
                Data = GetRandomFetchContactsByPhoneBookIdResponseData(),
                Links = GetRandomFetchContactsByPhoneBookIdResponseLinks(),
                Meta = GetRandomFetchContactsByPhoneBookIdResponseMeta(),

            };
        }

        private static List<dynamic> GetRandomFetchContactsByPhoneBookIdResponseData()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new 
            {
                Id = GetRandomNumber(),
                Pid = GetRandomNumber(),
                PhoneNumber = GetRandomString(),
                EmailAddress = new object(),
                Message = new object(),
                Company = new object(),
                FirstName = new object(),
                LastName = new object(),
                CreateAt = GetRandomString(),
                UpdatedAt = GetRandomString(),





            }).ToList<dynamic>();
        }

        private static dynamic GetRandomFetchContactsByPhoneBookIdResponseLinks()
        {
            return new
            {
                First = GetRandomString(),
                Last = GetRandomString(),
                Prev = new object(),
                Next = new object(),



            };
        }

        private static dynamic GetRandomFetchContactsByPhoneBookIdResponseMeta()
        {
            return new
            {
                CurrentPage = GetRandomNumber(),
                From = GetRandomNumber(),
                LastPage = GetRandomNumber(),
                Path = GetRandomString(),
                PerPage = GetRandomNumber(),
                To = GetRandomNumber(),
                Total = GetRandomNumber(),



            };
        }

        #endregion

        #region FetchSenderIdsResponse 

        private static dynamic CreateRandomFetchSenderIdResponseProperties()
        {
            return new
            {
                CurrentPage = GetRandomNumber(),
                Data = GetRandomFetchSenderIdResponseData(),
                FirstPageUrl = GetRandomString(),
                From = GetRandomNumber(),
                LastPage = GetRandomNumber(),
                LastPageUrl = GetRandomString(),
                NextPageUrl = GetRandomString(),
                Path = GetRandomString(),
                PerPage = GetRandomNumber(),
                PrevPageUrl = new object(),
                To = GetRandomNumber(),
                Total = GetRandomNumber(),


            };
        }


        private static List<dynamic> GetRandomFetchSenderIdResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                SenderId = GetRandomString(),
                Status = GetRandomString(),
                Company = GetRandomString(),
                Usecase = new object(),
                Country = new object(),
                CreatedAt = GetRandomString(),



            }).ToList<dynamic>();

        }

        #endregion

        #region CreateNumberMessageRequest
        private static dynamic CreateRandomCreateNumberMessageRequestProperties()
        {
            return new
            {
                To = GetRandomString(),
                Sms = GetRandomString(),
                ApiKey = GetRandomString(),


            };
        }


        #endregion

        #region CreateNumberMessageResponse 

        private static dynamic CreateRandomCreateNumberMessageResponseProperties()
        {
            return new
            {
                Code = GetRandomString(),
                MessageId = GetRandomString(),
                Message = GetRandomString(),
                Balance = GetRandomNumber(),
                User = GetRandomString(),


            };
        }


        #endregion

        #region CreateSendBulkMessageRequest
        private static dynamic CreateRandomCreateSendBulkMessageRequestProperties()
        {
            return new
            {
                To = CreateRandomStringList(),
                From = GetRandomString(),
                Sms = GetRandomString(),
                Type = GetRandomString(),
                Channel = GetRandomString(),
                ApiKey = GetRandomString(),



            };
        }


        #endregion

        #region CreateSendBulkMessageResponse 

        private static dynamic CreateRandomCreateSendBulkMessageResponseProperties()
        {
            return new
            {
                Code = GetRandomString(),
                MessageId = GetRandomString(),
                Message = GetRandomString(),
                Balance = GetRandomNumber(),
                User = GetRandomString(),


            };
        }


        #endregion

        #region CreateSendCampaignRequest
        private static dynamic CreateRandomCreateSendCampaignRequestProperties()
        {
            return new
            {
                ApiKey = GetRandomString(),
                CountryCode = GetRandomString(),
                SenderId = GetRandomString(),
                Message = GetRandomString(),
                Channel = GetRandomString(),
                MessageType = GetRandomString(),
                PhonebookId = GetRandomString(),
                Delimiter = GetRandomString(),
                RemoveDuplicate = GetRandomString(),
                CampaignType = GetRandomString(),
                ScheduleTime = GetRandomString(),
                ScheduleSmsStatus = GetRandomString(),




            };
        }


        #endregion

        #region CreateSendCampaignResponse 

        private static dynamic CreateRandomCreateSendCampaignProperties()
        {
            return new
            {

                Message = GetRandomString(),



            };
        }


        #endregion

        #region CreateSendMessageRequest
        private static dynamic CreateRandomCreateSendMessageRequestProperties()
        {
            return new
            {
                To = GetRandomString(),
                From = GetRandomString(),
                Sms = GetRandomString(),
                Type = GetRandomString(),
                Channel = GetRandomString(),
                ApiKey = GetRandomString(),
                Media = GetRandomCreateSendMessageRequestMedia()


            };
        }

        private static dynamic GetRandomCreateSendMessageRequestMedia()
        {
            return new
            {
                Url = GetRandomString(),
                Caption = GetRandomString(),

            };
        }


        #endregion

        #region CreateSendMessageResponse 

        private static dynamic CreateRandomCreateSendMessageResponseProperties()
        {
            return new
            {

                MessageId = GetRandomString(),
                Message = GetRandomString(),
                Balance = GetRandomNumber(),
                User = GetRandomString(),




            };
        }


        #endregion

        #region CreateTemplatedMessageRequest
        private static dynamic CreateRandomCreateTemplatedMessageRequestProperties()
        {
            return new
            {
                PhoneNumber = GetRandomString(),
                DeviceId = GetRandomString(),
                TemplateId = GetRandomString(),
                ApiKey = GetRandomString(),
                Data = GetRandomCreateTemplatedMessageRequestData(),



            };
        }

        private static dynamic GetRandomCreateTemplatedMessageRequestData()
        {
            return new
            {
                Otp = GetRandomNumber(),
                ProductName = GetRandomString(),
                ExpiryTime = GetRandomString(),

            };
        }


        #endregion

        #region CreateTemplatedMessageResponse 

        private static dynamic CreateRandomCreateTemplatedMessageResponseProperties()
        {
            return new
            {

                MessageId = GetRandomString(),
                Message = GetRandomString(),
                Balance = GetRandomString(),
                User = GetRandomString(),
                Code = GetRandomString(),




            };
        }


        #endregion

        #region CreateUpdateCampaignPhoneBookRequest
        private static dynamic CreateRandomCreateUpdateCampaignPhoneBookRequestProperties()
        {
            return new
            {
                ApiKey = GetRandomString(),
                PhonebookName = GetRandomString(),
                Description = GetRandomString(),




            };
        }


        #endregion

        #region CreateUpdateCampaignPhoneBookResponse 

        private static dynamic CreateRandomCreateUpdateCampaignPhoneBookResponseProperties()
        {
            return new
            {
                Message = GetRandomString(),
            };
        }


        #endregion


        public static TheoryData UnauthorizedExceptions()
        {
            return new TheoryData<HttpResponseException>
            {
                new HttpResponseUnauthorizedException(),
                new HttpResponseForbiddenException()
            };
        }



    }
}
