﻿using System;
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
        public async Task ShouldRetrieveCampaignHistoryAsync()
        {


            // given

            var apiKey = Environment.GetEnvironmentVariable("ApiKey");
            var campaignId = "C64e4d344ae2be";

            // when
            FetchCampaignsHistory retrievedTermiiModel =
              await this.termiiClient.Switch.RetrieveCampaignsHistoryAsync(apiKey, campaignId);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
