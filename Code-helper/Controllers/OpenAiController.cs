using Microsoft.AspNetCore.Mvc;
using OpenAIApp.Services;

namespace OpenAIApp.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAiController : ControllerBase
{

    private  readonly ILogger<OpenAiController> _logger;
    private readonly IOpenAiServices _openAiService;

    public OpenAiController (
        ILogger<OpenAiController> logger,
        IOpenAiServices openAiServices)
    {
        _logger = logger;
        _openAiService = openAiServices;
    }

     [HttpPost()]
    [Route("CheckCode")]
    public async Task<IActionResult> CheckCode(string text)
    {
        var result = await _openAiService.FixCode(text);
        return Ok(result);
    }
}
