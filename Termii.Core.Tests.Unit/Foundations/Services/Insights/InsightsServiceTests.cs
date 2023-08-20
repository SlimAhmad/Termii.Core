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
using Termii.Core.Services.Foundations.Termii.Insights.InsightsService;
using Tynamix.ObjectFiller;


namespace Termii.Core.Tests.Unit.Foundations.Services.Insights
{
    public partial class InsightsServiceTests
    {

        private readonly Mock<ITermiiBroker> termiiBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IInsightsService insightsService;

        public InsightsServiceTests()
        {
            termiiBrokerMock = new Mock<ITermiiBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            insightsService = new InsightsService(
                termiiBroker: termiiBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalSearchRequest, bool>> SameExternalSearchRequestAs(
             ExternalSearchRequest expectedExternalSearchRequest)
        {
            return actualExternalSearchRequest =>
                this.compareLogic.Compare(
                    expectedExternalSearchRequest,
                    actualExternalSearchRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalStatusRequest, bool>> SameExternalStatusRequestAs(
            ExternalStatusRequest expectedExternalStatusRequest)
        {
            return actualExternalStatusRequest =>
                this.compareLogic.Compare(
                    expectedExternalStatusRequest,
                    actualExternalStatusRequest)
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


        #region BalanceResponse 

        private static dynamic CreateRandomBalanceResponseProperties()
        {
            return new
            {
                User = GetRandomString(),
                Balance = GetRandomNumber(),
                Currency = GetRandomString()
            };
        }

        #endregion

        #region HistoryResponse
        private static dynamic CreateRandomHistoryResponseProperties()
        {
            return new
            {
                Sender = GetRandomString(),
                Receiver = GetRandomString(),
                Message = GetRandomString(),
                Amount = GetRandomNumber(),
                Reroute = GetRandomNumber(),
                Status = GetRandomString(),
                SmsType = GetRandomString(),
                SendBy = GetRandomString(),
                MediaUrl = new object(),
                MessageId = GetRandomString(),
                NotifyUrl = new object(),
                NotifyId = new object(),
                CreatedAt = GetRandomString(),

            };
        }


        #endregion

        #region SearchRequest
        private static dynamic CreateRandomSearchRequestProperties()
        {
            return new
            {
                ApiKey = GetRandomString(),
                PhoneNumber = GetRandomString(),

            };
        }


        #endregion

        #region SearchResponse
        private static dynamic CreateRandomSearchResponseProperties()
        {
            return new
            {
                Number = GetRandomString(),
                Status = GetRandomString(),
                Network = GetRandomString(),
                NetworkCode = GetRandomString(),


            };
        }


        #endregion

        #region SearchRequest
        private static dynamic CreateRandomStatusRequestProperties()
        {
            return new
            {
                ApiKey = GetRandomString(),
                PhoneNumber = GetRandomString(),
                CountryCode = GetRandomString(),
            };
        }


        #endregion

        #region StatusResponse

        private static dynamic CreateRandomStatusResponseProperties()
        {
            return new
            {
                Result = GetRandomStatusResultProperties(),

            };
        }
        private static dynamic GetRandomOperatorDetailsProperties()
        {
            return new
            {
                OperatorCode = GetRandomString(),
                OperatorName = GetRandomString(),
                MobileNumberCode = GetRandomString(),
                MobileRoutingCode = GetRandomString(),
                CarrierIdentificationCode = GetRandomString(),
                LineType = GetRandomString(),



            };
        }

        private static dynamic GetRandomCountryDetailProperties()
        {
            return new
            {
                CountryCode = GetRandomString(),
                MobileCountryCode = GetRandomString(),
                Iso = GetRandomString(),

            };
        }

        private static dynamic GetRandomRouteDetailProperties()
        {
            return new
            {
                Number = GetRandomString(),
                Ported = GetRandomNumber(),
             

            };
        }

        private static List<dynamic> GetRandomStatusResultProperties()
        {
            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                RouteDetail = GetRandomRouteDetailProperties(),
                CountryDetail = GetRandomCountryDetailProperties(),
                OperatorDetail = GetRandomOperatorDetailsProperties(),
                Status = GetRandomNumber(),




            }).ToList<dynamic>();
        }

        #endregion


        private static List<dynamic> GetRandomBankBranchList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Id = GetRandomNumber(),
                BankId = GetRandomNumber(),
                Bic = GetRandomString(),
                BranchCode = GetRandomString(),
                BranchName = GetRandomString(),
                SwiftCode = GetRandomString(),

            }).ToList<dynamic>();

        }

        private static List<dynamic> GetRandomBankList()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
               item => new
               {
                   Id = GetRandomNumber(),
                   Code = GetRandomString(),
                   Name = GetRandomString(),

               }).ToList<dynamic>();
        }
        private static dynamic CreateRandomBankProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Message = GetRandomString(),
                Data = GetRandomBankList()
            };
        }

        private static dynamic CreateRandomBankBranchesProperties()
        {
            return new
            {
                Message = GetRandomString(),
                Status = GetRandomString(),
                Data = GetRandomBankBranchList()
            };
        }


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
