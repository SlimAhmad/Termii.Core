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
        public async Task ShouldThrowDependencyExceptionOnPostCreateCampaignPhoneBookRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCreateCampaignPhoneBookRequestProperties =
               CreateRandomCreateCampaignPhoneBookRequestProperties();

            
            var randomCreateCampaignPhoneBookRequest = new CreateCampaignPhoneBookRequest
            {
               ApiKey = createRandomCreateCampaignPhoneBookRequestProperties.ApiKey,
               Description = createRandomCreateCampaignPhoneBookRequestProperties.Description,
               PhonebookName = createRandomCreateCampaignPhoneBookRequestProperties.PhonebookName,
               
           



            };

            var randomCreateCampaignPhoneBook = new CreateCampaignPhoneBook
            {
                Request = randomCreateCampaignPhoneBookRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationSwitchException =
                new InvalidConfigurationSwitchException(
                    httpResponseUrlNotFoundException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(
                    invalidConfigurationSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.PostCreatePhoneBookRequestAsync(randomCreateCampaignPhoneBook);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostCreateCampaignPhoneBookRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCreateCampaignPhoneBookRequestProperties =
             CreateRandomCreateCampaignPhoneBookRequestProperties();




            var randomCreateCampaignPhoneBookRequest = new CreateCampaignPhoneBookRequest
            {
                ApiKey = createRandomCreateCampaignPhoneBookRequestProperties.ApiKey,
                Description = createRandomCreateCampaignPhoneBookRequestProperties.Description,
                PhonebookName = createRandomCreateCampaignPhoneBookRequestProperties.PhonebookName,





            };

            var randomCreateCampaignPhoneBook = new CreateCampaignPhoneBook
            {
                Request = randomCreateCampaignPhoneBookRequest
            };

            var unauthorizedSwitchException =
                new UnauthorizedSwitchException(unauthorizedException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(unauthorizedSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.PostCreatePhoneBookRequestAsync(randomCreateCampaignPhoneBook);

            SwitchDependencyException
                actualSwitchDependencyException =
                    await Assert.ThrowsAsync<SwitchDependencyException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateCampaignPhoneBookRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCreateCampaignPhoneBookRequestProperties =
              CreateRandomCreateCampaignPhoneBookRequestProperties();




            var randomCreateCampaignPhoneBookRequest = new CreateCampaignPhoneBookRequest
            {
               ApiKey = createRandomCreateCampaignPhoneBookRequestProperties.ApiKey,
               Description = createRandomCreateCampaignPhoneBookRequestProperties.Description,
               PhonebookName = createRandomCreateCampaignPhoneBookRequestProperties.PhonebookName,





            };

            var randomCreateCampaignPhoneBook = new CreateCampaignPhoneBook
            {
                Request = randomCreateCampaignPhoneBookRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundSwitchException =
                new NotFoundSwitchException(
                    httpResponseNotFoundException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    notFoundSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.PostCreatePhoneBookRequestAsync(randomCreateCampaignPhoneBook);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateCampaignPhoneBookRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCreateCampaignPhoneBookRequestProperties =
          CreateRandomCreateCampaignPhoneBookRequestProperties();


            var randomCreateCampaignPhoneBookRequest = new CreateCampaignPhoneBookRequest
            {
              ApiKey = createRandomCreateCampaignPhoneBookRequestProperties.ApiKey,
               Description = createRandomCreateCampaignPhoneBookRequestProperties.Description,
               PhonebookName = createRandomCreateCampaignPhoneBookRequestProperties.PhonebookName,





            };

            var randomCreateCampaignPhoneBook = new CreateCampaignPhoneBook
            {
                Request = randomCreateCampaignPhoneBookRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidSwitchException =
                new InvalidSwitchException(
                    httpResponseBadRequestException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    invalidSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.PostCreatePhoneBookRequestAsync(randomCreateCampaignPhoneBook);

            SwitchDependencyValidationException
                actualSwitchDependencyValidationException =
                    await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                        retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateCampaignPhoneBookRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCreateCampaignPhoneBookRequestProperties =
          CreateRandomCreateCampaignPhoneBookRequestProperties();


            var randomCreateCampaignPhoneBookRequest = new CreateCampaignPhoneBookRequest
            {
              ApiKey = createRandomCreateCampaignPhoneBookRequestProperties.ApiKey,
               Description = createRandomCreateCampaignPhoneBookRequestProperties.Description,
               PhonebookName = createRandomCreateCampaignPhoneBookRequestProperties.PhonebookName,





            };

            var randomCreateCampaignPhoneBook = new CreateCampaignPhoneBook
            {
                Request = randomCreateCampaignPhoneBookRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallSwitchException =
                new ExcessiveCallSwitchException(
                    httpResponseTooManyRequestsException);

            var expectedSwitchDependencyValidationException =
                new SwitchDependencyValidationException(
                    excessiveCallSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.PostCreatePhoneBookRequestAsync(randomCreateCampaignPhoneBook);

            SwitchDependencyValidationException actualSwitchDependencyValidationException =
                await Assert.ThrowsAsync<SwitchDependencyValidationException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyValidationException.Should().BeEquivalentTo(
                expectedSwitchDependencyValidationException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCreateCampaignPhoneBookRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateCampaignPhoneBookRequestProperties =
          CreateRandomCreateCampaignPhoneBookRequestProperties();


            var randomCreateCampaignPhoneBookRequest = new CreateCampaignPhoneBookRequest
            {
              ApiKey = createRandomCreateCampaignPhoneBookRequestProperties.ApiKey,
               Description = createRandomCreateCampaignPhoneBookRequestProperties.Description,
               PhonebookName = createRandomCreateCampaignPhoneBookRequestProperties.PhonebookName,





            };

            var randomCreateCampaignPhoneBook = new CreateCampaignPhoneBook
            {
                Request = randomCreateCampaignPhoneBookRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerSwitchException =
                new FailedServerSwitchException(
                    httpResponseException);

            var expectedSwitchDependencyException =
                new SwitchDependencyException(
                    failedServerSwitchException);

            this.termiiBrokerMock.Setup(broker =>
                 broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.PostCreatePhoneBookRequestAsync(randomCreateCampaignPhoneBook);

            SwitchDependencyException actualSwitchDependencyException =
                await Assert.ThrowsAsync<SwitchDependencyException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchDependencyException.Should().BeEquivalentTo(
                expectedSwitchDependencyException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostCreateCampaignPhoneBookRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateCampaignPhoneBookRequestProperties =
            CreateRandomCreateCampaignPhoneBookRequestProperties();


            var randomCreateCampaignPhoneBookRequest = new CreateCampaignPhoneBookRequest
            {
              ApiKey = createRandomCreateCampaignPhoneBookRequestProperties.ApiKey,
               Description = createRandomCreateCampaignPhoneBookRequestProperties.Description,
               PhonebookName = createRandomCreateCampaignPhoneBookRequestProperties.PhonebookName,





            };

            var randomCreateCampaignPhoneBook = new CreateCampaignPhoneBook
            {
                Request = randomCreateCampaignPhoneBookRequest
            };

            var serviceException = new Exception();

            var failedSwitchServiceException =
                new FailedSwitchServiceException(serviceException);

            var expectedSwitchServiceException =
                new SwitchServiceException(failedSwitchServiceException);

            this.termiiBrokerMock.Setup(broker =>
                broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreateCampaignPhoneBook> retrieveSwitchTask =
               this.switchService.PostCreatePhoneBookRequestAsync(randomCreateCampaignPhoneBook);

            SwitchServiceException actualSwitchServiceException =
                await Assert.ThrowsAsync<SwitchServiceException>(
                    retrieveSwitchTask.AsTask);

            // then
            actualSwitchServiceException.Should().BeEquivalentTo(
                expectedSwitchServiceException);

            this.termiiBrokerMock.Verify(broker =>
                broker.PostCreatePhoneBookAsync(It.IsAny<ExternalCreateCampaignPhoneBookRequest>()),
                    Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}