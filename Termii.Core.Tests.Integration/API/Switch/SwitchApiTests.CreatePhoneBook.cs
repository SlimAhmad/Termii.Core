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
        public async Task ShouldCreatePhoneBookAsync()
        {


            // given
            var request = new CreateCampaignPhoneBook
            {
                Request = new CreateCampaignPhoneBookRequest
                {
                    ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                    Description = "test",
                    PhonebookName = "test",
                }
            };

       
            // when
            CreateCampaignPhoneBook retrievedTermiiModel =
              await this.termiiClient.Switch.CreatePhoneBookAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
