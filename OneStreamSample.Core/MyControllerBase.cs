using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OneStreamSample.Core.Controllers;

public abstract class MyControllerBase<TController> : ControllerBase
{
    protected ILogger<TController> Logger { get; set; }

    protected MyControllerBase(ILogger<TController> logger)
    {
        Logger = logger;
    }
}
