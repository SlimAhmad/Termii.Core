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
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalTokens;
using Termii.Core.Services.Foundations.Termii.Tokens.TokensService;
using Tynamix.ObjectFiller;

namespace Termii.Core.Tests.Unit.Foundations.Services.Tokens
{
    public partial class TokensServiceTests
    {

        private readonly Mock<ITermiiBroker> termiiBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ITokensService tokensService;

        public TokensServiceTests()
        {
            termiiBrokerMock = new Mock<ITermiiBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            tokensService = new TokensService(
                termiiBroker: termiiBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }

        private Expression<Func<ExternalVerifyTokenRequest, bool>> SameExternalVerifyTokenRequestAs(
          ExternalVerifyTokenRequest expectedExternalVerifyTokenRequest)
        {
            return actualExternalVerifyTokenRequest =>
                this.compareLogic.Compare(
                    expectedExternalVerifyTokenRequest,
                    actualExternalVerifyTokenRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalSendTokenRequest, bool>> SameExternalSendTokenRequestAs(
       ExternalSendTokenRequest expectedExternalSendTokenRequest)
        {
            return actualExternalSendTokenRequest =>
                this.compareLogic.Compare(
                    expectedExternalSendTokenRequest,
                    actualExternalSendTokenRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalEmailTokenRequest, bool>> SameExternalEmailTokenRequestAs(
       ExternalEmailTokenRequest expectedExternalEmailTokenRequest)
        {
            return actualExternalEmailTokenRequest =>
                this.compareLogic.Compare(
                    expectedExternalEmailTokenRequest,
                    actualExternalEmailTokenRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalInAppTokenRequest, bool>> SameExternalInAppTokenRequestAs(
       ExternalInAppTokenRequest expectedExternalInAppTokenRequest)
        {
            return actualExternalInAppTokenRequest =>
                this.compareLogic.Compare(
                    expectedExternalInAppTokenRequest,
                    actualExternalInAppTokenRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalVoiceCallRequest, bool>> SameExternalVoiceCallRequestAs(
       ExternalVoiceCallRequest expectedExternalVoiceCallRequest)
        {
            return actualExternalVoiceCallRequest =>
                this.compareLogic.Compare(
                    expectedExternalVoiceCallRequest,
                    actualExternalVoiceCallRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalVoiceTokenRequest, bool>> SameExternalVoiceTokenRequestAs(
       ExternalVoiceTokenRequest expectedExternalVoiceTokenRequest)
        {
            return actualExternalVoiceTokenRequest =>
                this.compareLogic.Compare(
                    expectedExternalVoiceTokenRequest,
                    actualExternalVoiceTokenRequest)
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




        #region EmailTokenRequest
        private static dynamic CreateRandomEmailTokenRequestProperties()
        {
            return new
            {
                EmailAddress = GetRandomString(),
                Code = GetRandomString(),
                ApiKey = GetRandomString(),
                EmailConfigurationId = GetRandomString(),


            };
        }


        #endregion

        #region EmailTokenResponse
        private static dynamic CreateRandomEmailTokenResponseProperties()
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

        #region InnAppTokenRequest
        private static dynamic CreateRandomInAppTokenRequestProperties()
        {
            return new
            {
                ApiKey = GetRandomString(),
                PinType = GetRandomString(),
                PhoneNumber = GetRandomString(),
                PinAttempts = GetRandomNumber(),
                PinTimeToLive = GetRandomNumber(),
                PinLength = GetRandomNumber(),



            };
        }


        #endregion

        #region InnAppTokenResponse
        private static dynamic CreateRandomInAppTokenResponseProperties()
        {
            return new
            {
                Status = GetRandomString(),
                Data = GetRandomInnAppTokenData(),




            };
        }

        private static dynamic GetRandomInnAppTokenData()
        {
            return new
            {
                PinId = GetRandomString(),
                Otp = GetRandomString(),
                PhoneNumber = GetRandomString(),
                PhoneNumberOther = GetRandomString(),





            };
        }


        #endregion

        #region SendTokenRequest
        private static dynamic CreateRandomSendTokenRequestProperties()
        {
            return new
            {
                ApiKey = GetRandomString(),
                MessageType = GetRandomString(),
                To = GetRandomString(),
                From = GetRandomString(),
                Channel = GetRandomString(),
                PinAttempts = GetRandomNumber(),
                PinTimeToLive = GetRandomNumber(),
                PinLength = GetRandomNumber(),
                PinPlaceholder = GetRandomString(),
                MessageText = GetRandomString(),
                PinType = GetRandomString(),



            };
        }


        #endregion

        #region SendTokenResponse
        private static dynamic CreateRandomSendTokenResponseProperties()
        {
            return new
            {

                PinId = GetRandomString(),
                To = GetRandomString(),
                SmsStatus = GetRandomString(),

            };
        }




        #endregion

        #region VerifyTokenRequest
        private static dynamic CreateRandomVerifyTokenRequestProperties()
        {
            return new
            {
                ApiKey = GetRandomString(),
                PinId = GetRandomString(),
                Pin = GetRandomString(),




            };
        }


        #endregion

        #region VerifyTokenResponse
        private static dynamic CreateRandomVerifyTokenResponseProperties()
        {
            return new
            {

                PinId = GetRandomString(),
                Verified = GetRandomString(),
                Msisdn = GetRandomString(),


            };
        }




        #endregion

        #region VoiceCallRequest
        private static dynamic CreateRandomVoiceCallRequestProperties()
        {
            return new
            {
                ApiKey = GetRandomString(),
                PhoneNumber = GetRandomString(),
                Code = GetRandomNumber(),




            };
        }


        #endregion

        #region VoiceCallResponse
        private static dynamic CreateRandomVoiceCallResponseProperties()
        {
            return new
            {

                Code = GetRandomString(),
                MessageId = GetRandomString(),
                PinId = GetRandomString(),
                Message = GetRandomString(),
                Balance = GetRandomNumber(),
                User = GetRandomString(),



            };
        }




        #endregion

        #region VoiceTokenRequest
        private static dynamic CreateRandomVoiceTokenRequestProperties()
        {
            return new
            {
                ApiKey = GetRandomString(),
                PhoneNumber = GetRandomString(),
                PinAttempts = GetRandomNumber(),
                PinTimeToLive = GetRandomNumber(),
                PinLength = GetRandomNumber(),

            };
        }


        #endregion

        #region VoiceTokenResponse
        private static dynamic CreateRandomVoiceTokenResponseProperties()
        {
            return new
            {
                Code = GetRandomString(),
                MessageId = GetRandomString(),
                PinId = GetRandomString(),
                Message = GetRandomString(),
                Balance = GetRandomNumber(),
                User = GetRandomString(),

            };
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
