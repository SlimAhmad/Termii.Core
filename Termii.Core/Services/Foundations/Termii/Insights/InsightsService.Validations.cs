using System;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Insights;

namespace Termii.Core.Services.Foundations.Termii.Insights.InsightsService
{
    internal partial class InsightsService
    {
        private static void ValidateSearchPhoneNumberStatus(Search  search)
        {
            ValidateSearchPhoneNumberStatusNotNull(search);
            ValidateSearchPhoneNumberStatusRequest(search.Request);
            Validate(
                (Rule: IsInvalid(search.Request), Parameter: nameof(search.Request)));

            Validate(
                (Rule: IsInvalid(search.Request.PhoneNumber), Parameter: nameof(SearchRequest.PhoneNumber)),
                (Rule: IsInvalid(search.Request.ApiKey), Parameter: nameof(SearchRequest.ApiKey))
                
                );

        }


        private static void ValidatePhoneNumberStatus(Status status)
        {
            ValidatePhoneNumberStatusNotNull(status);
            ValidatePhoneNumberStatusRequest(status.Request);
            Validate(
                (Rule: IsInvalid(status.Request), Parameter: nameof(status.Request)));

            Validate(
                (Rule: IsInvalid(status.Request.PhoneNumber), Parameter: nameof(StatusRequest.PhoneNumber)),
                (Rule: IsInvalid(status.Request.ApiKey), Parameter: nameof(StatusRequest.ApiKey)),
                (Rule: IsInvalid(status.Request.CountryCode), Parameter: nameof(StatusRequest.CountryCode))
            

                );

        }


        private static void ValidatePhoneNumberStatusNotNull(Status status)
        {
            if (status is null)
            {
                throw new NullInsightsException();
            }
        }

        private static void ValidatePhoneNumberStatusRequest(StatusRequest statusRequest)
        {
            Validate((Rule: IsInvalid(statusRequest), Parameter: nameof(StatusRequest)));
        }
        private static void ValidateSearchPhoneNumberStatusNotNull(Search  search)
        {
            if (search is null)
            {
                throw new NullInsightsException();
            }
        }

        private static void ValidateSearchPhoneNumberStatusRequest(SearchRequest searchRequest)
        {
            Validate((Rule: IsInvalid(searchRequest), Parameter: nameof(SearchRequest)));
        }

        private static void ValidateBalanceParameters(string text) =>
          Validate((Rule: IsInvalid(text), Parameter: nameof(Balance)));

        private static void ValidateHistoryParameters(string text) =>
         Validate((Rule: IsInvalid(text), Parameter: nameof(History)));

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
            var invalidstatusException = new InvalidInsightsException();

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