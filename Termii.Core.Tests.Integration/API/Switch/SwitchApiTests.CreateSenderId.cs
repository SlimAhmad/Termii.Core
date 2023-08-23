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
        public async Task ShouldCreateSenderIdAsync()
        {


            // given
            var request = new CreateSenderId
            {
                Request = new CreateSenderIdRequest
                {
                    ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                    Company = "Techametrix",
                    SenderId = "Techametrix",
                    Usecase = "testing use case endpoint testing testing"
                }
            };

           
            // when
            CreateSenderId retrievedTermiiModel =
              await this.termiiClient.Switch.CreateSenderIdAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
