using OneStreamSample.Client.Services.Interfaces;
using OneStreamSample.Shared;

namespace OneStreamSample.Client.Tests;

internal class MockOneStreamService : IOneStreamService
{
    public async Task<OneStreamModel> GetAsync()
    {
        await Task.CompletedTask;
        return new OneStreamModel()
        {
            Name = "Mock OneStream Model",
            Description = "Mocked model"
        };
    }

    public async Task<bool> UpdateAsync(OneStreamModel model)
    {
        await Task.CompletedTask;
        return true;
    }
}
