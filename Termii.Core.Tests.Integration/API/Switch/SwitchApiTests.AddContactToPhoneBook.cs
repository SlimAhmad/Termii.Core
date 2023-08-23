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
        public async Task ShouldAddContactToPhoneBookAsync()
        {
            // given
            var request = new AddContactToPhoneBook
            {
                Request = new AddContactToPhoneBookRequest
                {
                    ApiKey = "TLvP5oclsN6KPnJ8VPKXYtH7qCUSTrHkADiX1xs6G29yExzw2sNTvxWPTz10Qv",
                    PhoneNumber = "2347064415311",
                    CountryCode = "NG",
                    Company = "test",
                    EmailAddress = "slimahmad6@gmail.com",
                    FirstName = "Ahmad",
                    LastName = "Salim"
                }
            };

            var phoneBookId = "bdf582ef-d5e5-4940-add2-c0d8a73c19e3";
            // when
            AddContactToPhoneBook retrievedTermiiModel =
              await this.termiiClient.Switch.SendContactToPhoneBookAsync(request,phoneBookId);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
