using Microsoft.Extensions.Options;
using OneStreamSample.ConfigOptions;
using OneStreamSample.Services.Interfaces;

namespace OneStreamSample.Services;

public class FrontEndService : IFrontEndService
{
    #region Variables
    private readonly IHttpClientFactory _HttpClientFactory;
    private readonly IOptions<WebApiOptions> _Options;
    private readonly ILogger<FrontEndService> _Logger;
    #endregion

    #region Constructor
    public FrontEndService(IHttpClientFactory httpClientFactory, IOptions<WebApiOptions> options, ILogger<FrontEndService> logger)
    {
        _HttpClientFactory = httpClientFactory;
        _Options = options;
        _Logger = logger;
    }
    #endregion

    public async Task GetAsync()
    {
        try
        {
            await Task.Delay(1_250);

            var clientOther = _HttpClientFactory.CreateClient();
            var otherUrl = $"{_Options.Value.OtherApiEndpoint}Other";
            await clientOther.GetAsync(otherUrl);

            var clientExtra = _HttpClientFactory.CreateClient();
            var extraUrl = $"{_Options.Value.ExtraApiEndpoint}Extra";
            await clientExtra.GetAsync(extraUrl);
        }
        catch (Exception ex)
        {
            _Logger.LogError(ex, ex.Message);
        }
    }
}
