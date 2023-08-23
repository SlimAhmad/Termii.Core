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
        public async Task ShouldRetrieveStatusAsync()
        {
            // given
            var request = new Status
            {
                Request = new StatusRequest
                {
                    ApiKey = "TLvP5oclsN6KPnJ8VPKXYtH7qCUSTrHkADiX1xs6G29yExzw2sNTvxWPTz10Qv",
                    PhoneNumber = "07064415311",
                    CountryCode = "NG"
                }
            };

            // when
            Status retrievedTermiiModel =
              await this.termiiClient.Insights.PhoneNumberStatusAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
