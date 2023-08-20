using Microsoft.Extensions.DependencyInjection;
using System;
using Termii.Core.Brokers.DateTimes;
using Termii.Core.Brokers.Termii;
using Termii.Core.Clients.Insights;
using Termii.Core.Clients.Switch;
using Termii.Core.Clients.Tokens;
using Termii.Core.Models.Configurations;
using Termii.Core.Services.Foundations.Termii.Insights.InsightsService;
using Termii.Core.Services.Foundations.Termii.Switch.SwitchService;
using Termii.Core.Services.Foundations.Termii.Tokens.TokensService;

namespace Termii.Core.Clients.Termii
{
    public class TermiiClient : ITermiiClient
    {
        public TermiiClient(ApiConfigurations apiConfigurations)
        {
            IServiceProvider serviceProvider = RegisterServices(apiConfigurations);
            InitializeClients(serviceProvider);
        }

        public ITermiiClient Termii { get; set; }
        public ISwitchClient Switch { get; set; }

        public ITokensClient Tokens { get; set; }

        public IInsightsClient Insights { get; set; }



        private void InitializeClients(IServiceProvider serviceProvider)
        {

            Insights = serviceProvider.GetRequiredService<IInsightsClient>();
            Tokens = serviceProvider.GetRequiredService<ITokensClient>();
            Switch = serviceProvider.GetRequiredService<ISwitchClient>();


        }


        private static IServiceProvider RegisterServices(ApiConfigurations apiConfigurations)
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<ISwitchService, SwitchService>()
                .AddTransient<IDateTimeBroker, DateTimeBroker>()
                .AddTransient<IInsightsService, InsightsService>()
                .AddTransient<ITokensService, TokensService>()
                .AddTransient<ITermiiBroker,TermiiBroker>()
              

                .AddTransient<ITermiiClient, TermiiClient>()
                .AddTransient<ITokensClient, TokensClient>()
                .AddTransient<ISwitchClient, SwitchClient>()
                .AddTransient<IInsightsClient, InsightsClient>()
                .AddSingleton(apiConfigurations);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
