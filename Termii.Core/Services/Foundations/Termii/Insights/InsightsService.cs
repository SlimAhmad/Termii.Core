﻿using System.Linq;
using System.Threading.Tasks;
using Termii.Core.Brokers.DateTimes;
using Termii.Core.Brokers.Termii;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;
using Termii.Core.Models.Services.Foundations.Termii.Insights;

namespace Termii.Core.Services.Foundations.Termii.Insights.InsightsService
{
    internal partial class InsightsService : IInsightsService
    {
        private readonly ITermiiBroker termiiBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public InsightsService(
            ITermiiBroker termiiBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.termiiBroker = termiiBroker;
            this.dateTimeBroker = dateTimeBroker;
        }


        public ValueTask<Balance> GetBalanceAsync(string apiKey) =>
        TryCatch(async () =>
        {
            ValidateBalanceParameters(apiKey);
            ExternalBalanceResponse externalBalance = await termiiBroker.GetBalanceAsync(apiKey);
            return ConvertToInsights(externalBalance);
        });

        public ValueTask<History> GetHistoryAsync(string apiKey) =>
        TryCatch(async () =>
        {
            ValidateHistoryParameters(apiKey);
            ExternalHistoryResponse externalHistory = await termiiBroker.GetHistoryAsync(apiKey);
            return ConvertToInsights(externalHistory);
        });

        public ValueTask<Search> GetSearchPhoneNumberStatusAsync(Search externalSearch) =>
        TryCatch(async () =>
        {
            ValidateSearchPhoneNumberStatus(externalSearch);
            ExternalSearchRequest  externalSearchRequest =  ConvertToInsightsRequest(externalSearch);
            ExternalSearchResponse externalSearchResponse = await termiiBroker.GetSearchPhoneNumberStatusAsync(externalSearchRequest);
            return ConvertToInsights(externalSearch,externalSearchResponse);
        });

        public ValueTask<Status> GetPhoneNumberStatusAsync(Status externalStatus) =>
        TryCatch(async () =>
        {
            ValidatePhoneNumberStatus(externalStatus);
            ExternalStatusRequest externalStatusRequest = ConvertToInsightsRequest(externalStatus);
            ExternalStatusResponse externalStatusResponse = await termiiBroker.GetPhoneNumberStatusAsync(externalStatusRequest);
            return ConvertToInsights(externalStatus, externalStatusResponse);
        });




        private static ExternalSearchRequest ConvertToInsightsRequest(Search  search)
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

        private static Balance ConvertToInsights(ExternalBalanceResponse externalBalanceResponse)
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
        private static Search ConvertToInsights(Search search, ExternalSearchResponse externalSearchResponse)
        {
            search.Response = new SearchResponse
            {
               Network = externalSearchResponse.Network,
               NetworkCode = externalSearchResponse.NetworkCode,
               Number = externalSearchResponse.Number,
               Status = externalSearchResponse.Status,
               DndActive = externalSearchResponse.DndActive,
               Message = externalSearchResponse.Message,
            };
            return search;

        }

        private static Status ConvertToInsights(Status status, ExternalStatusResponse externalStatusResponse)
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

        private static History ConvertToInsights( ExternalHistoryResponse externalHistoryResponse)
        {
            return new History
            {
                Response = new HistoryResponse
                {
                    Data = externalHistoryResponse.Data.Select(data =>
                    {
                        return new HistoryResponse.Datum
                        {
                            Amount = data.Amount,
                            CountryCode = data.CountryCode,
                            CreatedAt = data.CreatedAt,
                            MediaUrl = data.MediaUrl,
                            Message = data.Message,
                            MessageId = data.MessageId,
                            NotifyId = data.NotifyId,
                            NotifyUrl = data.NotifyUrl,
                            Receiver = data.Receiver,
                            Reroute = data.Reroute,
                            SendBy = data.SendBy,
                            Sender = data.Sender,
                            SentAt = data.SentAt,
                            SmsType = data.SmsType,
                            Status = data.Status,

                        };
                    }).ToList(),
                    Links = new HistoryResponse.HistoryLinks
                    {
                       First = externalHistoryResponse.Links.First,
                       Last = externalHistoryResponse.Links.Last,
                       Next = externalHistoryResponse.Links.Next,
                       Prev = externalHistoryResponse.Links.Prev,
                     
                    },
                    Meta = new HistoryResponse.HistoryMeta
                    {
                       CurrentPage = externalHistoryResponse.Meta.CurrentPage,
                       From = externalHistoryResponse.Meta.From,
                       LastPage = externalHistoryResponse.Meta.LastPage,
                       Path = externalHistoryResponse.Meta.Path,
                       PerPage = externalHistoryResponse.Meta.PerPage,
                       To = externalHistoryResponse.Meta.To,
                       Total = externalHistoryResponse.Meta.Total,
                    }
                }
            };
         

        }



    }
}
