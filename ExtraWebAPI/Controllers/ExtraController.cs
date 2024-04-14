using Microsoft.AspNetCore.Mvc;
using OneStreamSample.Core.Controllers;

namespace ExtraWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ExtraController : MyControllerBase<ExtraController>
{
    public ExtraController(ILogger<ExtraController> logger) : base(logger)
    {
    }

    [HttpGet]
    public async Task GetAsync()
    {
        await Task.Delay(1_000);
    }
}
