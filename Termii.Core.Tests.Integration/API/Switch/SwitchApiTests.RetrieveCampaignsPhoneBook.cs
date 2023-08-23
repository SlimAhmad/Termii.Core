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
        public async Task ShouldRetrievePhoneBookAsync()
        {
            // given
         
            var apiKey = Environment.GetEnvironmentVariable("ApiKey");
            // when
            CampaignPhoneBook retrievedTermiiModel =
              await this.termiiClient.Switch.RetrievePhoneBooksAsync(apiKey);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
