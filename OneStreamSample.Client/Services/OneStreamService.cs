using Microsoft.Extensions.Options;
using OneStreamSample.Client.Services.Interfaces;
using OneStreamSample.Shared;
using System.Net.Http.Json;

namespace OneStreamSample.Client.Services;

public class OneStreamService : IOneStreamService
{
    #region Variables
    private readonly HttpClient _HttpClient;
    private readonly ILogger<OneStreamService> _Logger;
    #endregion

    #region Constructor
    public OneStreamService(HttpClient httpClient, ILogger<OneStreamService> logger)
    {
        _HttpClient = httpClient;
        _Logger = logger;
    }
    #endregion

    public async Task<OneStreamModel> GetAsync()
    {
        var retVal = await _HttpClient.GetFromJsonAsync<OneStreamModel>("FrontEndApi");
        return retVal;
    }

    public async Task<bool> UpdateAsync(OneStreamModel model)
    {
        var retVal = false;
        try
        {
            await _HttpClient.PostAsJsonAsync("FrontEndApi", model);
            retVal = true;
        }
        catch (Exception ex)
        {
            _Logger.LogError(ex.Message);
        }
        return retVal;
    }
}
