using FluentAssertions;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;
using Termii.Core.Models.Services.Foundations.Termii.Switch;
using Moq;
using RESTFulSense.Exceptions;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Exceptions;
using System;

namespace Termii.Core.Tests.Unit.Foundations.Services.Switch
{
    public partial class SwitchServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostUpdateCampaignPhoneBookRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCreateUpdateCampaignPhoneBookRequestProperties =
               CreateRandomCreateUpdateCampaignPhoneBookRequestProperties();


            var randomUpdateCampaignPhoneBookRequest = new UpdateCampaignPhoneBookRequest
            {
                ApiKey = createRandomCreateUpdateCampaignPhoneBookRequestProperties.ApiKey,
                Description = createRandomCreateUpdateCampaignPhoneBookRequestProperties.Description,
                PhonebookName = createRandomCreateUpdateCampaignPhoneBookRequestProperties.PhonebookName,
               




            };

            var randomUpdateCampaignPhoneBook = new UpdateCampaignPhoneBook
            {
                Request = randomUpdateCampaignPhoneBookRequest
            };

             var apiKey = GetRandomString();


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationSwitchException =
                new InvalidConfigurationSwitchException(
                    httpResponseUrlNotFoundException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(
                    invalidConfigurationSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UpdateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.UpdateCampaignPhoneBookRequestAsync(apiKey,randomUpdateCampaignPhoneBook);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostUpdateCampaignPhoneBookRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCreateUpdateCampaignPhoneBookRequestProperties =
               CreateRandomCreateUpdateCampaignPhoneBookRequestProperties();




            var randomUpdateCampaignPhoneBookRequest = new UpdateCampaignPhoneBookRequest
            {
                ApiKey = createRandomCreateUpdateCampaignPhoneBookRequestProperties.ApiKey,
                Description = createRandomCreateUpdateCampaignPhoneBookRequestProperties.Description,
                PhonebookName = createRandomCreateUpdateCampaignPhoneBookRequestProperties.PhonebookName,





            };

            var randomUpdateCampaignPhoneBook = new UpdateCampaignPhoneBook
            {
                Request = randomUpdateCampaignPhoneBookRequest
            };

            var apiKey = GetRandomString();

            var unauthorizedSwitchException =
                new UnauthorizedSwitchException(unauthorizedException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(unauthorizedSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UpdateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.UpdateCampaignPhoneBookRequestAsync(apiKey, randomUpdateCampaignPhoneBook);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUpdateCampaignPhoneBookRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCreateUpdateCampaignPhoneBookRequestProperties =
                CreateRandomCreateUpdateCampaignPhoneBookRequestProperties();




            var randomUpdateCampaignPhoneBookRequest = new UpdateCampaignPhoneBookRequest
            {
                ApiKey = createRandomCreateUpdateCampaignPhoneBookRequestProperties.ApiKey,
                Description = createRandomCreateUpdateCampaignPhoneBookRequestProperties.Description,
                PhonebookName = createRandomCreateUpdateCampaignPhoneBookRequestProperties.PhonebookName,





            };

            var randomUpdateCampaignPhoneBook = new UpdateCampaignPhoneBook
            {
                Request = randomUpdateCampaignPhoneBookRequest
            };

             var apiKey = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundSwitchException =
                new NotFoundSwitchException(
                    httpResponseNotFoundException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    notFoundSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UpdateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.UpdateCampaignPhoneBookRequestAsync(apiKey,randomUpdateCampaignPhoneBook);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUpdateCampaignPhoneBookRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCreateUpdateCampaignPhoneBookRequestProperties =
                CreateRandomCreateUpdateCampaignPhoneBookRequestProperties();


            var randomUpdateCampaignPhoneBookRequest = new UpdateCampaignPhoneBookRequest
            {
                ApiKey = createRandomCreateUpdateCampaignPhoneBookRequestProperties.ApiKey,
                Description = createRandomCreateUpdateCampaignPhoneBookRequestProperties.Description,
                PhonebookName = createRandomCreateUpdateCampaignPhoneBookRequestProperties.PhonebookName,





            };

            var randomUpdateCampaignPhoneBook = new UpdateCampaignPhoneBook
            {
                Request = randomUpdateCampaignPhoneBookRequest
            };

             var apiKey = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidSwitchException =
                new InvalidSwitchException(
                    httpResponseBadRequestException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    invalidSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UpdateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.UpdateCampaignPhoneBookRequestAsync(apiKey,randomUpdateCampaignPhoneBook);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUpdateCampaignPhoneBookRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCreateUpdateCampaignPhoneBookRequestProperties =
                CreateRandomCreateUpdateCampaignPhoneBookRequestProperties();


            var randomUpdateCampaignPhoneBookRequest = new UpdateCampaignPhoneBookRequest
            {
                ApiKey = createRandomCreateUpdateCampaignPhoneBookRequestProperties.ApiKey,
                Description = createRandomCreateUpdateCampaignPhoneBookRequestProperties.Description,
                PhonebookName = createRandomCreateUpdateCampaignPhoneBookRequestProperties.PhonebookName,





            };

            var randomUpdateCampaignPhoneBook = new UpdateCampaignPhoneBook
            {
                Request = randomUpdateCampaignPhoneBookRequest
            };

             var apiKey = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallSwitchException =
                new ExcessiveCallSwitchException(
                    httpResponseTooManyRequestsException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    excessiveCallSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UpdateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.UpdateCampaignPhoneBookRequestAsync(apiKey,randomUpdateCampaignPhoneBook);

            SwitchDependencyValidationException actualSwitchDependencyValidationException =
                await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostUpdateCampaignPhoneBookRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateUpdateCampaignPhoneBookRequestProperties =
               CreateRandomCreateUpdateCampaignPhoneBookRequestProperties();


            var randomUpdateCampaignPhoneBookRequest = new UpdateCampaignPhoneBookRequest
            {
                ApiKey = createRandomCreateUpdateCampaignPhoneBookRequestProperties.ApiKey,
                Description = createRandomCreateUpdateCampaignPhoneBookRequestProperties.Description,
                PhonebookName = createRandomCreateUpdateCampaignPhoneBookRequestProperties.PhonebookName,





            };

            var randomUpdateCampaignPhoneBook = new UpdateCampaignPhoneBook
            {
                Request = randomUpdateCampaignPhoneBookRequest
            };

             var apiKey = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerSwitchException =
                new FailedServerSwitchException(
                    httpResponseException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(
                    failedServerSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UpdateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.UpdateCampaignPhoneBookRequestAsync(apiKey,randomUpdateCampaignPhoneBook);

            SwitchDependencyException actualSwitchDependencyException =
                await Assert.ThrowsAsync<SwitchDependencyException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostUpdateCampaignPhoneBookRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateUpdateCampaignPhoneBookRequestProperties =
               CreateRandomCreateUpdateCampaignPhoneBookRequestProperties();


            var randomUpdateCampaignPhoneBookRequest = new UpdateCampaignPhoneBookRequest
            {
                ApiKey = createRandomCreateUpdateCampaignPhoneBookRequestProperties.ApiKey,
                Description = createRandomCreateUpdateCampaignPhoneBookRequestProperties.Description,
                PhonebookName = createRandomCreateUpdateCampaignPhoneBookRequestProperties.PhonebookName,





            };

            var randomUpdateCampaignPhoneBook = new UpdateCampaignPhoneBook
            {
                Request = randomUpdateCampaignPhoneBookRequest
            };

             var apiKey = GetRandomString();

            var serviceException = new Exception();

            var failedSwitchServiceException =
                new FailedSwitchServiceException(serviceException);

            var expectedSwitchServiceException =
                new SwitchServiceException(failedSwitchServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UpdateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.UpdateCampaignPhoneBookRequestAsync(apiKey,randomUpdateCampaignPhoneBook);

            SwitchServiceException actualSwitchServiceException =
                await Assert.ThrowsAsync<SwitchServiceException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchServiceException.Should().BeEquivalentTo(
                expectedSwitchServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.IsAny<ExternalUpdateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}