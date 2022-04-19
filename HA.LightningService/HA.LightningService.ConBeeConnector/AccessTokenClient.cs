using HA.LightningService.ConBeeConnector.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HA.LightningService.ConBeeConnector.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HA.LightningService.ConBeeConnector;

public class AccessTokenClient : IAccessToken
{
    private readonly ILogger<AccessTokenClient> _logger;
    private readonly IOptions<ConBeeOptions> _configuration;
    private readonly HttpClient _client;
    private readonly IMemoryCache _cache;

    public AccessTokenClient(ILogger<AccessTokenClient> logger, IOptions<ConBeeOptions> configuration, HttpClient client, IMemoryCache cache)
    {
        this._logger = logger;
        _configuration = configuration;
        client.BaseAddress = new Uri(configuration.Value.Url);
        _client = client;
        _cache = cache;
    }
        

    public async Task<string> GetAccessToken()
    {
        if (_configuration.Value.Source.ToLower() == "file")
            return _configuration.Value.ApiKey;
        try
        {
            var token = await  _cache.GetOrCreateAsync("Token", async entry =>
            {
                _logger.LogInformation("No token found in cache");
                var newToken = await GetAccessTokenAsynch();
                return newToken;
            });


            return token.Token;
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to extract token", e.Message);
            throw;
        }
    }

    private async Task<AccessToken> GetAccessTokenAsynch()
    {
        _logger.LogInformation("Request new token from controller api");
        var credentials = _configuration.Value.Username + ":" + _configuration.Value.Password;
        var credentialsBase64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
        var content = new StringContent(credentialsBase64String);
        var response = await _client.PostAsync("Authorization", content);

        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException("Failed to extract new token");

        var responseContent = await response.Content.ReadAsStringAsync();
        var token = JsonSerializer.Deserialize<AccessToken>(responseContent);

        return token;


    }
}