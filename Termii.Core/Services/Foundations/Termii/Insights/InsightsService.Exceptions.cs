using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Insights;

namespace Termii.Core.Services.Foundations.Termii.Insights.InsightsService
{
    internal partial class InsightsService
    {
        private delegate ValueTask<History> ReturningHistoryFunction();

        private delegate ValueTask<Balance> ReturningBalanceFunction();

        private delegate ValueTask<Search> ReturningSearchFunction();

        private delegate ValueTask<Status> ReturningStatusFunction();

        private async ValueTask<Search> TryCatch(ReturningSearchFunction returningSearchFunction)
        {
            try
            {
                return await returningSearchFunction();
            }
            catch (NullInsightsException nullInsightsException)
            {
                throw new InsightsValidationException(nullInsightsException);
            }
            catch (InvalidInsightsException invalidInsightsException)
            {
                throw new InsightsValidationException(invalidInsightsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationInsightsException =
                    new InvalidConfigurationInsightsException(httpResponseUrlNotFoundException);

                throw new InsightsDependencyException(invalidConfigurationInsightsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedInsightsException =
                    new UnauthorizedInsightsException(httpResponseUnauthorizedException);

                throw new InsightsDependencyException(unauthorizedInsightsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedInsightsException =
                    new UnauthorizedInsightsException(httpResponseForbiddenException);

                throw new InsightsDependencyException(unauthorizedInsightsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundInsightsException =
                    new NotFoundInsightsException(httpResponseNotFoundException);

                throw new InsightsDependencyValidationException(notFoundInsightsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidInsightsException =
                    new InvalidInsightsException(httpResponseBadRequestException);

                throw new InsightsDependencyValidationException(invalidInsightsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallInsightsException =
                    new ExcessiveCallInsightsException(httpResponseTooManyRequestsException);

                throw new InsightsDependencyValidationException(excessiveCallInsightsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerInsightsException =
                    new FailedServerInsightsException(httpResponseException);

                throw new InsightsDependencyException(failedServerInsightsException);
            }
            catch (Exception exception)
            {
                var failedInsightsServiceException =
                    new FailedInsightsServiceException(exception);

                throw new InsightsServiceException(failedInsightsServiceException);
            }
        }
  
        private async ValueTask<Status> TryCatch(ReturningStatusFunction returningStatusFunction)
        {
            try
            {
                return await returningStatusFunction();
            }
            catch (NullInsightsException nullInsightsException)
            {
                throw new InsightsValidationException(nullInsightsException);
            }
            catch (InvalidInsightsException invalidInsightsException)
            {
                throw new InsightsValidationException(invalidInsightsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationInsightsException =
                    new InvalidConfigurationInsightsException(httpResponseUrlNotFoundException);

                throw new InsightsDependencyException(invalidConfigurationInsightsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedInsightsException =
                    new UnauthorizedInsightsException(httpResponseUnauthorizedException);

                throw new InsightsDependencyException(unauthorizedInsightsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedInsightsException =
                    new UnauthorizedInsightsException(httpResponseForbiddenException);

                throw new InsightsDependencyException(unauthorizedInsightsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundInsightsException =
                    new NotFoundInsightsException(httpResponseNotFoundException);

                throw new InsightsDependencyValidationException(notFoundInsightsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidInsightsException =
                    new InvalidInsightsException(httpResponseBadRequestException);

                throw new InsightsDependencyValidationException(invalidInsightsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallInsightsException =
                    new ExcessiveCallInsightsException(httpResponseTooManyRequestsException);

                throw new InsightsDependencyValidationException(excessiveCallInsightsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerInsightsException =
                    new FailedServerInsightsException(httpResponseException);

                throw new InsightsDependencyException(failedServerInsightsException);
            }
            catch (Exception exception)
            {
                var failedInsightsServiceException =
                    new FailedInsightsServiceException(exception);

                throw new InsightsServiceException(failedInsightsServiceException);
            }
        }

        private async ValueTask<History> TryCatch(ReturningHistoryFunction returningHistoryFunction)
        {
            try
            {
                return await returningHistoryFunction();
            }
            catch (NullInsightsException nullInsightsException)
            {
                throw new InsightsValidationException(nullInsightsException);
            }
            catch (InvalidInsightsException invalidInsightsException)
            {
                throw new InsightsValidationException(invalidInsightsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationInsightsException =
                    new InvalidConfigurationInsightsException(httpResponseUrlNotFoundException);

                throw new InsightsDependencyException(invalidConfigurationInsightsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedInsightsException =
                    new UnauthorizedInsightsException(httpResponseUnauthorizedException);

                throw new InsightsDependencyException(unauthorizedInsightsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedInsightsException =
                    new UnauthorizedInsightsException(httpResponseForbiddenException);

                throw new InsightsDependencyException(unauthorizedInsightsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundInsightsException =
                    new NotFoundInsightsException(httpResponseNotFoundException);

                throw new InsightsDependencyValidationException(notFoundInsightsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidInsightsException =
                    new InvalidInsightsException(httpResponseBadRequestException);

                throw new InsightsDependencyValidationException(invalidInsightsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallInsightsException =
                    new ExcessiveCallInsightsException(httpResponseTooManyRequestsException);

                throw new InsightsDependencyValidationException(excessiveCallInsightsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerInsightsException =
                    new FailedServerInsightsException(httpResponseException);

                throw new InsightsDependencyException(failedServerInsightsException);
            }
            catch (Exception exception)
            {
                var failedInsightsServiceException =
                    new FailedInsightsServiceException(exception);

                throw new InsightsServiceException(failedInsightsServiceException);
            }
        }

        private async ValueTask<Balance> TryCatch(
            ReturningBalanceFunction returningBalanceFunction)
        {
            try
            {
                return await returningBalanceFunction();
            }
            catch (NullInsightsException nullInsightsException)
            {
                throw new InsightsValidationException(nullInsightsException);
            }
            catch (InvalidInsightsException invalidInsightsException)
            {
                throw new InsightsValidationException(invalidInsightsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationInsightsException =
                    new InvalidConfigurationInsightsException(httpResponseUrlNotFoundException);

                throw new InsightsDependencyException(invalidConfigurationInsightsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedInsightsException =
                    new UnauthorizedInsightsException(httpResponseUnauthorizedException);

                throw new InsightsDependencyException(unauthorizedInsightsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedInsightsException =
                    new UnauthorizedInsightsException(httpResponseForbiddenException);

                throw new InsightsDependencyException(unauthorizedInsightsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundInsightsException =
                    new NotFoundInsightsException(httpResponseNotFoundException);

                throw new InsightsDependencyValidationException(notFoundInsightsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidInsightsException =
                    new InvalidInsightsException(httpResponseBadRequestException);

                throw new InsightsDependencyValidationException(invalidInsightsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallInsightsException =
                    new ExcessiveCallInsightsException(httpResponseTooManyRequestsException);

                throw new InsightsDependencyValidationException(excessiveCallInsightsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerInsightsException =
                    new FailedServerInsightsException(httpResponseException);

                throw new InsightsDependencyException(failedServerInsightsException);
            }
            catch (Exception exception)
            {
                var failedInsightsServiceException =
                    new FailedInsightsServiceException(exception);

                throw new InsightsServiceException(failedInsightsServiceException);
            }
        }

    }
}