using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using OneStreamSample.Controllers;
using OneStreamSample.Services;
using OneStreamSample.Shared;

namespace OneStreamSample.Tests;

public class FrontEndApiControllerUnitTest
{
    [Fact]
    public async Task TestGetAsync()
    {
        // Arrange
        var logger = new Logger<FrontEndApiController>(new NullLoggerFactory());
        var frontEndService = new MockFrontEndService();
        var controller = new FrontEndApiController(logger, frontEndService);

        // Act / Assert
        try
        {
            var result = await controller.GetAsync();
            var resultType = result as OkObjectResult;

            Assert.NotNull(result);
            Assert.IsType<OneStreamModel>(resultType.Value);

            var resultValue = resultType.Value as OneStreamModel;
            Assert.Equal("New OneStream Model", resultValue.Name);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [Fact]
    public async Task TestUpdateAsync()
    {
        // Arrange
        var logger = new Logger<FrontEndApiController>(new NullLoggerFactory());
        var frontEndService = new MockFrontEndService();
        var controller = new FrontEndApiController(logger, frontEndService);

        // Act / Assert
        try
        {
            var model = new OneStreamModel()
            {
                Name = "My Unit Test",
                Description = "Blah"
            };

            var result = await controller.PostAsync(model);
            var resultType = result as OkResult;

            Assert.NotNull(result);
            Assert.Equal(200, resultType.StatusCode);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }
}