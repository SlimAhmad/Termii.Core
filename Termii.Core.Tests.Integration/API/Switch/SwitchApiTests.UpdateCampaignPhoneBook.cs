using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Switch;

namespace Termii.Core.Tests.Integration.API.Switch
{
    public partial class SwitchApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldUpdateCampaignPhoneBookAsync()
        {


            // given
            var request = new UpdateCampaignPhoneBook
            {
                Request = new UpdateCampaignPhoneBookRequest
                {
                    ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                    Description = "test 2",
                    PhonebookName = "test 2"
                }
            };

            var phoneBookId = "bdf582ef-d5e5-4940-add2-c0d8a73c19e3";
            // when
            UpdateCampaignPhoneBook retrievedTermiiModel =
              await this.termiiClient.Switch.UpdatePhoneBookAsync(phoneBookId,request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
