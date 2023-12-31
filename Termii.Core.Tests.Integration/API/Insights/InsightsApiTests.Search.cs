﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Insights;

namespace Termii.Core.Tests.Integration.API.Insights
{
    public partial class InsightsApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveSearchAsync()
        {
            // given
            var request = new Search
            {
                Request = new SearchRequest
                {
                    ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                    PhoneNumber = "08064246423"
                }
            };

            // when
            Search retrievedTermiiModel =
              await this.termiiClient.Insights.RetrieveSearchPhoneNumberStatusAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
