using Microsoft.AspNetCore.Mvc;
using OneStreamSample.Core.Controllers;

namespace OtherWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OtherController : MyControllerBase<OtherController>
{
    public OtherController(ILogger<OtherController> logger) : base(logger)
    {
    }

    [HttpGet]
    public async Task GetAsync()
    {
        await Task.Delay(1_750);
    }
}
