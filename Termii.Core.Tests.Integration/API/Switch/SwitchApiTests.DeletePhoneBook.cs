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
        public async Task ShouldDeletePhoneBookAsync()
        {


            // given

            var apiKey = "TLvP5oclsN6KPnJ8VPKXYtH7qCUSTrHkADiX1xs6G29yExzw2sNTvxWPTz10Qv";
            var phoneBookId = "7914a23d-8f41-4d49-abd6-5749dde71d1f";
            // when
            DeletePhoneBook retrievedTermiiModel =
              await this.termiiClient.Switch.RemovePhoneBookAsync(apiKey,phoneBookId);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
