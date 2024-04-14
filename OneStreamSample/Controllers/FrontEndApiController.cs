using Microsoft.AspNetCore.Mvc;
using OneStreamSample.Core.Controllers;
using OneStreamSample.Services.Interfaces;
using OneStreamSample.Shared;

namespace OneStreamSample.Controllers;

[ApiController]
[Route("[controller]")]
public class FrontEndApiController : MyControllerBase<FrontEndApiController>
{
    #region Variables
    private readonly IFrontEndService _FrontEndService;
    #endregion

    #region Constructor
    public FrontEndApiController(ILogger<FrontEndApiController> logger, IFrontEndService frontEndService) : base(logger)
    {
        _FrontEndService = frontEndService;
    }
    #endregion

    #region Endpoints
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        try
        {
            await Task.Delay(1_500);
            var model = new OneStreamModel()
            {
                Name = "New OneStream Model",
                Description = $"Date Ticks: [{DateTime.UtcNow.Ticks}]"
            };

            await _FrontEndService.GetAsync();

            return Ok(model);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return BadRequest();
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(OneStreamModel model)
    {
        try
        {
            await Task.Delay(1_500);
            return Ok();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            return BadRequest();
        }
    }
    #endregion
}
