using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace net.personaldata.notifier
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IConfiguration Configuration)
        {
            _logger = logger;
            _configuration = Configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var accessToken = await GetAccessTokenAsync();

            while (!stoppingToken.IsCancellationRequested)
            {
                _httpClient.SetBearerToken(accessToken);

                var apiUrl = _configuration["OAuth2Settings:ResourceUrl"];

                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response: " + content);
                }
                else
                {
                    Console.WriteLine("Failed to fetch data: " + response.StatusCode);
                }
            }
        }

        private async Task<string> GetAccessTokenAsync()
        {
            // Request an access token using client credentials
            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = _configuration["OAuth2Settings:TokenUrl"],
                ClientId = _configuration["OAuth2Settings:ClientId"],
                ClientSecret = _configuration["OAuth2Settings:ClientSecret"],
                GrantType = "client_credentials"
            });

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }

            return tokenResponse.AccessToken;
        }
    }
}
