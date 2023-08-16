using RESTFulSense.Clients;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Termii.Core.Models.Configurations;

namespace Termii.Core.Brokers.Termii
{
    internal partial class TermiiBroker : ITermiiBroker
    {

        private readonly ApiConfigurations termiiConfigurations;
        private readonly IRESTFulApiFactoryClient apiClient;
        private readonly HttpClient httpClient;


        public TermiiBroker(ApiConfigurations termiiConfigurations)
        {
            this.termiiConfigurations = termiiConfigurations;
            this.httpClient = SetupHttpClient();
            this.apiClient = SetupApiClient();
        }


        private async ValueTask<T> GetAsync<T>(string relativeUrl) =>
           await this.apiClient.GetContentAsync<T>(relativeUrl);

        private async ValueTask<T> PostAsync<T>(string relativeUrl, T content) =>
            await this.apiClient.PostContentAsync(relativeUrl, content);

        private async ValueTask<TResult> PostAsync<TRequest, TResult>(string relativeUrl, TRequest content)
        {
            return await this.apiClient.PostContentAsync<TRequest, TResult>(
                relativeUrl,
                content,
                mediaType: "application/json",
                ignoreDefaultValues: true);
        }



        private async ValueTask<TResult> PutAsync<TRequest, TResult>(string relativeUrl, TRequest content) =>
            await this.apiClient.PutContentAsync<TRequest, TResult>(
                relativeUrl,
                content,
                mediaType: "application/json",
                ignoreDefaultValues: true);
        private async ValueTask<T> PutAsync<T>(string relativeUrl, T content) =>
            await this.apiClient.PutContentAsync(relativeUrl, content);

        private async ValueTask<T> DeleteAsync<T>(string relativeUrl) =>
            await this.apiClient.DeleteContentAsync<T>(relativeUrl);

        private HttpClient SetupHttpClient()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress =
                    new Uri(uriString: this.termiiConfigurations.ApiUrl),
            };

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    scheme: "Bearer",
                    parameter: this.termiiConfigurations.ApiKey);

            return httpClient;
        }

        private IRESTFulApiFactoryClient SetupApiClient() =>
            new RESTFulApiFactoryClient(this.httpClient);


    }
}

