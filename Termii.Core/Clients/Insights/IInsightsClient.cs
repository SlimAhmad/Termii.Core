﻿using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Insights;

namespace Termii.Core.Clients.Insights
{
    public interface IInsightsClient
    {

        ValueTask<Balance> RetrieveBalanceAsync(string apiKey);

        ValueTask<History> RetrieveHistoryAsync(string apiKey);

        ValueTask<Search> RetrieveSearchPhoneNumberStatusAsync(Search externalSearch);

        ValueTask<Status> PhoneNumberStatusAsync(Status externalStatus);
    }
}
