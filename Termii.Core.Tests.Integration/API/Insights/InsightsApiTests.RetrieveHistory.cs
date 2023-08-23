using System;
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
        public async Task ShouldRetrieveHistoryAsync()
        {
            // given
            string? apiKey = Environment.GetEnvironmentVariable("ApiKey");

            // when
            History retrievedTermiiModel =
              await this.termiiClient.Insights.RetrieveHistoryAsync(apiKey);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
