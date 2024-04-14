using AngleSharp.Html.Dom;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using OneStreamSample.Client.Components;
using OneStreamSample.Client.Services;
using OneStreamSample.Client.Services.Interfaces;

namespace OneStreamSample.Client.Tests;

public class FeatureWidgetUnitTest
{
    [Fact]
    public void TestInitialRender()
    {
        try
        {
            // Arrange
            var context = new TestContext();
            var logger = new Logger<OneStreamService>(new NullLoggerFactory());
            context.Services.AddSingleton<IOneStreamService>(new MockOneStreamService());
            var cut = context.RenderComponent<FeatureWidget>();

            // Act
            var domElement = cut.Find(".form-group:nth-child(1) input");

            // Assert
            Assert.NotNull(domElement);
            Assert.IsAssignableFrom<IHtmlInputElement>(domElement);
            var inputValue = ((IHtmlInputElement)domElement).Value;
            Assert.NotNull(inputValue);
            Assert.Equal("Mock OneStream Model", inputValue);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }
}
