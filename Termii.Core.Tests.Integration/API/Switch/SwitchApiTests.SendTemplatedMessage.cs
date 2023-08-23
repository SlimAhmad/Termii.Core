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
        public async Task ShouldSendTemplatedMessageAsync()
        {


            // given
            var request = new TemplatedMessage
            {
                Request = new TemplatedMessageRequest
                {
                    ApiKey = Environment.GetEnvironmentVariable("ApiKey"),
                    DeviceId = "",
                    PhoneNumber = "07064415311",
                    TemplateId = "1493-csdn3-ns34w-sd3434-dfdf",
                    Data = new TemplatedMessageRequest.ExternalData
                    {
                       ExpiryTime = "2",
                       Otp = 123456,
                       ProductName = "tesr"
                    }
                }
            };

            // when
            TemplatedMessage retrievedTermiiModel =
              await this.termiiClient.Switch.SendTemplatedMessageAsync(request);

            // then
            Assert.NotNull(retrievedTermiiModel);
        }
    }
}
