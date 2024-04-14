using OneStreamSample.Shared;

namespace OneStreamSample.Client.Services.Interfaces;

public interface IOneStreamService
{
    Task<OneStreamModel> GetAsync();
    Task<bool> UpdateAsync(OneStreamModel model);
}
