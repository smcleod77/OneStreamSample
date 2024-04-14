using ExtraWebAPI.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace ExtraWebAPI.Tests;

public class ExtraControllerUnitTest
{
    [Fact]
    public async Task TestGetAsync()
    {
        // Arrange
        var logger = new Logger<ExtraController>(new NullLoggerFactory());
        var controller = new ExtraController(logger);

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