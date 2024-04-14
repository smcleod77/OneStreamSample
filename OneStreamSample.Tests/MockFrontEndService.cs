using OneStreamSample.Services.Interfaces;

namespace OneStreamSample.Tests;

internal class MockFrontEndService : IFrontEndService
{
    public async Task GetAsync()
    {
        await Task.CompletedTask;
    }
}
