using Termii.Core.Clients.Termii;
using Termii.Core.Models.Configurations;

namespace Termii.Core.Tests.Integration.API.Insights
{
    public partial class InsightsApiTests
    {
        private readonly ITermiiClient termiiClient;

        public InsightsApiTests()
        {
            var apiConfigurations = new ApiConfigurations
            {
              
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.termiiClient = new TermiiClient(apiConfigurations);
        }
    }
}
