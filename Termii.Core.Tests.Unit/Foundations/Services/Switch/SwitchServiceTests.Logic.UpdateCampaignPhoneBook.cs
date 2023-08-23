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
        public async Task ShouldPostUpdateCampaignPhoneBookWithUpdateCampaignPhoneBookRequestAsync()
        {
            // given 



            dynamic createRandomCreateUpdateCampaignPhoneBookRequestProperties =
              CreateRandomCreateUpdateCampaignPhoneBookRequestProperties();

            dynamic createRandomCreateUpdateCampaignPhoneBookResponseProperties =
                CreateRandomCreateUpdateCampaignPhoneBookResponseProperties();


            var randomExternalUpdateCampaignPhoneBookRequest = new ExternalUpdateCampaignPhoneBookRequest
            {
                ApiKey = createRandomCreateUpdateCampaignPhoneBookRequestProperties.ApiKey,
                PhonebookName = createRandomCreateUpdateCampaignPhoneBookRequestProperties.PhonebookName,
                Description = createRandomCreateUpdateCampaignPhoneBookRequestProperties.Description


            };

            var randomExternalUpdateCampaignPhoneBookResponse = new ExternalUpdateCampaignPhoneBookResponse
            {

               Message = createRandomCreateUpdateCampaignPhoneBookResponseProperties.Message,
              
                   
            };


            var randomUpdateCampaignPhoneBookRequest = new UpdateCampaignPhoneBookRequest
            {
                ApiKey = createRandomCreateUpdateCampaignPhoneBookRequestProperties.ApiKey,
                PhonebookName = createRandomCreateUpdateCampaignPhoneBookRequestProperties.PhonebookName,
                Description = createRandomCreateUpdateCampaignPhoneBookRequestProperties.Description

            };

            var randomUpdateCampaignPhoneBookResponse = new UpdateCampaignPhoneBookResponse
            {
                Message = createRandomCreateUpdateCampaignPhoneBookResponseProperties.Message
            };


            var randomUpdateCampaignPhoneBook = new UpdateCampaignPhoneBook
            {
                Request = randomUpdateCampaignPhoneBookRequest,
            };

            var phoneBookId = GetRandomString();
            UpdateCampaignPhoneBook inputUpdateCampaignPhoneBook = randomUpdateCampaignPhoneBook;
            UpdateCampaignPhoneBook expectedUpdateCampaignPhoneBook = inputUpdateCampaignPhoneBook.DeepClone();
            expectedUpdateCampaignPhoneBook.Response = randomUpdateCampaignPhoneBookResponse;

            ExternalUpdateCampaignPhoneBookRequest mappedExternalUpdateCampaignPhoneBookRequest =
               randomExternalUpdateCampaignPhoneBookRequest;

            ExternalUpdateCampaignPhoneBookResponse returnedExternalUpdateCampaignPhoneBookResponse =
                randomExternalUpdateCampaignPhoneBookResponse;

            this.termiiBrokerMock.Setup(broker =>
                broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.Is(
                      SameExternalUpdateCampaignPhoneBookRequestAs(mappedExternalUpdateCampaignPhoneBookRequest))))
                     .ReturnsAsync(returnedExternalUpdateCampaignPhoneBookResponse);

            // when
            UpdateCampaignPhoneBook actualCreateUpdateCampaignPhoneBook =
               await this.switchService.UpdatePhoneBookRequestAsync(phoneBookId,inputUpdateCampaignPhoneBook);

            // then
            actualCreateUpdateCampaignPhoneBook.Should().BeEquivalentTo(expectedUpdateCampaignPhoneBook);

            this.termiiBrokerMock.Verify(broker =>
               broker.UpdateCampaignPhoneBookAsync(It.IsAny<string>(),It.Is(
                   SameExternalUpdateCampaignPhoneBookRequestAs(mappedExternalUpdateCampaignPhoneBookRequest))),
                   Times.Once);

            this.termiiBrokerMock.VerifyNoOtherCalls();
        }
    }
}
