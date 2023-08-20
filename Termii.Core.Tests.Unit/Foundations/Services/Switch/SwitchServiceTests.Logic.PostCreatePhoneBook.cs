using FluentAssertions;
using Force.DeepCloner;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.ExternalTermii.ExternalSwitch;
using Termii.Core.Models.Services.Foundations.Termii.Switch;

namespace Termii.Core.Tests.Unit.Foundations.Services.Switch
{
    public partial class SwitchServiceTests
    {
        [Fact]
        public async Task ShouldPostCampaignPhoneBookWithCampaignPhoneBookRequestAsync()
        {
            // given 



            dynamic createRandomCreateCampaignPhoneBookRequestProperties =
              CreateRandomCreateCampaignPhoneBookRequestProperties();

            dynamic createRandomCreateCampaignPhoneBookResponseProperties =
                CreateRandomCreateCampaignPhoneBookResponseProperties();


            var randomExternalCreateCampaignPhoneBookRequest = new ExternalCreateCampaignPhoneBookRequest
            {
                ApiKey = createRandomCreateCampaignPhoneBookRequestProperties.ApiKey,
                PhonebookName = createRandomCreateCampaignPhoneBookRequestProperties.PhonebookName,
                Description = createRandomCreateCampaignPhoneBookRequestProperties.Description


            };

            var randomExternalCreateCampaignPhoneBookResponse = new ExternalCreateCampaignPhoneBookResponse
            {

               Message = createRandomCreateCampaignPhoneBookResponseProperties.Message
                   
            };


            var randomCreateCampaignPhoneBookRequest = new CreateCampaignPhoneBookRequest
            {
                ApiKey = createRandomCreateCampaignPhoneBookRequestProperties.ApiKey,
                PhonebookName = createRandomCreateCampaignPhoneBookRequestProperties.PhonebookName,
                Description = createRandomCreateCampaignPhoneBookRequestProperties.Description

            };

            var randomCampaignPhoneBookResponse = new CreateCampaignPhoneBookResponse
            {
                Message = createRandomCreateCampaignPhoneBookResponseProperties.Message
            };


            var randomCampaignPhoneBook = new CreateCampaignPhoneBook
            {
                Request = randomCreateCampaignPhoneBookRequest,
            };

            CreateCampaignPhoneBook inputCampaignPhoneBook = randomCampaignPhoneBook;
            CreateCampaignPhoneBook expectedCampaignPhoneBook = inputCampaignPhoneBook.DeepClone();
            expectedCampaignPhoneBook.Response = randomCampaignPhoneBookResponse;

            ExternalCreateCampaignPhoneBookRequest mappedExternalCreateCampaignPhoneBookRequest =
               randomExternalCreateCampaignPhoneBookRequest;

            ExternalCreateCampaignPhoneBookResponse returnedExternalCreateCampaignPhoneBookResponse =
                randomExternalCreateCampaignPhoneBookResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.PostCreatePhoneBookAsync(It.Is(
                      SameExternalCreateCampaignPhoneBookRequestAs(mappedExternalCreateCampaignPhoneBookRequest))))
                     .ReturnsAsync(returnedExternalCreateCampaignPhoneBookResponse);

            // when
            CreateCampaignPhoneBook actualCreateCampaignPhoneBook =
               await this.switchService.PostCreatePhoneBookRequestAsync(inputCampaignPhoneBook);

            // then
            actualCreateCampaignPhoneBook.Should().BeEquivalentTo(expectedCampaignPhoneBook);

            this.termiiBrokerMock.Verify(broker =>
               broker.PostCreatePhoneBookAsync(It.Is(
                   SameExternalCreateCampaignPhoneBookRequestAs(mappedExternalCreateCampaignPhoneBookRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
