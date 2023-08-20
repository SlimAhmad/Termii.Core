using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using Termii.Core.Models.Services.Foundations.Termii.Insights;
using Termii.Core.Models.Services.Foundations.Termii.Switch;

namespace Termii.Core.Services.Foundations.Termii.Switch.SwitchService
{
    internal partial class SwitchService
    {
        private delegate ValueTask<AddContactToPhoneBook> ReturningAddContactToPhoneBookFunction();

        private delegate ValueTask<AddMultipleContactsToPhoneBook> ReturningAddMultipleContactsToPhoneBookFunction();

        private delegate ValueTask<CampaignPhoneBook> ReturningCampaignPhoneBookFunction();

        private delegate ValueTask<CreateCampaignPhoneBook> ReturningCreateCampaignPhoneBookFunction();

        private delegate ValueTask<CreateSenderId> ReturningCreateSenderIdFunction();

        private delegate ValueTask<DeletePhoneBook> ReturningDeletePhoneBookFunction();

        private delegate ValueTask<DeletePhoneBookContact> ReturningDeletePhoneBookContactFunction();

        private delegate ValueTask<FetchCampaigns> ReturningFetchCampaignsFunction();

        private delegate ValueTask<FetchCampaignsHistory> ReturningFetchCampaignsHistoryFunction();

        private delegate ValueTask<FetchContactsByPhoneBookId> ReturningFetchContactsByPhoneBookIdFunction();

        private delegate ValueTask<FetchSenderIds> ReturningFetchSenderIdsFunction();

        private delegate ValueTask<NumberMessage> ReturningNumberMessageFunction();

        private delegate ValueTask<SendBulkMessage> ReturningSendBulkMessageFunction();

        private delegate ValueTask<SendCampaign> ReturningSendCampaignFunction();

        private delegate ValueTask<SendMessage> ReturningSendMessageFunction();

        private delegate ValueTask<TemplatedMessage> ReturningTemplatedMessageFunction();

        private delegate ValueTask<UpdateCampaignPhoneBook> ReturningUpdateCampaignPhoneBookFunction();




        private async ValueTask<AddContactToPhoneBook> TryCatch(ReturningAddContactToPhoneBookFunction returningAddContactToPhoneBookFunction)
        {
            try
            {
                return await returningAddContactToPhoneBookFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }


        private async ValueTask<AddMultipleContactsToPhoneBook> TryCatch(
            ReturningAddMultipleContactsToPhoneBookFunction returningAddMultipleContactsToPhoneBookFunction)
        {
            try
            {
                return await returningAddMultipleContactsToPhoneBookFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }
        private async ValueTask<CampaignPhoneBook> TryCatch(ReturningCampaignPhoneBookFunction returningCampaignPhoneBookFunction)
        {
            try
            {
                return await returningCampaignPhoneBookFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<CreateCampaignPhoneBook> TryCatch(
           ReturningCreateCampaignPhoneBookFunction returningCreateCampaignPhoneBookFunction)
        {
            try
            {
                return await returningCreateCampaignPhoneBookFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<CreateSenderId> TryCatch(
           ReturningCreateSenderIdFunction returningCreateSenderIdFunction)
        {
            try
            {
                return await returningCreateSenderIdFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<DeletePhoneBook> TryCatch(
           ReturningDeletePhoneBookFunction returningDeletePhoneBookFunction)
        {
            try
            {
                return await returningDeletePhoneBookFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<DeletePhoneBookContact> TryCatch(
           ReturningDeletePhoneBookContactFunction returningDeletePhoneBookContactFunction)
        {
            try
            {
                return await returningDeletePhoneBookContactFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<FetchCampaigns> TryCatch(
           ReturningFetchCampaignsFunction returningFetchCampaignsFunction)
        {
            try
            {
                return await returningFetchCampaignsFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<FetchCampaignsHistory> TryCatch(
           ReturningFetchCampaignsHistoryFunction returningFetchCampaignsHistoryFunction)
        {
            try
            {
                return await returningFetchCampaignsHistoryFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<FetchContactsByPhoneBookId> TryCatch(
           ReturningFetchContactsByPhoneBookIdFunction returningFetchContactsByPhoneBookIdFunction)
        {
            try
            {
                return await returningFetchContactsByPhoneBookIdFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<FetchSenderIds> TryCatch(
           ReturningFetchSenderIdsFunction returningFetchSenderIdsFunction)
        {
            try
            {
                return await returningFetchSenderIdsFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<NumberMessage> TryCatch(
           ReturningNumberMessageFunction returningNumberMessageFunction)
        {
            try
            {
                return await returningNumberMessageFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<SendBulkMessage> TryCatch(
           ReturningSendBulkMessageFunction returningSendBulkMessageFunction)
        {
            try
            {
                return await returningSendBulkMessageFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<SendCampaign> TryCatch(
           ReturningSendCampaignFunction returningSendCampaignFunction)
        {
            try
            {
                return await returningSendCampaignFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<SendMessage> TryCatch(
           ReturningSendMessageFunction returningSendMessageFunction)
        {
            try
            {
                return await returningSendMessageFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<TemplatedMessage> TryCatch(
           ReturningTemplatedMessageFunction returningTemplatedMessageFunction)
        {
            try
            {
                return await returningTemplatedMessageFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }

        private async ValueTask<UpdateCampaignPhoneBook> TryCatch(
           ReturningUpdateCampaignPhoneBookFunction returningUpdateCampaignPhoneBookFunction)
        {
            try
            {
                return await returningUpdateCampaignPhoneBookFunction();
            }
            catch (NullSwitchException nullSwitchException)
            {
                throw new SwitchValidationException(nullSwitchException);
            }
            catch (InvalidSwitchException invalidSwitchException)
            {
                throw new SwitchValidationException(invalidSwitchException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSwitchException =
                    new InvalidConfigurationSwitchException(httpResponseUrlNotFoundException);

                throw new SwitchDependencyException(invalidConfigurationSwitchException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseUnauthorizedException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSwitchException =
                    new UnauthorizedSwitchException(httpResponseForbiddenException);

                throw new SwitchDependencyException(unauthorizedSwitchException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSwitchException =
                    new NotFoundSwitchException(httpResponseNotFoundException);

                throw new SwitchDependencyValidationException(notFoundSwitchException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSwitchException =
                    new InvalidSwitchException(httpResponseBadRequestException);

                throw new SwitchDependencyValidationException(invalidSwitchException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSwitchException =
                    new ExcessiveCallSwitchException(httpResponseTooManyRequestsException);

                throw new SwitchDependencyValidationException(excessiveCallSwitchException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSwitchException =
                    new FailedServerSwitchException(httpResponseException);

                throw new SwitchDependencyException(failedServerSwitchException);
            }
            catch (Exception exception)
            {
                var failedSwitchServiceException =
                    new FailedSwitchServiceException(exception);

                throw new SwitchServiceException(failedSwitchServiceException);
            }
        }
    }
}