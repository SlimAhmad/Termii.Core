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
        public async Task ShouldDeletePhoneBookContactAsync()
        {


            // given

            var apiKey = Environment.GetEnvironmentVariable("ApiKey");
            var contactId = "27547615";
            // when
            DeletePhoneBookContact retrievedTermiiModel =
              await this.termiiClient.Switch.RemovePhoneBookContactAsync(apiKey, contactId);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
