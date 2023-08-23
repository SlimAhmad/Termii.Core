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
        public async Task ShouldCreateCampaignAsync()
        {


            // given
            var request = new SendCampaign
            {
                Request = new SendCampaignRequest
                {
                    ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                    CampaignType = "personalized",
                    Channel = "generic",
                    Delimiter = ",",
                    Message = "Welcome to Termii.",
                    MessageType = "Plain",
                    PhonebookId = "7914a23d-8f41-4d49-abd6-5749dde71d1f",
                    RemoveDuplicate = "yes",
                    ScheduleSmsStatus = "scheduled",
                    ScheduleTime = "30-06-2024 6:00",
                    SenderId = "E-Wallet",
                    CountryCode = "NG"
                }
            };

          
            // when
            SendCampaign retrievedTermiiModel =
              await this.termiiClient.Switch.CreateCampaignAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
