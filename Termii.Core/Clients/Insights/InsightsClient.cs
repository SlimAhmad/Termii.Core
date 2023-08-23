using FlutterWave.Core.Models.Clients.Insights.Exceptions;
using System.Text.Json;
using System.Threading.Tasks;
using Termii.Core.Models.Clients.Insights.Exceptions;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalInsights;
using Termii.Core.Models.Services.Foundations.Termii;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Insights;
using Termii.Core.Services.Foundations.Termii.Insights.InsightsService;
using Xeptions;

namespace Termii.Core.Clients.Insights
{
    internal class InsightsClient : IInsightsClient
    {
        private readonly IInsightsService insightsService;

        public InsightsClient(IInsightsService insightService) =>
            insightsService = insightService;

        public async ValueTask<Balance> RetrieveBalanceAsync(string apiKey)
        {
            try
            {
                return await insightsService.GetBalanceAsync(apiKey);
            }
            catch (InsightsValidationException insightsValidationException)
            {

                throw new InsightsClientValidationException(
                    insightsValidationException.InnerException as Xeption);
            }
            catch (InsightsDependencyValidationException insightsDependencyValidationException)
            {


                throw new InsightsClientValidationException(
                    insightsDependencyValidationException.InnerException as Xeption);
            }
            catch (InsightsDependencyException insightsDependencyException)
            {
                throw new InsightsClientDependencyException(
                    insightsDependencyException.InnerException as Xeption);
            }
            catch (InsightsServiceException insightsServiceException)
            {
                throw new InsightsClientServiceException(
                    insightsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<History> RetrieveHistoryAsync(string apiKey)
        {
            try
            {
                return await insightsService.GetHistoryAsync(apiKey);
            }
            catch (InsightsValidationException insightsValidationException)
            {

                throw new InsightsClientValidationException(
                    insightsValidationException.InnerException as Xeption);
            }
            catch (InsightsDependencyValidationException insightsDependencyValidationException)
            {


                throw new InsightsClientValidationException(
                    insightsDependencyValidationException.InnerException as Xeption);
            }
            catch (InsightsDependencyException insightsDependencyException)
            {
                throw new InsightsClientDependencyException(
                    insightsDependencyException.InnerException as Xeption);
            }
            catch (InsightsServiceException insightsServiceException)
            {
                throw new InsightsClientServiceException(
                    insightsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Status> PhoneNumberStatusAsync(Status externalStatus)
        {
            try
            {
                return await insightsService.GetPhoneNumberStatusAsync(externalStatus);
            }
            catch (InsightsValidationException insightsValidationException)
            {

                throw new InsightsClientValidationException(
                    insightsValidationException.InnerException as Xeption);
            }
            catch (InsightsDependencyValidationException insightsDependencyValidationException)
            {


                throw new InsightsClientValidationException(
                    insightsDependencyValidationException.InnerException as Xeption);
            }
            catch (InsightsDependencyException insightsDependencyException)
            {
                throw new InsightsClientDependencyException(
                    insightsDependencyException.InnerException as Xeption);
            }
            catch (InsightsServiceException insightsServiceException)
            {
                throw new InsightsClientServiceException(
                    insightsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Search> RetrieveSearchPhoneNumberStatusAsync(Search externalSearch)
        {
            try
            {
                return await insightsService.GetSearchPhoneNumberStatusAsync(externalSearch);
            }
            catch (InsightsValidationException insightsValidationException)
            {
               

                throw new InsightsClientValidationException(
                    insightsValidationException.InnerException as Xeption);
            }
            catch (InsightsDependencyValidationException insightsDependencyValidationException)
            {
                var message = insightsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    NotFoundSearchResponse response =
                        JsonSerializer.Deserialize<NotFoundSearchResponse>(message);

                    return new Search
                    {
                        Response = new SearchResponse
                        {
                            Message = response.Message,
                            DndActive = response.DndActive,
                            Network = response.Network,
                            NetworkCode = response.NetworkCode,
                            Number = response.Number,
                            Status = response.Status,

                        }
                    };
                }

                throw new InsightsClientValidationException(
                    insightsDependencyValidationException.InnerException as Xeption);
            }
            catch (InsightsDependencyException insightsDependencyException)
            {
                throw new InsightsClientDependencyException(
                    insightsDependencyException.InnerException as Xeption);
            }
            catch (InsightsServiceException insightsServiceException)
            {
                throw new InsightsClientServiceException(
                    insightsServiceException.InnerException as Xeption);
            }
        }
    }
}
