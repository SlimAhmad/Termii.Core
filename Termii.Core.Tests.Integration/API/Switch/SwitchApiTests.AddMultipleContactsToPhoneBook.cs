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
        public async Task ShouldAddContactsToPhoneBookAsync()
        {

         
            // given
            var request = new AddMultipleContactsToPhoneBook
            {
                Request = new AddMultipleContactsToPhoneBookRequest
                {
                    ApiKey = "TLvP5oclsN6KPnJ8VPKXYtH7qCUSTrHkADiX1xs6G29yExzw2sNTvxWPTz10Qv",
                    ContactFile = "C:/Users/moder/source/repos/Termii.Core/Termii.Core.Tests.Integration/API/test.xlsx",
                    CountryCode = "NG"
                }
            };

            var phoneBookId = "7914a23d-8f41-4d49-abd6-5749dde71d1f\"";
            // when
            AddMultipleContactsToPhoneBook retrievedTermiiModel =
              await this.termiiClient.Switch.SendContactsToPhoneBookAsync(request, phoneBookId);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
