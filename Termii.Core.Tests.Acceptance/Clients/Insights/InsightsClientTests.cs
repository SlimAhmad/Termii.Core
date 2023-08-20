using Termii.Core.Clients.Termii;
using Termii.Core.Models.Configurations;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;
using Termii.Core.Models.Services.Foundations.Termii.Insights;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace Termii.Core.Tests.Acceptance.Clients.Insights
{
    public partial class InsightsClientTests : IDisposable
    {
        private readonly string apiKey;
        private readonly WireMockServer wireMockServer;
        private readonly ITermiiClient termiiClient;

        public InsightsClientTests()
        {
            apiKey = GetRandomString();
            wireMockServer = WireMockServer.Start();

            var apiConfigurations = new ApiConfigurations
            {
                ApiUrl = wireMockServer.Url,
                ApiKey = apiKey,

            };

            termiiClient = new TermiiClient(apiConfigurations);
        }

        private static DateTimeOffset GetRandomDate() =>
             new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static ExternalSearchRequest ConvertToInsightsRequest(Search search)
        {

            return new ExternalSearchRequest
            {
                ApiKey = search.Request.ApiKey,
                PhoneNumber = search.Request.PhoneNumber,
            };



        }

        private static ExternalStatusRequest ConvertToInsightsRequest(Status status)
        {

            return new ExternalStatusRequest
            {
                ApiKey = status.Request.ApiKey,
                PhoneNumber = status.Request.PhoneNumber,
                CountryCode = status.Request.CountryCode,
            };



        }

        private static Balance ConvertToInsightsResponse(ExternalBalanceResponse externalBalanceResponse)
        {
            return new Balance
            {
                Response = new BalanceResponse
                {
                    Balance = externalBalanceResponse.Balance,
                    Currency = externalBalanceResponse.Currency,
                    User = externalBalanceResponse.User
                }
            };



        }
        private static Search ConvertToInsightsResponse(Search search, ExternalSearchResponse externalSearchResponse)
        {
            search.Response = new SearchResponse
            {
                Network = externalSearchResponse.Network,
                NetworkCode = externalSearchResponse.NetworkCode,
                Number = externalSearchResponse.Number,
                Status = externalSearchResponse.Status,
            };
            return search;

        }

        private static Status ConvertToInsightsResponse(Status status, ExternalStatusResponse externalStatusResponse)
        {
            status.Response = new StatusResponse
            {
                Result = externalStatusResponse.Result.Select(result =>
                {
                    return new StatusResponse.StatusResult
                    {
                        CountryDetail = new StatusResponse.CountryDetail
                        {
                            CountryCode = result.CountryDetail.CountryCode,
                            Iso = result.CountryDetail.Iso,
                            MobileCountryCode = result.CountryDetail.MobileCountryCode,
                        },
                        OperatorDetail = new StatusResponse.OperatorDetail
                        {
                            CarrierIdentificationCode = result.OperatorDetail.CarrierIdentificationCode,
                            LineType = result.OperatorDetail.LineType,
                            MobileNumberCode = result.OperatorDetail.MobileNumberCode,
                            MobileRoutingCode = result.OperatorDetail.MobileRoutingCode,
                            OperatorCode = result.OperatorDetail.OperatorCode,
                            OperatorName = result.OperatorDetail.OperatorName,
                        },
                        RouteDetail = new StatusResponse.RouteDetail
                        {
                            Number = result.RouteDetail.Number,
                            Ported = result.RouteDetail.Ported,
                        },
                        Status = result.Status
                    };
                }).ToList(),
            };
            return status;

        }

        private static History ConvertToInsightsResponse(ExternalHistoryResponse externalHistoryResponse)
        {
            return new History
            {
                Response = new HistoryResponse
                {
                    Amount = externalHistoryResponse.Amount,
                    Status = externalHistoryResponse.Status,
                    CreatedAt = externalHistoryResponse.CreatedAt,
                    MediaUrl = externalHistoryResponse.MediaUrl,
                    Message = externalHistoryResponse.Message,
                    MessageId = externalHistoryResponse.MessageId,
                    NotifyId = externalHistoryResponse.NotifyId,
                    NotifyUrl = externalHistoryResponse.NotifyUrl,
                    Receiver = externalHistoryResponse.Receiver,
                    Reroute = externalHistoryResponse.Reroute,
                    SendBy = externalHistoryResponse.SendBy,
                    Sender = externalHistoryResponse.Sender,
                    SmsType = externalHistoryResponse.SmsType,
                }
            };


        }


        private static ExternalSearchResponse CreateExternalSearchResponseResult() =>
                CreateExternalSearchResponseFiller().Create();

        private static ExternalBalanceResponse CreateExternalBalanceResponseResult() =>
           CreateExternalBalanceResponseFiller().Create();

        private static ExternalHistoryResponse CreateExternalHistoryResponseResult() =>
          CreateExternalHistoryResponseFiller().Create();

        private static ExternalStatusResponse CreateExternalStatusResponseResult() =>
           CreateExternalExternalStatusResponseFiller().Create();

        

        private static Search CreateSearchResponseResult() =>
          CreateSearchFiller().Create();

        private static Status CreateRandomStatusResponseResult() =>
          CreateRandomStatusFiller().Create();

        private static Filler<ExternalSearchResponse> CreateExternalSearchResponseFiller()
        {
            var filler = new Filler<ExternalSearchResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalBalanceResponse> CreateExternalBalanceResponseFiller()
        {
            var filler = new Filler<ExternalBalanceResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalStatusResponse> CreateExternalExternalStatusResponseFiller()
        {
            var filler = new Filler<ExternalStatusResponse>();

            filler.Setup()
               .OnType<object>().IgnoreIt();

            return filler;
        }
        private static Filler<ExternalHistoryResponse> CreateExternalHistoryResponseFiller()
        {
            var filler = new Filler<ExternalHistoryResponse>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }


        private static Filler<Search> CreateSearchFiller()
        {
            var filler = new Filler<Search>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
 
        private static Filler<Status> CreateRandomStatusFiller()
        {
            var filler = new Filler<Status>();

            filler.Setup()
                .OnType<object>().IgnoreIt()
                .OnType<DateTimeOffset>().Use(GetRandomDate());

            return filler;
        }
        public void Dispose() => wireMockServer.Stop();
    }
}
