using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using OtherWebAPI.Controllers;

namespace OtherWebAPI.Tests;

public class OtherControllerUnitTest
{
    [Fact]
    public async Task TestGetAsync()
    {
        // Arrange
        var logger = new Logger<OtherController>(new NullLoggerFactory());
        var controller = new OtherController(logger);

        // Act / Assert
        try
        {
            await controller.GetAsync();
            Assert.True(true);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }
}