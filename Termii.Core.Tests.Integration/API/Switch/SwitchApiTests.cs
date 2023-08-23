using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termii.Core.Clients.Termii;
using Termii.Core.Models.Configurations;

namespace Termii.Core.Tests.Integration.API.Switch
{
    public partial class SwitchApiTests
    {
        private readonly ITermiiClient termiiClient;

        public SwitchApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {

                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.termiiClient = new TermiiClient(apiConfigurations);
        }
    }
}
